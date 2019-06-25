using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ObjetoBase<TTipo> : Iterator<TTipo>, IObjeto
        where TTipo : class
    {
        public string Nome { get; set; }
        public int Nivel { get; set; } = 0;
        public abstract int Bytes { get; }
        public abstract IObjeto Pai { get; set; }
        public abstract FormataConsole.Cor Cor { get; set; }
        public Arquivo ConverterEmArquivo(IObjeto objeto) => (Arquivo)objeto;
        public Pasta ConverterEmPasta(IObjeto objeto) => (Pasta)objeto;
        public string PathVirtual {
            get {
                return Tipo == TipoObjeto.Pasta ? string.Format($@"{Nome}\") : Nome;
            }
            set { }
        }
        public abstract TipoObjeto Tipo { get; }
        public abstract void Adicionar(IObjeto objeto);
        public abstract override string ToString();
        public abstract bool EstruturaFilhos();
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
