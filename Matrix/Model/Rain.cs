using Matrix.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Model
{
    public class Rain
    {
        public List<Drops> list { get; set; }

        public static int MaxColorAge = 30; //Wert des Maximalen Farbverlaufs da 
        public static int StrangAnzahl { get; set; } = Console.WindowWidth / 4;
        public static int StrangLaenge { get; set; } = 30;



        //Konstruktor
        public Rain()
        {
            // Baut die Anzahl an Regen Strängen
            list = new List<Drops>();

            for (int i = 0; i < Rain.StrangAnzahl; i++)
            {
                list.Add(new Drops());
            }
        }

        //Setzt über Color die Farbe und über Age den Farbverlauf
        public void SetColor(int Age, int Color)
        {
            //Switch für die Farbauswahl Color und ein Switch für den Farbverlauf je nach Age
            switch (Color)
            {
                case 1:
                    switch (Age)
                    {
                        //Farbe Grün
                        case 0:
                            //Farbwert wird auf Weiß Gesetzt 
                            Console.Write("\x1b[38;2;255;255;255m");
                            break;
                        case 1:
                            Console.Write("\x1b[38;2;200;255;200m");
                            break;
                        case <= 25:
                            Console.Write("\x1b[38;2;0;255;0m");
                            break;
                        case 26:
                            Console.Write("\x1b[38;2;0;200;0m");
                            break;
                        case 27:
                            Console.Write("\x1b[38;2;0;150;0m");
                            break;
                        case 28:
                            Console.Write("\x1b[38;2;0;100;0m");
                            break;
                        case 29:
                            Console.Write("\x1b[38;2;0;50;0m");
                            break;
                        case >= 30:
                            Console.Write("\x1b[38;2;10;10;10m");
                            break;
                    }
                    break;
                case 2:
                    switch (Age)
                    {
                        //Farbe Lila
                        case 0:
                            //Farbwert wird auf Weiß Gesetzt 
                            Console.Write("\x1b[38;2;255;255;255m");
                            break;
                        case 1:
                            Console.Write("\x1b[38;2;200;200;255m");
                            break;
                        case <= 25:
                            Console.Write("\x1b[38;2;127;0;255m");
                            break;
                        case 26:
                            Console.Write("\x1b[38;2;100;0;200m");
                            break;
                        case 27:
                            Console.Write("\x1b[38;2;75;0;150m");
                            break;
                        case 28:
                            Console.Write("\x1b[38;2;50;0;100m");
                            break;
                        case 29:
                            Console.Write("\x1b[38;2;25;0;50m");
                            break;
                        case >= 30:
                            Console.Write("\x1b[38;2;10;10;10m");
                            break;
                    }
                    break;

                case 3:

                    switch (Age)
                    {
                        //Farbe Blau
                        case 0:
                            //Farbwert wird auf Weiß Gesetzt 
                            Console.Write("\x1b[38;2;255;255;255m");
                            break;
                        case 1:
                            Console.Write("\x1b[38;2;200;200;255m");
                            break;
                        case <= 25:
                            Console.Write("\x1b[38;2;0;0;255m");
                            break;
                        case 26:
                            Console.Write("\x1b[38;2;0;0;238m");
                            break;
                        case 27:
                            Console.Write("\x1b[38;2;0;0;205m");
                            break;
                        case 28:
                            Console.Write("\x1b[38;2;0;0;139m");
                            break;
                        case 29:
                            Console.Write("\x1b[38;2;0;0;128m");
                            break;
                        case >= 30:
                            Console.Write("\x1b[38;2;10;10;10m");
                            break;
                    }
                    break;
            }
        }

        //Setzt das Vergleicht Age mit MaxAge wenn kleiner ++ , wenn 
        public void SetAge(Rain rain, int i, int j)
        {
            if (rain.list[j].ColorAgeList[i] != MaxColorAge)
            {
                rain.list[j].ColorAgeList[i]++;
            }
        }

        //Schreib Zeichen oder wenn MaxAge erreicht Leerzeichen
        public void Write(Rain rain, int i, int j)
        {
            if (rain.list[j].ColorAgeList[i] < MaxColorAge)
            {
                Console.Write(Convert.ToChar(RandomNumberGenerator.GetInt32(48, 50)));
            }
            else
            {
                Console.Write(" ");
            }
        }

        public void CheckMinAnzahlStraenge(Rain rain)
        {
            if (rain.list.Count < StrangAnzahl)
            {
                do
                {
                    rain.list.Add(new Drops());
                }
                while (rain.list.Count < StrangAnzahl);
            }
        }

        //Anzahl der Stränge wird erhöht um 20 wenn das erste Zeichen Age 10/20/30 erreichthat 
        public void AnzahlStreangeErhoehen(Rain rain)
        {
            if (rain.list[0].ColorAgeList.First() == 10 || rain.list[0].ColorAgeList.First() == 20)
            {
                StrangAnzahl += Convert.ToInt32(StrangAnzahl * 0.1);
            }
        }

        //Löscht einen Eintrag in der Liste wenn Letzter auf 30
        public int Loeschen(Rain rain, int durchlaufe)
        {
            for (int i = 0; i < rain.list.Count; i++)
            {
                //Abfrage ob das letzte zeichen eines Stranges das MaxColorAge erricht hat
                if (rain.list[i].ColorAgeList.Last() == MaxColorAge)
                {
                    rain.list.RemoveAt(i);
                    durchlaufe = 1;

                }
            }
            return durchlaufe;
        }
    }
}

