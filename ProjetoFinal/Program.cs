using ProjetoFinal.Modelos;
using ProjetoFinal.Negocio;
using System;
using System.Globalization;
using System.Linq;

namespace ProjetoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Iniciarlizar(); Metodo criado para teste, sentando valores para Leitor, Livro, e Retirada
            var opcao = -1;
            while (opcao != 0)
            {                
                Console.WriteLine();
                Console.WriteLine("Menu Principal"); //Adicionado nessa parte para melhor visualizarmos em qual menu estamos
                Console.WriteLine("1 - Emprestimo e Devolução de Livro");
                Console.WriteLine("2 - Pesquisar Leitor");
                Console.WriteLine("3 - Leitor");
                Console.WriteLine("4 - Livro");
                Console.WriteLine("5 - Atendentede");
                Console.WriteLine("0 - Finalizar o programa");
                Console.WriteLine();
                Console.Write("Escolhe uma das opções listadas acima, inserindo o numero: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("1 - Emprestar livro");
                        Console.WriteLine("2 - Devolver Livro");
                        Console.WriteLine("3 - Listar Atrasados");
                        Console.WriteLine("0 - Voltar ao menu");
                        Console.WriteLine();
                        Console.Write("Escolhe uma das opções listadas acima, inserindo o numero: ");
                        int opcaoEmprestimo = Convert.ToInt32(Console.ReadLine());
                        RetiradaNegocio retiradaNegocio = new RetiradaNegocio();
                        Console.WriteLine();
                        switch (opcaoEmprestimo)
                        {
                            case 1:
                                Console.WriteLine();
                                RegistrarRetirada();
                                LeitorNegocio leitorEmprestimo = new LeitorNegocio();
                                LivroNegocio livroEmprestimo = new LivroNegocio();
                                var ultimaRetirada = retiradaNegocio.Listar().LastOrDefault();
                                var nomeLeitorEmprestado = leitorEmprestimo.Selecionar(ultimaRetirada.CodigoLeitor).Nome;
                                var tituloLivroEmprestado = livroEmprestimo.Selecionar(ultimaRetirada.CodigoLivro).Titulo;
                                Console.WriteLine();
                                Console.WriteLine($"Livro emprestado: {tituloLivroEmprestado}");
                                Console.WriteLine($"Leitor: {nomeLeitorEmprestado}");
                                Console.WriteLine($"Data do emprestimo: {ultimaRetirada.DataEmprestimo}");
                                Console.WriteLine($"Dia de devolução: {ultimaRetirada.DataLimite}");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.Write($"Digite o codigo do leitor: ");
                                int codigoLeitor = Convert.ToInt32(Console.ReadLine());
                                DevolverLivro(codigoLeitor);
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine();
                                ListarAtrasados();
                                Console.WriteLine();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("1 - Pesquisar por nome");
                        Console.WriteLine("2 - Listar todos os leitores ");
                        Console.WriteLine("0 - Voltar ao menu");
                        Console.WriteLine();
                        Console.Write("Escolhe uma das opções listadas acima, inserindo o numero: ");
                        var opcaoPesqusa = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        LeitorNegocio leitorPesquisa = new LeitorNegocio();
                        switch (opcaoPesqusa)
                        {
                            case 1:
                                Console.Write("Digite o nome do leitor: ");
                                var nomeLeitorPesquisa = Console.ReadLine();
                                if (leitorPesquisa.Listar().FirstOrDefault(r => r.Nome == nomeLeitorPesquisa) != null)
                                {
                                    Console.WriteLine();
                                    var leitorPesquisado = leitorPesquisa.Listar().FirstOrDefault(r => r.Nome == nomeLeitorPesquisa);
                                    Console.WriteLine($"Código {leitorPesquisado.Codigo} Nome: {leitorPesquisado.Nome}");
                                }
                                break;
                            case 2:
                                Console.WriteLine();
                                foreach (var cadaLeitor in leitorPesquisa.Listar())
                                {
                                    Console.WriteLine($"Código {cadaLeitor.Codigo} Nome: {cadaLeitor.Nome}");
                                }
                                Console.WriteLine();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        var opcaoLeitor = -1;
                        while (opcaoLeitor != 0)
                        {
                            Console.WriteLine();
                            LeitorNegocio leitorNegocio = new LeitorNegocio();
                            Console.WriteLine("1 - Cadastrar Leitor");
                            Console.WriteLine("2 - Cadastrar varios Leitor");
                            Console.WriteLine("3 - Atualizar cadastro do Leitor");
                            Console.WriteLine("4 - Listar Leitor");
                            Console.WriteLine("5 - Deletar Leitor");
                            Console.WriteLine("0 - Voltar ao menu anterior");
                            Console.WriteLine();
                            Console.Write("Escolhe uma das opções listadas acima, inserindo o numero: ");
                            opcaoLeitor = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            switch (opcaoLeitor)
                            {
                                case 1:
                                    Console.WriteLine();
                                    CadastrarLeitor();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    CadastrarLeitor();
                                    Console.Write("Digite cancelar, para voltar ao menu de Leitor ou aperte enter adicionar outro: ");
                                    string cancelar = Console.ReadLine();
                                    while (cancelar != "cancelar")
                                    {
                                        Console.WriteLine();
                                        CadastrarLeitor();
                                        Console.Write("Digite cancelar, para voltar ao menu de Leitor ou aperte enter adicionar outro: ");
                                        cancelar = Console.ReadLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    Console.WriteLine("Digite o codigo do Leitor, ou cancelar para voltar o menu de Leitor");
                                    int codigoLeitor = Convert.ToInt32(Console.ReadLine());
                                    //selecionar a Leitor cadastrada para atualizar
                                    var leitor = leitorNegocio.Selecionar(codigoLeitor);
                                    AtualizarLeitor(leitor);
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    foreach (var cadaLeitor in leitorNegocio.Listar())
                                    {
                                        Console.WriteLine($"Código {cadaLeitor.Codigo} Nome: {cadaLeitor.Nome}");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine();
                                    Console.Write("Para deletar um leitor, digite o codigo dele: ");
                                    var codigoLeitorRemover = Convert.ToInt32(Console.ReadLine());
                                    if (leitorNegocio.Selecionar(codigoLeitorRemover) != null)
                                    {
                                        var removerLeitor = leitorNegocio.Selecionar(codigoLeitorRemover);
                                        leitorNegocio.Deletar(removerLeitor);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 4:
                        var opcaoLivro = -1;
                        while (opcaoLivro != 0)
                        {
                            Console.WriteLine();
                            LivroNegocio livroNegocio = new LivroNegocio();
                            Console.WriteLine("1 - Cadastrar Livro");
                            Console.WriteLine("2 - Cadastrar varios Livro");
                            Console.WriteLine("3 - Atualizar cadastro do Livro");
                            Console.WriteLine("4 - Listar Livro");
                            Console.WriteLine("5 - Deletar Livro");
                            Console.WriteLine("0 - Voltar ao menu anterior");
                            Console.WriteLine();
                            Console.Write("Escolhe uma das opções listadas acima, inserindo o numero: ");
                            opcaoLivro = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            switch (opcaoLivro)
                            {
                                case 1:
                                    Console.WriteLine();
                                    CadastrarLivro();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    CadastrarLivro();
                                    Console.Write("Digite cancelar, para voltar ao menu de Livro ou aperte enter adicionar outro: ");
                                    string cancelar = Console.ReadLine();
                                    while (cancelar != "cancelar")
                                    {
                                        CadastrarLivro();
                                        Console.Write("Digite cancelar, para voltar ao menu de Livro ou aperte enter adicionar outro: ");
                                        cancelar = Console.ReadLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    Console.Write("Digite o codigo do Livro, ou cancelar para voltar o menu de Livro: ");
                                    int codigoLeitor = Convert.ToInt32(Console.ReadLine());
                                    //selecionar a Livro cadastrada para atualizar
                                    var livro = livroNegocio.Selecionar(codigoLeitor);
                                    AtualizarLivro(livro);
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    foreach (var cadaLeitor in livroNegocio.Listar())
                                    {
                                        Console.WriteLine($"Código {cadaLeitor.Codigo} Titulo: {cadaLeitor.Titulo}");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine();
                                    Console.Write("Para deletar um livro, digite o codigo dele: ");
                                    var codigoLivroRemover = Convert.ToInt32(Console.ReadLine());
                                    if (livroNegocio.Selecionar(codigoLivroRemover) != null)
                                    {
                                        var removerLivro = livroNegocio.Selecionar(codigoLivroRemover);
                                        livroNegocio.Deletar(removerLivro);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 5:
                        var opcaoAtendente = -1;
                        while (opcaoAtendente != 0)
                        {
                            Console.WriteLine();
                            AtendenteNegocio atendenteNegocio = new AtendenteNegocio();
                            Console.WriteLine("1 - Cadastrar Atendentede");
                            Console.WriteLine("2 - Cadastrar varios Atendentede");
                            Console.WriteLine("3 - Atualizar cadastro do Atendentede");
                            Console.WriteLine("4 - Listar Atendentede");
                            Console.WriteLine("5 - Deletar Atendentede");
                            Console.WriteLine("0 - Voltar ao menu anterior");
                            Console.WriteLine();
                            Console.Write("Escolhe uma das opções listadas acima, inserindo o numero: ");
                            opcaoAtendente = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            switch (opcaoAtendente)
                            {
                                case 1:
                                    Console.WriteLine();
                                    CadastrarAtendente();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    CadastrarLivro();
                                    Console.Write("Digite cancelar, para voltar ao menu de Atendente ou aperte enter adicionar outro: ");
                                    string cancelar = Console.ReadLine();
                                    while (cancelar != "cancelar")
                                    {
                                        CadastrarAtendente();
                                        Console.Write("Digite cancelar, para voltar ao menu de Atendente ou aperte enter adicionar outro: ");
                                        cancelar = Console.ReadLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    Console.WriteLine("Digite o codigo do atendente, ou cancelar para voltar o menu de atendente");
                                    int codigoAtendente = Convert.ToInt32(Console.ReadLine());
                                    //selecionar a atendente cadastrada para atualizar
                                    var atendente = atendenteNegocio.Selecionar(codigoAtendente);
                                    AtualizarAtendente(atendente);
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    foreach (var cadaAtendente in atendenteNegocio.Listar())
                                    {
                                        Console.WriteLine($"Código {cadaAtendente.Codigo} Nome: {cadaAtendente.Nome}");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine();
                                    Console.Write("Para deletar um atendente digite o codigo dele: ");
                                    var codigoAtendenteRemover = Convert.ToInt32(Console.ReadLine());
                                    if (atendenteNegocio.Selecionar(codigoAtendenteRemover) != null)
                                    {
                                        var removerLeitor = atendenteNegocio.Selecionar(codigoAtendenteRemover);
                                        atendenteNegocio.Deletar(removerLeitor);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        break;
                    default:
                        //caso nenhuma seja atendida
                        break;
                }
            }// Chave de fechamento do while de nosso menu principal

            Console.WriteLine("O programa terminou, aperte enter para fechar o console");
            Console.ReadKey();
        }//Fechamento do metodo Main

        public static void Iniciarlizar()
        {
            Leitor leitor1 = new Leitor();
            LeitorNegocio leitorNegocio = new LeitorNegocio();            
            leitor1.Codigo = 1;
            leitor1.Nome = "Maria";
            leitor1.Rua = "jose verde";
            leitor1.Numero = "14";
            leitor1.Bairro = "Vila verde";
            leitorNegocio.Adicionar(leitor1);
            Leitor leitor2 = new Leitor();
            leitor2.Codigo = 2;
            leitor2.Nome = "Joao";
            leitor2.Rua = "jose azul";
            leitor2.Numero = "17";
            leitor2.Bairro = "Vila azul";
            leitorNegocio.Adicionar(leitor2);
            Leitor leitor3 = new Leitor();
            leitor3.Codigo = 3;
            leitor3.Nome = "Jucerlei";
            leitor3.Rua = "jose amarelo";
            leitor3.Numero = "18";
            leitor3.Bairro = "Vila amarelo";
            leitorNegocio.Adicionar(leitor3);
            Leitor leitor4 = new Leitor();
            leitor4.Codigo = 4;
            leitor4.Nome = "Luana";
            leitor4.Rua = "jose rosa";
            leitor4.Numero = "19";
            leitor4.Bairro = "Vila rosa";
            leitorNegocio.Adicionar(leitor4);
            Leitor leitor5 = new Leitor();
            leitor5.Codigo = 5;
            leitor5.Nome = "Benecio";
            leitor5.Rua = "jose roxo";
            leitor5.Numero = "20";
            leitor5.Bairro = "Vila roxo";
            leitorNegocio.Adicionar(leitor5);

            Livro livro = new Livro();
            LivroNegocio livroNegocio = new LivroNegocio();
            livro.Codigo = 1;
            livro.Titulo = "Uma Breve História do Tempo – Stephen Hawking";
            livroNegocio.Adicionar(livro);
            Livro livro1 = new Livro();
            livro1.Codigo = 2;
            livro1.Titulo = "Uma Comovente Obra de Espantoso Talento – Dave Eggers";
            livroNegocio.Adicionar(livro1);
            Livro livro2 = new Livro();
            livro2.Codigo = 3;
            livro2.Titulo = "Muito Longe de Casa – Ishmael Beah";
            livroNegocio.Adicionar(livro2);
            Livro livro3 = new Livro();
            livro3.Codigo = 4;
            livro3.Titulo = "Uma Dobra no Tempo – Madeleine L’Engle";
            livroNegocio.Adicionar(livro3);
            Livro livro5 = new Livro();
            livro5.Codigo = 5;
            livro5.Titulo = "Alice – Lewis Carroll";
            livroNegocio.Adicionar(livro5);

            RetiradaNegocio retiradaNegocio = new RetiradaNegocio();
            CultureInfo cult = new CultureInfo("pt-BR");
            var dataEmprestimo = Convert.ToDateTime("08/08/2019", cult);
            Retirada retirada = new Retirada(1, 1, 1, dataEmprestimo);
            retiradaNegocio.Adicionar(retirada);

            RetiradaNegocio retiradaNegocio2 = new RetiradaNegocio();
            var dataEmprestimo2 = Convert.ToDateTime("20/07/2019", cult);
            Retirada retirada2 = new Retirada(2, 1, 3, dataEmprestimo2);
            retiradaNegocio.Adicionar(retirada2);

            RetiradaNegocio retiradaNegocio3 = new RetiradaNegocio();
            var dataEmprestimo3 = Convert.ToDateTime("12/07/2019", cult);
            Retirada retirada3 = new Retirada(3, 2, 2, dataEmprestimo3);
            retiradaNegocio.Adicionar(retirada3);

            RetiradaNegocio retiradaNegocio4 = new RetiradaNegocio();
            var dataEmprestimo4= Convert.ToDateTime("05/08/2019", cult);
            Retirada retirada4= new Retirada(4, 2, 2, dataEmprestimo4);
            retiradaNegocio.Adicionar(retirada4);

            RetiradaNegocio retiradaNegocio5 = new RetiradaNegocio();
            var dataEmprestimo5 = Convert.ToDateTime("04/08/2019", cult);
            Retirada retirada5 = new Retirada(5, 5, 4, dataEmprestimo5);
            retiradaNegocio.Adicionar(retirada5);


        }
        public static void CadastrarLeitor()
        {
            Leitor leitor = new Leitor();
            LeitorNegocio leitorNegocio = new LeitorNegocio();
            //Verificamos se existe algum leitor cadastrado, caso nao aja o FirstOrDefault ira retornar null
            if (leitorNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault() != null)
            {
                //Vamos obter o ultimo codigo cadastrado, já que deixar isso pro usuario é propenso a erros
                leitor.Codigo = leitorNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault().Codigo + 1;
            }
            else
            {
                //Caso seja null vamos iniciar o codigo em 1
                leitor.Codigo = 1;
            }
            //Criando um novo leitor
            Console.Write("Digite o nome do leitor: ");
            leitor.Nome = Console.ReadLine();
            Console.Write("Digite a rua: ");
            leitor.Rua = Console.ReadLine();
            Console.Write("Digite o numero: ");
            leitor.Numero = Console.ReadLine();
            Console.Write("Digite o bairro: ");
            leitor.Bairro = Console.ReadLine();

            //Adicionar o leitor a lista de leitores
            leitorNegocio.Adicionar(leitor);
        }

        public static void CadastrarAtendente()
        {
            Atendente atendente = new Atendente();
            AtendenteNegocio atendenteNegocio = new AtendenteNegocio();
            //Vamos obter o ultimo codigo cadastrado e adicionar 1, já que deixar isso pro usuario é propenso a erros

            //Verificamos se existe algum atendente cadastrado, caso nao aja o FirstOrDefault ira retornar null
            if (atendenteNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault() != null)
            {
                //Vamos obter o ultimo codigo cadastrado, já que deixar isso pro usuario é propenso a erros
                atendente.Codigo = atendenteNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault().Codigo + 1;
            }
            else
            {
                //Caso seja null vamos iniciar o codigo em 1
                atendente.Codigo = 1;
            }

            //Criando um novo Atendente
            Console.Write("Digite o nome do Atendente: ");
            atendente.Nome = Console.ReadLine();

            //Adicionar o Atendente a lista de Atendentees
            atendenteNegocio.Adicionar(atendente);
        }

        public static void RegistrarRetirada()
        {

            RetiradaNegocio retiradaNegocio = new RetiradaNegocio();
            int codigo;
            //Verificamos se existe alguma retirada cadastrado, caso nao aja o FirstOrDefault ira retornar null
            if (retiradaNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault() != null)
            {
                //Vamos obter o ultimo codigo cadastrado, já que deixar isso pro usuario é propenso a erros
                codigo = retiradaNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault().Codigo + 1;
            }
            else
            {
                //Caso seja null vamos iniciar o codigo em 1
                codigo = 1;
            }

            //Criando um novo registro de Retirada
            Console.Write("Digite o codigo do Leitor: ");
            var codigoLeitor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o codigo do Livro: ");
            var codigoLivro = Convert.ToInt32(Console.ReadLine());
            //Para trabalhar com o padrao de Data que utilizamos no brasil adicione o CultureInfo
            //Com ele podemos especificar de qual formato de data queremos utilizar
            //No brasil usamos o formato dd/MM/yyyy = dia/mes/ano
            CultureInfo cult = new CultureInfo("pt-BR");
            Console.Write("Digite a data de emprestimo: ");
            var dataEmprestimo = Convert.ToDateTime(Console.ReadLine(), cult);
            Retirada retirada = new Retirada(codigo, codigoLeitor, codigoLivro, dataEmprestimo);
            //Adicionar o Atendente a lista de Atendentees
            retiradaNegocio.Adicionar(retirada);
        }
        public static void CadastrarLivro()
        {
            Livro livro = new Livro();
            LivroNegocio livroNegocio = new LivroNegocio();
            //Verificamos se existe algum leitor cadastrado, caso nao aja o FirstOrDefault ira retornar null
            if (livroNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault() != null)
            {
                //Vamos obter o ultimo codigo cadastrado, já que deixar isso pro usuario é propenso a erros
                livro.Codigo = livroNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault().Codigo + 1;
            }
            else
            {
                //Caso seja null vamos iniciar o codigo em 1
                livro.Codigo = 1;
            }
            //Criando um novo Livro            
            Console.Write("Digite o titulo do livro: ");
            livro.Titulo = Console.ReadLine();


            //Adicionar o Atendente a lista de Atendentees
            livroNegocio.Adicionar(livro);
        }
        public static void AtualizarLeitor(Leitor leitor)
        {
            LeitorNegocio leitorNegocio = new LeitorNegocio();

            //Criando um novo leitor
            Console.Write("Digite o nome do leitor, ou aperte enter para pular: ");
            var nomeAtualizado = Console.ReadLine();
            if (!string.IsNullOrEmpty(nomeAtualizado))
            {
                leitor.Nome = nomeAtualizado;
            }
            Console.Write("Digite a rua, ou aperte enter para pular: ");
            var rua = Console.ReadLine();
            if (!string.IsNullOrEmpty(rua))
            {
                leitor.Rua = rua;
            }
            Console.Write("Digite o numero, ou aperte enter para pular: ");
            var numero = Console.ReadLine();
            if (!string.IsNullOrEmpty(numero))
            {
                leitor.Numero = numero;
            }
            Console.Write("Digite o bairro, ou aperte enter para pular: ");
            var bairro = Console.ReadLine();
            if (!string.IsNullOrEmpty(numero))
            {
                leitor.Bairro = bairro;
            }
            //Adicionar o leitor a lista de leitores
            leitorNegocio.Atualizar(leitor);
        }
        public static void AtualizarAtendente(Atendente atendente)
        {
            AtendenteNegocio atendenteNegocio = new AtendenteNegocio();

            Console.Write("Digite o nome do atendente, ou aperte enter para pular: ");
            var nomeAtualizado = Console.ReadLine();
            if (!string.IsNullOrEmpty(nomeAtualizado))
            {
                atendente.Nome = nomeAtualizado;
            }

            atendenteNegocio.Atualizar(atendente);
        }

        public static void AtualizarRetirada(Retirada retirada)
        {
            RetiradaNegocio retiradaNegocio = new RetiradaNegocio();

            Console.Write("Digite o codigo do leitor, ou aperte enter para pular : ");
            var codigoLeitor = Console.ReadLine();
            if (!string.IsNullOrEmpty(codigoLeitor))
            {
                retirada.CodigoLeitor = Convert.ToInt32(codigoLeitor);
            }
            Console.Write("Digite o codigo do Livro, ou aperte enter para pular: ");
            var codigoLivro = Console.ReadLine();
            if (!string.IsNullOrEmpty(codigoLivro))
            {
                retirada.CodigoLivro = Convert.ToInt32(codigoLivro);
            }
            Console.Write("Digite a data de emprestimo, ou aperte enter para pular: ");
            var dataEmprestimo = Console.ReadLine();
            if (!string.IsNullOrEmpty(codigoLeitor))
            {
                //Para trabalhar com o padrao de Data que utilizamos no brasil adicione o CultureInfo
                //Com ele podemos especificar de qual formato de data queremos utilizar
                //No brasil usamos o formato dd/MM/yyyy = dia/mes/ano
                CultureInfo cult = new CultureInfo("pt-BR");
                retirada.DataEmprestimo = Convert.ToDateTime(dataEmprestimo, cult);
                retirada.DataLimite = retirada.DataEmprestimo.AddDays(5);
            }

            retiradaNegocio.Atualizar(retirada);
        }

        public static void AtualizarLivro(Livro livro)
        {
            LivroNegocio livroNegocio = new LivroNegocio();
            Console.Write("Digite o titulo do livro: ");
            var titulo = Console.ReadLine();
            if (!string.IsNullOrEmpty(titulo))
            {
                livro.Titulo = titulo;
            }

            livroNegocio.Atualizar(livro);
        }
        public static void DevolverLivro(int codigoLeitor)
        {
            RetiradaNegocio retiradaNegocio = new RetiradaNegocio();
            LeitorNegocio leitorNegocio = new LeitorNegocio();
            LivroNegocio livroNegocio = new LivroNegocio();
            //Obter todos os livros que o leitor pegou emprestado            
            var listaLivrosEmprestado = retiradaNegocio.Listar().Where(r => r.CodigoLeitor == codigoLeitor && r.Devolvido == false);
            //Retornando o nome do leitor que esta com o livro
            Console.WriteLine($"Nome do leitor: {leitorNegocio.Selecionar(codigoLeitor).Nome}");
            foreach (var item in listaLivrosEmprestado)
            {
                Console.WriteLine($"Codigo da retirada {item.Codigo}");
                //Retornando o nome do livro que foi emprestado
                Console.WriteLine($"Nome do livro {livroNegocio.Selecionar(item.CodigoLivro).Titulo}");

                Console.WriteLine($"Data de emprestimo: {item.DataEmprestimo}");
                Console.WriteLine($"Data de limite: {item.DataLimite}");
                //Verificamos se o livro esta atrasado e caso esteja retornamos uma mensagem dizendo que esta atrasado
                //Comparamos com a data atual

                if (item.DataLimite < DateTime.Now)
                {
                    var diasAtrasado = DateTime.Now - item.DataLimite;
                    Console.WriteLine($"Atrasado a {diasAtrasado.Days}");
                    double valor = 0.0;
                    valor = CalcularAtraso(Convert.ToInt32(Math.Abs(diasAtrasado.Days)));
                    Console.WriteLine($"O leitor deve pagar {valor} reais pelo atraso");
                }
                Console.WriteLine();
            }
            Console.Write("Digite o codigo de emprestimo para devolver: ");
            var codigoDevolucao = Convert.ToInt32(Console.ReadLine());
            var devolucao = retiradaNegocio.Selecionar(codigoDevolucao);            
            double valorDevolucao = 0.0;
            if (devolucao.DataLimite < DateTime.Now)
            {
                var diasAtrasado = DateTime.Now - devolucao.DataLimite;
                valorDevolucao = CalcularAtraso(Convert.ToInt32(diasAtrasado.Days));
                Console.WriteLine($"O leitor deve pagar {valorDevolucao} reais pelo atraso, antes de devolver");
                Console.Write("Confirme o pagamento digitando S ou N para cancelar (S, N): ");
                var confirmarPagamento = Console.ReadLine();
                if (confirmarPagamento.ToLower() == "s")
                {
                    devolucao.Devolvido = true;
                    Console.WriteLine("Livro devolvido");
                }
                else
                {
                    Console.WriteLine("operação cancelada");
                }
            }
            else
            {
                var confirmar = Console.ReadLine();
                if (confirmar.ToLower() == "s")
                {
                    devolucao.Devolvido = true;
                    Console.WriteLine("Livro devolvido");
                }
                else
                {
                    Console.WriteLine("operação cancelada");
                }
            }
        }
        public static double CalcularAtraso(int dias)
        {
            return dias * 3.0;
        }
        public static void ListarAtrasados()
        { 
            RetiradaNegocio retiradaNegocio = new RetiradaNegocio();
            LeitorNegocio leitorNegocio = new LeitorNegocio();// Atribui o cliente pesquisado por key (chave)
            LivroNegocio livroNegocio = new LivroNegocio();
            if (retiradaNegocio.Listar().Where(r => r.DataLimite > DateTime.Now).Count() > 0)
            {
                foreach (var atrasados in retiradaNegocio.Listar().Where(r => r.DataLimite < DateTime.Now && r.Devolvido == false))
                {
                    Console.WriteLine($"Código: {atrasados.Codigo}");
                    Console.WriteLine($"Leitor: {leitorNegocio.Selecionar(atrasados.CodigoLeitor).Nome}");
                    Console.WriteLine($"Livro: {livroNegocio.Selecionar(atrasados.CodigoLivro).Titulo}");
                    Console.WriteLine($"Data emprestimo: {atrasados.DataEmprestimo}");
                    Console.WriteLine($"Data limite: {atrasados.DataLimite}");
                    var diasAtrasado = DateTime.Now - atrasados.DataLimite;
                    Console.WriteLine($"Dias atrasado: {diasAtrasado.Days}");
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Nenhum livro atrasado");
            }
        }

    }
}
