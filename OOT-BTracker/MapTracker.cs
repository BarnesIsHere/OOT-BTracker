using OOT_BTracker.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace OOT_BTracker
{
    public class MapTracker
    {
        main parent;
        Areas areas;
        Items items;
        Dungeons dungeons;
        ToolTip tip = new ToolTip();
        public MapTracker(main p) 
        {
            this.parent = p;
            areas = parent.areas;
            items = parent.loaditems;
            dungeons = parent.dungeonitem;

            parent.Window_Size(2);
        }

        public void Init_Buttons()
        {
            for (int i = 0; i < areas.output.areas.Count(); i++)
            {
                int x = areas.output.areas[i].posx;
                int y = areas.output.areas[i].posy;
                Button tbut = new Button();
                tbut.BackColor = Color.Green;
                tbut.Size = new Size(15, 15);
                tbut.Location = new Point(x, y);
                tbut.BringToFront();
                tbut.FlatStyle = FlatStyle.Flat;
                tbut.FlatAppearance.BorderColor = Color.Black;
                tbut.FlatAppearance.BorderSize = 1;
                tbut.FlatAppearance.MouseOverBackColor = Color.Green;
                tbut.FlatAppearance.MouseDownBackColor = Color.Green;
                tbut.MouseEnter += OnMouseEnterButton;
                tbut.MouseLeave += OnMouseLeaveButton;
                tbut.Tag = areas.output.areas[i].name;
                parent.Controls.Add(tbut);
            }

            for(int i = 0; i < dungeons.output.dungeons.Count(); i++)
            {
                bool showmap = dungeons.output.dungeons[i].showmap;
                int x = dungeons.output.dungeons[i].posx;
                int y = dungeons.output.dungeons[i].posy;
                if (showmap)
                {
                    Button tbut = new Button();
                    tbut.BackColor = Color.Red;
                    tbut.Size = new Size(15, 15);
                    tbut.Location = new Point(x, y);
                    tbut.BringToFront();
                    tbut.FlatStyle = FlatStyle.Flat;
                    tbut.FlatAppearance.BorderColor = Color.Black;
                    tbut.FlatAppearance.BorderSize = 1;
                    tbut.FlatAppearance.MouseOverBackColor = Color.Red;
                    tbut.FlatAppearance.MouseDownBackColor = Color.Red;
                    tbut.MouseEnter += OnMouseEnterButton;
                    tbut.MouseLeave += OnMouseLeaveButton;
                    tbut.Tag = dungeons.output.dungeons[i].name;
                    parent.Controls.Add(tbut);
                }
            }


            double width = 740;
            double height = width * 0.5625;
            ResourceManager rm = Resources.ResourceManager;
            PictureBox map = new PictureBox();
            map.Image = (Bitmap)rm.GetObject("hyrule");
            map.Size = new Size((int)width, (int)height);
            map.Location = new Point(460, 10);
            map.SizeMode = PictureBoxSizeMode.Zoom;
            parent.Controls.Add(map);
        }

        private void OnMouseEnterButton(object sender, EventArgs e)
        {
            tip.ShowAlways = true;
            Button button = sender as Button;
            tip.Show(button.Tag.ToString(), parent, new Point(Cursor.Position.X - parent.Left + 10, Cursor.Position.Y - parent.Top + 10));
        }
        private void OnMouseLeaveButton(object sender, EventArgs e)
        {
            tip.ShowAlways = false;
        }
    }
}
