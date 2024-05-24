using OOT_BTracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOT_BTracker
{
    public class MapTracker
    {
        main parent;
        public MapTracker(main p) 
        {
            double width = 740;
            double height = width * 0.5625;

            this.parent = p;
            parent.Size = new Size(parent.Width + 750, parent.Height + 400);
            parent.MinimumSize = new Size(parent.Width + 750, parent.Height + 400);
            parent.MaximumSize = new Size(parent.Width, parent.Height);

            ResourceManager rm = Resources.ResourceManager;
            PictureBox map = new PictureBox();
            map.Image = (Bitmap)rm.GetObject("hyrule");
            map.Size = new Size((int)width, (int)height);
            map.Location = new Point(460, 10);
            map.SizeMode = PictureBoxSizeMode.Zoom;
            parent.Controls.Add(map);
        }
    }
}
