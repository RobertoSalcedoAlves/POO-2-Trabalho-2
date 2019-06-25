using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections.Generic;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.Util
{
    public class Menu<TTipo> where TTipo : class
    {
        static IIterator<TTipo> Objeto { get; set; }
        public static string Titulo { get; set; }
        public static ConsoleKeyInfo acao = new ConsoleKeyInfo();
        public IEnumerable<string> Opcoes { get; set; }

        public static bool navegou, abriu, voltou, removeu, saiu, op1, op2, op3, op4;
        //public static Menu<TTipo> RaizMenu = new Menu<TTipo>("MenuRaiz", new List<string> { " ESC: sair", "Pressione o número que corresponde a opção desejada:  escolher" });
        public Menu(IIterator<TTipo> objeto, string titulo, IEnumerable<string> opcoes = null)
        {
            Objeto = objeto;
            Titulo = titulo;
            Opcoes = Opcoes ?? new List<string> { "Selecionar", "Excluir" };
        }

        public static void Rodar()
        {
            do
            {
                Console.Clear();
                MenuRaiz();
                navegou = acao.Key == ConsoleKey.UpArrow || acao.Key == ConsoleKey.DownArrow ? true : false;
                abriu = acao.Key == ConsoleKey.Enter ? true : false;
                removeu = acao.Key == ConsoleKey.Delete ? true : false;
                voltou = acao.Key == ConsoleKey.LeftArrow ? true : false;
                saiu = acao.Key == ConsoleKey.Escape ? true : false;
                op1 = acao.Key == ConsoleKey.D1 ? true : false;
                op2 = acao.Key == ConsoleKey.D2 ? true : false;
                op3 = acao.Key == ConsoleKey.D3 ? true : false;
                op4 = acao.Key == ConsoleKey.D4 ? true : false;

                if (navegou) { }
                //RenderizarCarrinho(acao.Key, navegou, removeu);
                Console.WriteLine("Escolha uma ação");
                acao = Console.ReadKey(false);
            }
            while (acao.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
        
        private static void MenuRaiz()
        {
            Linha('=');
            Destaque(Centralizado("SISTEMA DE RESERVA DE SALAS"));
            Linha('=');
            Imprimir(Justificado(new List<string> { " ESC: sair", "ENTER:  acessar item", "SETA ESQUERDA: menu anterior" }));
            Imprimir(Centralizado("Use as setas Up e Down para navegar pelos itens"));
            Linha('-');
        }
        private static void SubMenu()
        {
            do
            {
                Console.Clear();
                navegou = acao.Key == ConsoleKey.UpArrow || acao.Key == ConsoleKey.DownArrow ? true : false;
                abriu = acao.Key == ConsoleKey.Enter ? true : false;
                removeu = acao.Key == ConsoleKey.Delete ? true : false;
                voltou = acao.Key == ConsoleKey.LeftArrow ? true : false;
                Imprimir(Centralizado(Titulo));
                Linha('.');
                if (navegou) { Navegar(); }
                if (abriu)
                {
                    if (Objeto.Itens.First != null) { MostrarConteudo(); }
                    else { Imprimir(Objeto.ToString()); }
                    Linha('.');
                }
                if (removeu) { Remover(); }
                if (voltou) { break; }

                Console.WriteLine("Escolha uma ação");
                acao = Console.ReadKey(false);
            }
            while (acao.Key != ConsoleKey.Escape);
        }
        private static void Arvore()
        {
            do
            {
                Console.Clear();
                navegou = acao.Key == ConsoleKey.UpArrow || acao.Key == ConsoleKey.DownArrow ? true : false;
                abriu = acao.Key == ConsoleKey.Enter ? true : false;
                removeu = acao.Key == ConsoleKey.Delete ? true : false;
                saiu = acao.Key == ConsoleKey.Escape ? true : false;
                
                if (navegou) { }
                //RenderizarCarrinho(acao.Key, navegou, removeu);
                Console.WriteLine("Escolha uma ação");
                acao = Console.ReadKey(false);
            }
            while (acao.Key != ConsoleKey.Escape);
        }        

        private static void Navegar()
        {
            if (acao.Equals(ConsoleKey.UpArrow))
                Objeto.MoveBefore();
            else if (acao.Equals(ConsoleKey.DownArrow))
                Objeto.MoveNext();
        }
        private static void Abriu() => ((TTipo)Objeto).ToString();
        private static void Remover() => Objeto.RemoveItem(Objeto.Current);
        private static void MostrarConteudo()
        {
            foreach (var item in Objeto.Itens)
            {
                if (item.Equals(Objeto.Current)) { Selecionar(item.ToString()); }
                else { Console.WriteLine(item); }
            }
        }
    }
}
