using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Classe.Tabelas
{
    class RotorType
    {
        public string rotor { set; get; }
        public void Type(double nqa)
        {
            var Rotores = new List<string> { "Francis Lenta", "Francis Normal", "Francis Rápida" };
            if (nqa >= 50 && nqa <= 120)
            {
                rotor = Rotores[0];
            }
            else if (nqa > 120 && nqa <= 200)
            {
                rotor = Rotores[1];
            }
            else if (nqa > 200 && nqa <= 320)
            {
                rotor = Rotores[2];
            }
            else
            {
                rotor = "Essa não é característica de uma turbina Francis";
            }
        }
        
    }
}
