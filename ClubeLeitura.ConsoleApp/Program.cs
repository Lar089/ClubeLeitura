using ClubeLeitura.ConsoleApp.Telas;
using System;

namespace ClubeLeitura.ConsoleApp
{
    class Program
    {
        static TelaPrincipal telaPrincipal = new TelaPrincipal();

        static void Main(string[] args)
        {
            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterTela();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                if (telaSelecionada is TelaBase)
                    Console.WriteLine(telaSelecionada.Titulo); Console.WriteLine();

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (telaSelecionada is ICadastravel)
                {
                    ICadastravel tela = (ICadastravel)telaSelecionada;

                    if (opcao == "1")
                        tela.InserirNovoRegistro();

                    else if (opcao == "2")
                    {
                        bool temRegistros = tela.VisualizarRegistros(TipoVisualizacao.VisualizandoTela);
                        if (temRegistros)
                            Console.ReadLine();
                    }

                    else if (opcao == "3")
                        tela.EditarRegistro();

                    else if (opcao == "4")
                        tela.ExcluirRegistro();
                }
                else if (telaSelecionada is TelaEmprestimo)
                {
                    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaSelecionada;

                    if (opcao == "1")
                        telaEmprestimo.RegistrarEmprestimo();

                    else if (opcao == "2")
                        telaEmprestimo.RegistrarDevolucao();

                    else if (opcao == "3")
                    {
                        bool temRegistros = telaEmprestimo.VisualizarEmprestimosAbertos();
                        if (temRegistros)
                            Console.ReadLine();
                    }
                    else if (opcao == "4")
                    {
                        bool temRegistros = telaEmprestimo.VisualizarEmprestimosFechados();
                        if (temRegistros)
                            Console.ReadLine();
                    }

                }
                Console.Clear();
            }
        }
    }
}
