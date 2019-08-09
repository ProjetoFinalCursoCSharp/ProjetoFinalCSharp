using ProjetoFinal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Modelos
{
    public class Retirada : ICodigo
    {
        public int Codigo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimite { get; set; }
        public Nullable<DateTime> DataDevolvido { get; set; }
        public int CodigoLivro { get; set; }
        public Livro Livro { get; set; }
        public int CodigoLeitor { get; set; }
        public Leitor Leitor { get; set; }
        public bool Devolvido { get; set; }
        public Retirada()
        {}
        public Retirada(int codigo, int codigoLeitor, int codigoLivro, DateTime dataEmprestimo)
        {
            Codigo = codigo;
            CodigoLivro = codigoLivro;
            CodigoLeitor = codigoLeitor;
            DataEmprestimo = dataEmprestimo;
            DataLimite = DataEmprestimo.AddDays(5);
            Devolvido = false;
        }
        
    }
}
