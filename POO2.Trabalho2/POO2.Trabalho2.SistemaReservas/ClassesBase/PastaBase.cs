using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;
using POO2.Trabalho2.Util;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class PastaBase : ObjetoBase
    {        
        public PastaBase(string nome, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Nome = nome;
            Nivel += 3;
            itens.AddLast(this);
        }
        public override int Bytes { get { return Conteudo.Sum(x => x.Bytes); } }
        public override TipoObjeto Tipo { get { return TipoObjeto.Pasta; } }
        public override object Pai { get; set; }
        public override Cor Cor { get { return Cor.Am; } set { } }
        public LinkedList<IObjeto> Conteudo { get; set; } = new LinkedList<IObjeto>();
        public override void Adicionar(object filho)
        {
            IObjeto objeto = ((IObjeto)filho);
            objeto.Nivel = Nivel + 3;
            objeto.Pai = this;
            this.Conteudo.AddLast(objeto);
        }
        public override string ToString()
        { return string.Format($"{ new String(' ', this.Nivel)}{this.Nome} [{Bytes.ToString()} bytes]"); }
        public override void SubMenu()
        {
            string subTitulo = "Arquivo";
            string instrucao = "Número da opção desejada | Up e Down para navegar | Seta <-<- Menu Anterior";
            string informado = string.Empty;
            bool explorando = false;
            Ler = false;
            do
            {
                TopoMenu(this, subTitulo, instrucao, new List<string> { "Explorar", "Localizar", "Abrir", "Excluir" }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA
                if (Removeu) { ExcluirOpcoesSubMenu(ref informado, ref explorando); }///DELETE
                if (Opcao1) { Arvore(ref explorando); }///EXPLORAR
                if (Opcao2) { LocalizarSubMenu(subTitulo, instrucao, ref informado, ref explorando); }///LOCALIZAR
                if (Opcao3)///ABRIR
                {
                    if (explorando)
                    {
                        AbrirArquivo((IObjeto)Current);
                        explorando = ((IObjeto)Current).Tipo == TipoObjeto.Arquivo ? false : true;
                    }
                    else { Arvore(ref explorando); }
                }
                if (Opcao4) { ExcluirOpcoesSubMenu(ref informado, ref explorando); }///EXCLUIR
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            do
            {
                TopoMenu(this, subTitulo, instrucao2, new List<string> { "Por nome", "Por path", "Explorar", "Excluir" }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA
                if (Removeu) { ExcluirOpcoesSubMenu(ref informado, ref explorando); }///DELETE
                if (Opcao1)
                {
                    Campo("Digite o nome do arquivo"); informado = Console.ReadLine();///POR NOME
                    Resultado(SelecionarArquivoPorNome(informado),"Arquivo encontrado","Arquivo não localizado!"); informado = null;
                }
                if (Opcao2)
                {
                    Campo("Digite o caminho do arquivo"); informado = Console.ReadLine();///POR PATH
                    Resultado(SelecionarArquivoPorPath(informado), "Arquivo encontrado", "Arquivo não localizado!"); informado = null;
                }
                if (Opcao3) { Arvore(ref explorando); }///EXPLORAR
                if (Opcao4) { ExcluirOpcoesSubMenu(ref informado, ref explorando); }///EXCLUIR
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando)
        {
            if (explorando)
            {
                if (((IObjeto)Current).Nome != "Raiz") { RemoverNoh(); Arvore(ref explorando); }
                else { Aviso("Não é possível exluir a Raiz!"); }
            }
            else
            {
                if (string.IsNullOrEmpty(informado))
                {
                    Campo("Nome do arquivo ou caminho"); informado = Console.ReadLine();
                    if (informado.Replace('/', '\\').Contains('\\'))
                    {
                        Resultado(RemoverArquivoPorCaminho(informado));
                    }
                    else { Resultado(RemoverArquivoPorNome(informado)); }
                    informado = null;
                }
            }
        }
        public override void Resultado(bool acao, string sucesso = "Operação realizada com sucesso!", string inSucesso = "Operação não trouxe resultado!")
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
