using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaCadastro<Caixa>
    {
        private readonly Controlador<Caixa> controladorCaixa;
        public TelaCaixa(Controlador<Caixa> controlador)
            : base(controlador, "caixas")
        {
            controladorCaixa = controlador;
        }

        public override bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela("Visualizando caixas...");

            List<Caixa> caixas = controladorCaixa.SelecionarTodosRegistros();

            if (caixas.Count == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrada!", TipoMensagem.Atencao);
                return false;
            }

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Etiqueta", "Cor");

            foreach (Caixa caixa in caixas)
            {
                Console.WriteLine(configuracaColunasTabela, caixa.id, caixa.etiqueta, caixa.cor);
            }

            return true;
        }

        protected override Caixa PegarObjeto()
        {
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            return new Caixa(cor, etiqueta);
        }

    }
}