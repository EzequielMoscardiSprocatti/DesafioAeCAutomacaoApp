# Desafio AeC Automação

## Sobre o Desafio

O desafio consiste no desenvolvimento de um RPA simples que realiza uma busca automatizada no site da Alura ([https://www.alura.com.br/](https://www.alura.com.br/)) e grava os resultados em um banco de dados.


### Pré-requisitos

1. Código feito em **C#**.
2. Utilização do framework **Selenium**.
3. Utilização da abordagem **DDD** com **injeção de dependência**.

### Critérios de Avaliação

1. A aplicação preenche os requisitos básicos.
2. Manutenabilidade, clareza e limpeza de código, resultado funcional, entre outros fatores.
3. Explicação das decisões técnicas tomadas, as escolhas por bibliotecas e ferramentas.
4. Fluxo da aplicação.
5. Tratamento com erros e casos inesperados.
6. Uso do WebDriver.
7. Uso do GitFlow.

## Descrição do Projeto

A automação deve realizar de forma automática a busca no site da Alura por algum termo de sua escolha, por exemplo, “RPA”.

A automação deverá adicionar o termo no campo da busca e realizar a pesquisa. Com o retorno da pesquisa, salvar no banco de dados os seguintes dados:

- **Título**
- **Professor** (Pode ser um ou todos)
- **Carga Horária**
- **Descrição**

Exemplo:
- **Título:** “Formação Modelagem e Melhorias de Processos de Negócios”
- **Professor:** “Enio Moraes”
- **Carga Horária:** “86h”
- **Descrição:** “Um dos maiores desafios das organizações diz respeito à melhoria dos resultados de desempenho de negócios com agilidade operacional. Logo, conhecer de maneira clara os processos propicia uma gestão mais eficiente e viabiliza a implantação de melhorias e mudanças de forma organizada, gerenciável e previsível. Nesse sentido, a modelagem e consequente melhoria nos processos...”

## Estrutura do Projeto

### 1. Camada de Domínio

- **Entities**
  - `CursoResultado.cs`: Representa a entidade do curso com as propriedades: Id, UrlCurso, Titulo, Professor, CargaHora, Descricao, DataConsulta.
- **Interfaces**
  - `ICursoResultadoRepository.cs`: Interface do repositório para o curso.
- **Services**
  - `CursoResultadoService.cs`: Serviço de domínio para lógica de negócios relacionada aos cursos.

### 2. Camada de Infraestrutura

- **Data**
  - **Repositories**
    - `CursoResultadoJsonRepository.cs`: Implementação do repositório que salva os resultados em um arquivo JSON.

### 3. Camada de Aplicação

- **Services**
  - `CursoApplicationService.cs`: Serviço de aplicação que coordena a execução do robô RPA e interação com o repositório.

### 4. Camada de UI (Windows Forms)

- **Forms**
  - `FormularioCurso.cs`: Formulário Windows Forms que interage com o usuário e chama a camada de aplicação para executar o robô.
  - 
![BotAlura](https://github.com/EzequielMoscardiSprocatti/DesafioAeCAutomacaoApp/assets/19784186/e422802f-032b-4a09-b87c-2bfaa58a35bd)


