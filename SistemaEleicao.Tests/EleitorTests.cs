
using System;
using SistemaEleicao.Console.Models;
using SistemaEleicao.Console.Services;
using Xunit;

namespace SistemaEleicao.Tests
{
    public class EleitorTests
    {
        [Fact]
        public void DeveCadastrarEleitor()
        {
            var eleicao = new EleicaoManager();
            var eleitor = new Eleitor("12345678900");

            eleicao.CadastrarEleitor(eleitor);

            Assert.Single(eleicao.ListarEleitores());
        }

        [Fact]
        public void NaoDevePermitirDocumentoDuplicado()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarEleitor(
                new Eleitor("12345678900")
            );

            Assert.Throws<InvalidOperationException>(() =>
                eleicao.CadastrarEleitor(
                    new Eleitor("12345678900")
                )
            );
        }

        [Fact]
        public void NaoDevePermitirDocumentoVazio()
        {
            Assert.Throws<ArgumentException>(() =>
                new Eleitor("")
            );
        }

        [Fact]
        public void NaoDevePermitirVotarDuasVezes()
        {
            var eleitor = new Eleitor("12345678900");

            eleitor.RegistrarVoto();

            Assert.Throws<InvalidOperationException>(() =>
                eleitor.RegistrarVoto()
            );
        }
    }
}
