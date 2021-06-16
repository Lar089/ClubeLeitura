using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : Controlador<Emprestimo>
    {
        public string RegistrarEmprestimo(Amigo amigo, Revista revista, DateTime data)
        {
            Emprestimo emprestimo = new Emprestimo(amigo, revista, data);

            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                amigo.RegistrarEmprestimo(emprestimo);
                revista.RegistrarEmprestimo(emprestimo);

                emprestimo.id = NovoId();
                registros.Add(emprestimo);
            }

            return resultadoValidacao;
        }

        internal bool RegistrarDevolucao(int idEmprestimo, DateTime data)
        {
            Emprestimo emprestimo = (Emprestimo)SelecionarRegistroPorId(idEmprestimo);

            emprestimo.Fechar(data);

            return true;
        }

        internal List<Emprestimo> SelecionarEmprestimosEmAberto()
        {
            List<Emprestimo> emprestimosEmAberto = new List<Emprestimo>();

            List<Emprestimo> todosEmprestimos = SelecionarTodosRegistros();

            foreach (Emprestimo e in todosEmprestimos)
                if (e.estaAberto) emprestimosEmAberto.Add(e);
            
            return emprestimosEmAberto;
        }

        internal List<Emprestimo> SelecionarEmprestimosFechados(int mes)
        {
            List<Emprestimo> emprestimosFechados = new List<Emprestimo>();

            List<Emprestimo> todosEmprestimos = SelecionarTodosRegistros();

            foreach (Emprestimo e in todosEmprestimos)
                if (e.EstaFechado() && e.Mes == mes) emprestimosFechados.Add(e);
            
            return emprestimosFechados;
        }     
    }
}