using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Funcionario : ClasseBase<Funcionario, int>
    {
        public Funcao Funcao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Ramal { get; set; }

        public Funcionario(Funcao funcao, string nome, string email, int ramal)
        {
            Funcao = funcao;
            Nome = nome;
            Email = email;
            Ramal = ramal;
        }

        public override Funcionario SelecionarPorId(int id) => Lista.Find(x => x.Id == id);
    }
}
