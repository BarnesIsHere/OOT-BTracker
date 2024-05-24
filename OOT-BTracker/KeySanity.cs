using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Resources;
using OOT_BTracker.Properties;
using System.Drawing.Imaging;

namespace OOT_BTracker
{
    public class KeySanity
    {
        main parent;
        ItemTracker tracker;
        private List<ArrayList> keys;
        private static int height = 443;
        public KeySanity(main sender)
        {
            parent = sender;
            tracker = parent.Instance_ItemTracker();
            Init_Items();
        }

        private void Init_Items()
        {
            // DrawLine(parent.Height, 0, parent.Height+5, parent.Width);
            parent.Size = new Size(parent.Width, parent.Height + 125);
            parent.MinimumSize = new Size(parent.Width, parent.Height + 125);
            parent.MaximumSize = new Size(parent.Width, parent.Height);


            Init_Keys_Dungeons();
        }
        public void DrawLine(PaintEventArgs e)
        {
                Graphics g = e.Graphics;
                Pen whitepen = new Pen(Color.FromArgb(203,156,61), 5);
                g.DrawLine(whitepen, 0, height , 480, height);
        }

        private void Init_Text_Dungeons()
        {
            for(int i = 0; i < keys.Count; i++)
            {
                string dungeonname = keys[i][0].ToString();
                Color dungeoncolor = (Color)keys[i][1];

                Create_Label(
                    new Point(5 + (i * 45), height + 5),
                    dungeonname,
                    dungeoncolor
                    );
            }
        }

        private void Init_Keys_Dungeons()
        {
            keys = new List<ArrayList>();

            List<string> dungeonname = new List<string>(); // Welcher Dungeon
            List<Color> dungeoncolor = new List<Color>(); // Welche Farbe zugewiesen der Dungeon
            List<Boolean> isactive = new List<Boolean>(); // Ob Aktiv (Für Später, da Anfangs TCG immer nicht aktiv
            List<int> keystatus = new List<int>(); // Wieviele Schlüssel haben wir
            List<int> keymax = new List<int>(); // Wieviele Schlüssel gibt es
            List<Boolean> hasbigkey = new List<Boolean>(); // Gibt es hier einen Big Key // Gerudo member Card zählen wir mal auch als einen
            List<Boolean> bigkeystatus = new List<Boolean>(); // haben wir den Bigkey gefunden

            dungeonname.Add("FoT");
            dungeoncolor.Add(Color.FromArgb(27, 241, 27));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(6);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("FiT");
            dungeoncolor.Add(Color.FromArgb(255, 60, 60));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(8);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("WT");
            dungeoncolor.Add(Color.FromArgb(124, 182, 255));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(6);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("Sht");
            dungeoncolor.Add(Color.FromArgb(217, 103, 253));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(6);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("Spt");
            dungeoncolor.Add(Color.FromArgb(255, 205, 113));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(7);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("BotW");
            dungeoncolor.Add(Color.FromArgb(255, 153, 255));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(3);
            hasbigkey.Add(false);
            bigkeystatus.Add(false);

            dungeonname.Add("GF");
            dungeoncolor.Add(Color.FromArgb(255, 180, 116));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(4);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("GTG");
            dungeoncolor.Add(Color.FromArgb(255, 255, 164));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(9);
            hasbigkey.Add(false);
            bigkeystatus.Add(false);

            dungeonname.Add("GC");
            dungeoncolor.Add(Color.FromArgb(150, 150, 150));
            isactive.Add(true);
            keystatus.Add(0);
            keymax.Add(3);
            hasbigkey.Add(true);
            bigkeystatus.Add(false);

            dungeonname.Add("TCG");
            dungeoncolor.Add(Color.FromArgb(255, 80, 166));
            isactive.Add(false);
            keystatus.Add(0);
            keymax.Add(6);
            hasbigkey.Add(false);
            bigkeystatus.Add(false);

            for (int i = 0; i < dungeonname.Count; i++)
            {
                ArrayList arraylist = new ArrayList();
                arraylist.Add(dungeonname[i]);
                arraylist.Add(dungeoncolor[i]);
                arraylist.Add(isactive[i]);
                arraylist.Add(keystatus[i]);
                arraylist.Add(keymax[i]);
                arraylist.Add(hasbigkey[i]);
                arraylist.Add(bigkeystatus[i]);

                keys.Add(arraylist);
            }

            Init_Text_Dungeons();
            Init_Buttons();
        }

