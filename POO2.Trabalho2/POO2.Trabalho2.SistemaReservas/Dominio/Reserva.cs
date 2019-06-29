using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Reserva : ClasseBase<Reserva, int>
    {
        public Reserva(Funcionario funcionario, Sala sala, DateTime data, Horario horario, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Funcionario = funcionario;
            Sala = sala;
            Data = data;
            Horario = horario;
            Lista.AddLast(this);
            itens.AddLast(this);
        }
        
        public Funcionario Funcionario { get; set; }
        public Sala Sala { get; set; }
        public DateTime Data { get; set; }
        public Horario Horario { get; set; }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.Append($"{this.Id.ToString()} | ");
                retorno.AppendLine($"{this.Sala.ToString()}");
                retorno.Append($"{this.Data.ToString("dd/MM/yy")} | ");
                retorno.AppendLine($"{this.Horario.ToString()}");
                retorno.AppendLine($"{this.Funcionario.ToString()}");
                return retorno.ToString();
            }
        }
        public string DescricaoH {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.Append($"{this.Id.ToString()} | ");
                retorno.Append($"{this.Sala.ToString()} | ");
                retorno.Append($"{this.Data.ToString("dd/MM/yy")} das ");
                retorno.Append($"{this.Horario.ToString()} | ");
                retorno.Append($"{this.Funcionario.DescricaoH.ToString()}");
                return retorno.ToString();
            }
        }
        public override Reserva SelecionarPorId(int id) => Lista.FirstOrDefault(x => x.Id == id);
        public override bool Equals(object obj)
        {
            try
            {
                return ((Reserva)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public override void TopoMenu(string subTitulo, string instrucao, List<string> Opcoes, ref bool navegando)
        {
            Console.Clear();
            Titulo1();
            Titulo2(subTitulo);
            Numeracao(Opcoes, Dir.H);
            Instrucao(instrucao);
            Linha('-');
            Escolher();
            if (Navegou && navegando)
            {
                Navegar(Acao, this.Current);
                ListarSubMenu(ref navegando);
            }
        }
        public override void SubMenu()
        {
            string subTitulo = "Reservas";
            string instrucao = "Número da opção desejada | Up e Down para navegar | Seta <-<- Menu Anterior";
            string informado = string.Empty;
            bool navegando = true;
            Ler = false;
            do
            {
                TopoMenu(subTitulo, instrucao, new List<string> { "Criar", "Ver Todas", "Ver Disponibilidade" }, ref navegando);
                if (Voltou) { break; }///SETA ESQUERDA
                if (Opcao1) { CadastroSubMenu(); }///CADASTRAR
                if (Opcao2) { ListarSubMenu(ref navegando); }///LISTAR
                if (Opcao3) { PesquisarDisponibilidadeSubMenu(); }///ABRIR
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        private void CadastroSubMenu()
        {
            string subTitulo = "Cadastro de Reservas";
            string instrucao = "";
            string informado = string.Empty;
            bool explorando = false;
            bool reservaEfetivada = false;
            Ler = false;
            Reserva reserva;
            Funcionario funcionario = null;
            Sala sala = null;
            DateTime data = new DateTime();
            Horario horario = null;
            do
            {
                TopoMenu(subTitulo, instrucao, new List<string> { }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA

                if (funcionario != null) { Campo("Funcionário"); Mostrar(funcionario.Nome); }
                else { funcionario = EscolhaFuncionarioSubMenu(); }

                if (sala != null) { Campo("Sala"); Mostrar(sala.Nome); }
                else { sala = EscolhaSala(); }

                if (data.Year != 0001) { Campo("Data"); Mostrar(data.ToString()); }
                else { data = NovaDataSubMenu(); }

                if (horario != null) { Campo("Horário"); Mostrar(horario.Descricao); }
                else { horario = EscolhaHorarioSubMenu(); }

                reservaEfetivada = Disponivel(sala, data, horario);
                if (reservaEfetivada) { reserva = new Reserva(funcionario, sala, data, horario, Itens); }
                Resultado(reservaEfetivada, "Reserva feita", "Horário não disponível! Reserva não realizada!");
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        private void PesquisarDisponibilidadeSubMenu()
        {
            string subTitulo = "Verificar Disponibilidade de Reserva";
            string instrucao = "Digite as informações solicitadas";
            bool navegando = false;
            Ler = false;
            Sala sala = null;
            DateTime data = new DateTime();
            Horario horario = null;
            do
            {
                TopoMenu(subTitulo, instrucao, new List<string> { }, ref navegando);
                if (Voltou) { break; }///SETA ESQUERDA

                if (sala != null) { Campo("Sala"); Mostrar(sala.Nome); }
                else { Campo("Sala"); sala = EscolhaSala(); }

                if (data.Year != 0001) { Campo("Data"); Mostrar(data.ToString()); }
                else { Campo("Data"); data = NovaDataSubMenu(); }

                if (horario != null) { Campo("Horário"); Mostrar(horario.Descricao); }
                else { Campo("Horário"); horario = EscolhaHorarioSubMenu(); }

                if(sala != null && data.Year != 0001 && horario != null)
                {
                    Resultado(Disponivel(sala, data, horario), "Reserva disponível", "Reserva não disponível!");
                }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        private Funcionario EscolhaFuncionarioSubMenu()
        {
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            string informado = string.Empty;
            bool explorando = true;
            do
            {
                TopoMenu("Funcionário Solicitante da Reserva", instrucao, new List<string> { }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA

                foreach (var funcionario in MenuHelper.Funcionarios)
                {
                    ImprimirNoh(funcionario, Funcionario.Current);
                }
                if (Abriu) { return (Funcionario)Funcionario.Current; }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
            return null;
        }
        private Sala EscolhaSala()
        {
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            string informado = string.Empty;
            bool explorando = true;
            do
            {
                TopoMenu("Escolha da Sala", instrucao, new List<string> { }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA

                foreach (var sala in MenuHelper.Salas)
                {
                    ImprimirNoh(sala, Sala.Current);
                }
                if (Abriu) { return (Sala)Sala.Current; }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
            return null;
        }
        private Horario EscolhaHorarioSubMenu()
        {
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            string informado = string.Empty;
            bool explorando = true;
            do
            {
                TopoMenu("Escolha da Sala", instrucao, new List<string> { }, ref explorando);
                if (Voltou) { break; }///SETA ESQUERDA

                foreach (var horario in MenuHelper.Horarios)
                {
                    ImprimirNoh(horario, Horario.Current);
                }
                if (Abriu) { return (Horario)Horario.Current; }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
            return null;
        }
        private bool Disponivel(Sala sala, DateTime data, Horario horario)
        {
            return Lista.Where(x => x.Sala == sala && x.Data == data && x.Horario == horario).Count() > 0;
        } 
        private DateTime NovaDataSubMenu()
        {
            bool dataOk = false;
            string dataDigitada = Console.ReadLine();
            DateTime data;
            do
            {
                if (!DateTime.TryParse(dataDigitada, out data))
                { Aviso("Formato de data não reconhecido! Tente novamente."); };
            }
            while (!dataOk);
            return data;
        }
        private void ListarSubMenu(ref bool navegando)
        {
            string subTitulo = "Reservas";
            string instrucao = "Número da opção desejada | Up e Down para navegar | Seta <-<- Menu Anterior";
            string informado = string.Empty;
            Ler = false;
            do
            {
                TopoMenu(subTitulo, instrucao, new List<string> { "Alterar", "Excluir" }, ref navegando);
                if (Removeu || Opcao2) { ExcluirOpcoesSubMenu(ref informado, ref navegando); }///DELETE
                if (Voltou) { break; }///SETA ESQUERDA

                foreach (var reserva in MenuHelper.Reservas)
                {
                    if (reserva.Equals(this.Current)) { Selecionar(((Reserva)reserva).DescricaoH.ToString()); }
                    else { Imprimir(((Reserva)reserva).DescricaoH.ToString(), Cor); }
                }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);

            
        }
        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando)
        {
            if (explorando)
            {
                RemoverNoh();
                //if (((IObjeto)Current).Nome != "Raiz") { RemoverNoh(); Arvore(ref explorando); }
                //else { Aviso("Não é possível exluir a Raiz!"); }
            }
        }
    }
}
