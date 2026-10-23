
using SistemaEleicao.Console.Models;
using SistemaEleicao.Console.Services;
using Xunit;

namespace SistemaEleicao.Tests
{
    public class ApuracaoTests
    {
        [Fact]
        public void DeveContarVotosDoCandidato()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(new Candidato("Gabriel", 15));

            eleicao.CadastrarEleitor(new Eleitor("111"));
            eleicao.CadastrarEleitor(new Eleitor("222"));

            eleicao.RegistrarVoto("111", 15);
            eleicao.RegistrarVoto("222", 15);

            Assert.Equal(2, eleicao.ObterVotosCandidato(15));
        }

        [Fact]
        public void DeveRetornarZeroParaCandidatoSemVotos()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(new Candidato("Maria", 20));

            Assert.Equal(0, eleicao.ObterVotosCandidato(20));
        }

        [Fact]
        public void DeveIdentificarVencedor()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(new Candidato("Gabriel", 15));
            eleicao.CadastrarCandidato(new Candidato("Maria", 20));

            eleicao.CadastrarEleitor(new Eleitor("111"));
            eleicao.CadastrarEleitor(new Eleitor("222"));
            eleicao.CadastrarEleitor(new Eleitor("333"));

            eleicao.RegistrarVoto("111", 15);
            eleicao.RegistrarVoto("222", 15);
            eleicao.RegistrarVoto("333", 20);

            var vencedor = eleicao.ObterVencedor();

            Assert.NotNull(vencedor);
            Assert.Equal("Gabriel", vencedor.Nome);
        }

        [Fact]
        public void DeveRetornarNullQuandoHouverEmpate()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(new Candidato("Gabriel", 15));
            eleicao.CadastrarCandidato(new Candidato("Maria", 20));

            eleicao.CadastrarEleitor(new Eleitor("111"));
            eleicao.CadastrarEleitor(new Eleitor("222"));

            eleicao.RegistrarVoto("111", 15);
            eleicao.RegistrarVoto("222", 20);

            Assert.Null(eleicao.ObterVencedor());
        }

        [Fact]
        public void DeveRetornarNullQuandoNaoHouverVotosValidos()
        {
            var eleicao = new EleicaoManager();

            eleicao.CadastrarCandidato(new Candidato("Gabriel", 15));

            Assert.Null(eleicao.ObterVencedor());
        }
    }
}
