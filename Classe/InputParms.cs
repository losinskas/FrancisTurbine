using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3.Classe.Tabelas;
using ConsoleApp3.Classe;

namespace ConsoleApp3.Classe
{
    class InputParms
    {
        public double vazao { get; set; }           // Vazão de entrada [m³/s]
        public double altura { get; set; }          // Altura disponível de queda [m]
        public double rotacaoRPM { get;  set; }     // Rotação do rotor da máquina [rpm]
        public double rotacaoRPS { get; set; }      // Rotação do rotor da máquina [rps]
        public double saltoEnergetico { get; set; } // Salto energético [J/kg]
        public double rendimentoV { get; set; }     // Rendimento volumétrico 
        public double vazaoR { get; set; }          // Vazão no rotor com o rendimento [m³/s]
        public double nqar_11 { get; set; }         // Rotação específica da máquina [rpm]
        public double vazaoRegular { get; set; }    // Vazão regular [m³/s]
        public double nqar { get; set; }            // Rotação especifíca da máquina [rpm]
        public double potMaxEixo { get; set; }      // Potência máxima no eixo [kW]
        public double rendMeca { get; set; }        // Rendimento mecânico
        public double rendInterno { get; set; }     // Rendimento interno
        public string report { get; set; }          // String de relatório 
         public InputParms(double altura, double rotacao, double vazao, double rendimentoV, double rendMeca, double rendInterno)
        {
            this.altura = altura;
            this.rotacaoRPM = rotacao;
            this.vazao = vazao;
            this.rendimentoV = rendimentoV;
            this.rendInterno = rendInterno;
            this.rendMeca = rendMeca;

            this.rpmToRps(rotacao);
            this.hToY(altura);
            this.nqa();
            this.vazaoRendimento();
            this.report += $"A Turbina, com os parâmetros de entrada:\naltura:{altura}[m]\nvazão: {vazao}[m³/s\nrotação: {rotacao}[rpm]\nrendimento volumétrico: {rendimentoV}\n";
            RotorType type = new RotorType();
            type.Type(this.nqa());
            this.report += "\n---------Cálculos Iniciais---------------\n\n";
            this.report += $"O valor da nqa = {this.nqa()} e o tipo de rotor é {type.rotor}\n";
            this.report += $"A vazão com rendimento volumátrico é {vazaoR}[m³/s]\n";
            this.nqar11();
            this.report += $"O Valor de nqa1/1: {nqar_11}\n";
            this.qr();
            this.report += $"Vazão Regular: {vazaoRegular}[m³/s]\n";
            this.n_qar();
            this.report += $"A rotação especifíca nqar: {nqar}[rpm]\n";
            this.pot_max_eixo();
            this.report += $"A potência máxima no eixo P_max: {potMaxEixo} [kW]\n";

            OutputParmsGeometry output = new OutputParmsGeometry(nqar, altura, rotacaoRPM, vazaoRegular, rendimentoV);
            this.report += output.report;


        }

        public double nqa()
        {
            this.rpmToRps(this.rotacaoRPM);
            this.hToY(altura);
            double nqa = 1000 * this.rotacaoRPS * (Math.Pow(vazao, 0.5) / Math.Pow(this.saltoEnergetico, 0.75));
            return nqa;
        }
        public void rpmToRps(double rotacao)
        {
            rotacao /= 60;
            this.rotacaoRPS = rotacao;
        }
        public void hToY(double h)
        {
            double y = h * 9.81;
            this.saltoEnergetico = y;
        }
        public void vazaoRendimento()
        {
            this.vazaoR = this.vazao * rendimentoV;
        }

       public void nqar11()
        {
            this.nqar_11 = 3 * rotacaoRPM * (Math.Pow(vazaoR, 0.5) / (Math.Pow(altura, 0.75)));
        }
        public void qr()
        {
            this.vazaoRegular = 0.731 * (1 + 0.01 * Math.Pow(nqar_11, 0.5)) * vazaoR;
        }

        public void n_qar()
        {
            this.nqar = 3 * rotacaoRPM * (Math.Pow(vazaoRegular, 0.5) / Math.Pow(altura, 0.75));
        }
        public void pot_max_eixo()
        {
            this.potMaxEixo = (9.81 * vazaoR * altura) / (rendMeca * rendInterno);
        }

    }
}
