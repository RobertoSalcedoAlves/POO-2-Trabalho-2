﻿using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IObjeto
    {
        string Nome { get; set; }
        int Nivel { get; set; }
        int Bytes { get; }
        string PathVirtual { get; set; }
        TipoObjeto Tipo { get; }
        IObjeto Pai { get; set; }
        void Adicionar(IObjeto filho);
        bool EstruturaFilhos();
        Cor Cor { get; set; }
    }
    public enum TipoObjeto { Arquivo, Pasta }
}
