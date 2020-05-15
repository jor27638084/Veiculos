using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastrar_Veiculos
{
    class Caminhao : Veiculo
    {
        private int numero_eixos;
        private double max_carga;
        private string cabine_dupla;

        public Caminhao()
            : base()
        {
            this.numero_eixos = 0;
            this.max_carga = 0.00;
            this.cabine_dupla = null;
        }
        public Caminhao(string marca, string modelo, string cor, string placa, int numero_eixos, double max_carga, char cabine_dupla)
            : base(marca, modelo, cor, placa)
        {
            this.numero_eixos = numero_eixos;
            this.max_carga = max_carga;
            Cabine_dupla = cabine_dupla.ToString();
        }
        public int Numero_eixos
        {
            get { return numero_eixos; }
            set { numero_eixos = value; }
        }
        public double Max_carga
        {
            get { return max_carga; }
            set { max_carga = value; }
        }
        public string Cabine_dupla
        {
            get { return cabine_dupla; }
            set { cabine_dupla = value == "S" ? "SIM" : "NÃO"; }
        }
        public override string ToString()
        {
            return String.Format("{0} \nNumero de Eixos: {1} \nMaximo de Carga: {2} \nCabine Dupla: {3}", base.ToString(), numero_eixos, max_carga, cabine_dupla);
        }
    }
}
