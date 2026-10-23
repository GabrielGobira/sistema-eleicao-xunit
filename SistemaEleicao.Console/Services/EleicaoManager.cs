
using SistemaEleicao.Console.Models;

namespace SistemaEleicao.Console.Services
{
    public class EleicaoManager
    {
        private readonly List<Candidato> _candidatos = new();
        private readonly List<Eleitor> _eleitores = new();

        public void CadastrarCandidato(Candidato candidato)
        {
            if (candidato == null)
                throw new ArgumentNullException(nameof(candidato));

            if (_candidatos.Any(c => c.Numero == candidato.Numero))
                throw new InvalidOperationException(
                    "Já existe um candidato com esse número."
                );

            _candidatos.Add(candidato);
        }

        public List<Candidato> ListarCandidatos()
        {
            return new List<Candidato>(_candidatos);
        }

        public void CadastrarEleitor(Eleitor eleitor)
        {
            if (eleitor == null)
                throw new ArgumentNullException(nameof(eleitor));

            if (_eleitores.Any(e => e.Documento == eleitor.Documento))
                throw new InvalidOperationException(
                    "Já existe um eleitor com esse documento."
                );

            _eleitores.Add(eleitor);
        }

        public List<Eleitor> ListarEleitores()
        {
            return new List<Eleitor>(_eleitores);
        }
   private readonly Dictionary<int, int> _votos = new();

public int VotosBrancos { get; private set; }
public int VotosNulos { get; private set; }
public void RegistrarVoto(string documento, int? numeroCandidato)
{
    var eleitor = _eleitores.FirstOrDefault(
        e => e.Documento == documento
    );

    if (eleitor == null)
    {
        throw new InvalidOperationException(
            "Eleitor não cadastrado."
        );
    }

    // Impede que o eleitor vote duas vezes
    eleitor.RegistrarVoto();

    // Número nulo representa voto em branco
    if (numeroCandidato == null)
    {
        VotosBrancos++;
        return;
    }

    // Verifica se o candidato existe
    var candidato = _candidatos.FirstOrDefault(
        c => c.Numero == numeroCandidato.Value
    );

    if (candidato == null)
    {
        VotosNulos++;
        return;
    }

    // Registra o voto válido
    if (!_votos.ContainsKey(candidato.Numero))
    {
        _votos[candidato.Numero] = 0;
    }

    _votos[candidato.Numero]++;
}
 
public int ObterVotosCandidato(int numeroCandidato)
{
    if (_votos.TryGetValue(numeroCandidato, out int total))
    {
        return total;
    }

    return 0;
}


public Candidato? ObterVencedor()
{
    if (_votos.Count == 0)
    {
        return null;
    }

    int maiorQuantidade = _votos.Values.Max();

    int quantidadeEmpatados = _votos.Count(
        v => v.Value == maiorQuantidade
    );

    if (quantidadeEmpatados > 1)
    {
        return null;
    }

    int numeroVencedor = _votos
        .First(v => v.Value == maiorQuantidade)
        .Key;

    return _candidatos.FirstOrDefault(
        c => c.Numero == numeroVencedor
    );
}

}
}

