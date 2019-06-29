using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Iterators;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ObjetoBase : Iterator, IObjeto
    {
        public ObjetoBase(LinkedList<object> itens) : base(itens) { }
        public int Id { get; set; }
        protected int ProximoId { get => PegaNumeroItems() + 1; }
        public LinkedList<object> listaReordenada { get; set; } = new LinkedList<object>();
        public string Nome { get; set; }
        public int Nivel { get; set; } = 0;
        public abstract int Bytes { get; }
        public abstract object Pai { get; set; }
        public abstract override Cor Cor { get; set; }
        public TTipo Converter<TTipo>(IObjeto objeto) => (TTipo)objeto;
        public string PathVirtual { get { string pathVirtual = ""; pathVirtual = DefinirPath(this, pathVirtual); return pathVirtual + this.Nome; } set { } }
        public abstract TipoObjeto Tipo { get; }
        public abstract void Adicionar(object filho);
        public abstract override string ToString();
        public bool OrdenarItens(Pasta pasta)
        {
            try
            {
                foreach (var noh in Itens)
                {
                    if (noh == ((IObjeto)noh).Pai && noh == pasta && listaReordenada.Count == 0)
                    {
                        if (noh.Equals(Current))
                        {
                            if (!listaReordenada.Contains(noh))
                            {
                                listaReordenada.AddLast(noh);
                            }
                        }
                        else
                        {
                            if (!listaReordenada.Contains(noh))
                            {
                                listaReordenada.AddLast(noh);
                            }
                        }
                        continue;
                    }
                    if (((IObjeto)noh).Pai == pasta)
                        if (((IObjeto)noh).Tipo == TipoObjeto.Pasta)
                        {
                            if (noh.Equals(Current))
                            {
                                if (!listaReordenada.Contains(noh))
                                {
                                    listaReordenada.AddLast(noh);
                                }
                            }
                            else
                            {
                                if (!listaReordenada.Contains(noh))
                                {
                                    listaReordenada.AddLast(noh);
                                }
                            }
                            if (Itens != listaReordenada)
                                OrdenarItens((Pasta)noh);
                        }
                        else
                        {
                            if (noh.Equals(Current))
                            {
                                listaReordenada.AddLast(noh);
                            }
                            else
                            {
                                listaReordenada.AddLast(noh);
                            }
                        }
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public override bool Equals(object obj)
        {
            var objeto = (IObjeto)obj;
            if (objeto.Tipo == TipoObjeto.Arquivo) { return ((Arquivo)obj).Id == this.Id; }
            else { return ((Pasta)obj).Id == this.Id; }
        }
        public string DefinirPath(IObjeto objeto, string pathVirtual)
        {
            Pasta pai = (Pasta)objeto.Pai;
            if (pai == objeto)
                return pathVirtual;
            pathVirtual = pai.Nome + "\\" + pathVirtual;
            pathVirtual = DefinirPath(pai, pathVirtual);
            return pathVirtual;
        }
        public bool RemoverArquivoPorNome(string nomeArquivo)
        {
            foreach (var noh in Itens)
                if (((IObjeto)noh).Tipo == TipoObjeto.Arquivo && ((IObjeto)noh).Nome.ToUpper().Equals(nomeArquivo.ToUpper()))
                { DefinirNovoCurrent(((IObjeto)noh)); RemoverNoh(); return true; }
            return false;
        }
        public bool RemoverArquivoPorCaminho(string pathVirtual)
        {
            foreach (var noh in Itens)
                if (((IObjeto)noh).PathVirtual.ToUpper().Equals(pathVirtual.Replace('/', '\\').ToUpper()))
                { DefinirNovoCurrent(((IObjeto)noh)); RemoverNoh(); return true; }
            return false;
        }
        public bool LocalizarArquivoPorCaminho(string pathVirtual)
        {
            bool explorando = true;
            foreach (var noh in Itens)
            {
                if (((IObjeto)noh).Tipo == TipoObjeto.Arquivo && ((IObjeto)noh).PathVirtual.ToUpper().Equals(pathVirtual.Replace('/', '\\').ToUpper()))
                { DefinirNovoCurrent(((IObjeto)noh)); Arvore(ref explorando); }
            }
            return false;
        }
        public void AbrirArquivo(object objeto)
        {
            IObjeto obj = ((IObjeto)objeto);
            bool explorando = false;
            DefinirNovoCurrent(obj);
            if (obj.Tipo == TipoObjeto.Arquivo) { Campo("Conteúdo"); Mostrar(Converter<Arquivo>(obj).Conteudo); }
            else { Arvore(ref explorando); }
        }
        public void EstruturarItens(object nohPai)
        {
            nohPai = nohPai ?? MenuHelper.Raiz;
            ImprimirNoh(nohPai, this.Current);
            foreach (var noh in (LinkedList<IObjeto>)((Pasta)nohPai).Conteudo)
            {
                if (noh.Tipo == TipoObjeto.Arquivo) { ImprimirNoh(noh, this.Current); }
                else { EstruturarItens(noh); }
            }
        }
        public bool SelecionarArquivoPorPath(string path)
        {
            List<string> nohs = path.Replace('/', '\\').Split('\\').ToList();
            string nomeArquivo = nohs.Last();
            string nomePai = nohs.ElementAt(nohs.Count - 1);

            var arquivo =
                (Arquivo)Itens.FirstOrDefault(
                x => ((IObjeto)x).Tipo == TipoObjeto.Arquivo &&
                ((IObjeto)x).Nome == nomeArquivo &&
                ((IObjeto)(((IObjeto)x).Pai)).Nome == nomePai);
            if (arquivo != null)
            {
                DefinirNovoCurrent(arquivo); Campo("Encontrado");
                Mostrar(arquivo.ToString()); AbrirArquivo(arquivo); return true;
            }
            return false;
        }
        public bool SelecionarArquivoPorNome(string nomeArquivo)
        {
            var arquivo =
                (Arquivo)Itens.FirstOrDefault(x => ((IObjeto)x).Tipo == TipoObjeto.Arquivo && ((IObjeto)x).Nome.ToUpper().Equals(nomeArquivo.ToUpper()));
            if (arquivo != null) { DefinirNovoCurrent(arquivo); Campo("Encontrado"); Mostrar(arquivo.ToString()); AbrirArquivo(arquivo); nomeArquivo = string.Empty; return true; }
            nomeArquivo = string.Empty;
            return false;
        }        
        public override void RemoverNoh()
        {
            if (((IObjeto)Current).Tipo == TipoObjeto.Arquivo)
            {
                ((Pasta)(((IObjeto)Current).Pai)).Conteudo.Remove((IObjeto)Current);
                RemoveItem((IObjeto)Current);
                Reset();
            }
            else
            {
                LinkedList<IObjeto> itenslistaAtualiza = new LinkedList<IObjeto>();
                foreach (var noh in Itens)
                {
                    if ((((IObjeto)noh).Pai != ((IObjeto)Current)) && noh != Current)
                        itenslistaAtualiza.AddLast(((IObjeto)noh));
                }
                int numFilhos = ((Pasta)Current).Conteudo.Count;
                for (int i = 1; i <= numFilhos; i++)
                {
                    (((Pasta)Current).Conteudo).RemoveLast();
                }
                ((Pasta)(((IObjeto)Current).Pai)).Conteudo.Remove((IObjeto)Current);
                Itens.Clear();

                foreach (var noh in itenslistaAtualiza)
                {
                    Itens.AddLast(noh);
                }
                Reset();
            }
        }
        public void Arvore(ref bool explorando, object nohPai = null)
        {
            OrdenarItens(MenuHelper.Raiz);
            Itens = listaReordenada;
            EstruturarItens(nohPai);
            explorando = true;
            Ler = true;
        }
        public override void ImprimirNoh(object noh, object current)
        {
            if (noh.Equals(current)) { Selecionar(noh.ToString()); }
            else { Imprimir(noh.ToString(), Cor); }
        }
    }
}
