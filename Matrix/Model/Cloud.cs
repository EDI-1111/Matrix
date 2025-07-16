using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Matrix.Model
{
    public class Cloud
    {
        //Setzt die Maximale Anzahl an Farben fest für die Auswahl
        //Anzahl der Auswählbaren Farben 1: Grün  2: Lila 3: Blau
        public static int MaxColor { get; } = 3;


        //Auswahl Wert für Menü und Farbe Standart Wert 0
        public static int ChoiceMenu { get; set; }
        public static int ChoiceColor { get; set; }
        public static int ChoiceMenuColor { get; set; }
    }
}

