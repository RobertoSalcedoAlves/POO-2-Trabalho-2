using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;
using System.Text;
using System.Threading.Tasks;
using POO2.Trabalho2.Util;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class PastaBase<TTipo> : ObjetoBase<TTipo>
        where TTipo : class
    {
        public override int Bytes { get { return Conteudo.Sum(x => x.Bytes); } }
        public override TipoObjeto Tipo { get { return TipoObjeto.Pasta; } }
        public override IObjeto Pai { get; set; }
        public override Cor Cor { get { return Cor.Am; } set { } }
        public override Menu Menu { get { return new Menu("Pasta"); } set { } }
        public ICollection<IObjeto> Conteudo = new List<IObjeto>();
        public static int teste { get; set; } = 0;

        public PastaBase(string nome) { Nome = nome; Nivel += 3; }

        public override void Adicionar(IObjeto objeto)
        {
            objeto.Nivel = Nivel + 3;
            objeto.Pai = this;
            objeto.PathVirtual = this.PathVirtual + objeto.PathVirtual;
            this.Conteudo.Add(objeto);
        }

        public void RemoverArquivoPorNome(string nomeArquivo)
        {
            IObjeto arquivo = Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.Nome.Equals(nomeArquivo));
            if (arquivo != null)
                Conteudo.Remove(arquivo);
        }

        public void RemoverArquivoPorCaminho(string pathVirtual)
        {
            IObjeto objeto = Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.PathVirtual.Replace('/', '\\').Equals(pathVirtual));
            if (objeto != null)
                Conteudo.Remove(objeto);
        }

        public void LocalizarArquivoPorNome(string nomeArquivo)
        {
            IObjeto arquivo = Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.Nome.Equals(nomeArquivo));
            if (arquivo != null)
                Conteudo.Remove(arquivo);
            else
                InformarNaoLocalizado();
        }

        public void LocalizarArquivoPorCaminho(string pathVirtual)
        {
            IObjeto objeto = Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.PathVirtual.Replace('/', '\\').Equals(pathVirtual));
            if (objeto != null)
                AbrirArquivo(objeto);
            else
                InformarNaoLocalizado();
        }

        private void AbrirArquivo(IObjeto objeto) => Console.WriteLine(ConverterEmArquivo(objeto).Conteudo);

        public void SelecionarPorPath(string pathVirtual)
        {
            IObjeto objeto = Conteudo.First(x => x.Tipo == TipoObjeto.Arquivo && x.PathVirtual.Replace('/', '\\').Equals(pathVirtual));
            if (objeto != null)
                AbrirArquivo(objeto);
            else
                InformarNaoLocalizado();
        }

        private void InformarNaoLocalizado() => Console.WriteLine("Arquivo não localizado");

        private Arquivo ConverterEmArquivo(IObjeto objeto) => (Arquivo)objeto;
        private Pasta ConverterEmPasta(IObjeto objeto) => (Pasta)objeto;

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
                    Imprimir(noh.ToString(), noh.Cor);
                    noh.EstruturaFilhos();
                }
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
