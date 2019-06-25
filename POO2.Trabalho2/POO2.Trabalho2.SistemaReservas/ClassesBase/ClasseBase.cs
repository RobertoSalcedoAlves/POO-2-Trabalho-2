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
        public void Excluir(TTipo tipo) => Lista.Remove(tipo);
        public void ExcluirPorID(TChave id) => Lista.Remove(SelecionarPorId(id));
        public void SalvarAtualizar(TTipo tipo) => Lista.Add(tipo);
        public IEnumerable<TTipo> SelecionarTodos() => Lista.ToList();
        public abstract TTipo SelecionarPorId(TChave id);

        public override string ToString() => Descricao;
        public abstract override bool Equals(object obj);
        public override void Escolher()
        {
            Console.Clear();
            MenuHelper.MenuRaiz();
            Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = false;
            Navegou = Acao.Key == ConsoleKey.UpArrow || Acao.Key == ConsoleKey.DownArrow ? true : false;
            Abriu = Acao.Key == ConsoleKey.Enter ? true : false;
            Removeu = Acao.Key == ConsoleKey.Delete ? true : false;
            Voltou = Acao.Key == ConsoleKey.LeftArrow ? true : false;
            Saiu = Acao.Key == ConsoleKey.Escape ? true : false;
            Opcao1 = Acao.Key == ConsoleKey.D1 ? true : false;
            Opcao2 = Acao.Key == ConsoleKey.D2 ? true : false;
            Opcao3 = Acao.Key == ConsoleKey.D3 ? true : false;
            Opcao4 = Acao.Key == ConsoleKey.D4 ? true : false;
        }
    }
}
