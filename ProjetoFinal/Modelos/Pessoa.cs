using ProjetoFinal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Modelos
{
    public class Pessoa : ICodigo
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
