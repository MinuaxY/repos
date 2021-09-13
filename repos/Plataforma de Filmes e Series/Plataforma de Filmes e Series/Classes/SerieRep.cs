using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma_de_Filmes_e_Series.Interfaces;

namespace Plataforma_de_Filmes_e_Series.Classes
{
	public class SerieRep : IRepositorio<Filme_Serie>
	{
		private List<Filme_Serie> listaSerie = new List<Filme_Serie>();

		public void Edita(int id, Filme_Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Filme_Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Filme_Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Filme_Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}
