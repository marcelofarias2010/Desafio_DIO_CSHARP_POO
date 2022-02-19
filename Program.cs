
using DIO.Serie;

namespace DIO.Series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
 
      string operacaoUsuario = ObterOpcaoUsuario();

      while (operacaoUsuario.ToUpper() != "A")
      {
        switch (operacaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          case "X":
            Environment.Exit(0);
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        operacaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por atualizar nosso serviço");
      Console.ReadLine();    
    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar séries");
      var lista = repositorio.Lista();

      if(lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada. ");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "## Série Excluida ##":""));
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite os gêneros entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());
      
      Console.WriteLine("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();
      
      Console.WriteLine("Digite o ano do filme: ");
      int entradaAno = int.Parse(Console.ReadLine());
      
      Console.WriteLine("Digite uma descrição para o filme: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);
      repositorio.Insere(novaSerie);

    }

    private static void AtualizarSerie()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o Ano de Início da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);
      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o ID da serie: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Excluir(indiceSerie);
    }

    private static void VisualizarSerie()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaParId(indiceSerie);

      Console.WriteLine(serie);
    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:__");

      Console.WriteLine("1 - Listar série");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - visualizar série");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - sair");
      Console.WriteLine();
      
      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}