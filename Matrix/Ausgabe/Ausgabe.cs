using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Matrix.Model;

namespace Matrix.Ausgabe
{
    static class Ausgabe
    {
        public static void Run(IntPtr consoleWindowHandle)
        {
            Console.Clear();
            FullScreen(consoleWindowHandle);
            Task.Delay(1000).Wait();
            //Lade BildSchirm aufrufen
            //Loading(consoleWindowHandle);
            CheckWindowsize(consoleWindowHandle);
            HauptMenu(consoleWindowHandle);
        }
        public static void FullScreen(IntPtr consoleWindowHandle)
        {
            //Zum Maximieren des Fensters
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            //Wert für Die Fenster Eigenschaft Maximiert
            const int SW_SHOWMAXIMIZE = 3;
            ShowWindow(consoleWindowHandle, SW_SHOWMAXIMIZE);
        }
        public static void CheckWindowsize(IntPtr consoleWindowHandle)
        {
            if (Console.LargestWindowWidth != Console.WindowWidth || Console.LargestWindowHeight != Console.WindowHeight)
            {
                FullScreen(consoleWindowHandle);
                //Console.Clear();
            }
        }
        public static void Loading(IntPtr consoleWindowHandle)
        {
            int Prozent = 0;
            int temp = 0;


            string FullBlock = "█";


            Console.Clear();
            for (int i = 0; i < 26; i++)
            {
                CheckWindowsize(consoleWindowHandle);

                switch (Prozent)
                {
                    //Farbe Grün
                    case <= 10:
                        Console.Write("\x1b[38;2;0;70;0m");
                        break;
                    case <= 20:
                        Console.Write("\x1b[38;2;0;80;0m");
                        break;
                    case <= 30:
                        Console.Write("\x1b[38;2;0;100;0m");
                        break;
                    case <= 40:
                        Console.Write("\x1b[38;2;0;120;0m");
                        break;
                    case <= 50:
                        Console.Write("\x1b[38;2;0;140;0m");
                        break;
                    case <= 60:
                        Console.Write("\x1b[38;2;0;160;0m");
                        break;
                    case <= 70:
                        Console.Write("\x1b[38;2;0;180;0m");
                        break;
                    case <= 80:
                        Console.Write("\x1b[38;2;0;200;0m");
                        break;
                    case <= 90:
                        Console.Write("\x1b[38;2;0;230;0m");
                        break;
                    case <= 100:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }

                for (global::System.Int32 j = 0; j < 4; j++)
                {


                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);

                    Console.Write("Loading Please Wait! " + Prozent + " %"); //26 Zeichen Lang




                    if (i == 25)
                    {
                        Prozent = 100;

                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
                        Console.Write("Loading Please Wait! " + Prozent + " %"); //26 Zeichen Lang

                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10 + temp, Console.WindowHeight / 2 + 1);
                        Console.Write(FullBlock);
                        return;
                    }
                    else
                    {
                        Prozent += 1;
                    }

                    Task.Delay(RandomNumberGenerator.GetInt32(100, 201)).Wait();
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10 + temp, Console.WindowHeight / 2 + 1);
                Console.Write(FullBlock);
                temp += 1;


            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
            Console.Write("Loading Please Wait! " + Prozent + " %"); //26 Zeichen Lang

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10 + temp, Console.WindowHeight / 2 + 1);
            Console.Write(FullBlock);





        }
        public static void HauptMenu(IntPtr consoleWindowHandle)
        {
            string text = "Wählen sie eine Farbe: ";
            string text1 = "1. Grün";
            string text2 = "2. Lila";
            string text3 = "3. Blau";
            string text4 = "Eingabe: ";

            do
            {
                CheckWindowsize(consoleWindowHandle);
                Console.Clear();
                //Ab hier wird Menü geschrieben 

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text.Length / 2), (Console.WindowHeight / 2) - 4);
                Console.Write(text);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text1.Length / 2), (Console.WindowHeight / 2) - 2);
                Console.Write(text1);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text2.Length / 2), (Console.WindowHeight / 2));
                Console.Write(text2);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text3.Length / 2), (Console.WindowHeight / 2) + 2);
                Console.Write(text3);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text4.Length / 2), (Console.WindowHeight / 2) + 4);
                Console.Write(text4);
                //Eingabe 
                Cloud.ChoiceMenuColor = Convert.ToInt32(Console.ReadLine());
            }
            while (Cloud.ChoiceMenuColor < 1 || Cloud.ChoiceMenuColor > 3);

            switch (Cloud.ChoiceMenuColor)
            {
                case 1:
                    Console.Write("\x1b[38;2;0;255;0m");
                    break;
                case 2:
                    Console.Write("\x1b[38;2;127;0;255m");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            string text5 = "Bitte geben sie eine Zahl ein (1 - 3) (2 - 3) Comming Soon";
            string text6 = "1. Matrix RainList";
            string text7 = "2. Matrix Schrift";
            string text8 = "3. Matrix Symbol";
            string text9 = "4. Beende";
            string text10 = "Auswahl: ";

            do
            {
                CheckWindowsize(consoleWindowHandle);
                Console.Clear();

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text5.Length / 2), (Console.WindowHeight / 2) - 6);
                Console.Write(text5);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text6.Length / 2), (Console.WindowHeight / 2) - 4);
                Console.Write(text6);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text7.Length / 2), (Console.WindowHeight / 2) - 2);
                Console.Write(text7);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text8.Length / 2), (Console.WindowHeight / 2) - 0);
                Console.Write(text8);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text9.Length / 2), (Console.WindowHeight / 2) + 3);
                Console.Write(text9);

                Console.SetCursorPosition((Console.WindowWidth / 2) - (text10.Length / 2), (Console.WindowHeight / 2) + 6);
                Console.Write(text10);

                Cloud.ChoiceMenu = Convert.ToInt32(Console.ReadLine());

            } while (Cloud.ChoiceMenu < 1 || Cloud.ChoiceMenu > 1);

            switch (Cloud.ChoiceMenu)
            {
                case 1:
                    //Loading(consoleWindowHandle);
                    DoTheMagicRain(consoleWindowHandle);
                    break;
                case 2:
                    DoTheMagicFont(consoleWindowHandle);
                    break;
                case 3:
                    DoTheMagicSymbol(consoleWindowHandle);
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        public static void DoTheMagicSymbol(IntPtr consoleWindowHandle)
        {
            //Aufruf Symbol Klasse
        }
        public static void DoTheMagicFont(IntPtr consoleWindowHandle)
        {
            //Aufruf Schrift Klasse
        }
        public static void DoTheMagicRain(IntPtr consoleWindowHandle)
        {
            Console.Clear();
            //Aufruf der Klasse Rain für einen Satz Daten Dynamisch je nach Fenstergröße  
            Rain rain = new Rain();

            //Steht für die Durchläufe die gemacht werden.
            //nach einem kompletten Durchlauf (duchlauf++)
            int durchlaufe = 1;

            //Endlos Schleife
            do
            {
                //Index i = StrangAnzahl
                //Index j = StrangLänge

                //Überprüft ob sich die Fenster Größe geändert hat. und maximiert es
                Ausgabe.CheckWindowsize(consoleWindowHandle);

                for (int i = 0; i < durchlaufe; i++)
                {
                    for (int j = 0; j < Rain.StrangAnzahl; j++)
                    {
                        //Neue Stränge werden erzeugt falls nötig
                        //rain.CheckMinAnzahlStraenge(rain);

                        //Setzt die Cursor Position auf den Wert der Col und rowList des jeweiligen indexes
                        Console.SetCursorPosition(left: rain.list[j].Col, top: rain.list[j].RowList[i]);

                        //Setzt Farbwert anhand des Alters (Age) 0 - 30...n 
                        rain.SetColor(rain.list[j].ColorAgeList[i], Cloud.ChoiceMenuColor);

                        //Entscheidet anhand des alters ob ein Zeichen generiert werden soll oder ein EmptyBlock (Leerzeichen)
                        rain.Write(rain, i, j);

                        //Setzt Age einen hoch bis MaxAge (30) 
                        rain.SetAge(rain, i, j);
                    }
                }

                //Task.Delay(17).Wait();

                //AnzahlStränge erhöhen anhand des alters der vorläufer
                //rain.AnzahlStreangeErhoehen(rain);

                //Neue Stränge werden erzeugt falls nötig
                rain.CheckMinAnzahlStraenge(rain);

                // Das Löschen muss auserhalb der schleifen passiern damit die indexe nicht durcheinander kommen. sonst aut of bounce
                //Überprüft ob der Strang Durchgelaufen ist und Löscht ihn dann

                //Durchlauf wird bis StrangLänge bei jedem durchlauf erhöht
                if (durchlaufe < Rain.StrangLaenge)
                {
                    durchlaufe++;
                }

                durchlaufe = rain.Loeschen(rain, durchlaufe);

                Task.Delay(33).Wait();
            }
            while (true);
        }


        //public static void RegenAusgabe(list<Strand> matrixRainStrand)
        //{
        //    int durchlaufe = 1;
        //    for (int i = 0; i < durchlaufe; i++)
        //    {
        //        for (int j = 0; j < Strand.AnzahlStreangeStart + Strand.AnzahlStreangeNew; j++)
        //        {
        //            //j ist der erste Index (die Anfangsanzahl der Stränge und später + AnzahlStreangeNew,
        //            //und i der Zweite Index für die jeweilige Liste in dem Strang

        //            //Überprüft ob sich die Fenster Größe geändert hat.
        //            Strand.CheckWindowSize(matrixRainStrand, j);
        //            //Neue Stränge werden erzeugt falls nötig
        //            Strand.CheckNeueStreange(matrixRainStrand);
        //            //Setzt die Cursor Position auf den Wert der Col und rowList des jeweiligen indexes
        //            Console.SetCursorPosition(matrixRainStrand[j]., matrixRainStrand[j].rowList[i]);
        //            //Setzt Farbwert anhand des Alters (Age) 0 - 30...n 
        //            Strand.SetColor(matrixRainStrand[j].Age[i], auswahl);
        //            //Entscheidet anhand des alters ob ein Zeichen generiert werden soll oder ein FullBlock 
        //            Strand.Write(i);
        //            //Setzt Age einen hoch bis MaxAge (30) 
        //            Strand.SetAge(matrixRainStrand, j, Index_I);
        //            //Überprüft ob der Strang Durchgelaufen ist und Löscht ihn dann
        //            Strand.LoeschenErstellen(matrixRainStrand, i);
        //            //Neue Stränge werden erzeugt falls nötig
        //            Strand.CheckNeueStreange(matrixRainStrand);
        //        }

        //        //Task.Delay(100).Wait();
        //    }
        //}
    }
}
