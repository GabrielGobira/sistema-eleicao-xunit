
using System;
using SistemaEleicao.Console.Models;
using SistemaEleicao.Console.Services;
using Xunit;

namespace SistemaEleicao.Tests
{
    public class VotacaoTests
    {
        [Fact]
        public void DeveRegistrarVotoValido()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(
                new Candidato("Gabriel", 15)
            );

            var eleitor = new Eleitor("12345678900");
            eleicao.CadastrarEleitor(eleitor);

            eleicao.RegistrarVoto("12345678900", 15);

            Assert.True(eleitor.JaVotou);
            Assert.Equal(0, eleicao.VotosNulos);
            Assert.Equal(0, eleicao.VotosBrancos);
        }

        [Fact]
        public void DeveRegistrarVotoBranco()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarEleitor(
                new Eleitor("12345678900")
            );

            eleicao.RegistrarVoto("12345678900", null);

            Assert.Equal(1, eleicao.VotosBrancos);
        }

        [Fact]
        public void DeveRegistrarVotoNulo()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarEleitor(
                new Eleitor("12345678900")
            );

            eleicao.RegistrarVoto("12345678900", 99);

            Assert.Equal(1, eleicao.VotosNulos);
        }

        [Fact]
        public void NaoDevePermitirVotarDuasVezes()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(
                new Candidato("Gabriel", 15)
            );

            eleicao.CadastrarEleitor(
                new Eleitor("12345678900")
            );

            eleicao.RegistrarVoto("12345678900", 15);

            Assert.Throws<InvalidOperationException>(() =>
                eleicao.RegistrarVoto("12345678900", 15)
            );
        }

        [Fact]
        public void NaoDevePermitirVotoDeEleitorNaoCadastrado()
        {
            var eleicao = new EleicaoManager();

            Assert.Throws<InvalidOperationException>(() =>
                eleicao.RegistrarVoto("99999999999", 15)
            );
        }
    }
}
