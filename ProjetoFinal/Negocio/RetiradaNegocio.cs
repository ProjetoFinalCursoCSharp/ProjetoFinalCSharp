using ProjetoFinal.Interface;
using ProjetoFinal.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinal.Negocio
{
    public class RetiradaNegocio : INegocio<Retirada>
    {
        public static List<Retirada> ListaRetirada;
        public RetiradaNegocio()
        {
            if (ListaRetirada == null)
            {
                ListaRetirada = new List<Retirada>();
            }
        }
        public void Adicionar(Retirada item)
        {
            ListaRetirada.Add(item);
        }

        public void Atualizar(Retirada item)
        {
            Retirada retiradaCadastrada = Selecionar(item.Codigo);
            if (retiradaCadastrada != null)
            {
                retiradaCadastrada.CodigoLeitor = item.CodigoLeitor;
                retiradaCadastrada.CodigoLivro = item.CodigoLivro;                
                retiradaCadastrada.DataEmprestimo = item.DataEmprestimo;
                retiradaCadastrada.DataLimite = item.DataLimite;
                retiradaCadastrada.Devolvido = item.Devolvido;
                retiradaCadastrada.Leitor = item.Leitor;
                retiradaCadastrada.Livro = item.Livro;
            }
        }

        public void Deletar(Retirada item)
        {
            ListaRetirada.Remove(item);
        }

        public List<Retirada> Listar()
        {
            return ListaRetirada;
        }

        public Retirada Selecionar(int codigo)
        {
            return ListaRetirada.FirstOrDefault(r => r.Codigo == codigo);
        }
    }
}
