using POO2.Trabalho2.SistemaReservas;
using POO2.Trabalho2.SistemaReservas.ClassesBase;
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
        public static LinkedList<object> Pastas = new LinkedList<object>();
        public static LinkedList<object> Reservas = new LinkedList<object>();
        public static LinkedList<object> Funcionarios = new LinkedList<object>();
        public static LinkedList<object> Funcoes = new LinkedList<object>();
        public static LinkedList<object> Horarios = new LinkedList<object>();
        public static LinkedList<object> Salas = new LinkedList<object>();
        public static LinkedList<object> Relatorios = new LinkedList<object>();
        public static RelatorioBase RelatoriosReservas = new RelatorioReservasArquivo(Relatorios);
        public static Pasta Raiz = new Pasta("Raiz", Pastas);
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
            Pasta p1 = new Pasta("Primeira Pasta", Pastas);
            Pasta p2 = new Pasta("Segunda Pasta", Pastas);
            Pasta p3 = new Pasta("Terceira Pasta", Pastas);

            Raiz.Adicionar(p1);
            p1.Adicionar(p2);
            p2.Adicionar(p3);
            p2.Adicionar(new Pasta("Quarta Pasta", Pastas));
            p3.Adicionar(new Arquivo("Primeiro Arquivo", "Conteúdo de testes", Pastas));
            p3.Adicionar(new Arquivo("Segundo Arquivo", "Conteúdo de testes adfasdfasdf", Pastas));
        }
        private static void CriarSalas()
        {
            Sala sala;
            sala = new Sala("101", 30, Salas);
            sala = new Sala("102", 40, Salas);
            sala = new Sala("103", 50, Salas);
            sala = new Sala("104", 60, Salas);
            sala = new Sala("105", 70, Salas);
            sala = new Sala("106", 80, Salas);
            sala = new Sala("107", 90, Salas);
            sala = new Sala("108", 100, Salas);
            sala = new Sala("109", 10, Salas);
            sala = new Sala("110", 20, Salas);
        }
        private static void CriarHorarios()
        {
            Horario horario;
            for (int i = 8; i <= 17; i++)
                horario = new Horario(new TimeSpan(i, 0, 0), new TimeSpan(i + 1, 0, 0), Horarios);
        }
        private static void CriarFuncoes()
        {
            Funcao funcao;
            funcao = new Funcao("CEO", Funcoes);
            funcao = new Funcao("Diretor Comercial", Funcoes);
            funcao = new Funcao("Gerente Marketing", Funcoes);
            funcao = new Funcao("Gerente De Projetos", Funcoes);
            funcao = new Funcao("Analista de Negócios", Funcoes);
            funcao = new Funcao("Analista de Sistemas", Funcoes);
            funcao = new Funcao("Arquiteto de Software", Funcoes);
            funcao = new Funcao("Engenheiro de Computação", Funcoes);
            funcao = new Funcao("Desenvolvedor", Funcoes);
            funcao = new Funcao("Recursos Humanos", Funcoes);
        }
        private static void CriarFuncionarios()
        {
            Funcionario fun;
            fun = new Funcionario((Funcao)Funcoes.ElementAt(0), "Tio Patinhas", "teste@teste.com", 77, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(1), "Professor Pardal", "teste@teste.com", 87, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(2), "Capitão Boing", "teste@teste.com", 97, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(3), "Uguinho", "teste@teste.com", 67, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(4), "Zézinho", "teste@teste.com", 57, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(5), "Luizinho", "teste@teste.com", 47, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(6), "Maga Patalógica", "teste@teste.com", 37, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(7), "Pato Donald", "teste@teste.com", 27, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(8), "Margarida", "teste@teste.com", 17, Funcionarios);
            fun = new Funcionario((Funcao)Funcoes.ElementAt(9), "Roberto", "teste@teste.com", 107, Funcionarios);
        }
        private static void CriarReservas()
        {
            Reserva reserva;
            int i = 0;
            foreach (var funcionario in Funcionarios)
            {
                reserva = new Reserva(
                    (Funcionario)funcionario,
                    (Sala)Salas.ElementAt(i),
                    new DateTime(2020, i + 1, i + 1),
                    (Horario)Horarios.ElementAt(i),
                    Reservas);
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

                if (Opcao1) { ((Reserva)(Reservas.ElementAt(0))).SubMenu(); }
                if (Opcao2) { ((RelatorioBase)(Relatorios.ElementAt(0))).SubMenu(); }
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
        public static void Abrir<TTipo>(TTipo objeto) { Campo("Conteúdo"); Mostrar(objeto.ToString()); }
    }
}
