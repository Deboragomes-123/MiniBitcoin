using Xunit;
using MiniBitcoin.Console.Models;
using System;

namespace MiniBitcoin.Tests
{
    public class CarteiraTests
    {
        [Fact]
        public void CriarCarteira_ComValoresValidos_DeveDefinirSaldosCorretamente()
        {
            var carteira = new Carteira(1000m, 0.5m);
            Assert.Equal(1000m, carteira.SaldoBrl);
            Assert.Equal(0.5m, carteira.SaldoBtc);
        }

        [Fact]
        public void CriarCarteira_ComBrlNegativo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new Carteira(-100m, 0m));
        }

        [Fact]
        public void CriarCarteira_ComBtcNegativo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new Carteira(100m, -0.1m));
        }

        [Fact]
        public void DebitarBrl_SaldoInsuficiente_DeveLancarExcecao()
        {
            var carteira = new Carteira(100m, 0m);
            Assert.Throws<InvalidOperationException>(() => carteira.DebitarBrl(150m));
        }
    }
}
