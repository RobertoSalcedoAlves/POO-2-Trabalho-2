using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
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

        #region IMenu
        public ConsoleKeyInfo Acao { get; set; }
        public bool Navegou { get; set; }
        public bool Abriu { get; set; }
        public bool Voltou { get; set; }
        public bool Removeu { get; set; }
        public bool Saiu { get; set; }
        public bool Opcao1 { get; set; }
        public bool Opcao2 { get; set; }
        public bool Opcao3 { get; set; }
        public bool Opcao4 { get; set; }
        public abstract void SubMenu();
        public abstract void Escolher();
        #endregion
    }
}
