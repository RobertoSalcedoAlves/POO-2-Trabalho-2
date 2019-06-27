using POO2.Trabalho2.SistemaReservas.Dominio;
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
    public abstract class ClasseBase<TTipo, TChave> : Iterator<ICRUD<TTipo, TChave>>
        where TTipo : class
    {
        //public ClasseBase(Funcao funcao, string nome, string email, int ramal, LinkedList<IObjeto> _itens) : base(funcao, nome, email, ramal, _itens) { }
        //public ClasseBase(string nome, string conteudo, LinkedList<IObjeto> _itens) : base(nome, conteudo, _itens) { }
        //public ClasseBase(string nome, LinkedList<IObjeto> _itens) : base(nome, _itens) { }
        //public ClasseBase(TimeSpan horaInicio, TimeSpan horaFim, LinkedList<IObjeto> _itens) : base(horaInicio, horaFim, _itens) { }
        //public ClasseBase(DateTime data, Sala sala, LinkedList<IObjeto> _itens) : base(data, sala, _itens) { }
        //public ClasseBase(DateTime data, LinkedList<IObjeto> _itens) : base(data, _itens) { }
        //public ClasseBase(Sala sala, LinkedList<IObjeto> _itens) : base(sala, _itens) { }
        //public ClasseBase(LinkedList<IObjeto> _itens) : base(_itens) { }
        //public ClasseBase(Funcionario funcionario, Sala sala, DateTime data, Horario horario, LinkedList<IObjeto> _itens) : base(funcionario, sala, data, horario, _itens) { }
        //public ClasseBase(string nome, int numeroLugares, LinkedList<IObjeto> _itens) : base(nome, numeroLugares, _itens) { }

        public int Id { get; set; }
        public abstract string Descricao { get; }
        public static List<TTipo> Lista { get; set; } = new List<TTipo>();
        protected int ProximoId { get => PegaNumeroItems() + 1; }
        public void Excluir(TTipo tipo) => Lista.Remove(tipo);
        public void ExcluirPorID(TChave id) => Lista.Remove(SelecionarPorId(id));
        public void SalvarAtualizar(TTipo tipo) => Lista.Add(tipo);
        public IEnumerable<TTipo> SelecionarTodos() => Lista.ToList();
        public abstract TTipo SelecionarPorId(TChave id);
        public override string ToString() => Descricao;
        public abstract override bool Equals(object obj);
    }
}
