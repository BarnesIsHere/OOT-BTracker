using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace OOT_BTracker
{
    public class Areas
    {
        public Root output
        {
            get;
            set;
        }

        public Areas()
        {
            string url = "../../Configs/Areas.json";

            output = JsonConvert.DeserializeObject<Root>(File.ReadAllText(url));
        }
    }

    public class Area
    {
        public int id { get; set; }
        public string name { get; set; }
        public int posx { get; set; }
        public int posy { get; set; }
    }

    public class Root
    {
        public List<Area> areas { get; set; }
    }
}
