using System;

namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Revista : EntidadeBase
    {
        public string nome;
        public Caixa caixa;
        public string colecao;
        public int numeroEdicao;
        public Emprestimo[] historicoEmprestimos = new Emprestimo[10];

        public override string Validar()
        {
            return "ESTA_VALIDO";
        }

        public Revista(string nome, string colecao, int numeroEdicao, Caixa caixa)
        {
            this.nome = nome;
            this.colecao = colecao;
            this.numeroEdicao = numeroEdicao;
            this.caixa = caixa;
        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            historicoEmprestimos[ObtemPosicaoVazia()] = emprestimo;
        }

        private int ObtemPosicaoVazia()
        {
            return Array.IndexOf(historicoEmprestimos, null);
        }

        internal bool EstaEmprestada()
        {
            bool temEmprestimoEmAberto = false;

            foreach (Emprestimo emprestimo in historicoEmprestimos)
            {
                if (emprestimo != null && emprestimo.estaAberto)
                {
                    temEmprestimoEmAberto = true;
                    break;
                }
            }
            return temEmprestimoEmAberto;
        }
    }
}
