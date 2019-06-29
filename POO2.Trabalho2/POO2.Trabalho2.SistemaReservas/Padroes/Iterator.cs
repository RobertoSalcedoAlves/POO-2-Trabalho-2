using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas
{
    public abstract class Iterator : IIterator
    {
        public Iterator(LinkedList<object> itens) { Itens = itens; }
        public LinkedList<object> Itens { get; set; } = new LinkedList<object>();
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
        public void AdicionaItem(object item) => Itens.AddLast(item);
        public void RemoveItem(object item) => Itens.Remove(item);
        public void DefinirNovoCurrent(IObjeto noh)
        {
            int novoIndice = 0;
            foreach (var item in Itens) { if (item == noh) { indice = novoIndice; break; }; novoIndice++; }
        }
        public abstract void RemoverNoh();
        public abstract void ImprimirNoh(object noh, object current);

        #region IMenu
        public ConsoleKeyInfo Acao { get; set; }
        public bool Navegou { get; set; }
        public bool Abriu { get; set; }
        public bool Voltou { get; set; }
        public bool Removeu { get; set; }
        public bool Saiu { get; set; }
        public bool Ler { get; set; }
        public bool Opcao1 { get; set; }
        public bool Opcao2 { get; set; }
        public bool Opcao3 { get; set; }
        public bool Opcao4 { get; set; }
        public bool Opcao5 { get; set; }
        public bool Opcao6 { get; set; }
        public abstract Cor Cor { get; set; }
        public abstract void SubMenu();
        public void Escolher(bool ler = true)
        {
            Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = Opcao5 = Opcao6 = false;
            if (Ler)
            {
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
            Ler = !Ler;
        }
        public void Navegar(ConsoleKeyInfo acao, object current)
        {
            Current = current;
            if (acao.Key == ConsoleKey.UpArrow)
                MoveBefore();
            else if (acao.Key == ConsoleKey.DownArrow)
                MoveNext();
        }
        public abstract void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando);
        public abstract void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando);
        public abstract void TopoMenu(string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando);
        public abstract void Resultado(bool acao, string sucesso = "Operação realizada com sucesso!", string inSucesso = "Operação não realizada!");
        #endregion
    }
}
