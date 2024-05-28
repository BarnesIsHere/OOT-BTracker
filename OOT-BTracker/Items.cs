using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using System.Windows.Forms;

namespace OOT_BTracker
{
    public class Item
    {
        public string name { get; set; }
        public int pos { get; set; }
        public int status { get; set; }
        public bool uncheck { get; set; }
        public int type { get; set; }
        public string text { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public List<Picture> pictures { get; set; }
    }

    public class Picture
    {
        public string name { get; set; }
    }

    public class OOTItems
    {
        public List<Item> items { get; set; }
    }

    public class Items
    {
        public OOTItems output
        {
            get;
            set;
        }

        public Items()
        {
            string url = "../../Items.json";

            //output = JsonConvert.DeserializeObject<OOTItems>(File.ReadAllText(url));
           }
    }
}