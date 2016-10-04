using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class building
    {
        public string desc { get; set; }
        public string NPC { get; set; }
        public int rooms { get; set; }
        public int type { get; set; }
        public int baseCost { get; set; }
        public List<string> people { get; set; }
        private static Random rand = new Random();


        /// <summary>
        /// Initializes a new instance of the <see cref="building"/> class.
        /// </summary>
        /// <param name="size">The size of the building.</param>
        /// <param name="mon">The base amount of money.</param>
        public building(int size = 1, int mon = 100)
        {
            rooms = size;
            desc = generators.general("roomDesc.txt");
            baseCost = mon;
            type = rand.Next(0, 6);
            switch (type)
            {
                case 0: //general building
                    people = new List<string>(5);
                    for (int i = 0; i < rand.Next(6); i++)
                    {
                        if (i > 0 && rand.Next(5) == 0)
                        {
                            people.Add(generators.general("names.txt") + " " + people[rand.Next(i)].Split(' ').Last());
                        }
                        else
                        {
                            people.Add(generators.general("names.txt") + " " + generators.general("npcSurnames.txt"));
                        }
                    }
                    break;
                case 1: //inn
                    break;
                case 2: //temple
                    break;
                case 3: //governmental building
                    break;
                case 4: //smithy
                    break;
                case 5: //bakery
                default:
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="building"/> class.
        /// </summary>
        /// <param name="t">The type of building(0=residence,1=inn,2=temple,3=gov,4=smith,5=bake).</param>
        /// <param name="size">The size of the building.</param>
        /// <param name="mon">The base amount of money.</param>
        public building(int t, int size = 1, int mon = 100)
        {
            rooms = size;
            desc = generators.general("roomDesc.txt");
            baseCost = mon;
            type = t;
            switch (type)
            {
                case 0: //general building
                    people = new List<string>(5);
                    for (int i = 0; i < rand.Next(6); i++)
                    {
                        if (i > 0 && rand.Next(5) == 0)
                        {
                            people.Add(generators.general("names.txt") + " " + people[rand.Next(i)].Split(' ').Last());
                        }
                        else
                        {
                            people.Add(generators.general("names.txt") + " " + generators.general("npcSurnames.txt"));
                        }
                    }
                    break;
                case 1: //inn
                    break;
                case 2: //temple
                    break;
                case 3: //governmental building
                    break;
                case 4: //smithy
                    break;
                case 5: //bakery
                default:
                    break;
            }
        }
        
        public override string ToString()
        {
            string output = "";

            output += "This building is " + desc + ".\n";
            if (rooms != 1)
            {
                output += "It has " + rooms + " rooms."; 
            }
            else
            {
                output += "It has " + rooms + " room.";
            }

            if (people != null)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    output += "\n\t" + people[i] + " lives here.";
                }
            }
            
            output += "\n";
             
            return output; 
        }
    }
}