using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace RechnerWPF
{

    public partial class MainWindow : Window
    {
        string zwischenwert = "";
        string eingabeKlammerMulti;
        string eingabeProzentRechnung;
        string eingabeTrigonometrieRechnung;
        string eingabeOhneKlammern;
        string eingabepi_e;
        string klammerEinfügenString;
        string ergebnis = "";
        string ans = "";
        int klammerOffenCount = 0;
        List<double> zahlen;
        List<string> operatoren;

        public MainWindow()
        {
            InitializeComponent();

            textBlockAusgabe.Text = zwischenwert;
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("0");
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("1");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("2");
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("3");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("4");
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("5");
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("6");
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("7");
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("8");
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("9");
        }
        private void ButtonMal_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("*");
        }
        private void ButtonGeteilt_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("/");
        }
        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("+");
        }
        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("-");
        }
        private void ButtonKlammerAuf_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("(");
        }
        private void ButtonKlammerZu_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount--;
            EingabeHinzufügen(")");
        }
        private void ButtonHoch_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("^");
        }
        private void ButtonProzent_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("%");
        }
        private void ButtonCos_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("cos(");
        }
        private void ButtonSin_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("sin(");
        }
        private void ButtonTan_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("tan(");
        }
        private void ButtonArctan_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("arctan(");
        }
        private void ButtonArccos_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("arccos(");
        }
        private void ButtonArcsin_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("arcsin(");
        }
        private void ButtonKomma_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen(",");
        }
        private void ButtonWurzel_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("√(");
        }
        private void Buttonln_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("ln(");
        }
        private void Buttonlog_Click(object sender, RoutedEventArgs e)
        {
            klammerOffenCount++;
            EingabeHinzufügen("log(");
        }
        private void Buttone_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("e");
        }
        private void Buttonpi_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("π");
        }
        private void Buttonmd_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("md");
        }
        private void ButtonFak_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen("!");
        }
        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            zwischenwert = "";
            ergebnis = "";
            klammerOffenCount = 0;
            textBlockAusgabe.Text = zwischenwert;
        }
        private void Buttonans_Click(object sender, RoutedEventArgs e)
        {
            EingabeHinzufügen(ans);
        }
        private void ButtonGleich_Click(object sender, RoutedEventArgs e)
        {
            if (!zwischenwert.Equals(""))
                {
                    try
                    {
                        klammerEinfügenString = klammernAnhängen(zwischenwert);
                        eingabepi_e = replacer(klammerEinfügenString);
                        eingabeProzentRechnung = ProzentRechner(eingabepi_e);
                        eingabeKlammerMulti = KlammerMulti(eingabeProzentRechnung);
                        eingabeOhneKlammern = KlammerRechner(eingabeKlammerMulti);
                        eingabeTrigonometrieRechnung = trigonometrieRechner(eingabeOhneKlammern);
                        eingabeProzentRechnung = ProzentRechner(eingabeTrigonometrieRechnung);
                        zahlen = ZahlenFilter(eingabeProzentRechnung);
                        operatoren = OperatorFilter(eingabeProzentRechnung);
                        var punktVorStrichErgebnis = PunktVorStrichRechner(operatoren, zahlen);
                        zahlen = punktVorStrichErgebnis.Item2;
                        operatoren = punktVorStrichErgebnis.Item1;

                        ergebnis = RechnerAusfuehren(zahlen, operatoren).ToString("G");
                        ans = ergebnis;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ergebnis = "Error";
                        ans = "";
                    }
                }
            klammerOffenCount = 0;
            zwischenwert = "";
            textBlockAusgabe.Text = ergebnis;
        }

        private string klammernAnhängen(string eingabe)
        {
            for(int i = 0; i < klammerOffenCount; i++)
            {
                eingabe += ")";
            }

            return eingabe;
        }

        public static string replacer(string eingabe)
        {
            eingabe = eingabe.Replace("π", "3,14159265358979323");
            eingabe = eingabe.Replace("e", "2,71828182845904524");

            return eingabe;
        }

        private void EingabeHinzufügen(string eingabe)
        {
            if (ergebnis.Equals(""))
            {
                zwischenwert = zwischenwert + eingabe;

                klammerEinfügenString = klammernAnhängen(zwischenwert);

                textBlockAusgabe.Text = klammerEinfügenString;
            } 
            else if (eingabe.Equals("+") | eingabe.Equals("-") | eingabe.Equals("*") | eingabe.Equals("/") | eingabe.Equals("^") | eingabe.Equals("md"))
            {
                zwischenwert = ergebnis + eingabe;
                ergebnis = "";
            }
            else
            {
                ergebnis = "";
                zwischenwert = zwischenwert + eingabe;
            }
            klammerEinfügenString = klammernAnhängen(zwischenwert);
            textBlockAusgabe.Text = klammerEinfügenString;
        }
        private static string trigonometrieRechner(string eingabe)
        {
            string regexExpression = @"(sin|cos|tan|√|ln|log|arcsin|arccos|arctan)\([^(sin|cos|tan|√|ln|log|arcsin|arccos|arctan)]*?\)";

            string trigErgebnis;
            double replaceString;
            string[] trigMatches = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();

            if (trigMatches.Length == 0)
            {
                return eingabe;
            }

            do
            {
                foreach (string m in trigMatches) {

                    trigErgebnis = KlammerRechner(m);
                    
                    if (m.Contains("arcsin"))
                    {
                        trigErgebnis = trigErgebnis.Substring(6);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Asin(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }
                    else if (m.Contains("sin"))
                    {
                        trigErgebnis = trigErgebnis.Substring(3);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Sin(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }

                    if (m.Contains("arccos"))
                    {
                        trigErgebnis = trigErgebnis.Substring(6);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Acos(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }
                    else if (m.Contains("cos"))
                    {
                        trigErgebnis = trigErgebnis.Substring(3);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Cos(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }

                    if (m.Contains("arctan"))
                    {
                        trigErgebnis = trigErgebnis.Substring(6);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Atan(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }
                    else if (m.Contains("tan"))
                    {
                        trigErgebnis = trigErgebnis.Substring(3);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Tan(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }

                    if (m.Contains("√"))
                    {
                        trigErgebnis = trigErgebnis.Substring(1);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Sqrt(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }
                    if (m.Contains("ln"))
                    {
                        trigErgebnis = trigErgebnis.Substring(2);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Log(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }
                    if (m.Contains("log"))
                    {
                        trigErgebnis = trigErgebnis.Substring(3);
                        trigErgebnis = KlammerRechner(trigErgebnis);
                        replaceString = Convert.ToDouble(trigErgebnis);
                        trigErgebnis = Convert.ToString(Math.Log10(replaceString));
                        eingabe = eingabe.Replace(m, trigErgebnis);
                    }
                }

            Array.Clear(trigMatches, 0, trigMatches.Length);
            eingabe = KlammerRechner(eingabe);
            trigMatches = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();

            } while (trigMatches.Length != 0);

            return eingabe;
        }

        static string ProzentRechner(string eingabe)
        {
            string regexExpression = @"((^[-]\d+,\d+([\+\-\/\*\^]|md)(\d+,\d+|\d+)[%])|^[-]\d+([\+\-\/\*\^]|md)(\d+\d+|\d+)[%])|(\d+,\d+[\+\-\/\*\^])(\d+,\d+|\d+)[%]|(\d+([\+\-\/\*\^]|md))(\d+,\d+|\d+)[%]|((?<=[\+\-\/\*\^\(]|md)[-](\d+,\d+([\+\-\/\*\^]|md)(\d+,\d+|\d+)[%]|\d+([\+\-\/\*\^]|md)(\d+,\d+|\d+)[%]))";   //zahl operator zahl und % zeichen match
            List<double> prozentEingabe;
            List<string> Aufgabenoperator;
            double zwischenergebnis;

            string[] ProzentAufgaben = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();

            foreach (string s in ProzentAufgaben)
            {
                prozentEingabe = ZahlenFilter(s);
                Aufgabenoperator = OperatorFilter(s);
                if(Aufgabenoperator[0] == "+" | Aufgabenoperator[0] == "-")
                {
                    prozentEingabe[1] =  (prozentEingabe[1] / 100) * prozentEingabe[0];
                    zwischenergebnis = RechnerAusfuehren(prozentEingabe, Aufgabenoperator);
                    eingabe = eingabe.Replace(s, zwischenergebnis.ToString("G"));
                }
                else if(Aufgabenoperator[0] != "^")
                {
                    prozentEingabe[1] = (prozentEingabe[1] / 100);
                    zwischenergebnis = RechnerAusfuehren(prozentEingabe, Aufgabenoperator);
                    eingabe = eingabe.Replace(s, zwischenergebnis.ToString("G"));
                }
            }
            string regexExpression2 = @"(?!\+|\-|\/|\*|\^|md)(\d+,\d+|\d+)[%]";                                                                                               //alle zahlen mit % am ende
            string[] ProzentAufgaben2 = Regex.Matches(eingabe, regexExpression2).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();

            foreach (string s in ProzentAufgaben2)
            {
                prozentEingabe = ZahlenFilter(s);

                prozentEingabe[0] = prozentEingabe[0] / 100;
                eingabe = eingabe.Replace(s, prozentEingabe[0].ToString("G"));
                

            }
            return eingabe;
        }

        static string KlammerMulti(string eingabe)
        {
            string regexExpression = @"(?<=\d|\!)\(|\)(?=\d)|\)\(|\)(?=sin|cos|tan|√|ln|log|arcsin|arccos|arctan)|(?<=\d)(?=sin|cos|tan|√|ln|log|arcsin|arccos|arctan)|\%\(";                                              //Klammer direkt neben zahl(kein operator)

            string[] klammernMulti = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();

            foreach (string k in klammernMulti)
            {
                if (k == "(")
                {
                    Regex rgx = new Regex(@"(?<=\d+|\!)\(+?");
                    eingabe = rgx.Replace(eingabe, "*(", 1);
                }
                if (k == ")")
                {
                    Regex rgx = new Regex(@"\)(?=\d+)|\)(?=sin|cos|tan|√|ln|log|arcsin|arccos|arctan)");
                    eingabe = rgx.Replace(eingabe, ")*", 1);
                }
                if (k == ")(")
                {
                    Regex rgx = new Regex(@"\)\(+?");
                    eingabe = rgx.Replace(eingabe, ")*(", 1);
                }
                if (k == "")
                {
                    Regex rgx = new Regex(@"(?<=\d)(?=sin|cos|tan|√|ln|log|arcsin|arccos|arctan)");
                    eingabe = rgx.Replace(eingabe, "*", 1);
                }
                if (k == "%(")
                {
                    Regex rgx = new Regex(@"\%\(");
                    eingabe = rgx.Replace(eingabe, "%*(", 1);
                }
            }

            return eingabe;
        }

        static List<string> KlammerFilter(string eingabe)
        {
            string regexExpression = @"(?<!sin|cos|tan|√|ln|log|arcsin|arccos|arctan)\(([^(]*?)\)";                                              //inerste Klammer in einer Klammer

            string[] klammern = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();


            List<string> klammernList = new List<string>();
            foreach (string k in klammern)
            {
                klammernList.Add(k);
            }

            return klammernList;
        }

        static List<double> ZahlenFilter(string eingabe)
        {
            string regexExpression = @"(^[-]\d+,\d+(E\d+|E\-\d+)|^[-]\d+(E\d+|E\-\d+))|(\d+,\d+(E\d+|E\-\d+))|(\d+(E\d+|E\-\d+))|((?<=[\+\-\/\*\^\(\!]|md)[-](\d+,\d+(E\d+|E\-\d+)|\d+(E\d+|E\-\d+)))|((^[-]\d+,\d+)|^[-]\d+)|(\d+,\d+)|(\d+)|((?<=[\+\-\/\*\^\(\!]|md)[-](\d+,\d+|\d+))";                                              //alle zahlen, mit oder ohne komma und negative zahlen

            var zahlen = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => double.Parse(m.Value)).ToArray();

            List<double> zahlenList = new List<double>();
            foreach (double o in zahlen)
            {
                zahlenList.Add(o);
            }

            return zahlenList;
        }

        static List<string> OperatorFilter(string eingabe)
        {
            string regexExpression = @"(?<![\+\-\/\*\^]|md|^)([\+\-\/\*\^\!]|md)|((?<=\d+)([\+\-\/\*\^\!]|md)(?=\d+))|([\+\-\/\*\^\!]|md)(?=\()|(?<=\))([\+\-\/\*\^\!]|md)";                                             //alle operatoren zwischen 2 zahlen, neben klammer auf oder klammer zu, oder den ersten von zwei aufeinanderfolgenden operatoren

            string[] operatoren = Regex.Matches(eingabe, regexExpression).OfType<Match>().Select(m => string.Format(m.Value)).ToArray();


            List<string> operatorenList = new List<string>();
            foreach (string o in operatoren)
            {
                operatorenList.Add(o);
            }

            return operatorenList;
        }

        static string KlammerRechner(string eingabe)
        {
            double ergebnis;
            List<double> zahlen;
            List<string> operatoren;
            string klammerAufgabe;
            string ergebnisString;
            string eingabeOhneKlammern;
            string zwischenEingabeOhneKlammern = eingabe;
            List<string> klammerMatch = KlammerFilter(zwischenEingabeOhneKlammern);

            if (klammerMatch.Count == 0)
            {
                return eingabe;
            }

            do
            {
                klammerMatch = KlammerFilter(zwischenEingabeOhneKlammern);
                klammerAufgabe = klammerMatch[0].Substring(1, klammerMatch[0].Length - 2);
                zwischenEingabeOhneKlammern = ProzentRechner(zwischenEingabeOhneKlammern);
                zahlen = ZahlenFilter(klammerAufgabe);
                operatoren = OperatorFilter(klammerAufgabe);
                var punktVorStrichErgebnis = PunktVorStrichRechner(operatoren, zahlen);
                zahlen = punktVorStrichErgebnis.Item2;
                operatoren = punktVorStrichErgebnis.Item1;

                ergebnis = RechnerAusfuehren(zahlen, operatoren);
                ergebnisString = ergebnis.ToString();
                zwischenEingabeOhneKlammern = zwischenEingabeOhneKlammern.Replace(klammerMatch[0], ergebnisString);
                klammerMatch.Clear();

                klammerMatch = KlammerFilter(zwischenEingabeOhneKlammern);

            } while (klammerMatch.Count != 0);

            eingabeOhneKlammern = zwischenEingabeOhneKlammern;

            return eingabeOhneKlammern;
        }

        static Tuple<List<string>, List<double>> PunktVorStrichRechner(List<string> operatoren, List<double> zahlen)
        {
            int hochzeichenIndex;
            int multiplikationszeichenIndex;
            int geteiltzeichenIndex;
            int mdzeichenIndex;
            int fakIndex;

            fakIndex = operatoren.IndexOf("!");

            while (!fakIndex.Equals(-1))
            {
                zahlen[fakIndex] = RechnerSimpel(zahlen[fakIndex], 0, operatoren[fakIndex]);
                operatoren.RemoveAt(fakIndex);


                fakIndex = operatoren.IndexOf("!");
            }

            hochzeichenIndex = operatoren.IndexOf("^");

            while (!hochzeichenIndex.Equals(-1))
            {
                zahlen[hochzeichenIndex] = RechnerSimpel(zahlen[hochzeichenIndex], zahlen[hochzeichenIndex + 1], operatoren[hochzeichenIndex]);
                zahlen.RemoveAt(hochzeichenIndex + 1);
                operatoren.RemoveAt(hochzeichenIndex);


                hochzeichenIndex = operatoren.IndexOf("^");
            }

            multiplikationszeichenIndex = operatoren.IndexOf("*");
            geteiltzeichenIndex = operatoren.IndexOf("/");
            mdzeichenIndex = operatoren.IndexOf("md");

            while (!multiplikationszeichenIndex.Equals(-1) || !geteiltzeichenIndex.Equals(-1) || !mdzeichenIndex.Equals(-1))
            {
                if (((multiplikationszeichenIndex < geteiltzeichenIndex && multiplikationszeichenIndex != -1) || geteiltzeichenIndex.Equals(-1)) && ((multiplikationszeichenIndex < mdzeichenIndex && multiplikationszeichenIndex != -1) || mdzeichenIndex.Equals(-1)))
                {
                    zahlen[multiplikationszeichenIndex] = RechnerSimpel(zahlen[multiplikationszeichenIndex], zahlen[multiplikationszeichenIndex + 1], operatoren[multiplikationszeichenIndex]);
                    zahlen.RemoveAt(multiplikationszeichenIndex + 1);
                    operatoren.RemoveAt(multiplikationszeichenIndex);
                }

                if (((geteiltzeichenIndex < multiplikationszeichenIndex && geteiltzeichenIndex != -1) || multiplikationszeichenIndex.Equals(-1)) && ((geteiltzeichenIndex < mdzeichenIndex && geteiltzeichenIndex != -1) || mdzeichenIndex.Equals(-1)))
                {
                    zahlen[geteiltzeichenIndex] = RechnerSimpel(zahlen[geteiltzeichenIndex], zahlen[geteiltzeichenIndex + 1], operatoren[geteiltzeichenIndex]);
                    zahlen.RemoveAt(geteiltzeichenIndex + 1);
                    operatoren.RemoveAt(geteiltzeichenIndex);
                }

                if (((mdzeichenIndex < multiplikationszeichenIndex && mdzeichenIndex != -1) || multiplikationszeichenIndex.Equals(-1)) && ((mdzeichenIndex < geteiltzeichenIndex && mdzeichenIndex != -1) || geteiltzeichenIndex.Equals(-1)))
                {
                    zahlen[mdzeichenIndex] = RechnerSimpel(zahlen[mdzeichenIndex], zahlen[mdzeichenIndex + 1], operatoren[mdzeichenIndex]);
                    zahlen.RemoveAt(mdzeichenIndex + 1);
                    operatoren.RemoveAt(mdzeichenIndex);
                }

                multiplikationszeichenIndex = operatoren.IndexOf("*");
                geteiltzeichenIndex = operatoren.IndexOf("/");
                mdzeichenIndex = operatoren.IndexOf("md");
            }

            var tupleReturn = new Tuple<List<string>, List<double>>(operatoren, zahlen);
            return tupleReturn;
        }

        static double RechnerSimpel(double zahl1, double zahl2, string operatoro)
        {
            switch(operatoro)
            {
                case "+":
                
                    return zahl1 + zahl2;

                case "-":
                
                    return zahl1 - zahl2;

                case "*":
                
                    return zahl1 * zahl2;

                case "/":

                    return zahl1 / zahl2;

                case "md":

                    return zahl1 % zahl2;

                case "^":

                    return Math.Pow(zahl1, zahl2);

                case "!":
                    List<double> zahlen;
                    List<string> operatoren;
                    string stirling = "(n/e)^n*√(2*π*n)*(1+1/(12*n))";
                    stirling = replacer(stirling);
                    stirling = stirling.Replace("n", zahl1.ToString());
                    stirling = KlammerRechner(stirling);
                    stirling = trigonometrieRechner(stirling);
                    zahlen = ZahlenFilter(stirling);
                    operatoren = OperatorFilter(stirling);
                    var punktVorStrichErgebnis = PunktVorStrichRechner(operatoren, zahlen);
                    zahlen = punktVorStrichErgebnis.Item2;
                    operatoren = punktVorStrichErgebnis.Item1;

                    return RechnerAusfuehren(zahlen, operatoren);

                default:
                    throw new ArgumentException("wrong operator");
            }
        }

        static double RechnerAusfuehren(List<double> zahlen, List<string> operatoren)
        {
            int n = 2;
            int operatorenZahl = operatoren.Count;
            double zwischenergebnis;


            if (zahlen.Count == 0)
            {
                throw new ArgumentOutOfRangeException("error");
            }
            if (operatorenZahl == 0)
            {
                return zahlen[0];
            }


            zwischenergebnis = RechnerSimpel(zahlen[0], zahlen[1], operatoren[0]);

            if (operatorenZahl < 2)
            {
                return zwischenergebnis;
            }
            foreach (string o in operatoren.Skip(1))
            {
                zwischenergebnis = RechnerSimpel(zwischenergebnis, zahlen[n], o);
                n++;
            }

            return zwischenergebnis;
        }
    }
}
