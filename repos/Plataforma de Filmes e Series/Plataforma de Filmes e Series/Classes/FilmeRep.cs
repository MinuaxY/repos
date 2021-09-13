using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma_de_Filmes_e_Series.Interfaces;

namespace Plataforma_de_Filmes_e_Series.Classes
{
	public class FilmeRep : IRepositorio<Filme_Serie>
	{
		private List<Filme_Serie> listaFilme = new List<Filme_Serie>();

		public void Edita(int id, Filme_Serie objeto)
		{
			listaFilme[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFilme[id].Excluir();
		}

		public void Insere(Filme_Serie objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme_Serie> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filme_Serie RetornaPorId(int id)
		{
			return listaFilme[id];
		}
	}
}
