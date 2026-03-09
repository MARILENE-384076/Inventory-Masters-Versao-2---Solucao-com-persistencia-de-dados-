using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using AppInterfaceKinectMVVM.Commands;

namespace AppInterfaceKinectMVVM.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private KinectSensor sensor;

    private byte[] colorPixels;
    private WriteableBitmap colorBitmap;

    private DepthImagePixel[] depthPixels;

    private int[] referenciaChao;
    private bool calibrado = false;

    private Queue<double> historicoVolume = new();

    private const int MAX_HISTORICO_VOLUME = 20;
    private const int LIMITE_MINIMO_ALTURA_MM = 30;

    private double ultimoVolumeSuavizado = 0;

    public event PropertyChangedEventHandler PropertyChanged;

    public WriteableBitmap CameraImage
    {
        get => colorBitmap;
        set
        {
            colorBitmap = value;
            OnPropertyChanged(nameof(CameraImage));
        }
    }

    private string volume = "Volume: 0 cm³";
    public string Volume
    {
        get => volume;
        set
        {
            volume = value;
            OnPropertyChanged(nameof(Volume));
        }
    }

    private string status = "Inicializando Kinect...";
    public string Status
    {
        get => status;
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public ICommand CalibrarCommand { get; }
    public ICommand ToggleKinectCommand { get; }

    public MainViewModel()
    {
        CalibrarCommand = new RelayCommand(CalibrarChao);
        ToggleKinectCommand = new RelayCommand(ToggleKinect);

        InicializarKinect();
    }

    private void InicializarKinect()
    {
        sensor = KinectSensor.KinectSensors.FirstOrDefault(s => s.Status == KinectStatus.Connected);

        if (sensor == null)
        {
            Status = "Nenhum Kinect conectado.";
            return;
        }

        sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
        sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);

        colorPixels = new byte[sensor.ColorStream.FramePixelDataLength];

        depthPixels = new DepthImagePixel[sensor.DepthStream.FramePixelDataLength];

        CameraImage = new WriteableBitmap(
            sensor.ColorStream.FrameWidth,
            sensor.ColorStream.FrameHeight,
            96, 96,
            System.Windows.Media.PixelFormats.Bgr32,
            null);

        sensor.ColorFrameReady += Sensor_ColorFrameReady;
        sensor.DepthFrameReady += Sensor_DepthFrameReady;

        sensor.Start();

        Status = "Kinect iniciado. Clique em calibrar.";
    }

    private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
    {
        using var frame = e.OpenColorImageFrame();

        if (frame == null) return;

        frame.CopyPixelDataTo(colorPixels);

        CameraImage.WritePixels(
            new System.Windows.Int32Rect(0, 0, frame.Width, frame.Height),
            colorPixels,
            frame.Width * 4,
            0);
    }

    private void Sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
    {
        using var frame = e.OpenDepthImageFrame();

        if (frame == null) return;

        frame.CopyDepthImagePixelDataTo(depthPixels);

        if (calibrado && referenciaChao != null)
            CalcularVolume();
    }

    private void CalibrarChao()
    {
        if (depthPixels == null)
        {
            Status = "Sem dados de profundidade.";
            return;
        }

        referenciaChao = new int[depthPixels.Length];

        for (int i = 0; i < depthPixels.Length; i++)
            referenciaChao[i] = depthPixels[i].Depth;

        calibrado = true;
        historicoVolume.Clear();

        Status = "Chão calibrado. Coloque o objeto.";
    }

    private void ToggleKinect()
    {
        if (sensor == null) return;

        if (sensor.IsRunning)
        {
            sensor.Stop();
            Status = "Kinect desligado";
        }
        else
        {
            sensor.Start();
            Status = "Kinect ligado";
        }
    }

    private void CalcularVolume()
    {
        double volumeTotal = 0;

        double horizontalFOV = 57 * Math.PI / 180.0;
        double verticalFOV = 43 * Math.PI / 180.0;

        int width = sensor.DepthStream.FrameWidth;
        int height = sensor.DepthStream.FrameHeight;

        for (int i = 0; i < depthPixels.Length; i++)
        {
            int atual = depthPixels[i].Depth;
            int referencia = referenciaChao[i];

            if (atual <= 0 || referencia <= 0 || atual >= referencia)
                continue;

            int delta = referencia - atual;

            if (delta < LIMITE_MINIMO_ALTURA_MM)
                continue;

            double altura = delta / 1000.0;
            double distancia = atual / 1000.0;

            double pixelWidth = 2 * distancia * Math.Tan(horizontalFOV / 2) / width;
            double pixelHeight = 2 * distancia * Math.Tan(verticalFOV / 2) / height;

            double pixelArea = pixelWidth * pixelHeight;

            volumeTotal += altura * pixelArea;
        }

        double volumeCm3 = volumeTotal * 1_000_000;

        historicoVolume.Enqueue(volumeCm3);

        if (historicoVolume.Count > MAX_HISTORICO_VOLUME)
            historicoVolume.Dequeue();

        double media = historicoVolume.Average();

        double peso = 0.7;

        double volumeSuavizado = ultimoVolumeSuavizado * peso + media * (1 - peso);

        ultimoVolumeSuavizado = volumeSuavizado;

        Volume = $"Volume: {(volumeSuavizado > 0 ? volumeSuavizado : 0):F0} cm³";
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}