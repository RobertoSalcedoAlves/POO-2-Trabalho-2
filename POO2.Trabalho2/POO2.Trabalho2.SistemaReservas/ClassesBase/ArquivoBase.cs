using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using static POO2.Trabalho2.Util.FormataConsole;
using POO2.Trabalho2.Util;
using System.Collections.Generic;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ArquivoBase : ObjetoBase
    {
        public ArquivoBase(string nome, string conteudo, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Nivel = 3;
            Nome = nome;
            Bytes = System.Text.ASCIIEncoding.ASCII.GetByteCount(conteudo);
            Conteudo = conteudo;
            itens.AddLast(this);
        }
        public string Conteudo { get; set; }
        public override int Bytes { get; }
        public override TipoObjeto Tipo { get { return TipoObjeto.Arquivo; } }
        public override object Pai { get; set; }
        public override Cor Cor { get { return Cor.Vd; } set { } }
        public override void Adicionar(object objeto) => Negado();
        public void Remover(IObjeto objeto) => Negado();
        private void Negado() => Console.WriteLine("Não permitido");
        public override string ToString() => string.Format($"{new String(' ', this.Nivel)}{this.Nome} [{this.Bytes.ToString()} bytes]");
        public override void SubMenu() { throw new NotImplementedException(); }
        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void Resultado(bool acao, string sucesso = default, string inSucesso = default)
        {
            if (acao)
            { Sucesso(sucesso); }
            else { Aviso(inSucesso); }
        }
        public override void TopoMenu(IIterator objetoTipo, string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando)
        {
            Console.Clear();
            Titulo1();
            Titulo2(subTitulo);
            Numeracao(Opcoes, Dir.H);
            Instrucao(instrucao);
            Linha('-');
            Escolher();
            if (Navegou) { Navegar(Acao, objetoTipo); Arvore(ref explorando); }
        }

    }
}
