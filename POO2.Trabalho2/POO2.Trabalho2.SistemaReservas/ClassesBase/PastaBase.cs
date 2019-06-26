﻿using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class PastaBase : ObjetoBase
    {
        public override int Bytes { get { return Conteudo.Sum(x => x.Bytes); } }
        public override TipoObjeto Tipo { get { return TipoObjeto.Pasta; } }
        public override IObjeto Pai { get; set; }
        public override Cor Cor { get { return Cor.Am; } set { } }
        public ICollection<IObjeto> Conteudo = new List<IObjeto>();
        public PastaBase(string nome) { Nome = nome; Nivel += 3; Itens.AddLast(this); }
        public override void Adicionar(IObjeto filho)
        {
            filho.Nivel = Nivel + 3;
            filho.Pai = this;
            filho.PathVirtual = this.Nome + "\\" + filho.PathVirtual;
            this.Conteudo.Add(filho);
        }
        public bool RemoverArquivoPorNome(Pasta pasta, string nomeArquivo)
        {
            foreach (var noh in pasta.Conteudo)
            {
                if (noh.Tipo == TipoObjeto.Arquivo && noh.Nome.ToUpper().Equals(nomeArquivo.ToUpper())) { ((Pasta)noh.Pai).Conteudo.Remove(noh); return true; }
                if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).RemoverArquivoPorNome((Pasta)noh, nomeArquivo); }
            }
            return false;
        }
        public bool RemoverArquivoPorCaminho(Pasta pasta, string pathVirtual)
        {
            foreach (var noh in pasta.Conteudo)
            {
                if (noh.Tipo == TipoObjeto.Arquivo && noh.PathVirtual.ToUpper().Replace('/', '\\').Equals(pathVirtual.ToUpper())) { ((Pasta)noh.Pai).Conteudo.Remove(noh); return true; }
                if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).RemoverArquivoPorCaminho((Pasta)noh, pathVirtual); }
            }
            return false;
        }
        public bool LocalizarArquivoPorNome(Pasta pasta, string nomeArquivo)
        {
            foreach (var noh in pasta.Conteudo)
            {
                if (noh.Tipo == TipoObjeto.Arquivo && noh.Nome.ToUpper().Equals(nomeArquivo.ToUpper())) { Campo("Conteúdo", Cor.Vd); AbrirArquivo(noh); return true; }
                if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).LocalizarArquivoPorNome((Pasta)noh, nomeArquivo); }
            }
            return false;
        }
        public bool LocalizarArquivoPorCaminho(Pasta pasta, string pathVirtual)
        {
            foreach (var noh in pasta.Conteudo)
            {
                if (noh.Tipo == TipoObjeto.Arquivo && noh.PathVirtual.Replace('/', '\\').Equals(pathVirtual)) { Current = noh; Estrutura(); }
                if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).LocalizarArquivoPorCaminho((Pasta)noh, pathVirtual); }
            }
            return false;
        }
        private void AbrirArquivo(IObjeto objeto) => Console.WriteLine(ConverterEmArquivo(objeto).Conteudo);
        public bool SelecionarPorPath(string pathVirtual)
        {
            IObjeto objeto = Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.PathVirtual.Replace('/', '\\').Equals(pathVirtual));
            if (objeto != null) { AbrirArquivo(objeto); return true; }
            InformarNaoLocalizado(); return false;
        }
        private void InformarNaoLocalizado() => Aviso("Arquivo não localizado");
        public override string ToString() => string.Format($"{ new String(' ', this.Nivel)}{this.Nome} [{Bytes.ToString()} bytes]");
        public bool Estrutura()
        {
            Imprimir(this.ToString(), this.Cor);
            try { this.EstruturaFilhos(); return true; }
            catch (Exception) { return false; }
        }
        public override bool EstruturaFilhos()
        {
            try
            {
                foreach (var noh in this.Conteudo)
                {
                    if (noh.Equals((Pasta)Current)) { Selecionar(noh.ToString()); }
                    else { Imprimir(noh.ToString(), noh.Cor); }
                    noh.EstruturaFilhos();
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public override void SubMenu()
        {
            string informado = string.Empty;
            do
            {
                Console.Clear();
                Titulo1();
                Titulo2("OPÇÕES DE ARQUIVOS");
                Linha('-');
                Numeracao(new List<string> { "Acessar", "Excluir", "Localizar: Nome", "Localizar: Caminho", "Explorar" }, Dir.H);
                Instrucao("Use as setas Up e Down para navegar pelos itens");
                Linha('-');
                Escolher();
                if (Opcao1) { MenuHelper.Abrir(Current); }
                if (Opcao2)
                {
                    if (!string.IsNullOrEmpty(informado))
                    { RemoverArquivoPorNome(MenuHelper.PastaRaiz, informado); }
                    else { Aviso("Selecione um arquivo primeiro!"); }
                }
                if (Opcao3)
                {
                    Campo("Digite o nome do arquivo"); informado = Console.ReadLine();
                    LocalizarArquivoPorNome(MenuHelper.PastaRaiz, informado);
                }
                if (Opcao4)
                {
                    Campo("Digite o caminho do arquivo"); informado = Console.ReadLine();
                    LocalizarArquivoPorCaminho(MenuHelper.PastaRaiz, informado);
                }
                if (Navegou) { Navegar(Acao, this); Estrutura(); }
                if (Opcao5) { Estrutura(); }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
            Console.ReadKey();
        }
    }
}
