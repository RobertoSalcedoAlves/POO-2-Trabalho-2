using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IIterator : IMenu, IDisposable, IEnumerator
    {
        int indice { get; set; }
        bool EhUltimo();
        bool EhPrimeiro();
        bool MoveBefore();
        int PegaNumeroItems();
        object PegaItem(int index);
        void DefinirNovoCurrent(IObjeto noh);
        void RemoverNoh();
        void ImprimirNoh(object noh, object current);
    }
}
