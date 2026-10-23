
namespace SistemaEleicao.Console.Models
{
    public class Candidato
    {
        public string Nome { get; }
        public int Numero { get; }

        public Candidato(string nome, int numero)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException(
                    "O nome do candidato é obrigatório."
                );
            }

            if (numero < 0)
            {
                throw new ArgumentException(
                    "O número do candidato não pode ser negativo."
                );
            }

            Nome = nome;
            Numero = numero;
        }
    }
}
