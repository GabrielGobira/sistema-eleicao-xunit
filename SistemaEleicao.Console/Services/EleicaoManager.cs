
using SistemaEleicao.Console.Models;

namespace SistemaEleicao.Console.Services
{
    public class EleicaoManager
    {
        private readonly List<Candidato> _candidatos = new();

        public void CadastrarCandidato(Candidato candidato)
        {
            if (candidato == null)
            {
                throw new ArgumentNullException(nameof(candidato));
            }

            if (_candidatos.Any(c => c.Numero == candidato.Numero))
            {
                throw new InvalidOperationException(
                    "Já existe um candidato com esse número."
                );
            }

            _candidatos.Add(candidato);
        }

        public List<Candidato> ListarCandidatos()
        {
            return new List<Candidato>(_candidatos);
        }
    }
}
