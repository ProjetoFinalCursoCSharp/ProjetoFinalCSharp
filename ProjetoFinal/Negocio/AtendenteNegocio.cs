using ProjetoFinal.Interface;
using ProjetoFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Negocio
{
    public class AtendenteNegocio : INegocio<Atendente>
    {
        public static List<Atendente> ListaAtendente;
        public AtendenteNegocio()
        {
            if (ListaAtendente == null)
            {
                ListaAtendente = new List<Atendente>();
            }
        }
        public void Adicionar(Atendente item)
        {
            ListaAtendente.Add(item);
        }

        public void Atualizar(Atendente item)
        {
            Atendente atendenteCadastrada = Selecionar(item.Codigo);
            if (atendenteCadastrada != null)
            {
                atendenteCadastrada.Nome = item.Nome;
            }
        }

        public void Deletar(Atendente item)
        {
            ListaAtendente.Remove(item);
        }

        public List<Atendente> Listar()
        {
            return ListaAtendente;
        }

        public Atendente Selecionar(int codigo)
        {
            return ListaAtendente.FirstOrDefault(r => r.Codigo == codigo);
        }
    }
}