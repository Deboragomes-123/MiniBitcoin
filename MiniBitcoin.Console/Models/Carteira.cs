using System;

namespace MiniBitcoin.Console.Models
{
    public class Carteira
    {
        public decimal SaldoBrl { get; private set; }
        public decimal SaldoBtc { get; private set; }

        public Carteira(decimal saldoBrlInicial, decimal saldoBtcInicial)
        {
            if (saldoBrlInicial < 0)
                throw new ArgumentException("O saldo inicial em BRL não pode ser negativo.", nameof(saldoBrlInicial));
            if (saldoBtcInicial < 0)
                throw new ArgumentException("O saldo inicial em Bitcoin não pode ser negativo.", nameof(saldoBtcInicial));

            SaldoBrl = saldoBrlInicial;
            SaldoBtc = saldoBtcInicial;
        }

        public void AdicionarBrl(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.", nameof(valor));
            SaldoBrl += valor;
        }

        public void DebitarBrl(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.", nameof(valor));
            if (valor > SaldoBrl) throw new InvalidOperationException("Saldo em BRL insuficiente.");
            SaldoBrl -= valor;
        }

        public void AdicionarBtc(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.", nameof(valor));
            SaldoBtc += valor;
        }

        public void DebitarBtc(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.", nameof(valor));
            if (valor > SaldoBtc) throw new InvalidOperationException("Saldo em Bitcoin insuficiente.");
            SaldoBtc -= valor;
        }
    }
}