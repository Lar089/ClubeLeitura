using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Controladores
{
    public class Controlador<T> where T : EntidadeBase
    {
        protected List<T> registros;

        private int ultimoId;

        public Controlador()
        {
            registros = new List<T>();
        }

        public string InserirRegistro(T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.id = NovoId();
                registros.Add(registro);
            }
            return resultadoValidacao;
        }

        public string EditarRegistro(int id, T item)
        {
            string resultadoValidacao = item.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                for (int i = 0; i < registros.Count; i++)
                {
                 if(registros[i].id == id)
                    registros[i] = item;
                    break;
                }

            }
            return resultadoValidacao;
        }
        public bool ExcluirRegistro(int id)
        {
           return registros.Remove(SelecionarRegistroPorId(id));
        }

        public List<T> SelecionarTodosRegistros()
        {
            return registros;
        }


        public T SelecionarRegistroPorId(int id)
        {
            return registros.Find(x => x.id == id);
        }

        internal bool ExisteRegistroComEsteId(int id)
        {
            return SelecionarRegistroPorId(id) != null;
        }

        protected int ObterPosicaoOcupada(int id)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i] != default(T) && registros[i].id == id)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        protected int NovoId()
        {
            return ++ultimoId;
        }
    }
}