
# Sistema de Eleição

Sistema de votação desenvolvido em C# com .NET, utilizando testes automatizados com xUnit.

## Objetivo

Simular uma eleição, permitindo cadastrar candidatos e eleitores, registrar votos e consultar os resultados.

Projeto desenvolvido para a disciplina de Garantia da Qualidade de Software.

## Tecnologias utilizadas

- C#
- .NET
- xUnit
- Git e GitHub
- Visual Studio Code

## Funcionalidades

- Cadastro de candidatos.
- Validação de números de candidatos duplicados.
- Cadastro de eleitores por documento.
- Bloqueio de documentos duplicados.
- Registro de votos válidos.
- Registro de votos brancos e nulos.
- Bloqueio de votos duplicados.
- Contagem de votos por candidato.
- Identificação do vencedor.
- Identificação de empates.
- Menu interativo pelo terminal.

## Estrutura do projeto

SistemaEleicao/
- SistemaEleicao.Console/
  - Models/
    - Candidato.cs
    - Eleitor.cs
  - Services/
    - EleicaoManager.cs
  - Program.cs
- SistemaEleicao.Tests/
  - UnitTest1.cs
  - EleitorTests.cs
  - VotacaoTests.cs
  - ApuracaoTests.cs
- README.md

## Como executar

### 1. Clonar o repositório

git clone URL_DO_REPOSITORIO

### 2. Entrar na pasta

cd SistemaEleicao

### 3. Executar o sistema

dotnet run --project SistemaEleicao.Console

## Executar os testes

Na pasta principal do projeto, execute:

dotnet test

## Menu do sistema

1 - Cadastrar candidato

2 - Cadastrar eleitor

3 - Registrar voto

4 - Consultar resultado

0 - Sair

## Regras de negócio

- Cada candidato deve possuir um número único.
- Cada eleitor deve possuir um documento único.
- Cada eleitor pode votar apenas uma vez.
- Votos em candidatos inexistentes são considerados nulos.
- O eleitor pode optar por votar em branco.
- O candidato com mais votos válidos vence.
- Em caso de empate, não existe vencedor único.


## Testes automatizados

O projeto possui 20 testes automatizados com xUnit, cobrindo:

- Cadastro e validação de candidatos.
- Cadastro e validação de eleitores.
- Registro de votos válidos, brancos e nulos.
- Bloqueio de votos duplicados.
- Contagem de votos por candidato.
- Identificação do vencedor.
- Tratamento de empates.

### Executar os testes

```bash
dotnet test
```

Resultado da última execução: 20 testes aprovados.


## Autor

Gabriel Gobira de Souza

Projeto acadêmico desenvolvido para a disciplina de Garantia da Qualidade de Software.
