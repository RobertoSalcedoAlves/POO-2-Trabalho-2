using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Funcao : ClasseBase<Funcao, int>
    {
        public Funcao(string nome, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Nome = nome;
            Lista.AddLast(this);
            itens.AddLast(this);
            //Lista.Add(this);
        }
        public string Nome { get; set; }
        public override string Descricao {
            get { return string.Format($"Funcão: {this.Nome}"); }
        }
        public override Funcao SelecionarPorId(int id) => Lista.FirstOrDefault(x => x.Id == id);
        public override bool Equals(object obj)
        {
            try
            {
                return ((Funcao)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public override void SubMenu()
        {

        }
        public override void TopoMenu(IIterator objetoTipo, string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
    }
}
