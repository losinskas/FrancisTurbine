using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClosedXML.Excel;
using ConsoleApp3.Classe;

namespace ConsoleApp3.Classe.Tabelas
{

    
   
    class Excel
    {
        public Excel(InputParms input)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Turbina");

            
            this.ParamsInput(input, wb);
            OutputParmsGeometry output = new OutputParmsGeometry(input.nqar, input.altura, input.rotacaoRPM, input.vazaoRegular, input.rendimentoV);
            this.Output(output, wb);


            wb.SaveAs("TurbinaCalc.xlsx");
        }
        public void ParamsInput(InputParms input, XLWorkbook wb)
        {
            var ws = wb.Worksheets.Add("Parâmetros de Entrada");
            ws.Range("A1:G2").Merge();
            ws.Cell("A1").Value = "Parâmetros de entrada";
            ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("A1").Style.Alignment.Vertical= XLAlignmentVerticalValues.Center;
            ws.Cell("A1").Style.Font.Bold = true;
            ws.Cell("A1").Style.Font.FontSize = 18;
            ws.Range("A1:G2").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
           
            ws.Cell("B4").Value = "Altura h [m]";
            ws.Cell("C4").Value = input.altura;
            
            ws.Cell("B5").Value = "Vazão q [m³/s]";
            ws.Cell("C5").Value = input.vazao;
            
            ws.Cell("B6").Value = "Rotação do rotor n [rpm]";
            ws.Cell("C6").Value = input.rotacaoRPM;
            
            ws.Cell("B7").Value = "Rotação do rotor [rps]";
            ws.Cell("C7").Value = input.rotacaoRPS;
            
            ws.Cell("B8").Value = "Salto Energético Y [J/kg]";
            ws.Cell("C8").Value = input.saltoEnergetico;
            
            ws.Cell("B9").Value = "Rendimento Volumétrico nv";
            ws.Cell("C9").Value = input.rendimentoV;

            ws.Cell("B10").Value = "Vazão do rotor Rendimento Q_1/1 [m³/s]";
            ws.Cell("C10").Value = input.vazaoR;

            ws.Cell("B11").Value = "Rotação específica da máquina nqar";
            ws.Cell("C11").Value = input.nqar;
            
            ws.Cell("B12").Value = "Potência máxima no eixo [kW]";
            ws.Cell("C12").Value = input.potMaxEixo;
            
            ws.Cell("B13").Value = "Rendimento mecânico";
            ws.Cell("C13").Value = input.rendMeca;
            
            ws.Cell("B14").Value = "Rendimento interno";
            ws.Cell("C14").Value = input.rendInterno;

            ws.Range("B4:C14").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("B4:C14").Style.Border.BottomBorder= XLBorderStyleValues.Thin;
            ws.Range("B4:C14").Style.Border.LeftBorder= XLBorderStyleValues.Thin;
            ws.Range("B4:C14").Style.Border.RightBorder= XLBorderStyleValues.Thin;
            ws.Columns(2, 20).AdjustToContents();

        }
        public void Output(OutputParmsGeometry output, XLWorkbook wb)
        {
           
            var ws = wb.Worksheet("Turbina");
            ws.Cell("A1").Value = "Parameter_Name";
            ws.Cell("B1").Value = "Equation";
            ws.Cell("C1").Value = "Unit/Type";
            ws.Cell("D1").Value = "Commet";

            ws.Cell("A2").Value = "D5e";
            ws.Cell("B2").Value = output.De5;
            ws.Cell("C2").Value = "m";
            
            ws.Cell("A3").Value = "b0";
            ws.Cell("B3").Value = output.b0;
            ws.Cell("C3").Value = "m";
            
            ws.Cell("A4").Value = "D4e";
            ws.Cell("B4").Value = output.D4e;
            ws.Cell("C4").Value = "m";
            
            ws.Cell("A5").Value = "D4i";
            ws.Cell("B5").Value = output.D4i;
            ws.Cell("C5").Value = "m";
            
            ws.Cell("A6").Value = "D4m";
            ws.Cell("B6").Value = output.D4m;
            ws.Cell("C6").Value = "m";
            
            ws.Cell("A7").Value = "D3e";
            ws.Cell("B7").Value = output.D3e;
            ws.Cell("C7").Value = "m";
            
            ws.Cell("A8").Value = "beta4m";
            ws.Cell("B8").Value = output.beta4m;
            ws.Cell("C8").Value = "graus";
            
            ws.Cell("A9").Value = "D3i";
            ws.Cell("B9").Value = output.D3i;
            ws.Cell("C9").Value = "m";
            
            ws.Cell("A10").Value = "D5i";
            ws.Cell("B10").Value = output.D5i;
            ws.Cell("C10").Value = "m";
            
            ws.Cell("A11").Value = "Li";
            ws.Cell("B11").Value = output.Li;
            ws.Cell("C11").Value = "m";
            
            ws.Cell("A12").Value = "Le";
            ws.Cell("B12").Value = output.Le;
            ws.Cell("C12").Value = "m";
            
            ws.Cell("A13").Value = "L5e";
            ws.Cell("B13").Value = output.L5e;
            ws.Cell("C13").Value = "m";
            
            ws.Cell("A14").Value = "L4e";
            ws.Cell("B14").Value = output.L4e;
            ws.Cell("C14").Value = "m";
            
            ws.Cell("A14").Value = "L4i";
            ws.Cell("B14").Value = output.L4i;
            ws.Cell("C14").Value = "m";

            ws.Cell("A15").Value = "m";
            ws.Cell("A16").Value = "x";
            ws.Cell("B16").Value = "y";
            
            for (int i = 0; i < 30; i++)
            {
                ws.Cell("A" + (17 + i)).Value = output.xej[i];
                ws.Cell("B" + (17 + i)).Value = output.yej[i];

            }

            ws.Cell("A47").Value = "m";
            ws.Cell("A48").Value = "xe";
            ws.Cell("B48").Value = "ye";

            for (int i = 0; i < 29; i++)
            {
                ws.Cell("A" + (47+ i)).Value = output.xi[i] - output.b0;
                ws.Cell("B" + (47 + i)).Value = output.yi[i]+(output.D3e-output.D3i);
            }

        }

    }
}
