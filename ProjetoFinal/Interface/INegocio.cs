using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Interface
{
    public interface INegocio<T> where T : class
    {
        T Selecionar(int codigo);
        List<T> Listar();
        void Adicionar(T item);
        void Atualizar(T item);
        void Deletar(T item);
    }
}
