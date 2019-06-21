﻿using POO2.Trabalho2.SistemaReservas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas
{
    class Program
    {
        private static List<Sala> Salas = new List<Sala>();
        private static List<Funcao> Funcoes = new List<Funcao>();
        private static List<Funcionario> Funcionarios = new List<Funcionario>();
        private static List<Reserva> Reservas = new List<Reserva>();

        static void Main(string[] args)
        {
            CriarDadosParaTeste();



        }

        static void CriarDadosParaTeste()
        {
            CriarSalas();
            CriarFuncoes();
            CriarFuncionarios();
            CriarReservas();
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
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Professor Pardal", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Capitão Boing", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Uguinho", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Zézinho", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Luizinho", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Maga Patalógica", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Pato Donald", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Margarida", "teste@teste.com", 77));
            Funcionarios.Add(new Funcionario(Funcoes.ElementAt(0), "Roberto", "teste@teste.com", 77));
        }
        private static void CriarReservas()
        {
            int i = 0;
            foreach(var funcionario in Funcionarios)
            {
                Reservas.Add(new Reserva(
                    funcionario, 
                    Salas.ElementAt(i), 
                    new DateTime(2020, i + 1, i + 1), 
                    new TimeSpan(8, 0, 0), 
                    new TimeSpan(i + 1, 0, 0)));
                    i++;
            }            
        }
    }
}
