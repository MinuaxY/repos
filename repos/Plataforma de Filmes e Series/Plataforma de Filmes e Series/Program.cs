using System;
using Plataforma_de_Filmes_e_Series.Classes;
using Plataforma_de_Filmes_e_Series.Interfaces;
using Plataforma_de_Filmes_e_Series.Enum;

namespace Plataforma_de_Filmes_e_Series
{
    class Program
    {
        static SerieRep repSerie = new SerieRep();
        static FilmeRep repFilme = new FilmeRep();
		static string opcaoObtida;
		static void Main(string[] args)
		{
			//Menu
			string opcaoUsuario = ObterOpcaoUsuario();
			
			while (opcaoUsuario.ToUpper() != "X")
			{

				if (opcaoUsuario.CompareTo("1") == 0)
                {
					string menufilme = MenuFilme();
					switch (menufilme)
					{
						case "1":
							Listar();
							break;
						case "2":
							Inserir();
							break;
						case "3":
							Editar();
							break;
						case "4":
							Excluir();
							break;
						case "5":
							Visualizar();
							break;
						case "C":
							Console.Clear();
							break;

						case "X":
							break; 
						}
				}
				
				if (opcaoUsuario.CompareTo("2") == 0)
				{
					string menuserie = MenuSerie();
					switch (menuserie)
					{
						case "1":
							Listar();
							break;
						case "2":
							Inserir();
							break;
						case "3":
							Editar();
							break;
						case "4":
							Excluir();
							break;
						case "5":
							Visualizar();
							break;
						case "C":
							Console.Clear();
							break;

						case "X":
							break;
					}
                }

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes e Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Filmes");
			Console.WriteLine("2- Series");
			Console.WriteLine("X- Sair");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			opcaoObtida = opcaoUsuario;
			return opcaoUsuario;
		}

		private static string MenuSerie()
		{
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Editar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Voltar ao menu principal");
			Console.WriteLine();

			string menuserie = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return menuserie;
		}

		private static string MenuFilme()
		{
			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Editar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Voltar ao menu principal");
			Console.WriteLine();

			string menufilme = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return menufilme;
		}
		//Função que registra os Filmes e Séries
		private static void Inserir()
		{
			foreach (int i in System.Enum.GetValues(typeof(Eopcao)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Eopcao), i));
			}
			Console.Write("Digite o Tipo de Registro entre as opções acima: ");
			int entradaEopcao = int.Parse(Console.ReadLine());

			//Filme
			if(entradaEopcao == 1)
            {				
				Console.Write("Digite o Gênero do Filme: ");
				string entradaGenero = Console.ReadLine();

				Console.Write("Digite o Título do Filme: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início do Filme: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Sinopse do Filme: ");
				string entradaSinopse = Console.ReadLine();

				Filme_Serie novoFilme = new Filme_Serie(id: repFilme.ProximoId(),
											eopcao: (Eopcao)entradaEopcao,
											genero: entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											sinopse: entradaSinopse);

				repFilme.Insere(novoFilme);
			}

			//Serie
			if (entradaEopcao == 2)
            {				
				Console.Write("Digite o Gênero da Série: ");
				string entradaGenero = Console.ReadLine();

				Console.Write("Digite o Título da Série: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início da Série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Sinopse da Série: ");
				string entradaSinopse = Console.ReadLine();

				Filme_Serie novaSerie = new Filme_Serie(id: repSerie.ProximoId(),
											eopcao: (Eopcao)entradaEopcao,
											genero: entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											sinopse: entradaSinopse);

				repSerie.Insere(novaSerie);
			}
			
		}

		private static void Listar()
		{
			
			if(opcaoObtida.CompareTo("1") == 0)
            {
				Console.WriteLine("Lista de Filmes");

				var lista = repFilme.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma filme cadastrado.");
					return;
				}

				foreach (var filme in lista)
				{
					var excluido = filme.retornaExcluido();

					Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaID(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				}
			}
			
			//Lista Series
			else if(opcaoObtida.CompareTo("2") == 0)
            {
				Console.WriteLine("Lista de Séries");

				var lista = repSerie.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma série cadastrada.");
					return;
				}

				foreach (var serie in lista)
				{
					var excluido = serie.retornaExcluido();

					Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaID(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				}
            }
			
		}

		private static void Editar()
		{
			foreach (int i in System.Enum.GetValues(typeof(Eopcao)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Eopcao), i));
			}
			Console.Write("Digite o Tipo de Registro entre as opções acima: ");
			int entradaEopcao = int.Parse(Console.ReadLine());

			//Edita Filme
			if (entradaEopcao == 1)
			{
				Console.Write("Digite o id do Filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				Console.Write("Digite o Gênero do Filme: ");
				string entradaGenero = Console.ReadLine();

				Console.Write("Digite o Título do Filme: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início do Filme: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição do Filme: ");
				string entradaSinopse = Console.ReadLine();

				Filme_Serie atualizaFilme = new Filme_Serie(id: indiceFilme,
											eopcao: (Eopcao)entradaEopcao,
											genero: entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											sinopse: entradaSinopse);

				repFilme.Edita(indiceFilme, atualizaFilme);
			}

			//Edita Série
			else if(entradaEopcao == 2)
            {
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				Console.Write("Digite o Gênero da Série: ");
				string entradaGenero = Console.ReadLine();

				Console.Write("Digite o Título da Série: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início da Série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição da Série: ");
				string entradaSinopse = Console.ReadLine();

				Filme_Serie atualizaSerie = new Filme_Serie(id: indiceSerie,
											eopcao: (Eopcao)entradaEopcao,
											genero: entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											sinopse: entradaSinopse);

				repSerie.Edita(indiceSerie, atualizaSerie);
            }
		}

		private static void Visualizar()
		{

			if (opcaoObtida.CompareTo("1") == 0)
			{
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				var filme = repFilme.RetornaPorId(indiceFilme);

				Console.WriteLine(filme);
			}

			else if(opcaoObtida.CompareTo("2") == 0)
            {
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				var serie = repSerie.RetornaPorId(indiceSerie);

				Console.WriteLine(serie);
            }

		}

		private static void Excluir()
		{

			if (opcaoObtida.CompareTo("1") == 0)
			{
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				repFilme.Exclui(indiceFilme);
			}
			else if(opcaoObtida.CompareTo("2") == 0)
            {
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				repSerie.Exclui(indiceSerie);
            }
		}
	}
}
