using System;
using System.Text;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Funcionario : ClasseBase<Funcionario, int>
    {
        public Funcao Funcao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Ramal { get; set; }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.AppendLine(string.Format($"Nome: {this.Nome.ToString()}\t\n"));
                retorno.AppendLine(string.Format($"Função: {this.Funcao.ToString()}"));
                retorno.AppendLine(string.Format($"Email: {this.Email.ToString()}"));
                retorno.AppendLine(string.Format($"Ramal: {this.Ramal.ToString()}"));
                return retorno.ToString();
            }
        }

        public Funcionario(Funcao funcao, string nome, string email, int ramal)
        {
            Funcao = funcao;
            Nome = nome;
            Email = email;
            Ramal = ramal;
            Lista.Add(this);
        }

        public override Funcionario SelecionarPorId(int id) => Lista.Find(x => x.Id == id);

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
    }
}
