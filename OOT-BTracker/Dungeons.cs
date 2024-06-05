using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Drawing;

namespace OOT_BTracker
{
    public class Dungeon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
        public bool acitve { get; set; }
        public int status { get; set; }
        public int max { get; set; }
        public bool bk { get; set; }
        public bool bkstatus { get; set; }
        public int posx { get; set; }
        public int posy { get; set; }
        public bool showmap {  get; set; }
    }

    public class OOTDungeons
    {
        public List<Dungeon> dungeons { get; set; }
    }

    public class Dungeons
    {
        
        public OOTDungeons output
        {
            get;
            set;
        }

        public Dungeons()
        {
            string url = "../../Configs/Dungeons.json";

            output = JsonConvert.DeserializeObject<OOTDungeons>(File.ReadAllText(url));
        }
    }
}
