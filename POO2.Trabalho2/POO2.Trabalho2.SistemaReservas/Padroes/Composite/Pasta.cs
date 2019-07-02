using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using static POO2.Trabalho2.Util.FormataConsole;
using System.Collections.Generic;
using System;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Pasta : PastaBase
    {
        public Pasta(string nome, LinkedList<object> itens) : base(nome, itens) { }

        public override void ImprimirNoh(object noh, object current)
        {
            var obj = (IObjeto)noh;
            Cor = obj.Tipo == TipoObjeto.Arquivo ? Cor.Vd : Cor.Am;
            if (noh.Equals(current)) { Selecionar(noh.ToString()); }
            else { Imprimir(noh.ToString(), Cor); }
        }
    }
}
