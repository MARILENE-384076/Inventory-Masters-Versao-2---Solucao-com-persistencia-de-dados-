# Inventory Masters - Integração Kinect & Gestão de Estoque

Este projeto faz parte de um **Trabalho de Conclusão de Curso (TCC)** focado na automação de inventários utilizando sensores de movimento, integrando hardware e software de forma unificada.

## Equipe do Projeto
* **Marilene da Silva Araujo**
* **Miguel Cassio Braga Duarte**
* **Diulie Mileide Batista Correia**
* **Danilo Silva Santos**

## Estrutura do Repositório
A solução é dividida em dois módulos principais que trabalham em conjunto:

1. **AppInterfaceKinectMVVM**: Módulo de Hardware/Interface. Interface desenvolvida em **WPF** utilizando o padrão **MVVM** para comunicação com o sensor Kinect, permitindo a captura e processamento de movimentos e interações do usuário.
2. **Inventory-Masters-Software**: Módulo de Gestão. Sistema desenvolvido em **C#** com persistência de dados em **SQLite** para gerenciamento completo do fluxo de estoque (entrada e saída de materiais).

## Como Executar
* **Requisito de Hardware**: Certifique-se de ter o **SDK do Kinect** instalado para o funcionamento do módulo de interface.
* **Banco de Dados**: O banco de dados SQLite será carregado automaticamente ao iniciar o módulo de software, garantindo a persistência das informações.

---
