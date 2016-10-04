using System;
using System.Collections.Generic;

namespace RandomGens
{
    internal class town : PointOfIntrest
    {
        private int amtBuilding;
        private string style;
        private List<building> builds;
        private Random rand = new Random();
        private string name;
        private shop store;

        public town(int amtBuild = 1, int amtMon = 100)
        {
            store = new shop(amtMon, amtBuild);
            int rando;
            style = generators.general("artStyles.txt");
            amtBuilding = amtBuild;
            builds = new List<building>(20);
            for (int i = 0; i < amtBuild; i++)
            {
                building r = new building(0, rand.Next(1,10), amtMon);
                builds.Add(r);
            }
            if (amtBuilding != 0)
            {
                builds[amtBuild - 1] = new building(2, rand.Next(1,10), amtMon);
            }
            if (amtBuilding >= 5)
            {
                builds[rand.Next(amtBuild - 2)] = new building(1, rand.Next(1,10), amtMon);
                builds[rand.Next(amtBuild - 2)] = new building(3, rand.Next(1,10), amtMon);
                builds[rand.Next(amtBuild - 2)] = new building(3, rand.Next(1,10), amtMon);
                builds[rand.Next(amtBuild - 2)] = new building(4, rand.Next(1,10), amtMon);
                builds[rand.Next(amtBuild - 2)] = new building(4, rand.Next(1,10), amtMon);
            }
            else if (amtBuilding > 2)
            {
                builds[rand.Next(amtBuild - 2)] = new building(1, rand.Next(1,10), amtMon);
                builds[rand.Next(amtBuild - 2)] = new building(3, rand.Next(1,10), amtMon);
            }
            rando = rand.Next(0, 5);
            switch (rando)
            {
                case 0:
                    name = generators.general("npcSurnames.txt");
                    break;
                case 1:
                    name = generators.general("warriorSurnames.txt");
                    break;
                case 2:
                    name = generators.general("generalSurnames.txt");
                    break;
                case 3:
                    name = generators.general("names.txt");
                    break;
                case 4:
                    name = generators.general("demonNames.txt");
                    break;
                default:
                    break;
            }
            rando = rand.Next(0, 5);
            switch (rando)
            {
                case 0:
                    break;
                case 1:
                    name += " City";
                    break;
                case 2:
                    name += "burg";
                    break;
                case 3:
                    name += " Town";
                    break;
                case 4:
                    name += "sville";
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return name;
        }

        public override string getInfo() { 
            string output = "This town has " + amtBuilding + " important buildings.";
            output += " In general it is in the " + style + " style.\n";
            for (int i = 1; i < amtBuilding + 1; i++)
            {
                output += "\nBuilding " + i + ":\n";
                output += builds[i - 1].ToString();
            }
            output += "\nThis town also has a shop: ";
            output += "\n" + store.ToString();
            return output;
        }
    }
}