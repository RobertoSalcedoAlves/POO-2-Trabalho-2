using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas
{
    public abstract class ClasseBase<TTipo, TChave> : Iterator<TTipo>, ICRUD<TTipo, TChave>
        where TTipo : class
    {
        public int Id { get; set; }
        public List<TTipo> Lista { get; set; } = new List<TTipo>();
        private int ProximoId => Lista.Count() + 1;

        public ClasseBase() { Id = ProximoId; }

        public void Excluir(TTipo tipo) => Lista.Remove(tipo);
        public void ExcluirPorID(TChave id) => Lista.Remove(SelecionarPorId(id));
        public void SalvarAtualizar(TTipo tipo) => Lista.Add(tipo);
        public IEnumerable<TTipo> SelecionarTodos() => Lista.ToList();
        public abstract TTipo SelecionarPorId(TChave id);
    }
}
