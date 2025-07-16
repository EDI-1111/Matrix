using Matrix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model
{
    //Klasse rowList
    //Enthält 2 Listen für rowList und Age  x  AnzahlderStränge
    public class Drops
    {
        public int Col { get; set; } = 0;
        public List<int> ColorAgeList { get; set; }
        public List<int> RowList { get; set; }

        //Konstruktor
        public Drops()
        {
            //Setzt Wert für Position Zellen (Breite)
            Col = RandomNumberGenerator.GetInt32(0, Console.WindowWidth);

            //Listen Age und rowList
            ColorAgeList = new List<int>();
            RowList = new List<int>();

            //Erzeuge eine Random Zahl für Col
            int TempRow = RandomNumberGenerator.GetInt32(0, Convert.ToInt32(Console.WindowHeight * 0.9));

            //Erstellen neuer Einträge für die Listen 
            for (int i = 0; i < Rain.StrangLaenge; i++)
            {
                RowList.Add(TempRow++);
                ColorAgeList.Add(0);

                //Abfrage ob der Wert Das Untere Bildschirm Ende erreicht hat -1
                if (TempRow == Console.WindowHeight - 1)
                {
                    //Zähler für rowList wird zurückgesetzt 
                    TempRow = 0;
                }
            }
        }
    }
}
