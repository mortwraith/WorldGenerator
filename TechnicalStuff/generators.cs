using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class generators
    {
        private static Random rand = new Random();
        static public string general(string fileName)
        {
            if (!fileName.Contains("."))
            {
                fileName += ".txt";
            }
            StreamReader sr = new StreamReader(@"..\..\genFiles\" +  fileName);
            int line;
            List<string> strValues = new List<string>(100);
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            line = rand.Next(strValues.Count);
            sr.Close();
            return strValues[line];
        }

        static public string handOfCards()
        {
            string output = "";
            StreamReader sr = new StreamReader(@"..\..\genFiles\Cards.txt");
            int cardLine;
            List<string> strValues = new List<string>(100);
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            cardLine = rand.Next(strValues.Count);
            output = strValues[cardLine] + "\n";
            strValues.RemoveAt(cardLine);
            for (int i = 0; i < 4; i++)
            {
                cardLine = rand.Next(strValues.Count);
                output += strValues[cardLine] + "\n";
                strValues.RemoveAt(cardLine);
            }
            strValues.Clear();
            sr.Close();
            return output;
        }

        static public string generateCreature()
        {
            StreamReader sr = new StreamReader(@"..\..\genFiles\adjs.txt");
            int cardLine;
            List<string> strValues = new List<string>(100);
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            cardLine = rand.Next(strValues.Count);
            string output = strValues[cardLine];
            strValues.Clear();
            sr.Close();

            sr = new StreamReader(@"..\..\genFiles\creature.txt");
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            cardLine = rand.Next(strValues.Count);
            output += strValues[cardLine];
            strValues.Clear();
            sr.Close();
            return output;
        }

        static public string generateModifiedIntelligentCreature()
        {
            StreamReader sr = new StreamReader(@"..\..\genFiles\adjs.txt");
            int cardLine;
            List<string> strValues = new List<string>(100);
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            cardLine = rand.Next(strValues.Count);
            string output = strValues[cardLine];
            strValues.Clear();
            sr.Close();

            sr = new StreamReader(@"..\..\genFiles\races.txt"); 
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            cardLine = rand.Next(strValues.Count);
            output += strValues[cardLine];
            strValues.Clear();
            sr.Close();
            return output;
        }

        static public string generateIntelligentCreature()
        {
            int cardLine;
            List<string> strValues = new List<string>(100);
            StreamReader sr = new StreamReader(@"..\..\genFiles\races.txt");
            for (int i = 0; sr.Peek() != -1; i++)
            {
                strValues.Add(sr.ReadLine());
            }
            cardLine = rand.Next(strValues.Count);
            String output = strValues[cardLine];
            strValues.Clear();
            sr.Close();
            return output;
        }

        static public string generateTreasure()
        {
            int choice = rand.Next(1, 9);
            StreamReader sr = new StreamReader(@"..\..\genFiles\itemAdj.txt");
            int cardLine;
            string output;
            List<string> strValues = new List<string>(100);
            if (choice == 1 || choice == 3 || choice == 7)
            {
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output = strValues[cardLine];
                strValues.Clear();
                sr.Close();

                sr = new StreamReader(@"..\..\genFiles\items.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output += strValues[cardLine];
                strValues.Clear();
                sr.Close();
            }
            else if (choice == 2 || choice == 4 || choice == 8)
            {
                sr = new StreamReader(@"..\..\genFiles\items.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output = strValues[cardLine];
                strValues.Clear();
                sr.Close();

                sr = new StreamReader(@"..\..\genFiles\itemSuff.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output += strValues[cardLine];
                strValues.Clear();
                sr.Close();
            }
            else if (choice == 6)
            {
                sr = new StreamReader(@"..\..\genFiles\items.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output = strValues[cardLine];
                strValues.Clear();
                sr.Close();
            }
            else if (choice == 5)
            {
                sr = new StreamReader(@"..\..\genFiles\itemAdj.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output = strValues[cardLine];
                strValues.Clear();
                sr.Close();

                sr = new StreamReader(@"..\..\genFiles\items.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output += strValues[cardLine];
                strValues.Clear();
                sr.Close();

                sr = new StreamReader(@"..\..\genFiles\itemSuff.txt");
                for (int i = 0; sr.Peek() != -1; i++)
                {
                    strValues.Add(sr.ReadLine());
                }
                cardLine = rand.Next(strValues.Count);
                output += strValues[cardLine];
                strValues.Clear();
                sr.Close();
            }
            else
            {
                output = "This is broken. Please tell the developer." + choice;
            }
            return output;
        }
    }
}
