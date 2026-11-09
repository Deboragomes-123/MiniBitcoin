# MiniBitcoin Console Application

Aplicação de console desenvolvida em **.NET 10.0 (C#)** para gestão de carteira de criptomoeda (Bitcoin e BRL), cotação de mercado, operações de compra e venda com validação de saldo e extrato consolidado de portfólio.

Desenvolvido como parte da atividade de **Garantia e Qualidade de Software**.

---

## Arquitetura do Projeto

A solução está dividida em dois projetos principais:
1. **MiniBitcoin.Console**: Contém as regras de negócio (`Carteira`, `Transacao`), serviços de extrato/portfólio e a interface interativa de linha de comando (`Program.cs`).
2. **MiniBitcoin.Tests**: Projeto de testes unitários utilizando **xUnit** para validação das regras de negócio (TDD).

---

## Como Executar

### Pré-requisitos
- [.NET 10.0 SDK](https://dotnet.microsoft.com/) instalado em sua máquina.
- Git configurado.

### Passos para Clonar e Executar

1. **Clonar o Repositório:**
   ```bash
   git clone <URL_DO_SEU_REPOSITORIO_GITHUB>
   cd MiniBitcoin