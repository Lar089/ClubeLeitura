using System;

namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Amigo : EntidadeBase
    {
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string deOndeEh;
        private Emprestimo[] historicoEmprestimos = new Emprestimo[10];
        public Amigo()
        {
        }
        

        public Amigo(string nome, string nomeResponsavel,
            string telefone, string deOndeEh)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.deOndeEh = deOndeEh;
        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            historicoEmprestimos[ObtemPosicaoVazia()] = emprestimo;
        }

        public bool TemEmprestimoEmAberto()
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

        private int ObtemPosicaoVazia()
        {
            return Array.IndexOf(historicoEmprestimos, null);
        }

        public override bool Equals(object obj)
        {
            Amigo a = (Amigo)obj;

            return id == a.id;
        }

        public override string Validar()
        {
            return "ESTA_VALIDO";
        }
    }
}