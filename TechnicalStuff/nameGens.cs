using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class nameGens
    {
        //everything here based off of javascript from http://donjon.bin.sh/code/name/name_generator.js
/*

        List<string> name_set = new List<string>(100);
        List<string> chain_chace = new List<string>(100);

        public string generate_name(int type)
        {
            int chain = markov_chain(type);
            if (chain != -1)
            {
                return markov_name(chain);
            }
            return "";
        }


        private List<string> name_list(type, n_of)
        {
            var list = [];

            var i; for (i = 0; i < n_of; i++)
            {
                list.push(generate_name(type));
            }
            return list;
        }


        private int markov_chain(int type)
        {
            var chain; if (chain = chain_cache[type])
            {
                return chain;
            }
            else {
                var list; if (list = name_set[type])
                {
                    var chain; if (chain = construct_chain(list))
                    {
                        chain_cache[type] = chain;
                        return chain;
                    }
                }
            }
            return false;
        }

        private Dictionary<string,string> construct_chain(List<string> list)
        {
            Dictionary<string,string> chain = new Dictionary<string, string>();

            for (int i = 0; i < list.Count; i++)
            {
                List<string> names = list[i].Split(/\s +/);
                chain = incr_chain(chain, "parts", names.Count);

                var j; for (j = 0; j < names.Count; j++)
                {
                    var name = names[j];
                    chain = incr_chain(chain, "name_len", name.Count);

                    var c = name.Substring(0, 1);
                    chain = incr_chain(chain, "initial", c);

                    var str = name.Substring(1);
                    var last_c = c;

                    while (str.Count() > 0)
                    {
                        var c = str.Substring(0, 1);
                        chain = incr_chain(chain, last_c, c);

                        str = str.Substring(1);
                        last_c = c;
                    }
                }
            }
            return scale_chain(chain);
        }

        private Dictionary<string,string> incr_chain(Dictionary<string,string> chain,string key,string token)
        {
            if (chain[key])
            {
                if (chain[key][token])
                {
                    chain[key][token]++;
                }
                else {
                    chain[key][token] = 1;
                }
            }
            else {
                chain[key] = { };
                chain[key][token] = 1;
            }
            return chain;
        }

        private int scale_chain(int chain)
        {
            var table_len = { };

            var key; for (key in chain)
            {
                table_len[key] = 0;

                var token; for (token in chain[key])
                {
                    var count = chain[key][token];
                    var weighted = Math.floor(Math.pow(count, 1.3));

                    chain[key][token] = weighted;
                    table_len[key] += weighted;
                }
            }
            chain["table_len"] = table_len;
            return chain;
        }

        private string markov_name(int chain)
        {
            var parts = select_link(chain, "parts");
            var names = [];

            var i; for (i = 0; i < parts; i++)
            {
                var name_len = select_link(chain, "name_len");
                var c = select_link(chain, "initial");
                var name = c;
                var last_c = c;

                while (name.length < name_len)
                {
                    c = select_link(chain, last_c);
                    name += c;
                    last_c = c;
                }
                names.push(name);
            }
            return names.join(" ");
        }
        private string select_link(int chain, string key)
        {
            var len = chain["table_len"][key];
            var idx = Math.floor(Math.random() * len);

            var t = 0; for (token in chain[key])
            {
                t += chain[key][token];
                if (idx < t) { return token; }
            }
            return "-";
        }
        */
    }
}
