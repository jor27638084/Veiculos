using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cadastrar_Veiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LINHA = 300, COLUNA = 200;
            Veiculo[,] v = new Veiculo[LINHA, COLUNA];
            Carro[] car = new Carro[LINHA];
            Caminhao[] truck = new Caminhao[COLUNA];
            int l = 0, c = 0, opt;

            
            do
            {
                opt = menu();
                switch (opt)
                {
                    case 1:
                        int opt2;
                        Console.Clear();
                        Console.Write("\n1 Cadastrar Carros\n2 Cadastrar Caminhões: \n");
                        opt2 = int.Parse(Console.ReadLine());
                        switch (opt2)
                        {
                            case 1:
                                car[l] = cadastrarCarros();
                                break;
                            case 2:
                                truck[c] = cadastrarCaminhoes();
                                break;
                            default:
                                Console.WriteLine("Opção Inválida");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        int opt3;
                        Console.Write("\n1 Consulta por modelo\n2 Consulta por Cor\n3Consulta por placa: \n");
                        opt3 = int.Parse(Console.ReadLine());
                        switch (opt3)
                        {
                            case 1:
                                int menu_opt3;
                                Console.Write("\n1 Consultar modelo de Carro\n2 Consultar modelo de Caminhao:\n");
                                menu_opt3 = int.Parse(Console.ReadLine());
                                switch (menu_opt3)
                                {
                                    case 1:
                                        consultarCarroModelo(car, l);
                                        break;
                                    case 2:
                                        consultarCaminhaoModelo(truck, c);
                                        break;
                                    default:
                                        Console.WriteLine("Opção Inválida");
                                        break;
                                }
                                break;
                            case 2:
                                int menu_opt4;
                                Console.Write("\n1 Consultar Carro pela cor\n2 Consultar Caminhao pela cor:\n");
                                menu_opt4 = int.Parse(Console.ReadLine());
                                switch (menu_opt4)
                                {
                                    case 1:
                                        consultaCarroCor(car, l);
                                        break;
                                    case 2:
                                        consultaCaminhaoCor(truck, c);
                                        break;
                                    default:
                                        Console.WriteLine("Opção Inválida");
                                        break;
                                }
                                break;
                            case 3:
                                int menu_opt5;
                                Console.Write("\n1 Consultar Carro pela placa\n2 Consultar Caminhao pelo placa:\n");
                                menu_opt5 = int.Parse(Console.ReadLine());
                                switch (menu_opt5)
                                {
                                    case 1:
                                        consultaCarroPlaca(car, l);
                                        break;
                                    case 2:
                                        consultaCaminhaoPlaca(truck, c);
                                        break;
                                    default:
                                        Console.WriteLine("Opção Inválida");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Opção Inválida.");
                                break;
                        }
                        break;
                    case 3:
                        int opt4;
                        Console.Clear();
                        Console.Write("\n1 Exibir Carros cadastrados\n2 Exibir Caminhões cadastrados\n");
                        opt4 = int.Parse(Console.ReadLine());
                        switch (opt4)
                        {
                            case 1:
                                exibirCarros(car, l);
                                break;
                            case 2:
                                exibirCaminhoes(truck, c);
                                break;
                            case 3:
                                //exibirVeiculos(car, truck, v);
                                break;
                            default:
                                Console.WriteLine("Opção Inválida");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                Console.WriteLine("Aperte qualquer tecl para continuar.");
                Console.ReadKey();
            } while (opt != 0);

        }
        public static int menu()
        {
            Console.Clear();
            Console.WriteLine("Sistema de Cadastramento de Veículos");
            Console.Write("Escolha a opção desejada\n1 Cadastrar Veículos\n2 Consulta\n3 Exibir Veiculos Cadastrados\n");
            Console.WriteLine("0 para sair");
            return int.Parse(Console.ReadLine());
        }
        public static Carro cadastrarCarros()
        {
            Console.Clear();
            Console.WriteLine("Digite a marca do carro: ");
            string m = Console.ReadLine();
            Console.WriteLine("Digite o modelo do carro: ");
            string mod = Console.ReadLine();
            Console.WriteLine("Digite a cor do carro: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a placa do carro: ");
            string pla = Console.ReadLine();
            Console.WriteLine("Capacidade do porta-malas: ");
            double port_m = double.Parse(Console.ReadLine());
            Console.WriteLine("O carro tem bagageiro? Responta S para sim ou N para não");
            char bag = char.Parse(Console.ReadLine());
            Console.WriteLine("O carro tem sensor de ré? Responta S para sim ou N para não");
            char s_re = char.Parse(Console.ReadLine());

            return new Carro(m, mod, cor, pla, port_m, bag, s_re);

        }
        public static Caminhao cadastrarCaminhoes()
        {
            Console.Clear();
            Console.WriteLine("Digite a marca do caminhão: ");
            string m = Console.ReadLine();
            Console.WriteLine("Digite o modelo do caminhão: ");
            string mod = Console.ReadLine();
            Console.WriteLine("Digite a cor do caminhão: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a placa do caminhão: ");
            string pla = Console.ReadLine();
            Console.WriteLine("Numero de eixos: ");
            int eixo = int.Parse(Console.ReadLine());
            Console.WriteLine("Volume maximo de carga suportado: ");
            double carga = double.Parse(Console.ReadLine());
            Console.WriteLine("O caminhão tem cabine-dupla? Responta S para sim ou N para não");
            char c_dupla = char.Parse(Console.ReadLine());

            return new Caminhao(m, mod, cor, pla, eixo, carga, c_dupla);
        }
        public static void consultarCarroModelo(Carro[] cr, int lin)
        {
            string modelo;
            Console.Clear();
            Console.WriteLine("Qual modelo deseja consultar? ");
            modelo = Console.ReadLine();

            for (int x = 0; x <= lin; x++)
            {
                if (modelo == cr[x].Modelo)
                    Console.WriteLine(cr[x].ToString());
            }
        }
        public static void consultarCaminhaoModelo(Caminhao[] tr, int col)
        {
            string modelo;
            Console.Clear();
            Console.WriteLine("Qual modelo deseja consultar? ");
            modelo = Console.ReadLine();

            for (int x = 0; x <= col; x++)
            {
                if (modelo == tr[x].Modelo)
                    Console.WriteLine(tr[x].ToString());
            }
        }
        public static void consultaCarroCor(Carro[] cr, int lin)
        {
            string cor;
            Console.Clear();
            Console.WriteLine("Qual cor deseja consultar? ");
            cor = Console.ReadLine();

            for (int x = 0; x <= lin; x++)
            {
                if (cor == cr[x].Cor)
                    Console.WriteLine(cr[x].ToString());
            }
        }
        public static void consultaCaminhaoCor(Caminhao[] tr, int col)
        {
            string cor;
            Console.Clear();
            Console.WriteLine("Qual cor deseja consultar? ");
            cor = Console.ReadLine();

            for (int x = 0; x <= col; x++)
            {
                if (cor == tr[x].Cor)
                    Console.WriteLine(tr[x].ToString());
            }
        }
        public static void consultaCarroPlaca(Carro[] cr, int lin)
        {
            string placa;
            Console.Clear();
            Console.WriteLine("Qual modelo deseja consultar? ");
            placa = Console.ReadLine();

            for (int x = 0; x <= lin; x++)
            {
                if (placa == cr[x].Placa)
                    Console.WriteLine(cr[x].ToString());
            }
        }
        public static void consultaCaminhaoPlaca(Caminhao[] tr, int col)
        {
            string placa;
            Console.Clear();
            Console.WriteLine("Qual modelo deseja consultar? ");
            placa = Console.ReadLine();

            for (int x = 0; x <= col; x++)
            {
                if (placa == tr[x].Placa)
                    Console.WriteLine(tr[x].ToString());
            }
        }
        public static void exibirCarros(Carro[] cr, int lin)
        {
            Console.Clear();
            for (int x = 0; x <= lin; x++)
            {
                Console.WriteLine(cr[x].ToString());

            }
        }
        public static void exibirCaminhoes(Caminhao [] tr, int col)
        {
            Console.Clear();
            for (int x = 0; x <= col; x++)
            {
                Console.WriteLine(tr[x].ToString());

            }
        }
        /*public static void exibirVeiculos(Carro [] c, Caminhao [] t, Veiculo [,] v)
        {
            for(int x = 0; x <= c.Length; x++)
            {
                for(int y = 0; y <= t.Length; y++)
                {
                    Console.WriteLine(v[,].ToString());
                }
            }
        }*/


    }
}