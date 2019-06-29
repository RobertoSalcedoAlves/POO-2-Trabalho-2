using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class ClasseBase<TTipo, TChave> : Iterator
        where TTipo : class
    {
        public ClasseBase(LinkedList<object> itens) : base(itens) { }
        public int Id { get; set; }
        public LinkedList<TTipo> Lista { get; set; } = new LinkedList<TTipo>();
        protected int ProximoId { get => PegaNumeroItems() + 1; }
        public override Cor Cor { get { return Cor.PdTxt; } set { } }
        public void Excluir(TTipo tipo) => Lista.Remove(tipo);
        public void ExcluirPorID(TChave id) => Lista.Remove(SelecionarPorId(id));
        public void SalvarAtualizar(TTipo tipo) => Lista.AddLast(tipo);
        public IEnumerable<TTipo> SelecionarTodos() => Lista.ToList();
        public override string ToString() => Descricao;
        public override void RemoverNoh()
        {
            Lista.Remove((TTipo)Current);
            RemoveItem(this.Current);
            Reset();
        }
        public override void ImprimirNoh(object noh, object current)
        {
            if (noh.Equals(current)) { Selecionar(noh.ToString()); }
            else { Imprimir(noh.ToString(), Cor); }
        }
        public override void Resultado(bool acao, string sucesso, string inSucesso)
        {
            if (acao)
            { Sucesso(sucesso); }
            else { Aviso(inSucesso); }
        }
        public abstract override void TopoMenu(string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando);
        public abstract string Descricao { get; }
        public abstract override void SubMenu();
        public abstract override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando);
        public abstract override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando);
        public abstract override bool Equals(object obj);
        public abstract TTipo SelecionarPorId(TChave id);
    }
}
