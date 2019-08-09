using ProjetoFinal.Interface;
using ProjetoFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Negocio
{
    public class LeitorNegocio : INegocio<Leitor>
    {
        public static List<Leitor> ListaLeitor;
        public LeitorNegocio()
        {
            if (ListaLeitor == null)
            {
                ListaLeitor = new List<Leitor>();
            }
        }
        public void Adicionar(Leitor item)
        {
            ListaLeitor.Add(item);
        }

        public void Atualizar(Leitor item)
        {
            Leitor LeitorCadastrada = Selecionar(item.Codigo);
            if (LeitorCadastrada != null)//Verificamos se esse ja esta cadastrado                                         
            {
                LeitorCadastrada.Nome = item.Nome;//Atualizamos o item
                LeitorCadastrada.Bairro = item.Bairro;//Atualizamos o item
                LeitorCadastrada.Rua = item.Rua;//Atualizamos o item
                LeitorCadastrada.Numero = item.Numero;//Atualizamos o item
            }
        }

        public void Deletar(Leitor item)
        {
            ListaLeitor.Remove(item);
        }

        public List<Leitor> Listar()
        {
            return ListaLeitor;
        }

        public Leitor Selecionar(int codigo)
        {
            return ListaLeitor.FirstOrDefault(r => r.Codigo == codigo);
        }
    }
}
