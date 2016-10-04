using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class dungeon : PointOfIntrest
    {
        public int amtRooms { get; set; }
        private static Random rand = new Random();
        public List<room> rooms { get; set; }
        private string type;
        private string style;

        public dungeon(int amtRooms,int amtMon = 100)
        {
            style = generators.general("artStyles.txt");
            type = generators.general("dungeonTypes.txt");
            this.amtRooms = amtRooms;
            rooms = new List<room>(20);
            for (int i = 0; i < amtRooms; i++)
            {
                room r = new room(0, amtRooms, amtMon);
                rooms.Add(r);
            }
            if (amtRooms != 0)
            {
                rooms[amtRooms - 1] = new room(2, amtRooms, amtMon); 
            }
            if (amtRooms >= 5)
            {
                rooms[rand.Next(amtRooms - 2)] = new room(1, amtRooms, amtMon);
                rooms[rand.Next(amtRooms - 2)] = new room(3, amtRooms, amtMon);
                rooms[rand.Next(amtRooms - 2)] = new room(3, amtRooms, amtMon);
                rooms[rand.Next(amtRooms - 2)] = new room(4, amtRooms, amtMon);
                rooms[rand.Next(amtRooms - 2)] = new room(4, amtRooms, amtMon);
            }
            else if (amtRooms > 2)
            {
                rooms[rand.Next(amtRooms - 2)] = new room(1, amtRooms, amtMon);
                rooms[rand.Next(amtRooms - 2)] = new room(3, amtRooms, amtMon);
            }
            if (rooms.Count > 1)
            {
                rooms[rand.Next(amtRooms - 2)].hasExit = true; 
            }
            for (int i = 0; i < rooms.Count; i++)
            {
                    for (int j = 0; j < rooms[i].amtDoor && rooms[i].connections.Count < rooms[i].amtDoor +1 && rooms.Count != 1; j++)
                    {
                        int add = rand.Next(0, amtRooms);
                        while (add == i || rooms[i].connections.Contains(add))
                        {
                            add = rand.Next(0, amtRooms);
                        }
                    if (!rooms[i].connections.Contains(add+1))
                    {
                        rooms[i].connections.Add(add + 1); 
                    }
                    if (!rooms[add].connections.Contains(i + 1))
                    {
                        rooms[add].connections.Add(i + 1); 
                    }
                }              
            }
        }

        public override string ToString()
        {
            return rooms[rooms.Count - 1].boss.Split(' ')[0] + "\'s " + type;
        }

        public override string getInfo() { 
            string output = "This dungeon is a " + type + " in the " + style + " style. ";
            output += "It has " + amtRooms + " rooms.";
            for (int i = 1; i < amtRooms + 1; i++)
            {
                output += "\n\nRoom " + i + ":";
                output += rooms[i-1].ToString();
                output += "\n";
                if (rooms[i-1].connections.Count > 2)
                {
                    output += "It is connected to rooms ";
                    for (int j = 0; j < rooms[i - 1].connections.Count - 1; j++)
                    {
                        output += rooms[i - 1].connections[j] + ", ";
                    }
                    output += "and " + rooms[i - 1].connections.Last() + ". "; 
                }
                else if (rooms[i - 1].connections.Count > 1)
                {
                    output += "It is connected to rooms ";
                    for (int j = 0; j < rooms[i - 1].connections.Count - 1; j++)
                    {
                        output += rooms[i - 1].connections[j];
                    }
                    output += " and " + rooms[i - 1].connections.Last() + ". ";
                }
                else if (rooms.Count != 1)
                {
                    output += "It is connected to room ";
                    output += rooms[i - 1].connections.Last() + ". ";
                }
            }
            return output;
        }
    }
}
