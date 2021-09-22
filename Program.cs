using System;

namespace DIO.Filmes
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

				while (opcaoUsuario.ToUpper() != "X")
				{
						switch (opcaoUsuario)
						{
								case "1":
									ListarFilmes();
									break;
								case "2":
									InserirFilme();
									break;
								case "3":
									AtualizarFilme();
									break;
								case "4":
									ExcluirFilme();
									break;
								case "5":
									VisualizarFilme();
									break;
								
								case "C":
									Console.Clear();
									break;

								default:
									throw new ArgumentOutOfRangeException();
					
						}
					opcaoUsuario = ObterOpcaoUsuario();
				}			
				Console.WriteLine("Obrigado por utilizar nossos serviços.");
				Console.ReadLine();
		}
       
		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			
			Console.Write("Confirme se deseja excluir (s/n): ");
			int entradaExcluir = int.Parse(Console.ReadLine());
			if(entradaExcluir=='s')
			{
			repositorio.Exclui(indiceFilme);
			Console.Write("Filme foi  excluida: ");
			}else if(entradaExcluir=='n'){
				Console.Write("Filme não foi excluida: ");
			}else{
				Console.Write("Erro, na entrada de dados ");
			}
		}
		
		

		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}
		
      
		private static void AtualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			//https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			//https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();
			
			Console.Write("Digite o Título do Game em que o Filme foi baseado: ");
			string entradaBaseado = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										baseado: entradaBaseado,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceFilme, atualizaFilme);
		}
		
        
		private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		
		 private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");
			//https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			//https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Título do Game em que o Filme foi baseado: ");
			string entradaBaseado = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										baseado: entradaBaseado,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoFilme);
		}
		
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes  a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}