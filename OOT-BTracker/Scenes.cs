using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOT_BTracker
{
    public class Scenes
    {
        public ScenesRoot output
        {
            get;
            set;
        }

        public Scenes()
        {
            string url = "../../Configs/Scenes.json";

            output = JsonConvert.DeserializeObject<ScenesRoot>(File.ReadAllText(url));
        }
    }
    public class Actor
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public bool tracked { get; set; }
    }

    public class Condition
    {
        public string item { get; set; }
    }

    public class Entrance
    {
        public int id { get; set; }
        public int room { get; set; }
        public string name { get; set; }    
    }

    public class Room
    {
        public int id { get; set; }
        public List<Condition> condition { get; set; }
        public List<Actor> actors { get; set; }
    }

    public class ScenesRoot
    {
        public List<Scene> Scenes { get; set; }
    }

    public class Scene
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Entrance> entrances { get; set; }
        public List<Room> room { get; set; }
    }

}
