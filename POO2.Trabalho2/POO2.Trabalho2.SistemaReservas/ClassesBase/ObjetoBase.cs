using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
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

        public IObjeto Converter(IObjeto objeto)
        {
            switch (objeto.Tipo)
            {
                case TipoObjeto.Arquivo: return (Arquivo)objeto;
                case TipoObjeto.Pasta: return (Pasta)objeto;
                default: return (Pasta)objeto;
            }
        }

        public abstract TipoObjeto Tipo { get; }

        public string PathVirtual {
            get {
                return Tipo == TipoObjeto.Pasta ? string.Format($@"{Nome}\") : Nome;
            }
            set { }
        }        

        public abstract void Adicionar(IObjeto o);
        public abstract override string ToString();
        public abstract void Estruturar();
    }
}
