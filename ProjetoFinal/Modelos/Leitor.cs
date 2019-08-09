using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Modelos
{
    public class Leitor : Pessoa
    {        
        //Endereco
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public List<Retirada> Retiradas { get; set; }

    }
}
