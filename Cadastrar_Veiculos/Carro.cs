using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastrar_Veiculos
{
    class Carro : Veiculo
    {
        private double porta_mala;
        private string bagageiro;
        private string sensor_re;

        public Carro()
            : base()
        {
            this.porta_mala = 0.00;
            this.bagageiro = null;
            this.sensor_re = null;
        }
        public Carro(string marca, string modelo, string cor, string placa, double porta_mala, char bagageiro, char sensor_re)
            : base(marca, modelo, cor, placa)
        {
            this.porta_mala = porta_mala;
            Bagageiro = bagageiro.ToString();
            Sensor_re = sensor_re.ToString();
        }
        public double Porta_mala
        {
            get { return porta_mala; }
            set { porta_mala = value; }
        }
        public string Bagageiro
        {
            get { return bagageiro; }
            set { bagageiro = value == "S" ? "SIM" : "NÃO"; }
        }
        public string Sensor_re
        {
            get { return sensor_re; }
            set { sensor_re = value == "S" ? "SIM" : "NÃO"; }
        }
        public override string ToString()
        {
            return String.Format("{0} \nPorta malas: {1} \nBagageiro: {2} \nSensor de ré: {3}", base.ToString(), porta_mala, bagageiro, sensor_re);
        }
    }
}
