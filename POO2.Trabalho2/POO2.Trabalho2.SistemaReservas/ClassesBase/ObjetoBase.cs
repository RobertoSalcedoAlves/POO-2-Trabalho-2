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
    public abstract class ObjetoBase<TTipo> : Iterator<TTipo>, IObjeto
        where TTipo : class
    {
        public string Nome { get; set; }
        public int Nivel { get; set; } = 0;
        public abstract int Bytes { get; }
        public abstract IObjeto Pai { get; set; }
        public abstract FormataConsole.Cor Cor { get; set; }
        public abstract Menu Menu { get; set; }

        public IObjeto Converter(IObjeto objeto)
        {
            switch (objeto.Tipo)
            {
                case TipoObjeto.Arquivo: return (Arquivo)objeto;
                case TipoObjeto.Pasta: return (Pasta)objeto;
                default: return (Pasta)objeto;
            }
        }

        public string PathVirtual {
            get {
                return Tipo == TipoObjeto.Pasta ? string.Format($@"{Nome}\") : Nome;
            }
            set { }
        }
        public abstract TipoObjeto Tipo { get; }

        public abstract void Adicionar(IObjeto o);
        public abstract override string ToString();
        public abstract bool EstruturaFilhos();
    }
}
