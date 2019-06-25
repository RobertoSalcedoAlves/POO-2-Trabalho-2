using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ClasseBase<TTipo, TChave> : Iterator<TTipo>, ICRUD<TTipo, TChave>
        where TTipo : class
    {
        public int Id { get; set; }
        public abstract string Descricao { get;}
        public static List<TTipo> Lista { get; set; } = new List<TTipo>();        
        protected abstract int ProximoId { get; }        
        public ClasseBase() { Id = ProximoId; Itens.AddLast(this); }
        public abstract Menu<TTipo> Menu { get; set; }

        public void Excluir(TTipo tipo) => Lista.Remove(tipo);
        public void ExcluirPorID(TChave id) => Lista.Remove(SelecionarPorId(id));
        public void SalvarAtualizar(TTipo tipo) => Lista.Add(tipo);
        public IEnumerable<TTipo> SelecionarTodos() => Lista.ToList();
        public abstract TTipo SelecionarPorId(TChave id);

        public override string ToString() => Descricao;
        public abstract override bool Equals(object obj);
    }
}
