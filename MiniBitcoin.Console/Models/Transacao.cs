using System;
using System.Collections.Generic;

namespace MiniBitcoin.Console.Models
{
    public class Transacao
    {
        public string Tipo { get; } // "COMPRA" ou "VENDA"
        public decimal QuantidadeBtc { get; }
        public decimal CotacaoBtc { get; }
        public decimal ValorTotalBrl { get; }
        public DateTime DataHora { get; }

        public Transacao(string tipo, decimal quantidadeBtc, decimal cotacaoBtc)
        {
            Tipo = tipo;
            QuantidadeBtc = quantidadeBtc;
            CotacaoBtc = cotacaoBtc;
            ValorTotalBrl = quantidadeBtc * cotacaoBtc;
            DataHora = DateTime.Now;
        }
    }

    public class ExtratoService
    {
        private readonly List<Transacao> _transacoes = new List<Transacao>();

        public IReadOnlyCollection<Transacao> Transacoes => _transacoes.AsReadOnly();

        public void Registrar(Transacao transacao)
        {
            _transacoes.Add(transacao);
        }

        public decimal CalcularPatrimonioTotal(Carteira carteira, decimal cotacaoAtualBtc)
        {
            return carteira.SaldoBrl + (carteira.SaldoBtc * cotacaoAtualBtc);
        }
    }
}
