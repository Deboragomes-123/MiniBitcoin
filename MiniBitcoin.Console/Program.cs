using System;
using MiniBitcoin.Console.Models;

namespace MiniBitcoin.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var carteira = new Carteira(10000m, 0.1m);
            var extratoService = new ExtratoService();
            decimal cotacaoBtc = 350000.00m; // Cotação simulada em BRL

            int opcao = 0;
            do
            {
                System.Console.WriteLine("\n=== MINI BITCOIN WALLET ===");
                System.Console.WriteLine($"1. Consultar Cotação e Saldos (Patrimônio: R$ {extratoService.CalcularPatrimonioTotal(carteira, cotacaoBtc):N2})");
                System.Console.WriteLine("2. Comprar Bitcoin");
                System.Console.WriteLine("3. Vender Bitcoin");
                System.Console.WriteLine("4. Exibir Extrato de Transações");
                System.Console.WriteLine("5. Sair");
                System.Console.Write("Escolha uma opção: ");

                if (int.TryParse(System.Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            System.Console.WriteLine($"\nCotação Atual BTC: R$ {cotacaoBtc:N2}");
                            System.Console.WriteLine($"Saldo BRL: R$ {carteira.SaldoBrl:N2}");
                            System.Console.WriteLine($"Saldo BTC: {carteira.SaldoBtc:F8} BTC");
                            break;
                        case 2:
                            System.Console.Write("Informe a quantidade de BTC que deseja comprar: ");
                            if (decimal.TryParse(System.Console.ReadLine(), out decimal qtdCompra) && qtdCompra > 0)
                            {
                                decimal custo = qtdCompra * cotacaoBtc;
                                try
                                {
                                    carteira.DebitarBrl(custo);
                                    carteira.AdicionarBtc(qtdCompra);
                                    extratoService.Registrar(new Transacao("COMPRA", qtdCompra, cotacaoBtc));
                                    System.Console.WriteLine("Compra realizada com sucesso!");
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine($"Erro na compra: {ex.Message}");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Quantidade inválida.");
                            }
                            break;
                        case 3:
                            System.Console.Write("Informe a quantidade de BTC que deseja vender: ");
                            if (decimal.TryParse(System.Console.ReadLine(), out decimal qtdVenda) && qtdVenda > 0)
                            {
                                try
                                {
                                    carteira.DebitarBtc(qtdVenda);
                                    decimal receita = qtdVenda * cotacaoBtc;
                                    carteira.AdicionarBrl(receita);
                                    extratoService.Registrar(new Transacao("VENDA", qtdVenda, cotacaoBtc));
                                    System.Console.WriteLine("Venda realizada com sucesso!");
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine($"Erro na venda: {ex.Message}");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Quantidade inválida.");
                            }
                            break;
                        case 4:
                            System.Console.WriteLine("\n--- EXTRATO DE TRANSAÇÕES ---");
                            foreach (var t in extratoService.Transacoes)
                            {
                                System.Console.WriteLine($"[{t.DataHora}] {t.Tipo}: {t.QuantidadeBtc:F8} BTC | Cotação: R$ {t.CotacaoBtc:N2} | Total: R$ {t.ValorTotalBrl:N2}");
                            }
                            break;
                        case 5:
                            System.Console.WriteLine("Encerrando aplicação...");
                            break;
                        default:
                            System.Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Entrada inválida.");
                }

            } while (opcao != 5);
        }
    }
}
