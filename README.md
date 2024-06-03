# Desafio AeC Automação

## Sobre o desafio.

O desafio consiste no desenvolvimento de um RPA simples que realiza uma busca 
automaizada no site da Alura (https://www.alura.com.br/) e grava os resultados em um 
banco de dados (mais informações abaixo). 

### Os pré-requisitos são: 
1. Que o código seja feito em C#; 
2. Utilização do framework Selenium; 
3. Utilização da abordagem DDD com injeção de dependência;
Seu projeto será avaliado de acordo com os seguintes critérios: 
1. Sua aplicação preenche os requisitos básicos; 
2. Manutenabilidade, clareza e limpeza de código, resultado funcional, entre outros fatores; 
3. Explique as decisões técnicas tomadas, as escolhas por bibliotecas e ferrramentas; 
4. Fluxo da aplicação;
5. Tratamento com erros e casos inesperados; 
6. Se usou Webdriver; 
7. Se fez uso do GitFlow;

### Descrição do projeto
A automação deve realizar de forma automática a busca no site da Alura por algum termo 
de sua escolha, por exemplo, “RPA”.

A automação deverá adicionar o termo no campo da busca e realizar a pesquisa. 

Com o retorno da pesquisa salvar no banco de dados os seguintes dados: 
- **Título**
- **Professor** (Pode ser um ou todos)
- **Carga Horária**
- **Descrição**

Exemplo:
- **Título:** “Formação Modelagem e Melhorias de Processos de Negócios”
- **Professor:** “Enio Moraes”
- **Carga Horária:** “86h”
- **Descrição:** “Um dos maiores desafios das organizações diz respeito à melhoria dos resultados de desempenho de negócios com agilidade operacional. Logo, conhecer de maneira clara os processos propicia uma gestão mais eficiente e viabiliza a implantação de melhorias e mudanças de forma organizada, gerenciável e previsível. Nesse sentido, a modelagem e consequente melhoria nos processos...”


## **Decisões Técnicas**

C# e Selenium: Escolhidos pela robustez e capacidade de automação de tarefas de teste em navegadores.

DDD com Injeção de Dependência: Para manter a separação de responsabilidades e facilitar a manutenção e escalabilidade.

Repositório JSON: Para simplificar o armazenamento de dados sem necessidade de instalar um banco de dados completo.

## **Fluxo da Aplicação**

![BotAlura](https://github.com/EzequielMoscardiSprocatti/DesafioAeCAutomacaoApp/assets/19784186/2647b830-1512-4ace-ab66-c3763f398140)


![BotAluraAtualizado](https://github.com/EzequielMoscardiSprocatti/DesafioAeCAutomacaoApp/assets/19784186/c89f28be-28c5-4681-90be-8de453678312)


O usuário interage com o formulário Windows Forms.

O formulário chama a camada de aplicação para executar o robô.


A camada de aplicação utiliza o Selenium para realizar a busca no site da Alura.

Os dados coletados são salvos no repositório (arquivo JSON).

## **Tratamento de Erros**

Implementação de try-catch blocks nas operações críticas.

Mensagens de erro amigáveis para o usuário em caso de falhas.

## **Uso de WebDriver**

O projeto utiliza ChromeDriver para interagir com o navegador Google Chrome.

A execução é configurada para exibir a interface gráfica para melhor entendimento do processo.

## **Uso do GitFlow**

Branches de feature, develop e main são utilizadas para organizar o desenvolvimento.

Pull requests e code reviews são realizados antes de merges importantes.
