using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AppInterfaceKinectUnificado
{
    public partial class MainWindow : Window
    {
        private KinectSensor sensor;

        private byte[] colorPixels;
        private WriteableBitmap colorBitmap;

        private DepthImagePixel[] depthPixels;

        private int[] referenciaChao;
        private bool calibrado = false;

        private Queue<double> historicoVolume = new Queue<double>();

        private const int MAX_HISTORICO_VOLUME = 20;
        private const int LIMITE_MINIMO_ALTURA_MM = 30;

        private double ultimoVolumeSuavizado = 0;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InicializarKinect();
        }

        private void InicializarKinect()
        {
            sensor = KinectSensor.KinectSensors.FirstOrDefault(s => s.Status == KinectStatus.Connected);

            if (sensor == null)
            {
                StatusTextBlock.Text = "Nenhum Kinect conectado.";
                return;
            }

            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);

            colorPixels = new byte[sensor.ColorStream.FramePixelDataLength];
            depthPixels = new DepthImagePixel[sensor.DepthStream.FramePixelDataLength];

            colorBitmap = new WriteableBitmap(
                sensor.ColorStream.FrameWidth,
                sensor.ColorStream.FrameHeight,
                96, 96,
                PixelFormats.Bgr32,
                null);

            CameraImage.Source = colorBitmap;

            sensor.ColorFrameReady += Sensor_ColorFrameReady;
            sensor.DepthFrameReady += Sensor_DepthFrameReady;

            sensor.Start();

            StatusTextBlock.Text = "Kinect iniciado. Clique em Calibrar Chão.";
        }

        private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using var frame = e.OpenColorImageFrame();

            if (frame == null) return;

            frame.CopyPixelDataTo(colorPixels);

            colorBitmap.WritePixels(
                new Int32Rect(0, 0, frame.Width, frame.Height),
                colorPixels,
                frame.Width * 4,
                0);
        }

        private void Sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using var frame = e.OpenDepthImageFrame();

            if (frame == null) return;

            frame.CopyDepthImagePixelDataTo(depthPixels);

            if (calibrado)
                CalcularVolume();
        }

        private void CalibrarChao_Click(object sender, RoutedEventArgs e)
        {
            if (depthPixels == null)
            {
                StatusTextBlock.Text = "Sem dados de profundidade.";
                return;
            }

            referenciaChao = new int[depthPixels.Length];

            for (int i = 0; i < depthPixels.Length; i++)
                referenciaChao[i] = depthPixels[i].Depth;

            calibrado = true;
            historicoVolume.Clear();

            StatusTextBlock.Text = "Chão calibrado. Coloque o objeto.";
        }

        private void ToggleKinect_Click(object sender, RoutedEventArgs e)
        {
            if (sensor == null) return;

            if (sensor.IsRunning)
            {
                sensor.Stop();
                ToggleKinectButton.Content = "Ligar Kinect";
                StatusTextBlock.Text = "Kinect desligado.";
            }
            else
            {
                sensor.Start();
                ToggleKinectButton.Content = "Desligar Kinect";
                StatusTextBlock.Text = "Kinect ligado.";
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

            VolumeTextBlock.Text = $"Volume: {(volumeSuavizado > 0 ? volumeSuavizado : 0):F0} cm³";
        }
    }
}