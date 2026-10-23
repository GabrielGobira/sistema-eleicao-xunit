
namespace SistemaEleicao.Console.Models
{
    public class Candidato
    {
        public string Nome { get; set; }
        public int Numero { get; set; }

        public Candidato(string nome, int numero)
        {
            Nome = nome;
            Numero = numero;
        }
    }
}
