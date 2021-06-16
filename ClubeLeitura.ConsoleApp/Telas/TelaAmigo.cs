using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaAmigo : TelaCadastro<Amigo>
    {
        private readonly Controlador<Amigo> controlador;
        public TelaAmigo(Controlador<Amigo> controlador)
            : base(controlador,"amigo")
        {
            this.controlador = controlador;
        }


        protected override Amigo PegarObjeto()
        {
            Console.Write("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amiguinho: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite da onde é o amiguinho: ");
            string deOndeEh = Console.ReadLine();

            return new Amigo(nome, nomeResponsavel, telefone, deOndeEh);
        }

        public override bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela("Visualizando amigos...");

            List<Amigo> amigos = controlador.SelecionarTodosRegistros();

            if (amigos.Count == 0)
            {
                ApresentarMensagem("Nenhum amigo cadastrado!", TipoMensagem.Atencao);
                return false;
            }

            string configuracaoColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Nome", "Local");

            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine(configuracaoColunasTabela, amigo.id, amigo.nome, amigo.deOndeEh);
            }

            return true;
        }
    }
}
