using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financeiro.modelo;
using Financeiro.dao;

namespace FinanceiroConsole
{
    class Program
    {
            static void Main(string[] args)        {
                int opcao = 9;

                while (opcao != 7)
                {
                    Console.Clear();
                    Console.WriteLine("-----CONTAS A PAGAR--------");
                    Console.WriteLine("1 - Inserir");
                    Console.WriteLine("2 - Remover");
                    Console.WriteLine("3 - Modificar");
                    Console.WriteLine("4 - Pesquisar por ID");
                    Console.WriteLine("5 - Pesquisar por data");
                    Console.WriteLine("6 - Pesquisar todos");
                    Console.WriteLine("7 - Sair");
                    opcao = Convert.ToInt32(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Inserir();
                            break;
                        case 2:
                            Remover();
                            break;
                        case 3:
                            Modificar();
                            break;
                        case 4:
                            PesquisarPorID();
                            break;
                        case 5:
                            PesquisarPorNome();
                            break;
                        case 6:
                            PesquisarTodos();
                            break;
                    }
                }
            }

        public static void Inserir()
        {
            Console.Clear();
            Lancamento lancamento = new Lancamento();
            LancamentoDAO lancamentodao = new LancamentoDAO();
            Console.WriteLine("Informe a data do lancamento");
            lancamento.data = Console.ReadLine();
            Console.WriteLine("Informe a descricao do lancamento");
            lancamento.descricao = Console.ReadLine();
            lancamentodao.Inserir(lancamento);
            Console.WriteLine("Lancamento incluido com sucesso");
            Console.ReadKey();
        }
        public static void Remover()
        {
            Console.Clear();
            Lancamento lancamento = new Lancamento();
            LancamentoDAO lancamentodao = new LancamentoDAO();
            Console.WriteLine("Informe o id do lancamento que deseja remover");
            lancamento.idLancamento = Convert.ToInt32(Console.ReadLine());
            lancamentodao.Remover(lancamento);
            Console.WriteLine("Lancamento removido com sucesso");
            Console.ReadKey();
        }
        public static void Modificar()
        {
            Console.Clear();
            Lancamento lancamento = new Lancamento();
            LancamentoDAO lancamentodao = new LancamentoDAO();
            Console.WriteLine("Informe o id do lancamento que deseja modificar");
            lancamento.idLancamento = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe a data do lancamento");
            lancamento.data = Console.ReadLine();
            Console.WriteLine("Informe a descricao do lancamento");
            lancamento.descricao = Console.ReadLine();
            lancamentodao.Modificar(lancamento);
            Console.WriteLine("Lancamento modificado com sucesso");
            Console.ReadKey();
        }
        public static void PesquisarPorID()
        {
            Console.Clear();
            Lancamento lancamento = new Lancamento();
            LancamentoDAO lancamentodao = new LancamentoDAO();
            int x;
            Console.WriteLine("Informe o id do lancamento que deseja pesquisar");
            x = Convert.ToInt32(Console.ReadLine());
            lancamento = lancamentodao.PesquisarPorId(x);
            Console.WriteLine("Lancamento: {0} Data: {1} Descricao: {3}", lancamento.idLancamento, lancamento.data, lancamento.descricao);
            Console.ReadKey();
        }
        public static void PesquisarPorNome()
        {
            Console.Clear();
            List<Lancamento> lancamentos = new List<Lancamento>();
            LancamentoDAO lancamentodao = new LancamentoDAO();
            String x;
            Console.WriteLine("Informe a data do lancamento que deseja pesquisar");
            x = Console.ReadLine();
            lancamentos = lancamentodao.PesquisarPorData(x);
            foreach (Lancamento lancamento in lancamentos)
            {
                Console.WriteLine("Id: {0} Data: {1} Descricap: {2}", lancamento.idLancamento, lancamento.data, lancamento.descricao);
            }
            Console.ReadKey();
        }
        public static void PesquisarTodos()
        {
            Console.Clear();
            List<Lancamento> lancamentos = new List<Lancamento>();
            LancamentoDAO lancamentodao = new LancamentoDAO();
            lancamentos = lancamentodao.PesquisarTodos();
            foreach (Lancamento lancamento in lancamentos)
            {
                Console.WriteLine("Id: {0} Data: {1} Descricao: {2}", lancamento.idLancamento, lancamento.data, lancamento.descricao);
            }
            Console.ReadKey();
        }
    
    }
}
