
using System;
using System.Linq;
using SistemaEleicao.Console.Models;
using SistemaEleicao.Console.Services;
using Xunit;

namespace SistemaEleicao.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeveCadastrarCandidato()
        {
            // Arrange
            var eleicao = new EleicaoManager();
            var candidato = new Candidato("Gabriel", 15);

            // Act
            eleicao.CadastrarCandidato(candidato);

            // Assert
            Assert.Single(eleicao.ListarCandidatos());
        }

        [Fact]
        public void NaoDevePermitirNumeroDuplicado()
        {
            // Arrange
            var eleicao = new EleicaoManager();

            var candidato1 = new Candidato("Gabriel", 15);
            var candidato2 = new Candidato("Joao", 15);

            eleicao.CadastrarCandidato(candidato1);

            // Act e Assert
            Assert.Throws<InvalidOperationException>(() =>
                eleicao.CadastrarCandidato(candidato2)
            );
        }

        [Fact]
        public void DevePermitirCandidatosComNumerosDiferentes()
        {
            // Arrange
            var eleicao = new EleicaoManager();

            // Act
            eleicao.CadastrarCandidato(new Candidato("Gabriel", 15));
            eleicao.CadastrarCandidato(new Candidato("Maria", 20));

            // Assert
            Assert.Equal(2, eleicao.ListarCandidatos().Count);
        }
    
[Fact]
public void NaoDevePermitirCandidatoComNomeVazio()
{
    Assert.Throws<ArgumentException>(() =>
        new Candidato("", 15)
    );
}

[Fact]
public void NaoDevePermitirCandidatoComNomeEmBranco()
{
    Assert.Throws<ArgumentException>(() =>
        new Candidato("   ", 15)
    );
}

[Fact]
public void NaoDevePermitirCandidatoComNumeroNegativo()
{
    Assert.Throws<ArgumentException>(() =>
        new Candidato("Gabriel", -1)
    );
}
}
}
