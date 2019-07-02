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
                retorno.AppendLine($"{this.Horario.ToString()} | ");
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
        public override void TopoMenu(IIterator objetoTipo, string subTitulo, string instrucao, List<string> Opcoes, ref bool navegando)
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
                Navegar(Acao, objetoTipo);
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
                TopoMenu(this, subTitulo, instrucao, new List<string> { "Criar", "Ver Todas", "Ver Disponibilidade" }, ref navegando);
                if (Voltou) { break; }///SETA ESQUERDA
                if (Opcao1) { CadastroSubMenu(); }///CADASTRAR
                if (Opcao2) { ListarSubMenu(ref navegando); }///LISTAR
                if (Opcao3) { PesquisarDisponibilidadeSubMenu(); }///ABRIR
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        private bool CadastroSubMenu()
        {
            string subTitulo = "Cadastro de Reservas";
            string instrucao = "";
            string informado = string.Empty;
            bool reservaDisponivel = false;
            bool navegando = false;
            Ler = true;
            Reserva reserva;
            Funcionario funcionario = null;
            Sala sala = null;
            DateTime data = new DateTime();
            Horario horario = null;
            do
            {
                TopoMenu(this, subTitulo, instrucao, new List<string> { }, ref navegando);
                if (Voltou || Saiu) { break; }///SETA ESQUERDA

                if (funcionario != null) { Campo("Funcionário"); Mostrar(funcionario.Nome); }
                else { funcionario = EscolhaFuncionarioSubMenu(); continue; }

                if (funcionario != null)
                {
                    if (sala != null) { Campo("Sala"); Mostrar(sala.Nome); }
                    else { sala = EscolhaSala(); continue; }
                }

                if (funcionario != null && sala != null)
                {
                    if (data.Year != 0001) { Campo("Data"); Mostrar(data.ToString()); }
                    else { data = NovaDataSubMenu(out informado); }
                    if (!string.IsNullOrEmpty(informado)) { Aviso(informado); Console.ReadKey(false); }
                }

                if (funcionario != null && sala != null && data.Year != 0001)
                {
                    if (horario != null) { Campo("Horário"); Mostrar(horario.Descricao); }
                    else
                    {
                        horario = EscolhaHorarioSubMenu();
                    }
                    reservaDisponivel = Disponivel(sala, data, horario);
                }
                if (funcionario != null && sala != null && data.Year != 0001 && horario != null)
                {
                    Resultado(reservaDisponivel, "Reserva realizada com sucesso!", "Reserva indisponível! Não realizada!");
                    if (reservaDisponivel)
                    {
                        reserva = new Reserva(funcionario, sala, data, horario, Itens);
                        funcionario = null; sala = null; horario = null; data = new DateTime();
                        return true;
                    }
                    else { break; }
                }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
            return false;
        }
        private void PesquisarDisponibilidadeSubMenu()
        {
            string subTitulo = "Verificar Disponibilidade de Reserva";
            string instrucao = "Digite as informações solicitadas";
            string informado = string.Empty;
            bool navegando = false;
            Ler = false;
            Sala sala = null;
            DateTime data = new DateTime();
            Horario horario = null;
            do
            {
                TopoMenu(this, subTitulo, instrucao, new List<string> { }, ref navegando);
                if (Voltou || Saiu) { break; }///SETA ESQUERDA

                if (sala != null) { Campo("Sala"); Mostrar(sala.Nome); }
                else { Campo("Sala"); sala = EscolhaSala(); }

                if (sala.Id != 0)
                {
                    if (data.Year != 0001) { Campo("Data"); Mostrar(data.ToString()); }
                    else { Campo("Data"); data = NovaDataSubMenu(out informado); }
                }

                if (sala != null && data.Year != 0001)
                {
                    if (horario != null) { Campo("Horário"); Mostrar(horario.Descricao); }
                    else { Campo("Horário"); horario = EscolhaHorarioSubMenu(); }
                    if (!string.IsNullOrEmpty(informado)) { Aviso(informado); Console.ReadKey(false); }
                }

                if (sala != null && data.Year != 0001 && horario != null)
                {
                    Resultado(Disponivel(sala, data, horario), "Reserva disponível", "Reserva não disponível!");
                }
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }
        private Funcionario EscolhaFuncionarioSubMenu()
        {
            bool navegando = true;
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            Ler = true;
            do
            {
                TopoMenu((Funcionario)MenuHelper.Funcionarios.ElementAt(0), "Funcionário Solicitante da Reserva", instrucao, new List<string> { }, ref navegando);
                if (Voltou || Saiu) { break; }///SETA ESQUERDA

                foreach (var func in MenuHelper.Funcionarios)
                {
                    if (func.Equals(Funcionario.Current)) { Selecionar(((Funcionario)func).DescricaoH.ToString()); }
                    else { Imprimir(((Funcionario)func).DescricaoH.ToString(), Cor); }
                }
                if (Abriu) { return (Funcionario)Funcionario.Current; }
                Acao = Console.ReadKey(false);
                Ler = true;
            }
            while (!Saiu);
            return null;
        }
        private Sala EscolhaSala()
        {
            bool navegando = true;
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            Ler = false;
            do
            {
                TopoMenu((Sala)MenuHelper.Salas.ElementAt(0), "Escolha da Sala", instrucao, new List<string> { }, ref navegando);
                if (Voltou || Saiu) { break; }///SETA ESQUERDA

                foreach (var sal in MenuHelper.Salas)
                {
                    ImprimirNoh(sal, Sala.Current);
                }
                if (Abriu) { return (Sala)Sala.Current; }
                Acao = Console.ReadKey(false);
                Ler = true;
            }
            while (!Saiu);
            return null;
        }
        private Horario EscolhaHorarioSubMenu()
        {
            bool navegando = true;
            string instrucao = "ENTER - escolher | Setas Up e Down - navegar";
            Ler = false;
            do
            {
                TopoMenu((Horario)MenuHelper.Horarios.ElementAt(0), "Escolha do Horário", instrucao, new List<string> { }, ref navegando);
                if (Voltou || Saiu) { break; }///SETA ESQUERDA

                foreach (var hor in MenuHelper.Horarios)
                {
                    ImprimirNoh(hor, Horario.Current);
                }
                if (Abriu) { return (Horario)Horario.Current; }
                Acao = Console.ReadKey(false);
                Ler = true;
            }
            while (!Saiu);
            return null;
        }
        private bool Disponivel(Sala sala, DateTime data, Horario horario)
        {
            var reservaExistente = Lista.Where(x => x.Sala == sala && x.Data == data && x.Horario == horario).Count();
            return reservaExistente == 0;
        }
        private DateTime NovaDataSubMenu(out string retorno)
        {
            bool dataOk = false;
            string dataDigitada;
            retorno = string.Empty;
            DateTime data;
            do
            {
                Campo("Data"); dataDigitada = Console.ReadLine();
                if (DateTime.TryParse(dataDigitada, out data)) { break; }
                retorno = "Formato de data não reconhecido! Tente novamente."; ;
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
                TopoMenu(this, subTitulo, instrucao, new List<string> { "Alterar", "Excluir" }, ref navegando);
                if (Removeu || Opcao2) { ExcluirOpcoesSubMenu(ref informado, ref navegando); }///DELETE
                if (Voltou || Saiu) { break; }///SETA ESQUERDA

                foreach (var reserva in MenuHelper.Reservas)
                {
                    if (reserva.Equals(this.Current)) { Selecionar(((Reserva)reserva).DescricaoH.ToString()); }
                    else { Imprimir(((Reserva)reserva).DescricaoH.ToString(), Cor); }
                }
                Acao = Console.ReadKey(false);
                Ler = true;
            }
            while (!Saiu);
        }
        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool navegando)
        {
            if (navegando)
            {
                RemoverNoh();
            }
        }
    }
}
