using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma_de_Filmes_e_Series.Enum;

namespace Plataforma_de_Filmes_e_Series.Classes
{
	public class Filme_Serie : RefBase
	{
		// Atributos
		private Eopcao Eopcao { get; set; }
		private string Genero { get; set; }
		private string Titulo { get; set; }
		private string Sinopse { get; set; }
		private int Ano { get; set; }
		private bool Excluido { get; set; }

		//Métodos
		public Filme_Serie(int id, Eopcao eopcao, string genero, string titulo, string sinopse, int ano)
		{
			this.ID = id;
			this.Eopcao = eopcao;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Sinopse = sinopse;
			this.Ano = ano;
			this.Excluido = false;
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += this.Eopcao + Environment.NewLine;
			retorno += "Gênero: " + this.Genero + Environment.NewLine;
			retorno += "Titulo: " + this.Titulo + Environment.NewLine;
			retorno += "Descrição: " + this.Sinopse + Environment.NewLine;
			retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
			retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
		public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaID()
		{
			return this.ID;
		}
		public bool retornaExcluido()
		{
			return this.Excluido;
		}
		public void Excluir()
		{
			this.Excluido = true;
		}
	}
}
