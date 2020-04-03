using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Classe
{
 
    class OutputParmsGeometry
    {
        public string report { get; set; }          // String de relatório   
        public double nqar { get; set; }            // Rotação especifíca [rpm]
        public double altura { get; set; }          // Altura disponível [m]
        public double rotacaoRPM { get; set; }      // Rotação do eixo [rpm]
        public double vazaoRegular { get; set; }    // vazão regular [m³/s]
        public double De5 { get; set; }             // Diâmetro externo da aresta de saída [m]
        public double b0 { get; set; }              // Largura do distribuidor [m]
        public double D4e { get; set; }             // Diâmetro externo da aresta de entrada [m]

        public OutputParmsGeometry(double nqar, double altura, double rotacaoRPM, double vazaoRegular)
        {
            this.nqar = nqar;
            this.altura = altura;
            this.rotacaoRPM = rotacaoRPM;
            this.vazaoRegular = vazaoRegular;
            this.D_e5();
            this.report += $"O diâmetro interno da aresta de saída é {De5}\n";
            this.b_0();
            this.report += $"A largura do distribuidor b_0 é {b0}\n";
            this.D_4e();
            this.report += $"O diâmetro externo da aresta de entrada D_e: {D4e} [m]";

        }

        public void D_e5()
        {
            this.De5 = 24.786 * (Math.Pow(altura, 0.5) / rotacaoRPM) + 0.685 * (Math.Pow(vazaoRegular, 0.5) / Math.Pow(altura, 0.25));
        }
        public void b_0()
        {
            this.b0 = ((0.168 * Math.Pow(10, -2) * nqar) - (0.018 * Math.Pow(10, -4) * Math.Pow(nqar, 2))) * De5;
        }
        public void D_4e()
        {
            this.D4e = ((0.165 * Math.Pow(10, -4) * Math.Pow(nqar, 2)) - (0.835 * Math.Pow(10, -2) * nqar) + 2.017) * De5;
               
        }


    }
}
