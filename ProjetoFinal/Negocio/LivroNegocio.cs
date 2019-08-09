using ProjetoFinal.Interface;
using ProjetoFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Negocio
{
    public class LivroNegocio : INegocio<Livro>
    {
        public static List<Livro> ListaLivro;
        public LivroNegocio()
        {
            if (ListaLivro == null)
            {
                ListaLivro = new List<Livro>();
            }
        }
        public void Adicionar(Livro item)
        {
            ListaLivro.Add(item);
        }

        public void Atualizar(Livro item)
        {
            Livro livroCadastrada = Selecionar(item.Codigo);
            if (livroCadastrada != null)
            {
                livroCadastrada.Titulo = item.Titulo;
            }
        }

        public void Deletar(Livro item)
        {
            ListaLivro.Remove(item);
        }

        public List<Livro> Listar()
        {
            return ListaLivro;
        }

        public Livro Selecionar(int codigo)
        {
            return ListaLivro.FirstOrDefault(r => r.Codigo == codigo);
        }
    }
}
