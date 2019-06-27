using POO2.Trabalho2.SistemaReservas;
using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.Util
{
    public static class MenuHelper
    {

        private static List<Sala> Salas = new List<Sala>();
        private static List<Horario> Horarios = new List<Horario>();
        private static List<Funcao> Funcoes = new List<Funcao>();
        private static List<Funcionario> Funcionarios = new List<Funcionario>();
        private static List<Reserva> Reservas = new List<Reserva>();
        private static FactoryLog factoryRelatorio = new FactoryLog();
        public static Pasta Raiz = new Pasta("Raiz");

        static ConsoleKeyInfo Acao { get; set; }
        static bool Navegou, Abriu, Voltou, Removeu, Saiu, Opcao1, Opcao2, Opcao3, Opcao4;

        #region Dados de Teste
        static void CriarDadosParaTeste()
        {
            CriarSalas();
            CriarHorarios();
            CriarFuncoes();
            CriarFuncionarios();
            CriarReservas();
            CriarPastasEArquivos();
        }
        private static void CriarPastasEArquivos()
        {
            Raiz.Pai = Raiz;
            Pasta p1 = new Pasta("Primeira Pasta");
            Pasta p2 = new Pasta("Segunda Pasta");
            Pasta p3 = new Pasta("Terceira Pasta");

            Raiz.Adicionar(p1);
            p1.Adicionar(p2);
            p2.Adicionar(p3);
            p2.Adicionar(new Pasta("Quarta Pasta"));
            p3.Adicionar(new Arquivo("Primeiro Arquivo", "Conteúdo de testes"));
            p3.Adicionar(new Arquivo("Segundo Arquivo", "Conteúdo de testes adfasdfasdf"));

        }
        private static void CriarSalas()
        {
            Salas.Add(new Sala("101", 30));
            Salas.Add(new Sala("102", 40));
            Salas.Add(new Sala("103", 50));
            Salas.Add(new Sala("104", 60));
            Salas.Add(new Sala("105", 70));
            Salas.Add(new Sala("106", 80));
            Salas.Add(new Sala("107", 90));
            Salas.Add(new Sala("108", 100));
            Salas.Add(new Sala("109", 10));
            Salas.Add(new Sala("110", 20));
        }
        private static void CriarHorarios()
        {
            for (int i = 8; i <= 17; i++)
            {
                Horarios.Add(new Horario(new TimeSpan(i, 0, 0), new TimeSpan(i + 1, 0, 0)));
            }
        }
        private static void CriarFuncoes()
        {
            Funcoes.Add(new Funcao("CEO"));
            Funcoes.Add(new Funcao("Diretor Comercial"));
            Funcoes.Add(new Funcao("Gerente Marketing"));
            Funcoes.Add(new Funcao("Gerente De Projetos"));
            Funcoes.Add(new Funcao("Analista de Negócios"));
            Funcoes.Add(new Funcao("Analista de Sistemas"));
            Funcoes.Add(new Funcao("Arquiteto de Software"));
            Funcoes.Add(new Funcao("Engenheiro de Computação"));
            Funcoes.Add(new Funcao("Desenvolvedor"));
            Funcoes.Add(new Funcao("Recursos Humanos"));
        }
        private static void CriarFuncionarios()
        {
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Tio Patinhas", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Professor Pardal", "teste@teste.com", 87));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Capitão Boing", "teste@teste.com", 97));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Uguinho", "teste@teste.com", 67));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Zézinho", "teste@teste.com", 57));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Luizinho", "teste@teste.com", 47));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Maga Patalógica", "teste@teste.com", 37));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Pato Donald", "teste@teste.com", 27));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Margarida", "teste@teste.com", 17));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Roberto", "teste@teste.com", 107));
        }
        private static void CriarReservas()
        {
            int i = 0;
            foreach (var funcionario in Funcionarios)
            {
                Reservas.Add(new Reserva(
                    funcionario,
                    Salas[i],
                    new DateTime(2020, i + 1, i + 1),
                    Horarios[i]));
                i++;
            }
        }
        #endregion

        public static void Rodar()
        {
            CriarDadosParaTeste();
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
                Opcao1 = Acao.Key == ConsoleKey.NumPad1 ? true : false;
                Opcao2 = Acao.Key == ConsoleKey.NumPad2 ? true : false;
                Opcao3 = Acao.Key == ConsoleKey.NumPad3 ? true : false;
                Opcao4 = Acao.Key == ConsoleKey.NumPad4 ? true : false;

                if (Opcao3) { Raiz.SubMenu(); }
                Acao = Console.ReadKey(false);
            }
            while (Acao.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }

        public static void MenuRaiz()
        {
            Titulo1();
            Numeracao(new List<string> { "Reservas", "Relatórios", "Arquivos" }, Dir.H);
            Linha('-');
            Instrucao("Digite o número da opção desejada");
            Linha('-');
        }
        //public static void SubMenu(IIterator objeto)
        //{
        //    do
        //    {
        //        Navegou = Abriu = Voltou = Removeu = Saiu = Opcao1 = Opcao2 = Opcao3 = Opcao4 = false;
        //        Console.Clear();
        //        Navegou = Acao.Key == ConsoleKey.UpArrow || Acao.Key == ConsoleKey.DownArrow ? true : false;
        //        Abriu = Acao.Key == ConsoleKey.Enter ? true : false;
        //        Removeu = Acao.Key == ConsoleKey.Delete ? true : false;
        //        Voltou = Acao.Key == ConsoleKey.LeftArrow ? true : false;

        //        objeto.SubMenu();
        //        //objeto;
        //        //Imprimir(Centralizado(objeto.));
        //        Linha('.');
        //        if (Navegou) { Navegar(objeto); }
        //        if (Abriu)
        //        {
        //            if (objeto.Itens.First != null) { MostrarConteudo(objeto); }
        //            else { Imprimir(objeto.ToString()); }
        //            Linha('.');
        //        }
        //        if (Removeu) { RemoveItem(objeto); }
        //        if (Voltou) { break; }

        //        Console.WriteLine("Escolha uma ação");
        //        Acao = Console.ReadKey(false);
        //    }
        //    while (Acao.Key != ConsoleKey.Escape);
        //}
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
        public static void Navegar(IIterator objeto)
        {
            if (Acao.Equals(ConsoleKey.UpArrow))
                objeto.MoveBefore();
            else if (Acao.Equals(ConsoleKey.DownArrow))
                objeto.MoveNext();
        }
        public static void Abrir<TTipo>(TTipo objeto) {Campo("Conteúdo"); Mostrar(objeto.ToString());}
        //public static void Remover(IIterator objeto) => RemoveItem(objeto);
        //public static void MostrarConteudo(IIterator objeto)
        //{
        //    foreach (var item in Itens)
        //    {
        //        if (item.Equals(objeto.Current)) { Selecionar(item.ToString()); }
        //        else { Console.WriteLine(item); }
        //    }
        //}
    }
}
