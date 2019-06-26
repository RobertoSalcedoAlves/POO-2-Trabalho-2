using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using static POO2.Trabalho2.Util.FormataConsole;
using POO2.Trabalho2.Util;
using System.Collections.Generic;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ArquivoBase : ObjetoBase
    {
        public ArquivoBase(string nome, string conteudo = "")
        {
            Nivel = 3;
            Nome = nome;
            Bytes = System.Text.ASCIIEncoding.ASCII.GetByteCount(conteudo);
            Conteudo = conteudo;
            Itens.AddLast(this);
        }
        public string Conteudo { get; set; }
        public override int Bytes { get; }
        public override TipoObjeto Tipo { get { return TipoObjeto.Arquivo; } }
        public override IObjeto Pai { get; set; }
        public override Cor Cor { get { return Cor.Vd; } set { } }
        public override void Adicionar(IObjeto objeto) => Negado();
        public void Remover(IObjeto o) => Negado();
        private void Negado() => Console.WriteLine("Não permitido");
        public override string ToString() => string.Format($"{new String(' ', this.Nivel)}{this.Nome} [{this.Bytes.ToString()} bytes]");
        public override bool EstruturaFilhos() => false;

        public override void SubMenu()
        {
            do
            {
                Console.Clear();
                Titulo2("OPÇÕES DE ARQUIVOS");
                Linha('-');
                Numeracao(new List<string> { "Acessar", "Excluir", "Localizar Por Nome", "Localizar Por Caminho"}, Dir.H);
                Instrucao("Use as setas Up e Down para navegar pelos itens");
                Linha('-');
                Escolher();
                if (Opcao1) { MenuHelper.Abrir(Current); }
                if (Opcao2) { MenuHelper.Remover(this); } //((Pasta)Pai).RemoveItem(this); }
                if (Opcao3) { Imprimir("Digite o nome do arquivo: ", Cor.Am); ((Pasta)Pai).LocalizarArquivoPorNome(MenuHelper.PastaRaiz, Console.ReadLine()); }
                if (Opcao4) { Imprimir("Digite o caminho do arquivo: ", Cor.Am); ((Pasta)Pai).LocalizarArquivoPorCaminho(MenuHelper.PastaRaiz, Console.ReadLine()); }
                if (Navegou) { Navegar(Acao, this); }
                foreach(var item in Itens) { if (item.Equals(Current)) { Selecionar(item.ToString()); } Imprimir(item.ToString()); }
                Acao = Console.ReadKey(false);
            }
            while (! Saiu);
            Console.ReadKey();
        }

    }
}
