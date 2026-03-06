# Inventory Masters - Soluções Inteligentes em Mapeamento de Estoque 

<div align="center">

### 👥 Integrantes do Grupo

| | |
| :---: | :---: |
| **Danilo Silva Santos** | **Diulie Mileide Batista Correia** |
| **Marilene da Silva Araujo** | **Miguel Cassio Braga Duarte** |

</div>

<p align="center">
  <img src="https://github.com/user-attachments/assets/ecb6559d-d790-4798-97c7-f280d315ff58" width="600" alt="Equipe" />
</p>

#  Quem somos!

A Inventory Masters é uma plataforma tecnológica voltada para a gestão inteligente de excedentes produtivos.
Atuamos conectando empresas a soluções estratégicas de reaproveitamento de materiais.
Transformamos desperdícios em ativos com potencial de geração de valor econômico.
Promovemos redução de custos, eficiência operacional e responsabilidade ambiental.
Somos inovação aplicada à gestão sustentável e competitiva.

<p align="center">
![WhatsApp Image 2026-03-03 at 21 25 41](https://github.com/user-attachments/assets/a9c43063-1e2c-4c96-9774-90c1dabe1ac6)
</p>
-------

#  Demanada  
O cenário empresarial atual é caracterizado por elevados níveis de produção e, como resultado, pela criação contínua de excedentes produtivos. Esses excedentes englobam sobras de matéria-prima, materiais que não atendem aos padrões comerciais, resíduos operacionais e produtos que não são totalmente aproveitados durante o processo de produção. Na maioria das organizações, esses materiais não são monitorados de maneira estratégica, sendo considerados apenas como resíduos ou um custo inevitável.
A falta de sistemas organizados de rastreabilidade e gerenciamento desses excedentes causa efeitos consideráveis. Do ponto de vista econômico, as empresas enfrentam prejuízos financeiros devido ao desperdício de recursos, à gestão ineficiente de estoques e à destinação imprópria de materiais reutilizáveis. Do ponto de vista ambiental, o descarte inadequado contribui para o crescimento dos resíduos sólidos, sobrecarrega os aterros e  maior pressão sobre recursos naturais.

Além disso, observa-se que muitas organizações enfrentam dificuldades em integrar práticas sustentáveis às suas rotinas operacionais de maneira eficiente e mensurável. Embora a economia circular seja amplamente discutida como modelo estratégico para o desenvolvimento sustentável, sua aplicação prática ainda é limitada pela falta de ferramentas tecnológicas acessíveis e integradas à gestão empresarial.

Diante desse contexto, surge a necessidade de soluções inovadoras que permitam transformar excedentes produtivos em ativos econômicos, promovendo redução de custos, geração de novas oportunidades de receita e fortalecimento da responsabilidade socioambiental corporativa.

É nesse cenário que se insere a proposta da Inventory Masters: uma plataforma tecnológica voltada para a gestão inteligente, rastreabilidade e direcionamento estratégico de excedentes produtivos em múltiplos setores da economia. A solução busca estruturar um modelo operacional capaz de conectar empresas geradoras de excedentes a oportunidades de reaproveitamento, criando um ecossistema de valorização de materiais antes subutilizados ou descartados.

Assim, o presente estudo se justifica pela necessidade de desenvolver mecanismos práticos que integrem eficiência operacional, inovação tecnológica e sustentabilidade, contribuindo para a consolidação de modelos empresariais mais competitivos e alinhados às demandas ambientais contemporâneas.


---
## Solução 

A Inventory Masters é uma plataforma tecnológica desenvolvida para a gestão estratégica e inteligente de excedentes produtivos em diferentes setores da economia. Seu propósito é oferecer às organizações um sistema estruturado de rastreabilidade, controle e direcionamento de materiais que, tradicionalmente, seriam tratados apenas como descarte operacional.

Por meio de monitoramento sistematizado, organização de dados e análise de fluxos produtivos, a plataforma identifica resíduos e sobras operacionais com potencial de reaproveitamento, promovendo sua reinserção estratégica na cadeia produtiva. Dessa forma, materiais antes considerados perdas passam a ser reconhecidos como ativos capazes de gerar valor econômico, otimizar processos e reduzir desperdícios.

A Inventory Masters atua como um elo integrador entre empresas geradoras de excedentes e parceiros aptos a reutilizá-los, estruturando um ecossistema colaborativo orientado à eficiência operacional e à sustentabilidade empresarial. Ao conectar oferta e demanda de materiais reaproveitáveis, a solução contribui simultaneamente para a redução de custos, melhoria da performance organizacional e mitigação de impactos ambientais.

Mais do que uma iniciativa sustentável, a proposta configura-se como um modelo escalável de inovação aplicada à gestão empresarial, alinhado às tendências contemporâneas de responsabilidade socioambiental, competitividade de mercado e transformação digital.

---

## Viabilidade Técnologica 


---
# Modelagem do Projeto
---
## Diagrama de Caso de Uso

<p align="center">
  <img width="600" height="600" alt="image" src="https://github.com/user-attachments/assets/d83b0b36-40d2-42e9-92ea-254ca5dadd2b" />
</p>



| Nome  |  Funcionalidade       |Perfil         | Descrição                                                                        |
|-------|-----------------------|---------------|----------------------------------------------------------------------------------|
|UC01:  | Efetuar Login         | Administrador / Operador | Logar no Sistema                                                      |
|UC02:  | Configurar Parâmetros | Administrador | Definir os limites de volume ($m^3$) para disparo de alertas.                    |
|UC03:  | Manter Parceiros      | Administrador | Cadastrar, editar ou excluir empresas que receberão os excedentes.               |
|UC04:  | Registrar Medição     | Sistema / Operador | Captura automática via câmera ou inserção manual do volume atual.           |
|UC05:  | Monitorar Dashboard   | Operador | Visualizar em tempo real o status dos resíduos/estoque.                               |
|UC06:  | Notificar Parceiros   | Sistema | (Automático)<< include >> no UC03. Se o volume atingir o limite, o sistema envia o alerta. |
|UC07:  | Gerar Relatório       | Administrador |Exportar histórico de medições e eficiência de destinação.                            |
|UC08:  | Efetuar Log Out       | Administrador / Operador| Deslogar do Sistema                                                        |

---

## Diagrama de Fluxo 

<p align="center">
 <img width="600" height="600" alt="image" src="https://github.com/user-attachments/assets/b92c757a-874f-4b71-a10b-4036d5f615df" />
</p>


## Diagrama de Fluxo de Dados (Nível 1)

  ### Entidades Externas
  • **Câmera / Visão Computacional:** Origem dos dados de volume. <br />
  • **Usuário (Adm/Op):** Interage com as configurações e relatórios. <br />
  • **Parceiro:** Destinatário final dos alertas de excedentes.

  ---

  ### Processos Principais
  • **P1: Coletar e Validar Medição:** Recebe o sinal da câmera, calcula o volume e atribui a confiabilidade da leitura. <br />
  • **P2: Monitorar Limites (Gatilho):** Compara o volume recebido com os limites gravados em ParametrosSistema. <br />
  • **P3: Gerenciar Notificações:** Se o limite for atingido, busca os parceiros ativos e formata a mensagem. <br />
  • **P4: Gerar Inteligência de Dados:** Consolida medições para o Dashboard e relatórios de auditoria.

  ---

  ### Depósitos de Dados 
  • **D1: MedicoesVolume:** Histórico de todas as leituras. <br />
  • **D2: ParametrosSistema:** Regras de negócio (limite max/min). <br />
  • **D3: Parceiros:** Cadastro de quem pode receber o excedente. <br />
  • **D4: Notificacoes:** Registro de logs de envios realizados.
 
## Detalhamento do Fluxo de Execução 

1. **Entrada de Dados:** O sensor (Câmera) envia o *VolumeMedido* para o Processo 1. <br />
2. **Persistência:** O sistema grava a medição no banco de dados **D1**. <br />
3. **Verificação de Regra:** O Processo 2 lê o *VolumeMaximoPermitido* de **D2**. <br />
4. **Tomada de Decisão:** Caso $VolumeMedido > VolumeMaximo$, o fluxo segue para o Processo 3. <br />
5. **Saída de Notificação:** O sistema consulta **D3** (Parceiros), registra o envio em **D4** e dispara o e-mail/alerta para o **Parceiro Externo**.

________________________________________

## Modelagem de Banco de Dados

### Modelo Conceitual:

<img width="1349" height="616" alt="InventoryMaster_ModeloConceitual" src="https://github.com/user-attachments/assets/c6d86792-4619-4497-9876-0407c63a003f" />

| Nome da Entidade        | Atributos                                                                       | Chave Primária | Chave Secundária                     |
| ----------------------- | ------------------------------------------------------------------------------- | -------------- | ------------------------------------ |
| **Parceiro**            | Id, Nome, Empresa, Email, Telefone, Endereco, Ativo, Data_Cadastro              | Id             | —                                    |
| **ParametrosSistema**   | Id, Volume_Maximo, Volume_Minimo, Email_Notificacao_Ativo, Data_Atualizacao     | Id             | —                                    |
| **Usuario**             | Id, Nome, Email, Senha, Perfil, Data_Cadastro, Ativo                            | Id             | —                                    |
| **MedicaoVolume**       | Id, Data_Hora, Volume_Medido, Origem_Leitura                                    | Id             | —                                    |
| **Notificacao**         | Id, Data_Envio, Volume_Momento, Status_Envio, Mensagem, Quantidade_Destinatario | Id             | —                                    |
| **NotificacaoParceiro** | Status_Entrega                                                                  | —              | Ligação entre Parceiro e Notificacao |


### Modelo Lógico:

<img width="1080" height="614" alt="InventoryMaster_ModeloLogico" src="https://github.com/user-attachments/assets/08a23fd9-58b8-4b26-8be3-b3bf43bcd847" />

| Nome da Entidade    | Descrição                                                                        | Atributos               | Tipo de Dado | PK/FK |
| ------------------- | -------------------------------------------------------------------------------- | ----------------------- | ------------ | ----- |
| Parceiro            | Guarda informações das empresas parceiras que recebem notificações.              | Id                      | INTEGER      | PK    |
|                     |                                                                                  | Nome                    | VARCHAR      |       |
|                     |                                                                                  | Empresa                 | VARCHAR      |       |
|                     |                                                                                  | Email                   | VARCHAR      |       |
|                     |                                                                                  | Telefone                | VARCHAR      |       |
|                     |                                                                                  | Endereco                | VARCHAR      |       |
|                     |                                                                                  | Ativo                   | BOOLEAN      |       |
|                     |                                                                                  | Data_Cadastro           | DATE         |       |
| Usuario             | Representa os usuários cadastrados no sistema.                                   | Id                      | INTEGER      | PK    |
|                     |                                                                                  | Nome                    | VARCHAR      |       |
|                     |                                                                                  | Email                   | VARCHAR      |       |
|                     |                                                                                  | Senha                   | VARCHAR      |       |
|                     |                                                                                  | Perfil                  | VARCHAR      |       |
|                     |                                                                                  | Data_Cadastro           | DATE         |       |
|                     |                                                                                  | Ativo                   | BOOLEAN      |       |
| Notificacao         | Registra notificações enviadas pelo sistema.                                     | Id                      | INTEGER      | PK    |
|                     |                                                                                  | Data_Envio              | DATE         |       |
|                     |                                                                                  | Volume_Momento          | DECIMAL      |       |
|                     |                                                                                  | Status_Envio            | VARCHAR      |       |
|                     |                                                                                  | Mensagem                | VARCHAR      |       |
|                     |                                                                                  | Quantidade_Destinatario | INTEGER      |       |
|                     |                                                                                  | fk_Usuario_Id           | INTEGER      | FK    |
| MedicaoVolume       | Armazena medições de volume registradas no sistema.                              | Id                      | INTEGER      | PK    |
|                     |                                                                                  | Data_Hora               | DATE         |       |
|                     |                                                                                  | Volume_Medido           | DECIMAL      |       |
|                     |                                                                                  | Origem_Leitura          | VARCHAR      |       |
|                     |                                                                                  | fk_Usuario_Id           | INTEGER      | FK    |
| ParametrosSistema   | Define os parâmetros de controle do sistema.                                     | Id                      | INTEGER      | PK    |
|                     |                                                                                  | Volume_Maximo           | DECIMAL      |       |
|                     |                                                                                  | Volume_Minimo           | DECIMAL      |       |
|                     |                                                                                  | Email_Notificacao_Ativo | BOOLEAN      |       |
|                     |                                                                                  | Data_Atualizacao        | DATE         |       |
| NotificacaoParceiro | Tabela associativa que relaciona notificações aos parceiros que irão recebê-las. | Id                      | INTEGER      | PK    |
|                     |                                                                                  | fk_Parceiro_Id          | INTEGER      | FK    |
|                     |                                                                                  | fk_Notificacao_Id       | INTEGER      | FK    |
|                     |                                                                                  | Status_Entrega          | VARCHAR      |       |



### Modelo Fisíco:

<table align="center">
  <tr>
    <td><img src="https://github.com/user-attachments/assets/3552237e-01ba-4191-98a3-ebccb8b9e5cd" width="400" alt="imagem 1"></td>
    <td><img src="https://github.com/user-attachments/assets/6fe7cd76-1829-4d89-b7f8-9cce91d0c49c" width="400" alt="imagem 2"></td>
  </tr>
</table>

---

## Viabilidade Técnica 
### 1. Introdução

O presente documento tem por objetivo apresentar a viabilidade técnica do projeto Inventory Masters, que propõe o mapeamento volumétrico inteligente de estoques utilizando o sensor Kinect do Xbox 360 integrado a um sistema desenvolvido em plataforma .NET.

A solução visa identificar, monitorar e classificar excedentes produtivos em diferentes setores da economia, permitindo sua destinação estratégica para reaproveitamento, redistribuição ou reinserção na cadeia produtiva.

Trata-se de um projeto inovador e de baixo custo, que integra tecnologia, eficiência operacional e sustentabilidade, promovendo a redução de desperdícios e a valorização de materiais antes subutilizados.

---

### 2. Descrição da Solução

A solução consiste na utilização do sensor Kinect Xbox 360 para captura tridimensional do espaço físico destinado ao armazenamento de materiais e excedentes. Por meio da leitura volumétrica automatizada, o sistema identifica variações de ocupação, auxiliando no controle e rastreabilidade de estoques excedentes.

Os dados coletados são processados em um software desenvolvido na linguagem C#, utilizando o .NET SDK 8. O sistema permite classificar materiais com potencial de reaproveitamento, redistribuição interna ou destinação externa para parceiros estratégicos.

A interface foi projetada para ser intuitiva, operada por gestos simples detectados pelo Kinect e acessível via navegador, eliminando a necessidade de conhecimento técnico avançado. Dessa forma, o processo de identificação, organização e geração de relatórios gerenciais ocorre de maneira prática, eficiente e escalável.

---
 ### 3. Requisitos de Hardware

Para o funcionamento adequado do sistema, será utilizado o seguinte hardware:

Notebook ou Computador – Processador Intel Core i7, 16 GB de memória RAM, SSD de 500 GB;

Sensor Kinect Xbox 360 – Com adaptador USB e fonte de alimentação;

Fonte de alimentação bivolt para o sensor;

Estrutura de suporte para fixação estável do Kinect no ambiente de monitoramento.

---
### 4. Organização Tecnológica

Para garantir o funcionamento do sistema de monitoramento volumétrico em tempo real, serão utilizados:

Sistema Operacional: Windows 10 ou superior (64 bits);

Plataforma de Desenvolvimento: .NET SDK 8 utilizando Rider (JetBrains);

Linguagem de Programação: C#;

Framework Web: ASP.NET Core com Razor Pages;

Bibliotecas e APIs: Microsoft Kinect SDK 1.8 e bibliotecas para captura e processamento de imagens 3D;

Ferramentas de Apoio: Git para controle de versão.

---

### 5. Metodologia de Implementação

Configuração do Hardware: instalação e calibração do Kinect no ambiente destinado ao armazenamento de excedentes produtivos.

Desenvolvimento da Aplicação Web: criação das Razor Pages para exibição em tempo real dos dados de captura volumétrica e indicadores operacionais.

Processamento e Visualização: integração do Kinect com o sistema para apresentação de métricas de ocupação, alertas de variação volumétrica e visualização tridimensional.

Classificação Estratégica: definição de parâmetros para categorização dos excedentes (reaproveitamento interno, redistribuição externa ou descarte responsável).

Testes em Ambiente Real: validação da precisão da detecção volumétrica e ajustes de sensibilidade.

Implantação Final: disponibilização do sistema em ambiente operacional, acessível via navegador interno da organização.

---

### 6. Benefícios e Justificativa

Monitoramento volumétrico em tempo real;

Identificação automatizada de excedentes produtivos;

Apoio à tomada de decisão gerencial baseada em dados;

Redução de desperdícios e melhor aproveitamento de recursos;

Potencial geração de valor econômico a partir de materiais subutilizados;

Baixo custo comparado a sistemas industriais tradicionais de mapeamento 3D;

Integração entre tecnologia, eficiência operacional e sustentabilidade empresarial.

---

## viabilidade Economica 
### 1. Custos Estimados de Implantação

O projeto Inventory Masters foi concebido como uma solução tecnológica de baixo custo, utilizando hardware acessível e desenvolvimento próprio, o que reduz significativamente o investimento inicial quando comparado a sistemas industriais de mapeamento volumétrico.

##Investimento em Hardware

| Item                              | Quantidade | Valor Unitário (R$) | Total (R$) |
|-----------------------------------|------------|--------------------|------------|
| Kinect Xbox 360                  | 1          | 30,00              | 30,00      |
| Cabo/adaptador USB com fonte     | 1          | 80,00              | 80,00      |
| CPU Core i3                      | 1          | 800,00             | 800,00     |
| **Subtotal Hardware**            |            |                    | **910,00** |

---

### 2. Custo de Desenvolvimento (Mão de Obra)

O desenvolvimento do sistema foi realizado por três integrantes da equipe, cada um dedicando 10 horas de trabalho, totalizando 30 horas.

Considerando o valor estimado de R$ 15,00 por hora:

30 horas × R$ 15,00 = R$ 450,00

---

### 3. Custo Total do Projeto


| Categoria | valor  | 
|-------|----|
| Hardware| R$ 910,00   |
|Mão de Obra      |R$ 450,00  |
| Total Geral|R$ 1360,00   |

O valor total demonstra a viabilidade financeira da solução, principalmente quando comparado a sistemas comerciais de automação e controle volumétrico, que possuem custos significativamente mais elevados.

---

### 4. Análise da Estrutura de Investimento

A maior parte do investimento (aproximadamente 48,7%) está concentrada na aquisição do equipamento principal (CPU), seguido pela mão de obra (27,4%). Os demais componentes representam uma parcela reduzida do orçamento total.

Esse cenário evidencia que, em ambientes onde já exista infraestrutura computacional disponível, o custo de implantação pode ser ainda menor, ampliando a atratividade econômica da solução.

---

### 5. Benefícios Econômicos

A implementação da Inventory Masters proporciona:

Baixo custo inicial de implantação;

Redução de perdas financeiras decorrentes de desperdícios e má gestão de excedentes;

Identificação de materiais com potencial de reaproveitamento interno ou redistribuição externa;

Possibilidade de geração de valor econômico a partir de excedentes produtivos;

Redução do tempo gasto em inventários manuais;

Otimização da mão de obra operacional;

Apoio à tomada de decisão com base em dados volumétricos.

Além disso, empresas que trabalham com reaproveitamento, reciclagem, logística reversa ou economia solidária podem atuar como parceiras estratégicas para absorção dos materiais identificados pelo sistema, ampliando o impacto econômico e ambiental da solução.
---
### 6. Conclusão

O projeto Inventory Masters apresenta um investimento inicial de R$ 1.360,00, valor consideravelmente inferior ao custo de manter um colaborador dedicado exclusivamente ao controle manual de estoques.

Considerando o salário mínimo projetado para 2025 (R$ 1.518,00) e encargos trabalhistas estimados em aproximadamente 70%, o custo mensal de um funcionário pode ultrapassar R$ 2.580,00.

Dessa forma, a automação proposta demonstra potencial de retorno financeiro em curto prazo, além de proporcionar ganhos recorrentes por meio da redução de desperdícios, otimização de recursos e valorização de excedentes produtivos.

A solução alia eficiência operacional, tecnologia acessível e sustentabilidade empresarial, consolidando-se como uma alternativa economicamente viável e estrategicamente relevante.




---





