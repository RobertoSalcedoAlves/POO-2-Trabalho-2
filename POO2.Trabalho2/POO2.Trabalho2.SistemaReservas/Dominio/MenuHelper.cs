using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections.Generic;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.Util
{
    public static class MenuHelper
    {
        static ConsoleKeyInfo Acao { get; set; }
        static bool Navegou, Abriu, Voltou, Removeu, Saiu, Opcao1, Opcao2, Opcao3, Opcao4;

        public static void Rodar()
        {
            do
            {
                Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = false;
                Console.Clear();
                MenuRaiz();
                Navegou = Acao.Key == ConsoleKey.UpArrow || Acao.Key == ConsoleKey.DownArrow ? true : false;
                Abriu = Acao.Key == ConsoleKey.Enter ? true : false;
                Removeu = Acao.Key == ConsoleKey.Delete ? true : false;
                Voltou = Acao.Key == ConsoleKey.LeftArrow ? true : false;
                Saiu = Acao.Key == ConsoleKey.Escape ? true : false;
                Opcao1 = Acao.Key == ConsoleKey.D1 ? true : false;
                Opcao2 = Acao.Key == ConsoleKey.D2 ? true : false;
                Opcao3 = Acao.Key == ConsoleKey.D3 ? true : false;
                Opcao4 = Acao.Key == ConsoleKey.D4 ? true : false;

                if (Opcao1) { }
                //RenderizarCarrinho(acao.Key, navegou, removeu);
                Console.WriteLine("Escolha uma ação");
                Acao = Console.ReadKey(false);
            }
            while (Acao.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }

        public static void MenuRaiz()
        {
            Linha('=');
            Titulo1("SISTEMA DE RESERVA DE SALAS");
            Linha('=');
            Numeracao(new List<string> { "Reservas", "Funcionários", "Relatórios" }, Dir.H);
            Linha('-');
            Imprimir(Justificado(new List<string> { " ESC: sair", "ENTER:  acessar item", "SETA ESQUERDA: menu anterior" }));
            Imprimir(Centralizado("Use as setas Up e Down para navegar pelos itens"));
            Linha('-');
        }
        public static void SubMenu(IIterator<IMenu> objeto)
        {
            do
            {
                Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = false;
                Console.Clear();
                Navegou = Acao.Key == ConsoleKey.UpArrow || Acao.Key == ConsoleKey.DownArrow ? true : false;
                Abriu = Acao.Key == ConsoleKey.Enter ? true : false;
                Removeu = Acao.Key == ConsoleKey.Delete ? true : false;
                Voltou = Acao.Key == ConsoleKey.LeftArrow ? true : false;

                objeto.SubMenu();
                //objeto;
                //Imprimir(Centralizado(objeto.));
                Linha('.');
                if (Navegou) { Navegar(objeto); }
                if (Abriu)
                {
                    if (objeto.Itens.First != null) { MostrarConteudo(objeto); }
                    else { Imprimir(objeto.ToString()); }
                    Linha('.');
                }
                if (Removeu) { Remover(objeto); }
                if (Voltou) { break; }

                Console.WriteLine("Escolha uma ação");
                Acao = Console.ReadKey(false);
            }
            while (Acao.Key != ConsoleKey.Escape);
        }
        public static void Arvore()
        {
            do
            {
                Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = false;
                Console.Clear();
                Navegou = Acao.Key == ConsoleKey.UpArrow || Acao.Key == ConsoleKey.DownArrow ? true : false;
                Abriu = Acao.Key == ConsoleKey.Enter ? true : false;
                Removeu = Acao.Key == ConsoleKey.Delete ? true : false;
                Saiu = Acao.Key == ConsoleKey.Escape ? true : false;

                if (Navegou) { }
                //RenderizarCarrinho(acao.Key, navegou, removeu);
                Console.WriteLine("Escolha uma ação");
                Acao = Console.ReadKey(false);
            }
            while (Acao.Key != ConsoleKey.Escape);
        }

        public static void Navegar(IIterator<IMenu> objeto)
        {
            if (Acao.Equals(ConsoleKey.UpArrow))
                objeto.MoveBefore();
            else if (Acao.Equals(ConsoleKey.DownArrow))
                objeto.MoveNext();
        }
        public static void Abrir<TTipo>(TTipo objeto) => ((TTipo)objeto).ToString();
        public static void Remover(IIterator<IMenu> objeto) => objeto.RemoveItem(objeto.Current);
        public static void MostrarConteudo(IIterator<IMenu> objeto)
        {
            foreach (var item in objeto.Itens)
            {
                if (item.Equals(objeto.Current)) { Selecionar(item.ToString()); }
                else { Console.WriteLine(item); }
            }
        }
    }
}