        private void Init_Buttons()
        {
            ResourceManager rm = Resources.ResourceManager;



            for (int i = 0; i < keys.Count(); i++)
            {
                string dungeonname = keys[i][0].ToString();
                Boolean isactive = (Boolean)keys[i][2];
                int keystatus = (int)keys[i][3];
                int keymax = (int)keys[i][4];
                Boolean hasbigkey = (Boolean)keys[i][5];
                Boolean bigkeystatus = (Boolean)keys[i][6];

                if (isactive)
                {
                    Button kbut = new Button();
                    kbut.Image = (Bitmap)rm.GetObject("key_small");
                    if (dungeonname != "" & keystatus == 0)
                    {
                        kbut.Image = SetImageOpacity(kbut.Image, 0.2F);
                        kbut.ForeColor = Color.DarkGray;
                    }
                    kbut.Tag = i;
                    kbut.Size = new Size(40, 40);
                    kbut.Location = new Point(5 + (i * 45), height + 40);
                    kbut.FlatStyle = FlatStyle.Flat;
                    kbut.FlatAppearance.BorderSize = 0;
                    kbut.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    kbut.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    kbut.Text = keystatus.ToString() + "/" + keymax.ToString();
                    kbut.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);
                    kbut.TextAlign = ContentAlignment.BottomRight;
                    kbut.MouseDown += new MouseEventHandler(kbuttons);
                    parent.Controls.Add(kbut);
                    keys[i].Add(kbut);
                }

                if(hasbigkey)
                {
                    Button bbut = new Button();
                    bbut.Image = (Bitmap)rm.GetObject("key_boss");
                    if (dungeonname == "GF")
                    {
                        bbut.Image = (Bitmap)rm.GetObject("membership");
                        bigkeystatus = tracker.Get_GF();
                        keys[i][6] = bigkeystatus;
                    }
                    if (dungeonname != "" & !bigkeystatus)
                    {
                        bbut.Image = SetImageOpacity(bbut.Image, 0.2F);
                    }
                        bbut.Tag = i;
                    bbut.Size = new Size(40, 40);
                    bbut.Location = new Point(5 + (i * 45), height + 80);
                    bbut.FlatStyle = FlatStyle.Flat;
                    bbut.FlatAppearance.BorderSize = 0;
                    bbut.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    bbut.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    bbut.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);
                    bbut.MouseDown += new MouseEventHandler(bbuttons);
                    parent.Controls.Add(bbut);
                    keys[i].Add(bbut);
                }
            }
        }

        private void kbuttons(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int pos = Convert.ToInt32(button.Tag);
            string dungeonname = keys[pos][0].ToString();
            int keystatus = (int)keys[pos][3];
            int keymax = (int)keys[pos][4];

            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (keystatus)
                    {
                        case 0:
                            button.Image = SetImageOpacity(button.Image, 10F);
                            button.ForeColor = Color.White;
                            keystatus++;
                            button.Text = keystatus.ToString() + "/" + keymax.ToString();
                            break;
                        default:
                            if (keymax != keystatus)
                            {
                                keystatus++;
                                button.Text = keystatus.ToString() + "/" + keymax.ToString();
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch(keystatus)
                    {
                        case 0:
                            break;
                        case 1:
                            button.Image = SetImageOpacity(button.Image, 0.2F);
                            button.ForeColor = Color.DarkGray;
                            keystatus--;
                            button.Text = keystatus.ToString() + "/" + keymax.ToString();
                            break;
                        default:
                            keystatus--;
                            button.Text = keystatus.ToString() + "/" + keymax.ToString();
                            break;
                    }
                    break;
            }

            keys[pos][3] = keystatus;
        }
        private void bbuttons(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int pos = Convert.ToInt32(button.Tag);
            string dungeonname = keys[pos][0].ToString();
            Boolean bigkeystatus = (Boolean)keys[pos][6];

            switch(e.Button)
            {
                case MouseButtons.Left:
                    if(!bigkeystatus)
                    {
                        bigkeystatus = !bigkeystatus;
                        button.Image = SetImageOpacity(button.Image, 10F);
                        if(dungeonname == "GF")
                        {
                            tracker.Set_GF(bigkeystatus);
                        }
                    }
                    break;
                case MouseButtons.Right:
                    if (bigkeystatus)
                    {
                        bigkeystatus = !bigkeystatus;
                        button.Image = SetImageOpacity(button.Image, 0.2F);
                        if (dungeonname == "GF")
                        {
                            tracker.Set_GF(bigkeystatus);
                        }
                    }
                    break;
            }

            keys[pos][6] = bigkeystatus;
        }
        private void Create_Label(Point p, string t, Color c)
        {
            Label l = new Label();
            l.Location = p;
            l.Text = t;
            l.Font = new Font(FontFamily.GenericSansSerif, 9F); ;
            l.ForeColor = c;
            l.Size = new Size(40, 40);
            l.TextAlign = ContentAlignment.MiddleCenter;
            parent.Controls.Add(l);
        }

        private Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public void Set_GF(Boolean active)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                string dungeonnames = keys[i][0].ToString();
                Boolean bigkeystatus = (Boolean)keys[i][6];
                if (dungeonnames == "GF")
                {
                    Button button = (Button)keys[i][8];
                    if (active)
                    {
                        keys[i][6] = true;
                        button.Image = SetImageOpacity(button.Image, 10F);
                    }
                    else
                    {
                        keys[i][6] = false;
                        button.Image = SetImageOpacity(button.Image, 0.2F);
                    }
                }
            }
        }
    }
}
