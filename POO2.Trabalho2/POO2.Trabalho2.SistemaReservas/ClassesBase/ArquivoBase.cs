using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using static POO2.Trabalho2.Util.FormataConsole;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ArquivoBase<TTipo> : ObjetoBase<TTipo>
        where TTipo : class
    {
        public string Conteudo { get; set; }
        public override int Bytes { get; }
        public override TipoObjeto Tipo { get { return TipoObjeto.Arquivo; } }

        public ArquivoBase(string nome, string conteudo = "")
        {
            Nome = nome;
            Bytes = System.Text.ASCIIEncoding.ASCII.GetByteCount(conteudo);
            Conteudo = conteudo;            
        }

        public override void Adicionar(IObjeto o) => Negado();
        public void Remover(IObjeto o) => Negado();
        private void Negado() => Console.WriteLine("Não permitido");
        public override string ToString() => string.Format($"{new String(' ', this.Nivel)}{this.Nome} ({this.Bytes.ToString()} bytes)\t\n");
        public override void Estruturar() => Imprimir(this.ToString(), Cor.Am);
    }
}
