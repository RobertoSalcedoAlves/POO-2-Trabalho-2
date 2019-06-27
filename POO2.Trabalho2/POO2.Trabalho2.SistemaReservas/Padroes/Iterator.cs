using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas
{
    public abstract class Iterator<TTipo> : IIterator
        where TTipo : class
    {
        //public Iterator(Funcionario funcionario, Sala sala, DateTime data, Horario horario) { }
        //public Iterator(Funcao funcao, string nome, string email, int ramal) {}
        //public Iterator(string nome, string conteudo) { }
        //public Iterator(string nome) { }
        //public Iterator(TimeSpan horaInicio, TimeSpan horaFim) { }
        //public Iterator(string nome, int numeroLugares) { }
        //public Iterator(DateTime data, Sala sala) { }
        //public Iterator(DateTime data) { }
        //public Iterator(Sala sala) { }
        public Iterator() { }
        public static LinkedList<TTipo> Itens { get; set; } = new LinkedList<TTipo>();
        public int indice { get; set; }
        public void Reset() => indice = 0;
        public object Current { get { return PegaItem(indice); } set { } }
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
        public void AdicionaItem(TTipo item) => Itens.AddLast(item);
        public void RemoveItem(TTipo item) => Itens.Remove(item);

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
        public bool Opcao5 { get; set; }
        public bool Opcao6 { get; set; }
        public abstract void SubMenu();
        public void Escolher()
        {
            Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = false;
            Navegou = Acao.Key == ConsoleKey.UpArrow || Acao.Key == ConsoleKey.DownArrow ? true : false;
            Abriu = Acao.Key == ConsoleKey.Enter ? true : false;
            Removeu = Acao.Key == ConsoleKey.Delete ? true : false;
            Voltou = Acao.Key == ConsoleKey.LeftArrow ? true : false;
            Saiu = Acao.Key == ConsoleKey.Escape ? true : false;
            Opcao1 = Acao.Key == ConsoleKey.NumPad1 ? true : false;
            Opcao2 = Acao.Key == ConsoleKey.NumPad2 ? true : false;
            Opcao3 = Acao.Key == ConsoleKey.NumPad3 ? true : false;
            Opcao4 = Acao.Key == ConsoleKey.NumPad4 ? true : false;
            Opcao5 = Acao.Key == ConsoleKey.NumPad5 ? true : false;
            Opcao6 = Acao.Key == ConsoleKey.NumPad6 ? true : false;
        }
        public void Navegar(ConsoleKeyInfo acao, Iterator<IObjeto> item)
        {
            if (acao.Key == ConsoleKey.UpArrow)
                item.MoveBefore();
            else if (acao.Key == ConsoleKey.DownArrow)
                item.MoveNext();
        }
        #endregion
    }
}
