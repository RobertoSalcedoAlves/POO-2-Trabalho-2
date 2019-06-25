using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using static POO2.Trabalho2.Util.FormataConsole;
using POO2.Trabalho2.Util;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ArquivoBase<TTipo> : ObjetoBase<TTipo>
        where TTipo : class
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
        public override Cor Cor { get { return Cor.Az; } set { } }
        public override void Adicionar(IObjeto objeto) => Negado();
        public void Remover(IObjeto o) => Negado();
        private void Negado() => Console.WriteLine("Não permitido");
        public override string ToString() => string.Format($"{new String(' ', this.Nivel)}{this.Nome} [{this.Bytes.ToString()} bytes]");
        public override bool EstruturaFilhos() => false;

        public override void SubMenu()
        {
            do
            {
                Titulo2("OPÇÕES DE ARQUIVOS");

                Escolher();
                if (Opcao1) { }
                if (Opcao2) { }
                if (Opcao3) { }
                if (Opcao4) { }


                Linha('=');
                
                Linha('=');
                Numeracao(new List<string> { "Novo", "Localizar", "Excluir" }, Dir.H);
                Linha('-');
                Imprimir(Justificado(new List<string> { " ESC: sair", "ENTER:  acessar item", "SETA ESQUERDA: menu anterior" }));
                Imprimir(Centralizado("Use as setas Up e Down para navegar pelos itens"));
                Linha('-');

                //if (Objeto.Itens.First != null) { MostrarConteudo(); }
                //else { Imprimir(Objeto.ToString()); }

                //RenderizarCarrinho(acao.Key, navegou, removeu);
                Console.WriteLine("Escolha uma ação");
                Acao = Console.ReadKey(false);
            }
            while (Acao.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }

    }
}
