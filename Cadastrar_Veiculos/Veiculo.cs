using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastrar_Veiculos
{
    class Veiculo
    {
        private string marca;
        private string modelo;
        private string cor;
        private string placa;


        public Veiculo()
        {
            this.marca = null;
            this.modelo = null;
            this.cor = null;
            this.placa = null;
        }
        public Veiculo(string marca, string modelo, string cor, string placa)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.cor = cor;
            this.placa = placa;
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public override string ToString()
        {
            return (String.Format("Marca: {0} \nModelo: {1} \nCor: {2} \nPlaca: {0}", marca, modelo, cor, placa));
        }

    }
}
