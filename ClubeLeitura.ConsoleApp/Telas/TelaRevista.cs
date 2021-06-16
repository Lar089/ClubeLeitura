using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaCadastro<Revista>
    {
        private readonly TelaCaixa telaCaixa;
        
        private Controlador<Revista> controladorRevista;
        private Controlador<Caixa> controladorCaixa;

        public TelaRevista(Controlador<Revista> controladorRevista, Controlador<Caixa> controladorCaixa, TelaCaixa telaCaixa)
            : base (controladorRevista, "revista")
        {
            this.controladorRevista = controladorRevista;
            this.controladorCaixa = controladorCaixa;
            this.telaCaixa = telaCaixa;
        }

        public override bool VisualizarRegistros(TipoVisualizacao tipo)
        {
            if (tipo == TipoVisualizacao.VisualizandoTela)
                ConfigurarTela("Visualizando revistas...");

            List<Revista> revistas = controladorRevista.SelecionarTodosRegistros();

            if (revistas.Count == 0)
            {
                ApresentarMensagem("Nenhum revista cadastrado!", TipoMensagem.Atencao);
                return false;
            }

            string configuracaColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Nome", "Coleção", "Caixa");

            foreach (Revista revista in revistas)
            {
                Console.WriteLine(configuracaColunasTabela, revista.id, revista.nome,
                    revista.colecao, revista.caixa.cor);
            }

            return true;
        }

        protected override Revista PegarObjeto()
        {
            telaCaixa.VisualizarRegistros(TipoVisualizacao.Pesquisando);

            Console.Write("\nDigite o número da caixa: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorCaixa.ExisteRegistroComEsteId(idCaixa);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem("Nenhuma revista foi encontrada com este número: " 
                    + idCaixa, TipoMensagem.Erro);

                ConfigurarTela("Inserindo uma revista...");

                return PegarObjeto();
            }

            Caixa caixa = controladorCaixa.SelecionarRegistroPorId(idCaixa);

            Console.Write("Digite a nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write("Digite o número de edição da revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            return new Revista(nome, colecao, numeroEdicao, caixa);
        }

    }
}
