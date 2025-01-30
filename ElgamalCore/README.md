# Implementação Eficiente do Criptossistema ElGamal em C#

## Descrição do Projeto
Este projeto visa o desenvolvimento de uma implementação eficiente do criptossistema ElGamal utilizando a linguagem C#. O trabalho aborda operações com números grandes, geração de primos seguros, raízes primitivas e validação de segurança e desempenho do sistema para aplicações práticas.

## Área de Concentração
- **Matemática Discreta e Criptografia**
- **Linha de Pesquisa:** Criptografia e Algoritmos de Segurança

## Autor
- **Romário J. O. Veloso** (Bacharelando em Engenharia Eletrônica)

## Resumo Técnico
O criptossistema ElGamal é baseado no problema do logaritmo discreto, proporcionando alta segurança na transmissão de dados. Este projeto aborda desafios como:
- Processamento de números grandes utilizando `BigInteger` do .NET.
- Geração e validação de primos seguros e raízes primitivas.
- Desenvolvimento de funções para geração de chaves, criptografia e descriptografia.

## Palavras-chave
ElGamal, Criptografia, Logaritmo Discreto, C#, Números Grandes

## Objetivos

### Geral
Implementar o criptossistema ElGamal em C# com foco em eficiência computacional e segurança.

### Específicos
1. Desenvolver uma biblioteca para operações com números grandes utilizando a classe `BigInteger`.
2. Validar primos seguros e raízes primitivas.
3. Criar funções para geração de chaves, criptografia e descriptografia.
4. Implementar uma interface para interação com o sistema utilizando Blazor Server.

## Metodologia
1. **Configuração do Ambiente**:
   - Utilização do **Visual Studio 2022** com .NET 8.0.
   - Implementação modular para facilitar manutenção e extensibilidade.

2. **Desenvolvimento de Biblioteca de Números Grandes**:
   - Operações básicas como geração de números aleatórios e primos.
   - Teste de primalidade utilizando o algoritmo de Miller-Rabin.

3. **Algoritmos de Primalidade e Raízes Primitivas**:
   - Implementação de funções para validar primos seguros e suas raízes primitivas.

4. **Implementação do Criptossistema ElGamal**:
   - Gerar chaves públicas e privadas.
   - Criar funções de criptografia e descriptografia.

5. **Implementação da Interface Web**:
   - Desenvolvimento de uma interface interativa com Blazor Server para geração de chaves, criptografia e descriptografia.

6. **Validação e Testes**:
   - Avaliar desempenho com diferentes tamanhos de chaves.
   - Verificar segurança e correção funcional.

## Cronograma de Atividades
| Atividade                                     | Semana 1 | Semana 2 | Semana 3 | Semana 4 |
|-----------------------------------------------|----------|----------|----------|----------|
| Revisão bibliográfica e configuração do ambiente | X        |          |          |          |
| Desenvolvimento da biblioteca de números grandes | X        | X        |          |          |
| Geração de primos e raízes primitivas          |          | X        |          |          |
| Implementação do sistema ElGamal              |          |          | X        |          |
| Implementação da interface com Blazor         |          |          | X        |          |
| Validação e testes                             |          |          |          | X        |
| Escrita e revisão do relatório final          |          |          |          | X        |

## Estrutura Modular do Projeto

O projeto foi desenvolvido com uma estrutura modular para garantir organização, facilidade de manutenção e extensibilidade. Abaixo, descrevemos os principais componentes:

### Principais Componentes:
- **ElgamalCore**: Contém toda a lógica do sistema ElGamal, incluindo:
  - Geração de números aleatórios e primos (`BigNumber`).
  - Testes de primalidade e validação de raízes primitivas.
  - Implementação das funções de criptografia e descriptografia.
- **ElGamalInterface**: Interface web interativa construída com Blazor Server, permitindo ao usuário:
  - Gerar chaves públicas e privadas.
  - Criptografar mensagens.
  - Descriptografar mensagens.

## Como Rodar o Projeto

1. Certifique-se de ter o **.NET 8.0** instalado no sistema.
2. Clone o repositório do projeto.
3. Abra a solução no Visual Studio 2022.

### Executando a Interface Web
1. Defina o projeto `ElGamalInterface` como **Startup Project**.
2. Pressione `F5` para iniciar a aplicação.
3. Acesse a aplicação no navegador em `http://localhost:5000`.

### Estrutura de Diretórios

ElgamalSolution/
├── ElgamalCore/            (Lógica principal do sistema ElGamal)
│   ├── NumerosGrandes/
│   │   ├── BigNumber.cs          // Operações com números grandes (geração de aleatórios, primos, etc.)
│   │   ├── TestesPrimalidade.cs  // Implementação de testes de primalidade (ex.: Miller-Rabin)
│   ├── Criptografia/
│   │   ├── ElGamal.cs            // Implementação do sistema ElGamal (geração de chaves, criptografia e descriptografia)
│   │   └── CodificadorTexto.cs   // Codificação e decodificação de texto para números (preparação para criptografia)
├── ElGamalInterface/       (Interface web utilizando Blazor Server)
│   ├── Pages/
│   │   ├── Index.razor           // Página inicial com as opções de geração de chaves, criptografia e descriptografia
│   ├── Shared/
│   │   ├── NavMenu.razor         // Menu de navegação da interface Blazor
│   ├── wwwroot/
│       ├── css/
│       │   ├── app.css           
│       │   ├── bootstrap.min.css 
├── ElgamalSolution.sln      // Arquivo de solução do Visual Studio que conecta os projetos



## Referências
1. ElGamal, T. *A Public Key Cryptosystem and a Signature Scheme Based on Discrete Logarithms*. Advances in Cryptology, CRYPTO 1984.
2. Hussein, H. I.; Abduallah, W. M. *An Efficient ElGamal Cryptosystem Scheme*. International Journal of Computers and Applications, 2019.
3. Burton, D. *Elementary Number Theory*. 6ª ed., McGraw-Hill, 2007.

## Observações
- **Requisitos:** O projeto requer a instalação do .NET 8.0 e do Visual Studio 2022.
- **Aviso:** O sistema foi projetado para fins educacionais e deve ser ajustado para uso em produção.
