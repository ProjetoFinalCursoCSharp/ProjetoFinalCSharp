using ProjetoFinal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Modelos
{
    public class Livro:ICodigo
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public int CodigoRetirada { get; set; }
        public Retirada Retirada { get; set; }
    }
}
