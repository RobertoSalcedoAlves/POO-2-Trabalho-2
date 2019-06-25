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
        public string Conteudo { get; set; }
        public override int Bytes { get; }
        public override TipoObjeto Tipo { get { return TipoObjeto.Arquivo; } }
        public override IObjeto<TTipo> Pai { get; set; }
        public override Cor Cor { get { return Cor.Az; } set { } }
        public override Menu<TTipo> Menu { get { return new Menu<TTipo>(this,"Arquivo"); } set { } }
        public ArquivoBase(string nome, string conteudo = "")
        {
            Nivel = 3;
            Nome = nome;
            Bytes = System.Text.ASCIIEncoding.ASCII.GetByteCount(conteudo);
            Conteudo = conteudo;
            Itens.AddLast(this);
        }
        public override void Adicionar(IObjeto<TTipo> objeto) =>  Negado();
        public void Remover(IObjeto<TTipo> o) => Negado();
        private void Negado() => Console.WriteLine("Não permitido");
        public override string ToString() => string.Format($"{new String(' ', this.Nivel)}{this.Nome} [{this.Bytes.ToString()} bytes]");
        public override bool EstruturaFilhos() => false;
    }
}
