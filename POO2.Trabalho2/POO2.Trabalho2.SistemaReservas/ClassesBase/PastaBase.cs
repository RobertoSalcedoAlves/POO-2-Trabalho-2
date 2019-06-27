using POO2.Trabalho2.SistemaReservas.Interfaces;
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
        public PastaBase(string nome)
        {
            Id = ProximoId;
            Nome = nome;
            Nivel += 3;
            Itens.AddLast(this);
        }
        public override int Bytes { get { return Conteudo.Sum(x => x.Bytes); } }
        public LinkedList<IObjeto> listaReordenada = new LinkedList<IObjeto>();
        public override TipoObjeto Tipo { get { return TipoObjeto.Pasta; } }
        public override IObjeto Pai { get; set; }
        public override Cor Cor { get { return Cor.Am; } set { } }
        public ICollection<IObjeto> Conteudo { get; set; } = new List<IObjeto>();
        public override void Adicionar(IObjeto filho)
        {
            filho.Nivel = Nivel + 3;
            filho.Pai = this;
            this.Conteudo.Add(filho);
        }
        public bool SelecionarPorPath(string pathVirtual)
        {
            IObjeto objeto = MenuHelper.Raiz.Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.PathVirtual.Replace('/', '\\').Equals(pathVirtual));
            if (objeto != null) { AbrirArquivo(objeto); return true; }
            InformarNaoLocalizado(); return false;
        }
        public bool SelecionarArquivoPorPath(Pasta pasta, string path)
        {
            List<string> nohs = path.Replace('/', '\\').Split('\\').ToList();
            string nomeArquivo = nohs.Last();
            string nomePai = nohs.ElementAt(nohs.Count - 1);
            //Arquivo arquivo =
            //    (Arquivo)(pasta.Conteudo.FirstOrDefault(
            //    x => x.Tipo == TipoObjeto.Arquivo &&
            //    x.Nome == nomeArquivo &&
            //    x.Pai.Nome == nomePai));
            var arquivo =
                (Arquivo)Itens.FirstOrDefault(
                x => x.Tipo == TipoObjeto.Arquivo &&
                x.Nome == nomeArquivo &&
                x.Pai.Nome == nomePai);
            if (arquivo != null) { Current = arquivo; Campo("Arquivo"); Mostrar(arquivo.ToString()); AbrirArquivo(arquivo); return true; }
            Aviso("Não localizado!");
            return false;
            //else
            //{
            //    foreach (var noh in pasta.Conteudo)
            //    {
            //        if (noh.Tipo == TipoObjeto.Pasta)
            //            SelecionarArquivoPorPath((Pasta)noh, path);
            //    }
            //    return false;
            //}
        }
        public bool SelecionarArquivoPorNome(Pasta pasta, string nomeArquivo)
        {
            var arquivo =
                (Arquivo)Itens.FirstOrDefault(x => x.Tipo == TipoObjeto.Arquivo && x.Nome.ToUpper().Equals(nomeArquivo.ToUpper()));
            if(arquivo != null) { Current = arquivo; Campo("Arquivo"); Mostrar(arquivo.ToString()); AbrirArquivo(arquivo); nomeArquivo = string.Empty; return true; }
            Aviso("Não localizado!");
            nomeArquivo = string.Empty;
            //foreach (var noh in Itens)
            //{
            //    if (noh.Tipo == TipoObjeto.Arquivo && noh.Nome.ToUpper().Equals(nomeArquivo.ToUpper())) { Current = noh; Campo("Conteúdo"); AbrirArquivo(noh); return true; }
            //    Aviso("Não localizado!");
            //    if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).SelecionarArquivoPorNome((Pasta)noh, nomeArquivo); }
            //}
            return false;
        }
        public bool RemoverArquivoPorNome(Pasta pasta, string nomeArquivo)
        {
            foreach (var noh in Itens)
            {
                if (noh.Tipo == TipoObjeto.Arquivo && noh.Nome.ToUpper().Equals(nomeArquivo.ToUpper())) { ((Pasta)noh.Pai).Conteudo.Remove(noh); return true; }
                //if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).RemoverArquivoPorNome((Pasta)noh, nomeArquivo); }
            }
            return false;
        }
        public bool RemoverArquivoPorCaminho(Pasta pasta, string pathVirtual)
        {
            foreach (var noh in Itens)
            {
                if (noh.Tipo == TipoObjeto.Arquivo && noh.PathVirtual.ToUpper().Replace('/', '\\').Equals(pathVirtual.ToUpper())) { ((Pasta)noh.Pai).Conteudo.Remove(noh); return true; }
                //if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).RemoverArquivoPorCaminho((Pasta)noh, pathVirtual); }
            }
            return false;
        }
        public bool LocalizarArquivoPorCaminho(Pasta pasta, string pathVirtual)
        {
            foreach (var noh in Itens)
            {
                var teste = noh.PathVirtual;
                if (noh.Tipo == TipoObjeto.Arquivo && noh.PathVirtual.Replace('/', '\\').Equals(pathVirtual)) { Current = noh; OrdenarItens(MenuHelper.Raiz); }
                //if (noh.Tipo == TipoObjeto.Pasta) { ((Pasta)noh).LocalizarArquivoPorCaminho((Pasta)noh, pathVirtual); }
            }
            return false;
        }
        private void AbrirArquivo(IObjeto objeto) { Current = objeto; Campo("Conteúdo"); Mostrar(Converter<Arquivo>(objeto).Conteudo); }
        private void InformarNaoLocalizado() => Aviso("Arquivo não localizado");
        public override string ToString() => string.Format($"{ new String(' ', this.Nivel)}{this.Nome} [{Bytes.ToString()} bytes]");
        public override bool Equals(object obj)
        {
            try { return ((Pasta)obj).Id == this.Id; }
            catch (Exception) { try { return ((Arquivo)obj).Id == this.Id; } catch (Exception) { return false; } }
        }
        public void EstruturarItens()
        {
            foreach (var noh in (LinkedList<IObjeto>)Itens)
            {
                if (noh.Equals(Current)) { Selecionar(noh.ToString()); }
                else { Imprimir(noh.ToString(), noh.Cor); }
            }
        }
        public void Arvore()
        {
            OrdenarItens(MenuHelper.Raiz);
            Itens = listaReordenada;
            EstruturarItens();
            Ler = true;
        }
        public override bool OrdenarItens(Pasta pasta)
        {
            try
            {
                foreach (var noh in (LinkedList<IObjeto>)Itens)
                {
                    if (noh == noh.Pai && noh == pasta && listaReordenada.Count == 0)
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
                    if (noh.Pai == pasta)
                        if (noh.Tipo == TipoObjeto.Pasta)
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
        public override void SubMenu()
        {
            string subTitulo = "Arquivo";
            string instrucao1 = "Use as setas Up e Down para navegar pelos itens | Esc: Menu Anterior";
            string instrucao2 = "Pressione o número da opção desejada | Esc: Menu Anterior";
            string informado = string.Empty;
            bool explorando = false;
            Ler = false;
            bool ler = false;
            do
            {
                MenuTopo(subTitulo, instrucao1, new List<string> { "Explorar", "Localizar", "Abrir", "Excluir" });
                if (Opcao1) { explorando = true;  Arvore(); }
                if (Opcao2)
                {
                    explorando = false;
                    do
                    {
                        MenuTopo(subTitulo, instrucao2, new List<string> { "Por nome", "Por path", "Explorar", "Excluir" });
                        if (Opcao1) { Campo("Digite o nome do arquivo"); informado = Console.ReadLine();
                            SelecionarArquivoPorNome(MenuHelper.Raiz, informado); informado = null; }
                        if (Opcao2) { Campo("Digite o caminho do arquivo"); informado = Console.ReadLine();
                            SelecionarArquivoPorPath(MenuHelper.Raiz, informado); informado = null; }
                        if (Opcao3) { Arvore(); explorando = true; }
                        if (Opcao4)
                        {
                            if (explorando) { RemoveItem((IObjeto)Current); explorando = false; continue; }
                            if (!string.IsNullOrEmpty(informado) && informado.Replace('/', '\\').Contains('\\')) { RemoveItem((IObjeto)Current); continue; }
                            if (!string.IsNullOrEmpty(informado)) { RemoveItem((IObjeto)Current); continue; }
                        }
                        Acao = Console.ReadKey(false);
                    }                    
                    while (!Saiu);
                }
                if (Opcao2) { MenuHelper.Abrir(Current); }
                if (Opcao4)
                {
                    if (((IObjeto)Current).Tipo == TipoObjeto.Arquivo){ RemoveItem((Arquivo)Current); informado = null; Arvore(); continue;}
                    else { Aviso("Selecione um arquivo primeiro!"); }
                }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        private void MenuTopo(string subTitulo, string instrucao, List<string> Opcoes)
        {
            Console.Clear();
            Titulo1();
            Titulo2(subTitulo);
            Numeracao(Opcoes, Dir.H);
            Instrucao(instrucao);
            Linha('-');
            Escolher();
            if (Navegou) { Navegar(Acao); Arvore(); }
        }
    }
}
