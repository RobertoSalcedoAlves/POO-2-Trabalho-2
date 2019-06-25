using POO2.Trabalho2.SistemaReservas.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas
{
    public abstract class Iterator<TTipo> : IIterator<TTipo>
        where TTipo : class
    {
        public LinkedList<object> Itens { get; set; } = new LinkedList<object>();
        public int indice { get; set; }
        public void Reset() => indice = 0;
        object IIterator<TTipo>.Current { get { return PegaItem(indice); } set {} }
        public bool EhUltimo() => indice == PegaNumeroItems() - 1 ? true : false;
        public bool EhPrimeiro() => indice == 0 ? true : false;
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
            return Itens.Count;
        }
        public object PegaItem(int index)
        {
            return Itens.ElementAt(index);
        }
        public void Dispose() => this.Dispose();
        public void AdicionaItem(object item) => Itens.AddLast(item);
        public void RemoveItem(object item) => Itens.Remove(item);
    }
}
