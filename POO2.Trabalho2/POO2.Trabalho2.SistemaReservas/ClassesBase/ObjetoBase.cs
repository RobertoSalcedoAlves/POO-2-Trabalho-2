using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ObjetoBase : Iterator<IObjeto>, IObjeto
    {
        public ObjetoBase(string nome, string conteudo, LinkedList<IObjeto> _itens) : base(nome, conteudo, _itens) { }
        public int Id { get; set; }
        protected int ProximoId { get => PegaNumeroItems() + 1; }
        public string Nome { get; set; }
        public int Nivel { get; set; } = 0;
        public abstract int Bytes { get; }
        public abstract IObjeto Pai { get; set; }
        public abstract FormataConsole.Cor Cor { get; set; }
        public TTipo Converter<TTipo>(IObjeto objeto) => (TTipo)objeto;
        public string PathVirtual { get { string pathVirtual = ""; pathVirtual = PegarPath(this, pathVirtual); return pathVirtual; } set { } }
        public abstract TipoObjeto Tipo { get; }
        public abstract void Adicionar(IObjeto filho);
        public abstract override string ToString();
        public abstract bool EstruturaFilhos();
        public string PegarPath(IObjeto objeto, string pathVirtual)
        {
            Pasta pai = (Pasta)objeto.Pai;
            if (pai == objeto)
                return "";
            pathVirtual += pai.Nome + "\\";
            pathVirtual = PegarPath(pai, pathVirtual);
            return pathVirtual;
        }
        public abstract override bool Equals(object obj);
    }
}
