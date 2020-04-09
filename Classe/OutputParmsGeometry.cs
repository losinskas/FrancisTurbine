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
        public double rendimento { get; set; }      // Rendimento 
        public double De5 { get; set; }             // Diâmetro externo da aresta de saída [m]
        public double b0 { get; set; }              // Largura do distribuidor [m]
        public double D4e { get; set; }             // Diâmetro externo da aresta de entrada [m]
        public double D4i { get; set; }             // Diâmetro interno da aresta de entrada [m]
        public double D4m { get; set; }             // Diâmetro médio entre D4e e D4i [m]
        public double D3e { get; set; }             // Diâmetro externo da coroa externa [m] 
        public double u4m { get; set; }             // Velocidade média na aresta de entrada u4m [m/s]
        public double cm { get; set; }              // Velocidade média no tubo de admissão c_m[m/s]
        public double cu4m { get; set; }            // Velocidade média na entrada c_m_4m [m/s]
        public double beta4m { get; set; }          // Ângulo de direção da pá na entrada do rotor [°graus]
        public double D3i { get; set; }             // Diâmetro externo da coroa interna D_3i [m]
        public double D5i { get; set; }             // Diâmetro da coroa interna D_5i [m]
        public double Li { get; set; }              // Altura da coroa interna L_i [m]
        public double []xi = new double[30];
        public double []yi = new double[30];
        public double Le { get; set; }              // Altura externa da coroa L_e [m]
        public double L5e { get; set; }             // Altura do ponto D_3i até D_5e L_5e [m]
        public double Yem { get; set; }             // Espessura máxima da coroa externa Y_em [m]
        public double[] xej = new double[30];       // Pontos para determinar o traçado da coroa interna [m]
        public double[] yej = new double[30];       // Equação para o traçado da coroa interna [m]
        public double L4e { get; set; }             // Comprimento do arco de circunferência entre D_4e e D_5e L_4e [m]
        public double L4i { get; set; }             // Comprimento do arco de circunferência entre D_4i e D_5i L_4i [m]            
        public OutputParmsGeometry(double nqar, double altura, double rotacaoRPM, double vazaoRegular, double rendimento)
        {
            this.nqar = nqar;
            this.altura = altura;
            this.rotacaoRPM = rotacaoRPM;
            this.vazaoRegular = vazaoRegular;
            this.rendimento = rendimento;
            this.D_e5();
            this.De5 = 0.6922;
            this.report += $"O diâmetro interno da aresta de saída: {De5} [m]\n";
            this.b_0();
            this.report += $"A largura do distribuidor b_0: {b0} [m]\n";
            this.D_4e();
            this.report += $"O diâmetro externo da aresta de entrada D_4e: {D4e} [m]\n";
            this.D_4i();
            this.report += $"O diâmetro interno da aresta de entrada D_4i: {D4i} [m]\n";
            this.D_4m();
            this.report += $"O diâmetro médio entre D_4e e D_4i: {D4m} [m]\n";
            this.D_3e();
            this.report += $"O diâmetro externo da coroa externa D_3e: {D3e} [m]\n";
            this.u_4m();
            this.report += $"A velocidade média entre as arestas de entrada u_4m: {u4m} [m/s]\n";
            this.c_m();
            this.report += $"A velocidade no tubo de admissão c_m: {cm} [m/s]\n";
            this.c_u4m();
            this.report += $"A velocidade média na aresta de entrada c_u4m: {cu4m} [m/s]\n";
            this.beta_4m();
            this.report += $"O ângulo de direção da pá na entrada do rotor beta_4m: {beta4m} [graus]\n";
            this.D_3i();
            this.report += $"O diâmetro externo da coroa interna D_3i: {D3i} [m]\n";
            this.D_5i();
            this.report += $"O diâmetro interno da coroa interna D_5i: {D5i} [m]\n";
            this.L_i();
            this.report += $"Altura da coroa interna L_i: {Li} [m]\n L_1/4: {Li/4}\n";
            this.y_i();
            this.report += "O valor de x_ij [m] \t O valor de y_ij [m]\n";
            for (int i = 0; i < 30; i++)
            {
                this.report += $"{xi[i]} \t {yi[i]} \n";
            }
            this.L_e();
            this.report += $"A altura da coroa externa L_e: {Le} [m]\n";
            this.L_5e();
            this.report += $"A altura do ponto D_3i até D_5e, L_5e: {L5e} [m]\n";
            this.Y_em();
            this.report += $"A espessura máxima da coroa externa Y_em: {Yem} [m]\n";
            this.L_4e();
            this.report += $"O comprimento do arco de circunferência entre D_4e e D_5e L_4e: {L4e} [m]\n";
            this.Y_ej();
            this.report += "O valor de x_ej [m] \t O valor de y_ej [m]\n";
            for (int i = 0; i < 29; i++)
            {
                this.report += $"{xej[i]} \t {yej[i]} \n";
            }
            this.L_4i();
            this.report += $"Comprimento do arco de circunferência entre D_4i e D_5i, L_4i: {L4i} [m]\n";
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
        public void D_4i()
        {
            this.D4i = (0.5 + 84.5 * Math.Pow(nqar, -1)) * De5;
        }
        public void D_4m()
        {
            this.D4m = 0.5 * (D4e + D4i);
        }
        public void D_3e()
        {
            this.D3e = (1.255 - (0.633 * Math.Pow(10, -3)*nqar)) * De5;
        }
        public void u_4m()
        {
            this.u4m = (Math.PI * D4m * rotacaoRPM) / 60;
        }
        public void c_m()
        {
            this.cm = (4*vazaoRegular) / (Math.PI * b0 * D3e);
        }
        public void c_u4m()
        {
            double ni = Math.Pow((0.7183+0.00556*nqar-0.000065417*Math.Pow(nqar, 2)+0.00000020919*Math.Pow(nqar, 3)),0.5);
            this.cu4m = (9.81 * ni * altura) / u4m;
        }
        public void beta_4m()
        {
            double angleRadian = Math.Atan(cm / (u4m - cu4m));
           

            this.beta4m = angleRadian*180/Math.PI;
        }
        public void D_3i()
        {
            this.D3i = (0.7 + (0.16 / (2.11 * Math.Pow(10, -3) * nqar + 0.08))) * De5;
        }
        public void D_5i()
        {
            this.D5i = (0.86 - (2.18 * Math.Pow(10, -3) * nqar)) * De5;
        }
        public void L_i()
        {
            this.Li = (0.4 + (0.168 * Math.Pow(10, -2) * nqar) - (0.0177 * Math.Pow(10, -4) * Math.Pow(nqar, 2))) * De5;
        }
        public void y_i()
        {
            double limite = this.Li ;
            double delta = limite / 30;
            double count = 0;
            for (int i = 0; i < 30; i++)
            {
                xi[i] = count;
                yi[i] = 1.54 * D3i * Math.Pow((xi[i] / (4 * Li) * Math.Pow(1 - (xi[i] / (4 * Li)),3)), 0.5);
                count += delta;
            }
        }
        public void L_e()
        {
            this.Le = ((0.042 * Math.Pow(10, -4) * Math.Pow(nqar, 2)) - (0.4 * Math.Pow(10, -2) * nqar) + 1.2) * De5;
        }
        public void L_5e()
        {
            this.L5e = (0.26 - 0.21 * Math.Pow(10, -3) * nqar) * De5;
        }
        public void Y_em()
        {
            this.Yem = (0.162 * (D3e - De5)) / Math.Pow(L5e / Le * (Math.Pow(1 - (L5e / Le), 3)), 0.5);
        }
        public void L_4e()
        {
            this.L4e = (2.222 * Math.Pow(10, -4) * nqar + 0.0833) * D4e;
        }
        public void Y_ej()
        {
            double lim = L4e*4; // 4;
            double delta = lim / 30;
            double count = 0;
            for (int i = 0; i < 29; i++)
            {
                this.xej[i] = count;
                this.yej[i] = 3.08 * Yem * Math.Pow(xej[i] / Le * (Math.Pow(1 - xej[i] / Le, 3)),0.5);
                count += delta;
            }

        }
        public void L_4i()
        {
            this.L4i = ((2.353 * Math.Pow(10, -6) * Math.Pow(nqar, 2)) - (0.8667 * Math.Pow(10, -3) * nqar) + 0.328) * D4e;
        }
    }
}
