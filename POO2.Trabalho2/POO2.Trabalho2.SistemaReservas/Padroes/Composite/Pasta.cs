using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using static POO2.Trabalho2.Util.FormataConsole;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Pasta : PastaBase
    {
        public Pasta(string nome, LinkedList<object> itens) : base(nome, itens) { }

        public override void ImprimirNoh(object noh, object current)
        {
            if (noh.Equals(current)) { Selecionar(noh.ToString()); }
            else { Imprimir(noh.ToString(), Cor); }
        }
    }
}
