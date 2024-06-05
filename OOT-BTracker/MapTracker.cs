using OOT_BTracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OOT_BTracker
{
    public class MapTracker
    {
        main parent;
        Areas areas;
        Items items;
        Dungeons dungeons;
        Viewport view = new Viewport();
        Scenes scenes = new Scenes();
        ToolTip tip = new ToolTip();

        private class Viewport
        {
            public double left = 470;
            public double top = 20 + (740 * 0.5625);
            public List<Button> viewbutton;
            public Label scenename;
            public Label entrances;
            public Label checkslbl;
            public Button btn;
            public CheckBox templ;
            public FlowLayoutPanel checkpanel;
            public FlowLayoutPanel entrancepanel;
        }
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
                tbut.Click += Choose_Display;
                tbut.Tag = areas.output.areas[i].name + "|" + areas.output.areas[i].id;
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
                    tbut.Click += Choose_Display;
                    tbut.Tag = dungeons.output.dungeons[i].name + "|" + dungeons.output.dungeons[i].id;
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
            string text = button.Tag.ToString().Split('|')[0];
            tip.Show(text, parent, new Point(Cursor.Position.X - parent.Left + 10, Cursor.Position.Y - parent.Top + 10));
        }
        private void OnMouseLeaveButton(object sender, EventArgs e)
        {
            tip.ShowAlways = false;
        }

        private void Choose_Display(Object sender, EventArgs e)
        {
            if (view.checkpanel != null)
            {
                parent.Controls.Remove(view.checkpanel);
            }
            if(view.entrancepanel != null)
            {
                parent.Controls.Remove(view.entrancepanel);
            }
            parent.Controls.Remove(view.checkslbl);
            parent.Controls.Remove(view.entrances);
            parent.Controls.Remove(view.scenename);


            Button button = sender as Button;
            int areal = Convert.ToInt32(button.Tag.ToString().Split('|')[1]);
            view.viewbutton = new List<Button>();

            view.checkpanel = new FlowLayoutPanel();
            view.checkpanel.Location = new Point((Int32)view.left + 150, (Int32)view.top + 44);
            view.checkpanel.Size = new Size(570, 376);
            view.checkpanel.FlowDirection = FlowDirection.TopDown;
            view.checkpanel.AutoScroll = true;

            view.entrancepanel = new FlowLayoutPanel();
            view.entrancepanel.Location = new Point((Int32)view.left, (Int32)view.top + 40);
            view.entrancepanel.Size = new Size(150, 380);
            view.entrancepanel.FlowDirection = FlowDirection.TopDown;
            view.entrancepanel.AutoScroll = true;


            /*ListView templ = new ListView();
            templ.Location = new Point((Int32)view.left, (Int32)view.top);
            templ.Size = new Size(720, 400);
            templ.BackColor = Color.Black;
            templ.ForeColor = Color.White;
            templ.BorderStyle = BorderStyle.None;
            templ.Activation = ItemActivation.OneClick;
            templ.CheckBoxes = true;
            templ.MultiSelect = false;
            templ.View = View.List;
            templ.ItemChecked += List_Click;
            */
            for (int i = 0; i < scenes.output.Scenes.Count; i++)
            {


                int sceneid = scenes.output.Scenes[i].id;
                Scene scene = scenes.output.Scenes[i];
                if(areal == sceneid)
                {
                    view.scenename = new Label();
                    view.scenename.Text = scene.name;
                    view.scenename.Location = new Point((Int32)view.left, (Int32)view.top);
                    view.scenename.AutoSize = true;
                    view.scenename.Font = new Font(FontFamily.GenericSerif, 14F);
                    parent.Controls.Add(view.scenename);
                    view.entrances = new Label();
                    view.entrances.Text = "Entrances";
                    view.entrances.Location = new Point((Int32)view.left, (Int32)view.top +20);
                    view.entrances.AutoSize = true;
                    view.entrances.Font = new Font(FontFamily.GenericSerif, 14F);
                    view.entrances.ForeColor = Color.OrangeRed;
                    parent.Controls.Add(view.entrances);
                    view.checkslbl = new Label();
                    view.checkslbl.Text = "Checks";
                    view.checkslbl.Location = new Point((Int32)view.left + 150, (Int32)view.top + 20);
                    view.checkslbl.AutoSize = true;
                    view.checkslbl.Font = new Font(FontFamily.GenericSerif, 14F);
                    view.checkslbl.ForeColor = Color.OrangeRed;
                    parent.Controls.Add(view.checkslbl);

                    for (int j = 0; j < scene.entrances.Count; j++)
                    {
                        Entrance entrance = scene.entrances[j];
                        view.btn = new Button();
                        view.btn.Text = entrance.name;
                        view.btn.FlatStyle = FlatStyle.Flat;
                        view.btn.FlatAppearance.BorderSize = 0;
                        view.btn.AutoSize = true;
                        view.btn.Font = new Font(FontFamily.GenericSerif, 14F);
                        view.btn.Click += Choose_Display;
                        view.btn.Tag = entrance.name + "|" + entrance.id + "|" + entrance.room;
                        view.entrancepanel.Controls.Add(view.btn);
                    }

                    for(int j = 0; j < scene.room.Count; j++)
                    {
                        Room room = scene.room[j];
                        for(int k = 0; k < room.actors.Count; k++)
                        {
                            Actor actor = room.actors[k];
                            if (actor.active)
                            {
                                view.templ = new CheckBox();
                                view.templ.ForeColor = Color.White;
                                view.templ.BackColor = Color.Black;
                                view.templ.Font = new Font(FontFamily.GenericSerif, 14F);
                                view.templ.AutoSize = true;
                                /*templ.Items.Add(actor.name);
                                int lastindex = templ.Items.Count - 1;*/
                                view.templ.Tag = sceneid + "|" + room.id + "|" + actor.id + "|" + actor.name;
                                view.templ.Text = actor.name;
                                view.templ.CheckedChanged += Checkbox_Check;
                                view.templ.Checked = Check_Uncheck_Scenes_Check(sceneid, j, k);
                                view.checkpanel.Controls.Add(view.templ);
                            }
                        }
                    }
                }
            }
            //parent.Controls.Add(templ);
            parent.Controls.Add(view.entrancepanel);
            parent.Controls.Add(view.checkpanel);
        }

        private void Checkbox_Check(Object sender, EventArgs e)
        {
            CheckBox item = sender as CheckBox;
            int sceneid = Convert.ToInt32(item.Tag.ToString().Split('|')[0]);
            int roomid = Convert.ToInt32(item.Tag.ToString().Split('|')[1]);
            int actorid = Convert.ToInt32(item.Tag.ToString().Split('|')[2]);


            if (item.Checked)
            {
                item.ForeColor = Color.Green;
                Check_Uncheck_Scenes(sceneid, roomid, actorid, true);
            }
            else
            {
                item.ForeColor = Color.White;
                Check_Uncheck_Scenes(sceneid, roomid, actorid, false);
            }
        }

        private bool Check_Uncheck_Scenes_Check(int sceneid, int roomid, int actorid)
        {
            for(int i = 0; i < scenes.output.Scenes.Count; i++)
            {
                int scene = scenes.output.Scenes[i].id;
                if(sceneid == scene)
                {
                    return scenes.output.Scenes[i].room[roomid].actors[actorid].tracked;
                }
            }
            return false;
        }

        private void Check_Uncheck_Scenes(int sceneid, int roomid, int actorid, bool check)
        {
            for (int i = 0; i < scenes.output.Scenes.Count; i++)
            {
                int scene = scenes.output.Scenes[i].id;
                if (sceneid == scene)
                {
                    scenes.output.Scenes[i].room[roomid].actors[actorid].tracked = check;
                }
            }
        }
    }
}
