using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas
{
    public abstract class Iterator<TTipo> : IEnumerator
        where TTipo : class
    {
        public LinkedList<TTipo> itens = new LinkedList<TTipo>();
        private int indice { get; set; }
        public void Reset() => indice = 0;
        public object Current => PegaItem(indice);
        private bool EhUltimo() => indice == PegaNumeroItems() - 1 ? true : false;
        private bool EhPrimeiro() => indice == 0 ? true : false;

        public bool MoveNext()
        {
            if (!EhUltimo()) { indice++; return true; }
            return false;
        }
        public bool MoveBefore()
        {
            if (!EhPrimeiro()) { indice--; return true; }
            return false;
        }
        public int PegaNumeroItems()
        {
            return itens.Count;
        }
        public TTipo PegaItem(int index)
        {
            return itens.ElementAt(index);
        }
    }
}
