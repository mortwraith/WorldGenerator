using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class room
    {
        public int type { get; set; }
        public int amtMon { get; set; }
        public int amtTreas { get; set; }
        public int amtDoor { get; set; }
        public int amtCreat { get; set; }
        public List<string> treasures { get; set; }
        public List<string> creatures { get; set; }
        public List<int> connections { get; set; }
        public bool hasBoss { get; set; }
        public bool hasExit { get; set; }
        public string boss { get; set; }
        public string style { get; set; }
        public string desc { get; set; }
        public string MyProperty { get; set; }
        private static Random rand = new Random();

        public room(int type, int amtRooms, int mon)
        {
            connections = new List<int>(20);
            this.type = type;
            hasBoss = false;
            desc = generators.general("roomDesc.txt");
            amtDoor = rand.Next(1, amtRooms);
            switch (type)
            {
                case 0: //general
                    style = generators.general("roomStyles.txt");
                    amtCreat = rand.Next(0, 6);
                    amtTreas = rand.Next(0, 2);
                    amtMon = rand.Next(0, mon);
                    break;
                case 1: //jail
                    style = generators.general("jailRooms.txt");
                    amtCreat = rand.Next(1, 9);
                    break;
                case 2: //boss
                    style = generators.general("bossRooms.txt");
                    hasBoss = true;
                    hasExit = true;
                    if (rand.Next(2) == 1)
                    {
                        boss = generators.general("demonNames.txt");
                        boss += " the demon";
                    }
                    else
                    {
                        boss = generators.general("bossNames.txt") + " ";
                        boss += generators.general("bossDesc.txt");
                    }
                    amtCreat = rand.Next(0, 3);
                    break;
                case 3: //treasure
                    style = generators.general("treasureRooms.txt");
                    amtCreat = rand.Next(0, 3);
                    amtTreas = rand.Next(2,5);
                    amtMon = rand.Next(mon/2, (int)(mon*2.5));
                    break;
                case 4: //shrine
                    style = generators.general("shrineRooms.txt");
                    amtCreat = rand.Next(1, 4);
                    amtTreas = rand.Next(0, 2);
                    amtMon = rand.Next((int)(mon / 3.0), mon * 2);
                    break;
                default:
                    style = generators.general("roomStyles.txt");
                    amtCreat = 0;
                    amtMon = 0;
                    amtTreas = 0;
                    break;
            }
            creatures = new List<string>(10);
            for (int i = 0; i < amtCreat; i++)
            {
                creatures.Add(generators.generateCreature());
            }
            treasures = new List<string>(10);
            for (int i = 0; i < amtTreas; i++)
            {
                treasures.Add(generators.generateTreasure());

            }
        }

        public override string ToString()
        {
            string output;
            output = "\nThis room is a ";
            output += style + ". The room is ";
            output += desc + ". ";
            if (hasExit)
            {
                output += "This room has an exit for the dungeon.";
            }
            output += " There ";
            switch (type)
            {
                case 0: //general
                    if (amtCreat != 1)
                    {
                        output += "are " + amtCreat + " creatures";
                    }
                    else
                    {
                        output += "is " + amtCreat + " creature";
                    }
                    output += " in the room.";
                    for (int j = 1; j < amtCreat + 1; j++)
                    {
                        output += "\n    - Creature " + j + " is ";
                        if (creatures[j - 1].ElementAt(0) == 'A' || creatures[j - 1].ElementAt(0) == 'E' || creatures[j - 1].ElementAt(0) == 'I' || creatures[j - 1].ElementAt(0) == 'O' || creatures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + creatures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + creatures[j - 1] + ".";
                        }
                    }
                    //end creature gen
                    //start treasure gen
                    output += "\nThere ";
                    if (amtTreas != 1)
                    {
                        output += "are " + amtTreas + " treasures";
                    }
                    else
                    {
                        output += "is " + amtTreas + " treasure";
                    }
                    output += " in the room.";
                    for (int j = 1; j < amtTreas + 1; j++)
                    {
                        output += "\n    - Treasure " + j + " is ";
                        if (treasures[j - 1].ElementAt(0) == 'A' || treasures[j - 1].ElementAt(0) == 'E' || treasures[j - 1].ElementAt(0) == 'I' || treasures[j - 1].ElementAt(0) == 'O' || treasures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + treasures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + treasures[j - 1] + ".";
                        }
                    }
                    break;

                case 1: //jail
                    output += "is a jailor and there ";
                    if (amtCreat > 2)
                    {
                        output += "are " + (amtCreat - 1) + " creatures";
                    }
                    else
                    {
                        output += "is " + (amtCreat-1) + " creature";
                    }
                    output += " caged. \n    + The jailor is a " + creatures[0];
                    for (int j = 2; j < amtCreat + 1; j++)
                    {
                        output += "\n    - Creature " + (j-1) + " is ";
                        if (creatures[j - 1].ElementAt(0) == 'A' || creatures[j - 1].ElementAt(0) == 'E' || creatures[j - 1].ElementAt(0) == 'I' || creatures[j - 1].ElementAt(0) == 'O' || creatures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + creatures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + creatures[j - 1] + ".";
                        }
                    }
                    //end creature gen
                    break;

                case 2:     //boss
                    if (amtCreat != 1)
                    {
                        output += "are " + amtCreat + " guards";
                    }
                    else
                    {
                        output += "is " + amtCreat + " guard";
                    }
                    output += " in the room.";
                    output += " It also contains the dungeon leader, " + boss + ". ";
                    for (int j = 1; j < amtCreat + 1; j++)
                    {
                        output += "\n    - Guard " + j + " is ";
                        if (creatures[j - 1].ElementAt(0) == 'A' || creatures[j - 1].ElementAt(0) == 'E' || creatures[j - 1].ElementAt(0) == 'I' || creatures[j - 1].ElementAt(0) == 'O' || creatures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + creatures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + creatures[j - 1] + ".";
                        }
                    }
                    //end creature gen
                    break;
                case 3:     //treasure
                    if (amtCreat != 1)
                    {
                        output += "are " + amtCreat + " guards";
                    }
                    else
                    {
                        output += "is " + amtCreat + " guard";
                    }
                    output += " in the room.";
                    for (int j = 1; j < amtCreat + 1; j++)
                    {
                        output += "\n    - Guard " + j + " is ";
                        if (creatures[j - 1].ElementAt(0) == 'A' || creatures[j - 1].ElementAt(0) == 'E' || creatures[j - 1].ElementAt(0) == 'I' || creatures[j - 1].ElementAt(0) == 'O' || creatures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + creatures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + creatures[j - 1] + ".";
                        }
                    }
                    //end creature gen
                    //start treasure gen
                    output += "\nThere ";
                    if (amtTreas != 1)
                    output += "are " + amtTreas + " treasures";
                    output += " and " + amtMon + " gold in the room. ";
                    for (int j = 1; j < amtTreas + 1; j++)
                    {
                        output += "\n    - Treasure " + j + " is ";
                        if (treasures[j - 1].ElementAt(0) == 'A' || treasures[j - 1].ElementAt(0) == 'E' || treasures[j - 1].ElementAt(0) == 'I' || treasures[j - 1].ElementAt(0) == 'O' || treasures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + treasures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + treasures[j - 1] + ".";
                        }
                    }
                    break;
                case 4: //shrine
                    output += "is a high priest and there ";
                    if (amtCreat > 2)
                    {
                        output += "are " + (amtCreat - 1) + " acolytes";
                    }
                    else
                    {
                        output += "is " + (amtCreat - 1) + " acolyte";
                    }
                    output += " worshiping. \n    + The high priest is a " + creatures[0];
                    for (int j = 2; j < amtCreat + 1; j++)
                    {
                        output += "\n    - Acolyte " + (j - 1) + " is ";
                        if (creatures[j - 1].ElementAt(0) == 'A' || creatures[j - 1].ElementAt(0) == 'E' || creatures[j - 1].ElementAt(0) == 'I' || creatures[j - 1].ElementAt(0) == 'O' || creatures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + creatures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + creatures[j - 1] + ".";
                        }
                    }
                    //end creature gen
                    //start treasure gen
                    output += "\nThere ";
                    if (amtTreas != 1)
                    {
                        output += "are " + amtTreas + " treasures";
                    }
                    else
                    {
                        output += "is " + amtTreas + " treasure";
                    }
                    output += " and " + amtMon + " gold being offered to the god. ";
                    for (int j = 1; j < amtTreas + 1; j++)
                    {
                        output += "\n    - Treasure " + j + " is ";
                        if (treasures[j - 1].ElementAt(0) == 'A' || treasures[j - 1].ElementAt(0) == 'E' || treasures[j - 1].ElementAt(0) == 'I' || treasures[j - 1].ElementAt(0) == 'O' || treasures[j - 1].ElementAt(0) == 'U')
                        {
                            output += "an " + treasures[j - 1] + ".";
                        }
                        else
                        {
                            output += "a " + treasures[j - 1] + ".";
                        }
                    }
                    break;

                default:
                    break;
            }
            return output;
        }
    }
}
