using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using static POO2.Trabalho2.Util.FormataConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Funcionario : ClasseBase<Funcionario, int>
    {
        public Funcionario(Funcao funcao, string nome, string email, int ramal, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Funcao = funcao;
            Nome = nome;
            Email = email;
            Ramal = ramal;
            Lista.AddLast(this);
            itens.AddLast(this);
        }
        public Funcao Funcao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Ramal { get; set; }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.AppendLine(string.Format($"Funcionário (a): {this.Nome.ToString()}"));
                retorno.AppendLine(string.Format(this.Funcao.ToString()));
                retorno.AppendLine(string.Format($"Email: {this.Email.ToString()}"));
                retorno.AppendLine(string.Format($"Ramal: {this.Ramal.ToString()}"));
                return retorno.ToString();
            }
        }
        public string DescricaoH {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.Append(string.Format($"Funcionário (a): {this.Nome.ToString()} ("));
                retorno.Append(string.Format($"{this.Funcao.ToString()})"));
                retorno.Append(string.Format($"Email: {this.Email.ToString()}"));
                retorno.Append(string.Format($"Ramal: {this.Ramal.ToString()}"));
                return retorno.ToString();
            }
        }
        public override Funcionario SelecionarPorId(int id) => Lista.FirstOrDefault(x => x.Id == id);
        public override bool Equals(object obj)
        {
            try
            {
                return ((Funcionario)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public override void SubMenu()
        {
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            string informado = string.Empty;
            bool explorando = true;
            do
            {
                TopoMenu("Escolha do Funcionário", instrucao, new List<string> { }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA
                
                if (Abriu) { }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        public override void TopoMenu(string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando)
        {
            Console.Clear();
            Titulo1();
            Titulo2(subTitulo);
            Numeracao(Opcoes, Dir.H);
            Instrucao(instrucao);
            Linha('-');
            Escolher();
            if (Navegou && explorando)
            {
                Navegar(Acao, this.Current);
                foreach (var item in MenuHelper.Reservas)
                {
                    ImprimirNoh(item, this.Current);
                }
            }
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
