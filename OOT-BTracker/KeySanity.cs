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
        Items items;
        private static int height = 443;
        private Dungeons ditems;
        List<Button> buttons = new List<Button>();
        private float ausblend = 0.5F, einblend = 2F;
        public KeySanity(main sender)
        {
            parent = sender;
            items = parent.loaditems;
            ditems = parent.dungeonitem;
            tracker = parent.Instance_ItemTracker();
            Init_Items();
        }

        public void Init_Items()
        {
            //Init_Keys_Dungeons();
            Init_Text_Dungeons();
            Init_Buttons();
        }

        private void Init_Text_Dungeons()
        {
            for(int i = 0; i < ditems.output.dungeons.Count(); i++)
            {
                string dungeonlbl = ditems.output.dungeons[i].shortname;
                int red = ditems.output.dungeons[i].red;
                int green = ditems.output.dungeons[i].green;
                int blue = ditems.output.dungeons[i].blue;
                Color dungeoncolor = Color.FromArgb(red, green, blue);

                Create_Label(
                    new Point(5 + (i * 45), height + 5),
                    dungeonlbl,
                    dungeoncolor
                    );
            }
        }
        public void DrawLine(PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen whitepen = new Pen(Color.FromArgb(203, 156, 61), 5);
            //g.DrawLine(whitepen, 0, height, 480, height);
            g.DrawLine(whitepen, 0, 444, 455, 444);

        }

        private void Init_Buttons()
        {
            ResourceManager rm = Resources.ResourceManager;



            for (int i = 0; i < ditems.output.dungeons.Count(); i++)
            {
                string dungeonname = ditems.output.dungeons[i].shortname;
                Boolean isactive = ditems.output.dungeons[i].acitve;
                int keystatus = ditems.output.dungeons[i].status;
                int keymax = ditems.output.dungeons[i].max;
                Boolean hasbigkey = ditems.output.dungeons[i].bk;
                Boolean bigkeystatus = ditems.output.dungeons[i].bkstatus;

                if (isactive)
                {
                    Button kbut = new Button();
                    kbut.Image = (Bitmap)rm.GetObject("key_small");
                    if (dungeonname != "" & keystatus == 0)
                    {
                        kbut.Image = SetImageOpacity(kbut.Image, ausblend);
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
                    kbut.Font = new Font(parent.pfc.Families[0], 8.0F, FontStyle.Regular);
                    kbut.TextAlign = ContentAlignment.BottomRight;
                    kbut.MouseDown += new MouseEventHandler(kbuttons);
                    parent.Controls.Add(kbut);
                    buttons.Add(kbut);
                }

                if(hasbigkey)
                {
                    Button bbut = new Button();
                    bbut.Image = (Bitmap)rm.GetObject("key_boss");
                    if (dungeonname == "GF")
                    {
                        bbut.Image = (Bitmap)rm.GetObject("membership");
                        bigkeystatus = tracker.Get_GF();
                        ditems.output.dungeons[i].bkstatus = bigkeystatus;
                    }
                    if (dungeonname != "" & !bigkeystatus)
                    {
                        bbut.Image = SetImageOpacity(bbut.Image, ausblend);
                    }
                        bbut.Tag = i;
                    bbut.Size = new Size(40, 40);
                    bbut.Location = new Point(5 + (i * 45), height + 80);
                    bbut.FlatStyle = FlatStyle.Flat;
                    bbut.FlatAppearance.BorderSize = 0;
                    bbut.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    bbut.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    bbut.Font = new Font(parent.pfc.Families[0], 8.0F, FontStyle.Regular);
                    bbut.MouseDown += new MouseEventHandler(bbuttons);
                    parent.Controls.Add(bbut);
                    buttons.Add(bbut);
                }
            }
        }

        private void kbuttons(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int pos = Convert.ToInt32(button.Tag);
            string dungeonname = ditems.output.dungeons[pos].shortname;
            int keystatus = ditems.output.dungeons[pos].status;
            int keymax = ditems.output.dungeons[pos].max;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (keystatus)
                    {
                        case 0:
                            button.Image = SetImageOpacity(button.Image, einblend);
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
                            button.Image = SetImageOpacity(button.Image, ausblend);
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

            ditems.output.dungeons[pos].status = keystatus;
        }
        private void bbuttons(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int pos = Convert.ToInt32(button.Tag);
            string dungeonname = ditems.output.dungeons[pos].shortname;
            Boolean bigkeystatus = ditems.output.dungeons[pos].bkstatus;

            switch(e.Button)
            {
                case MouseButtons.Left:
                    if(!bigkeystatus)
                    {
                        bigkeystatus = !bigkeystatus;
                        button.Image = SetImageOpacity(button.Image, einblend);
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
                        button.Image = SetImageOpacity(button.Image, ausblend);
                        if (dungeonname == "GF")
                        {
                            tracker.Set_GF(bigkeystatus);
                        }
                    }
                    break;
            }

            ditems.output.dungeons[pos].bkstatus = bigkeystatus;
        }
        private void Create_Label(Point p, string t, Color c)
        {
            Label l = new Label();
            l.Location = p;
            l.Text = t;
            l.Font = new Font(parent.pfc.Families[0], 8F); ;
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
            for (int i = 0; i < ditems.output.dungeons.Count(); i++)
            {
                string dungeonnames = ditems.output.dungeons[i].shortname;
                Boolean bigkeystatus = ditems.output.dungeons[i].bkstatus;
                if (dungeonnames == "GF")
                {
                    if (active)
                    {
                        ditems.output.dungeons[i].bkstatus = true;
                        buttons[i].Image = SetImageOpacity(buttons[i].Image, einblend);
                    }
                    else
                    {
                        ditems.output.dungeons[i].bkstatus = false;
                        buttons[i].Image = SetImageOpacity(buttons[i].Image, ausblend);
                    }
                }
            }
        }

        public void KeySanity_Terminate()
        {
        }
    }
}
