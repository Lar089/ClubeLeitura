﻿namespace ClubeLeitura.ConsoleApp.Telas
{
    public interface ICadastravel
    {
        void InserirNovoRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        bool VisualizarRegistros(TipoVisualizacao tipo);

        string ObterOpcao();
    }
}
