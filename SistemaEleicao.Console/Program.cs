
using SistemaEleicao.Console.Services;
using SistemaEleicao.Console.Models;

EleicaoManager eleicao = new EleicaoManager();

int opcao;

do
{
    System.Console.Clear();

    System.Console.WriteLine("================================");
    System.Console.WriteLine("       SISTEMA DE ELEICAO       ");
    System.Console.WriteLine("================================");
    System.Console.WriteLine("1 - Cadastrar candidato");
    System.Console.WriteLine("2 - Cadastrar eleitor");
    System.Console.WriteLine("3 - Registrar voto");
    System.Console.WriteLine("4 - Consultar resultado");
    System.Console.WriteLine("0 - Sair");
    System.Console.WriteLine("================================");

    System.Console.Write("Escolha uma opcao: ");

    if (!int.TryParse(System.Console.ReadLine(), out opcao))
    {
        opcao = -1;
    }

    switch (opcao)
    {
     
case 1:
    System.Console.WriteLine("=== CADASTRO DE CANDIDATO ===");

    System.Console.Write("Digite o nome do candidato: ");
    string nome = System.Console.ReadLine() ?? "";

    System.Console.Write("Digite o numero do candidato: ");
    string entradaNumero = System.Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(nome))
    {
        System.Console.WriteLine("O nome nao pode ser vazio.");
        break;
    }

    if (!int.TryParse(entradaNumero, out int numero))
    {
        System.Console.WriteLine("Numero invalido!");
        break;
    }

    try
    {
        Candidato candidato = new Candidato(nome, numero);

        eleicao.CadastrarCandidato(candidato);

        System.Console.WriteLine(
            "Candidato cadastrado com sucesso!"
        );
    }
    catch (InvalidOperationException ex)
    {
        System.Console.WriteLine("Erro: " + ex.Message);
    }

    break;


        case 2:
{
    System.Console.WriteLine("=== CADASTRO DE ELEITOR ===");

    System.Console.Write("Digite o documento do eleitor: ");
    string documento = System.Console.ReadLine() ?? "";

    try
    {
        Eleitor eleitor = new Eleitor(documento);

        eleicao.CadastrarEleitor(eleitor);

        System.Console.WriteLine(
            "Eleitor cadastrado com sucesso!"
        );
    }
    catch (ArgumentException ex)
    {
        System.Console.WriteLine("Erro: " + ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        System.Console.WriteLine("Erro: " + ex.Message);
    }

    break;
}


       
case 3:
{
    System.Console.WriteLine("=== REGISTRO DE VOTO ===");

    System.Console.Write("Digite o documento do eleitor: ");
    string documentoVotante = System.Console.ReadLine() ?? "";

    System.Console.WriteLine();
    System.Console.WriteLine("Candidatos disponíveis:");

    foreach (var candidato in eleicao.ListarCandidatos())
    {
        System.Console.WriteLine(
            $"{candidato.Numero} - {candidato.Nome}"
        );
    }

    System.Console.WriteLine();
    System.Console.WriteLine("Digite o numero do candidato.");
    System.Console.WriteLine("Digite B para votar em branco.");
    System.Console.Write("Seu voto: ");

    string entradaVoto = (System.Console.ReadLine() ?? "").Trim();

    int? numeroVoto;

    if (entradaVoto.Equals("B", StringComparison.OrdinalIgnoreCase))
    {
        numeroVoto = null;
    }
    else if (int.TryParse(entradaVoto, out int numeroDigitado))
    {
        numeroVoto = numeroDigitado;
    }
    else
    {
        System.Console.WriteLine("Entrada invalida!");
        break;
    }

    try
    {
        eleicao.RegistrarVoto(documentoVotante, numeroVoto);

        if (numeroVoto == null)
        {
            System.Console.WriteLine("Voto em branco registrado!");
        }
        else if (eleicao.ListarCandidatos()
            .Any(c => c.Numero == numeroVoto))
        {
            System.Console.WriteLine("Voto valido registrado!");
        }
        else
        {
            System.Console.WriteLine("Voto nulo registrado!");
        }
    }
    catch (InvalidOperationException ex)
    {
        System.Console.WriteLine("Erro: " + ex.Message);
    }

    break;
}

      
case 4:
{
    System.Console.WriteLine("=== RESULTADO DA ELEICAO ===");
    System.Console.WriteLine();

    var candidatos = eleicao.ListarCandidatos();

    int totalVotosValidos = 0;
    int maiorQuantidade = 0;
    int candidatosEmpatados = 0;

    foreach (var candidato in candidatos)
    {
        int votos = eleicao.ObterVotosCandidato(candidato.Numero);

        System.Console.WriteLine(
            $"{candidato.Nome} ({candidato.Numero}): {votos} voto(s)"
        );

        totalVotosValidos += votos;

        if (votos > maiorQuantidade)
        {
            maiorQuantidade = votos;
            candidatosEmpatados = 1;
        }
        else if (votos == maiorQuantidade && votos > 0)
        {
            candidatosEmpatados++;
        }
    }

    System.Console.WriteLine();
    System.Console.WriteLine($"Votos validos: {totalVotosValidos}");
    System.Console.WriteLine($"Votos brancos: {eleicao.VotosBrancos}");
    System.Console.WriteLine($"Votos nulos: {eleicao.VotosNulos}");

    int totalGeral = totalVotosValidos
        + eleicao.VotosBrancos
        + eleicao.VotosNulos;

    System.Console.WriteLine($"Total de votos: {totalGeral}");

    System.Console.WriteLine();
    System.Console.WriteLine("=== VENCEDOR ===");

    if (maiorQuantidade == 0)
    {
        System.Console.WriteLine("Nenhum voto valido registrado.");
    }
    else if (candidatosEmpatados > 1)
    {
        System.Console.WriteLine("A eleicao terminou empatada!");
    }
    else
    {
        var vencedor = eleicao.ObterVencedor();

        System.Console.WriteLine(
            $"Vencedor: {vencedor!.Nome}"
        );

        System.Console.WriteLine(
            $"Numero: {vencedor.Numero}"
        );

        System.Console.WriteLine(
            $"Total de votos: {maiorQuantidade}"
        );
    }

    break;
}

        case 0:
            System.Console.WriteLine("Encerrando o sistema...");
            break;

        default:
            System.Console.WriteLine("Opcao invalida!");
            break;
    }

    if (opcao != 0)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Pressione ENTER para continuar...");
        System.Console.ReadLine();
    }

} while (opcao != 0);
