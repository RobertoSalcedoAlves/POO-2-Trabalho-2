using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface ICRUD<TTipo, TChave> : IMenu
        where TTipo : class
    {
        void SalvarAtualizar(TTipo tipo);
        void Excluir(TTipo tipo);
        void ExcluirPorID(TChave id);
        IEnumerable<TTipo> SelecionarTodos();
        TTipo SelecionarPorId(TChave id);

    }
}
