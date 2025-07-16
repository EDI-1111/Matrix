
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Matrix.Ausgabe;
using Matrix.Model;


namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Initialisiere Konsolenausgabe für ANSI-Codes
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Setzt Stadart Farbe
            Console.ForegroundColor = ConsoleColor.Green;

            //Start Programm

            //Warten bis Eingabe 

            Console.CursorVisible = false;

            //Einbinden der Funktionen der DLL Bibliotek
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            //Wert für Die Fenster Eigenschaft Maximiert
            const int SW_SHOWMAXIMIZE = 3;

            //Aufruf des Handel vom Konsolenfenster 
            //Mann erzeugt ein Behälter der ein Pointer (extern) verweißt
            //diesen befühlt man mit der Funktion GetForegroundWindow()
            //und bekommt das Momentan aktive Fenster Handel übergeben.
            IntPtr consoleWindowHandle = GetForegroundWindow();

            //Funktion zum einstellen des Fensters des Übergebenen Handel´s
            //( SW_MAXIMIZE = 3   die drei steht für maximieren in der Funkton)
            ShowWindow(consoleWindowHandle, SW_SHOWMAXIMIZE);
            Ausgabe.Ausgabe.Run(consoleWindowHandle);
        }
    }
}


