using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public abstract class TelaCadastro<T> : TelaBase, ICadastravel where T : EntidadeBase
    {
        private readonly Controlador<T> controlador;
        private readonly string tipoEntidade;

        public TelaCadastro(Controlador<T> controlador, string tipoEntidade):base($"Cadastro de {tipoEntidade}")
        {
            this.controlador = controlador;
            this.tipoEntidade = tipoEntidade;
        }

        protected abstract T PegarObjeto();
        
        public void InserirNovoRegistro()
        {
            ConfigurarTela($"Inserindo um novo {tipoEntidade}...");

            T objeto = PegarObjeto();

            string resultadoValidacao = controlador.InserirRegistro(objeto);

            if (resultadoValidacao == "ESTA_VALIDO")
                ApresentarMensagem($"{tipoEntidade} inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void EditarRegistro()
        {
            ConfigurarTela($"Editando um {tipoEntidade}...");

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write($"\nDigite o número do {tipoEntidade} que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controlador.ExisteRegistroComEsteId(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem($"Nenhum {tipoEntidade} foi encontrado com este número: " + id, TipoMensagem.Erro);
                EditarRegistro();
                return;
            }

            T objeto = PegarObjeto();

            string resultadoValidacao = controlador.EditarRegistro(id, objeto);

            if (resultadoValidacao == "ESTA_VALIDO")
                ApresentarMensagem($"{tipoEntidade} editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela($"Excluindo um {tipoEntidade}...");

            bool temRegistros = VisualizarRegistros(TipoVisualizacao.Pesquisando);

            if (temRegistros == false)
                return;

            Console.Write($"\nDigite o número do {tipoEntidade} que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controlador.ExisteRegistroComEsteId(id);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem($"Nenhum {tipoEntidade} foi encontrado com este número: " + id, TipoMensagem.Erro);
                ExcluirRegistro();
                return;
            }

            bool conseguiuExcluir = controlador.ExcluirRegistro(id);

            if (conseguiuExcluir)
                ApresentarMensagem($"{tipoEntidade} excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem($"Falha ao tentar excluir o {tipoEntidade}", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public abstract bool VisualizarRegistros(TipoVisualizacao tipo);
       
    }
}
