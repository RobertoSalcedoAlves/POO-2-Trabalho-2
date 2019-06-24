using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using static POO2.Trabalho2.Util.FormataConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;

namespace POO2.Trabalho2.SistemaReservas
{
    class Program
    {
        private static List<Sala> Salas = new List<Sala>();
        private static List<Horario> Horarios = new List<Horario>();
        private static List<Funcao> Funcoes = new List<Funcao>();
        private static List<Funcionario> Funcionarios = new List<Funcionario>();
        private static List<Reserva> Reservas = new List<Reserva>();
        private static FactoryLog factoryRelatorio = new FactoryLog();
        private Pasta PastaRaiz = new Pasta("Raiz");

        static void Main(string[] args)
        {
            MenuSuerior();
            //CriarDadosParaTeste();

            //ConsoleKeyInfo acao = new ConsoleKeyInfo();
            //bool navegou, removeu;
            //do
            //{
            //    Console.Clear();
            //    navegou = acao.Key == ConsoleKey.UpArrow || acao.Key == ConsoleKey.DownArrow ? true : false;
            //    removeu = acao.Key == ConsoleKey.R ? true : false;
            //    MenuSuerior();
            //    //RenderizarCarrinho(acao.Key, navegou, removeu);
            //    Console.WriteLine("Escolha uma ação");
            //    acao = Console.ReadKey(false);
            //}
            //while (acao.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }

        private static void MenuSuerior()
        {
            Linha('=');
            Destaque(Centralizado("SISTEMA DE RESERVA DE SALAS"));
            Linha('=');
            Imprimir(Justificado(new List<string> {" ESC: sair", "ENTER:  acessar item", "SETA ESQUERDA: menu anterior" }));
            Imprimir(Centralizado("Use as setas Up e Down para navegar pelos itens"));
            Linha('-');
            Selecionar("Selecionado");
            Aviso("Aviso");
            Numeracao(new List<string> { "Roberto", "Débora", "Mellyssa", "Thomas" }, Dir.H);
            Console.WriteLine();
            CriarPastasEArquivos();
            //PastaRaiz.Estruturar();

        }

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
            Pasta pasta = new Pasta("Primeira nível 1");
            Pasta p2 = new Pasta("Pasta2");
            p2.Adicionar(new Arquivo("Arquivo teste", "Conteúdo de testes"));

            pasta.Adicionar(p2);
            pasta.Estruturar();
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
    }
}
