using OOT_BTracker.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace OOT_BTracker
{
    public class ItemTracker
    {
        main parent;
        KeySanity keySanity;
        
        private List<ArrayList> items;
        private int[] dungeon_state = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private string[] dungeon_name = { "FREE", "DEKU", "DCVN", "JABU", "FRST", "FIRE", "WATR", "SHDW", "SPRT"};

        public ItemTracker(main sender)
        {
            parent = sender;
            Init_Items();
            Original_Size();
        }

        public void Set_KeySanity(KeySanity k)
        {
            this.keySanity = k;
        }


        public void Original_Size()
        {
            parent.Size = new Size(470, 480);
            parent.MinimumSize = new Size(470, 480);
            parent.MaximumSize = new Size(470, 480);
        }

        // Erstelle alle Items die für den Tracker benötigt werden
        private void Init_Items()
        {
            items = new List<ArrayList>();

            // Hier alle Itemnamen platzieren
            List<string> itemnames = new List<string>(); // Namen des Itemd
            List<int> itemstatus = new List<int>(); // Status Gechecked/Ungechecked zu Beginn
            List<int> itemuncheck = new List<int>(); // Ist das Item Uncheckable
            /* Welches programm muss durchlaufen werden fürs Tracken // Später auch welches Item muss geladen werden.
             * 0 = Check/Uncheck Bsp. Mastersword oder Nayru
             * 1 = Hochzählen runterzählen +1/-1
             * 2 = Hochzählen runterzählen +10/-10
             * 3 = Itembild ändern
             * 4 = Check/Uncheck normal + Strg Links und Rechts Durch Dungeons durchschalten
             * 5 = Check/Uncheck mit Text Rechts Unten
             * */
            List<int> tracktype = new List<int>();
            List<string> itemtext = new List<string>();
            List<int> itemmin = new List<int>(); //Minimum  nach Akviierung
            List<int> itemmax = new List<int>();// Falls Maximale Anzahl hier eintragen, sonst 0 eintragen
            List<List<string>> itempictures = new List<List<string>>();
            List<string> itempicturesinside;

            itemnames.Add("stick");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(2);
            itemtext.Add("");
            itemmin.Add(10);
            itemmax.Add(30);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("stick");
            itempictures.Add(itempicturesinside);

            itemnames.Add("nut");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(2);
            itemtext.Add("");
            itemmin.Add(20);
            itemmax.Add(40);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("nut");
            itempictures.Add(itempicturesinside);

            itemnames.Add("bomb_bag_bombs");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(2);
            itemtext.Add("");
            itemmin.Add(20);
            itemmax.Add(40);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("bomb_bag_bombs");
            itempictures.Add(itempicturesinside);

            itemnames.Add("bow");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(2);
            itemtext.Add("");
            itemmin.Add(30);
            itemmax.Add(50);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("bow");
            itempictures.Add(itempicturesinside);

            itemnames.Add("arrow_fire");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Fire");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("arrow_fire");
            itempictures.Add(itempicturesinside);

            itemnames.Add("magic_din");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Din");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("magic_din");
            itempictures.Add(itempicturesinside);

            itemnames.Add("sword_kokiri");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("sword_kokiri");
            itempictures.Add(itempicturesinside);

            itemnames.Add("sword_master");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("sword_master");
            itempictures.Add(itempicturesinside);

            itemnames.Add("sword_biggoron");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("sword_biggoron");
            itempictures.Add(itempicturesinside);

            itemnames.Add("slingshot");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(2);
            itemtext.Add("");
            itemmin.Add(30);
            itemmax.Add(50);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("slingshot");
            itempictures.Add(itempicturesinside);

            itemnames.Add("ocarina_saria");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(2);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("ocarina_saria");
            itempicturesinside.Add("ocarina_time");
            itempictures.Add(itempicturesinside);

            itemnames.Add("bombchu");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("bombchu");
            itempictures.Add(itempicturesinside);

            itemnames.Add("hookshot_small");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(2);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("hookshot_small");
            itempicturesinside.Add("hookshot_long");
            itempictures.Add(itempicturesinside);

            itemnames.Add("arrow_ice");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Ice");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("arrow_ice");
            itempictures.Add(itempicturesinside);

            itemnames.Add("magic_farore");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Far");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("magic_farore");
            itempictures.Add(itempicturesinside);

            itemnames.Add("shield_kokiri");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("shield_kokiri");
            itempictures.Add(itempicturesinside);

            itemnames.Add("shield_hylia");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("shield_hylia");
            itempictures.Add(itempicturesinside);

            itemnames.Add("shield_mirror");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("shield_mirror");
            itempictures.Add(itempicturesinside);

            itemnames.Add("boomerang");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("boomerang");
            itempictures.Add(itempicturesinside);

            itemnames.Add("lens");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("lens");
            itempictures.Add(itempicturesinside);

            itemnames.Add("bean");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(1);
            itemmax.Add(10);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("bean");
            itempictures.Add(itempicturesinside);

            itemnames.Add("hammer");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("hammer");
            itempictures.Add(itempicturesinside);

            itemnames.Add("arrow_light");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Light");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("arrow_light");
            itempictures.Add(itempicturesinside);

            itemnames.Add("magic_nayru");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Nay");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("magic_nayru");
            itempictures.Add(itempicturesinside);

            itemnames.Add("tunic_forest");
            itemstatus.Add(1);
            itemuncheck.Add(1);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("tunic_forest");
            itempictures.Add(itempicturesinside);

            itemnames.Add("tunic_fire");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("Goron");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("tunic_fire");
            itempictures.Add(itempicturesinside);

            itemnames.Add("tunic_water");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("Zora");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("tunic_water");
            itempictures.Add(itempicturesinside);

            itemnames.Add("wallet_default");
            itemstatus.Add(1);
            itemuncheck.Add(1);
            tracktype.Add(3);
            itemtext.Add("99");
            itemmin.Add(0);
            itemmax.Add(4);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("wallet_default");
            itempicturesinside.Add("wallet_silver");
            itempicturesinside.Add("wallet_gold");
            itempicturesinside.Add("wallet_tycoon");
            itempictures.Add(itempicturesinside);

            itemnames.Add("skulltula");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(1);
            itemmax.Add(100);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("skulltula");
            itempictures.Add(itempicturesinside);

            itemnames.Add("bottle");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("bottle");
            itempictures.Add(itempicturesinside);

            itemnames.Add("zora_letter");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("zora_letter");
            itempictures.Add(itempicturesinside);

            itemnames.Add("egg");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(11);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("egg");
            itempicturesinside.Add("cucco");
            itempicturesinside.Add("zelda_letter");
            itempicturesinside.Add("mask_keaton");
            itempicturesinside.Add("mask_skull");
            itempicturesinside.Add("mask_spooky");
            itempicturesinside.Add("mask_bunny");
            itempicturesinside.Add("mask_truth");
            itempicturesinside.Add("mask_goron");
            itempicturesinside.Add("mask_zora");
            itempicturesinside.Add("mask_gerudo");
            itempictures.Add(itempicturesinside);

            itemnames.Add("egg");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(11);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("egg");
            itempicturesinside.Add("cucco");
            itempicturesinside.Add("cojiro");
            itempicturesinside.Add("mushroom");
            itempicturesinside.Add("medicine");
            itempicturesinside.Add("saw");
            itempicturesinside.Add("broken_sword");
            itempicturesinside.Add("prescription");
            itempicturesinside.Add("frog");
            itempicturesinside.Add("eyedrops");
            itempicturesinside.Add("claim");
            itempictures.Add(itempicturesinside);

            itemnames.Add("boots_normal");
            itemstatus.Add(1);
            itemuncheck.Add(1);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("boots_normal");
            itempictures.Add(itempicturesinside);

            itemnames.Add("boots_iron");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("boots_iron");
            itempictures.Add(itempicturesinside);

            itemnames.Add("boots_hover");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("boots_hover");
            itempictures.Add(itempicturesinside);

            itemnames.Add("scale_silver");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(2);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("scale_silver");
            itempicturesinside.Add("scale_gold");
            itempictures.Add(itempicturesinside);

            itemnames.Add("magic_power_small");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(2);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("magic_power_small");
            itempicturesinside.Add("magic_power_big");
            itempictures.Add(itempicturesinside);

            itemnames.Add("glove_goron");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(3);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(3);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("glove_goron");
            itempicturesinside.Add("glove_silver");
            itempicturesinside.Add("glove_gold");
            itempictures.Add(itempicturesinside);

            itemnames.Add("membership");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("membership");
            itempictures.Add(itempicturesinside);

            itemnames.Add("stoneofagony");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("stoneofagony");
            itempictures.Add(itempicturesinside);

            itemnames.Add("heart_piece");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(1);
            itemmax.Add(36);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("heart_piece");
            itempictures.Add(itempicturesinside);

            itemnames.Add("heart_container");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(1);
            itemmax.Add(8);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("heart_container");
            itempictures.Add(itempicturesinside);

            itemnames.Add("heart_double");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("heart_double");
            itempictures.Add(itempicturesinside);

            itemnames.Add("bottle_poe_big");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("bottle_poe_big");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_zelda");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_zelda");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_epona");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_epona");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_saria");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_saria");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_sun");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_sun");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_time");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_time");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_storm");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_storm");
            itempictures.Add(itempicturesinside);

            itemnames.Add("song_scarecrow");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("song_scarecrow");
            itempictures.Add(itempicturesinside);

            itemnames.Add("");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("");
            itempictures.Add(itempicturesinside);

            itemnames.Add("triforce_piece");
            itemstatus.Add(0);
            itemuncheck.Add(1);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(1);
            itemmax.Add(1000);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("triforce_piece");
            itempictures.Add(itempicturesinside);

            itemnames.Add("warp_forest");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Min");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("warp_forest");
            itempictures.Add(itempicturesinside);

            itemnames.Add("warp_fire");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Bol");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("warp_fire");
            itempictures.Add(itempicturesinside);

            itemnames.Add("warp_water");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Ser");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("warp_water");
            itempictures.Add(itempicturesinside);

            itemnames.Add("warp_spirit");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Req");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("warp_spirit");
            itempictures.Add(itempicturesinside);

            itemnames.Add("warp_shadow");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Noc");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("warp_shadow");
            itempictures.Add(itempicturesinside);

            itemnames.Add("warp_light");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(5);
            itemtext.Add("Pre");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("warp_light");
            itempictures.Add(itempicturesinside);

            itemnames.Add("");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("");
            itempictures.Add(itempicturesinside);

            itemnames.Add("ice_trap");
            itemstatus.Add(0);
            itemuncheck.Add(1);
            tracktype.Add(1);
            itemtext.Add("");
            itemmin.Add(1);
            itemmax.Add(1000);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("ice_trap");
            itempictures.Add(itempicturesinside);

            itemnames.Add("");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(0);
            itemtext.Add("");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("");
            itempictures.Add(itempicturesinside);

            itemnames.Add("stone_forest");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("stone_forest");
            itempictures.Add(itempicturesinside);

            itemnames.Add("stone_fire");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("stone_fire");
            itempictures.Add(itempicturesinside);

            itemnames.Add("stone_water");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("stone_water");
            itempictures.Add(itempicturesinside);

            itemnames.Add("medallion_forest");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("medallion_forest");
            itempictures.Add(itempicturesinside);

            itemnames.Add("medallion_fire");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("medallion_fire");
            itempictures.Add(itempicturesinside);

            itemnames.Add("medallion_water");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("medallion_water");
            itempictures.Add(itempicturesinside);

            itemnames.Add("medallion_spirit");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("medallion_spirit");
            itempictures.Add(itempicturesinside);

            itemnames.Add("medallion_shadow");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("medallion_shadow");
            itempictures.Add(itempicturesinside);

            itemnames.Add("medallion_light");
            itemstatus.Add(0);
            itemuncheck.Add(0);
            tracktype.Add(4);
            itemtext.Add("???");
            itemmin.Add(0);
            itemmax.Add(0);
            itempicturesinside = new List<string>();
            itempicturesinside.Add("medallion_light");
            itempictures.Add(itempicturesinside);




            for (int i = 0; i < itemnames.Count; i++)
            {
                ArrayList arraylist = new ArrayList();
                arraylist.Add(itemnames[i]);
                arraylist.Add(itemstatus[i]);
                arraylist.Add(itemuncheck[i]);
                arraylist.Add(tracktype[i]);
                arraylist.Add(itemtext[i]);
                arraylist.Add(itemmin[i]);
                arraylist.Add(itemmax[i]);
                arraylist.Add(itempictures[i]);

                items.Add(arraylist);
            }

            Init_buttons();
        }

        private List<string> Array_Auslesen(ArrayList arraylist)
        {
            List<string> itemlist = (List<string>)arraylist[7];
            return itemlist;
        }

        public void Init_buttons()
        {
            int zeile = 9;
            int zeilec = 0, spaltec = 0;
            for (int i = 0; i < items.Count(); i++)
            {

                string itemnames = items[i][0].ToString();
                int itemstatus = Convert.ToInt32(items[i][1]);
                bool itemuncheck = Convert.ToBoolean(items[i][2]);
                int tracktype = Convert.ToInt32(items[i][3]);
                string itemtext = items[i][4].ToString();
                int itemmin = Convert.ToInt32(items[i][5]);
                int itemmax = Convert.ToInt32(items[i][6]);

                //List<ArrayList> itempictures = items[37].ToArray()[0]);

                ResourceManager rm = Resources.ResourceManager;

                Button tbut = new Button();
                tbut.Image = (Bitmap)rm.GetObject(items[i].ToArray()[0].ToString());
                if (items[i].ToArray()[0].ToString() != "" & (Int32)items[i].ToArray()[1] == 0 & !Convert.ToBoolean(items[i][2]))
                {
                    tbut.Image = SetImageOpacity(tbut.Image, 0.2F);
                }
                tbut.Tag = i;
                tbut.Size = new Size(48, 48);
                tbut.Location = new Point(10 + (zeilec * 48), 40 + (spaltec * 48));
                tbut.FlatStyle = FlatStyle.Flat;
                tbut.FlatAppearance.BorderSize = 0;
                tbut.FlatAppearance.MouseOverBackColor = Color.Transparent;
                tbut.FlatAppearance.MouseDownBackColor = Color.Transparent;
                tbut.Text = items[i][4].ToString();
                tbut.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);
                tbut.TextAlign = ContentAlignment.BottomRight;
                if (tracktype == 4)
                {
                    tbut.TextAlign = ContentAlignment.BottomCenter;
                    tbut.ForeColor = Color.DarkGray;
                }
                if (tracktype == 5)
                {
                    tbut.ForeColor = Color.DarkGray;
                }
                tbut.MouseDown += new MouseEventHandler(tbuttons);
                parent.Controls.Add(tbut);
                items[i].Add(tbut);
                zeilec++;
                if (zeilec == zeile)
                {
                    zeilec = 0;
                    spaltec++;
                }


            }
            /*
            for (int i = 0; i < items.Count(); i++)
            {
                MessageBox.Show(items[i].ToArray()[0].ToString());
            }
            */
        }


        public Image SetImageOpacity(Image image, float opacity)
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
        private void tbuttons(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int pos = Convert.ToInt32(button.Tag);
            ResourceManager rm = Resources.ResourceManager;

            string itemnames = items[pos][0].ToString();
            int itemstatus = Convert.ToInt32(items[pos][1]);
            bool itemuncheck = Convert.ToBoolean(items[pos][2]);
            int tracktype = Convert.ToInt32(items[pos][3]);
            string itemtext = items[pos][4].ToString();
            int itemmin = Convert.ToInt32(items[pos][5]);
            int itemmax = Convert.ToInt32(items[pos][6]);
            List<string> itempictures = Array_Auslesen(items[pos]);

            if (items[pos][0].ToString() != "")
            {
                bool uncheckable = Convert.ToBoolean(items[pos][2]);
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        switch (tracktype)
                        {
                            case 0:
                                if (itemstatus != 0)
                                {
                                    if (!itemuncheck)
                                    {
                                        button.Image = SetImageOpacity(button.Image, 0.2F);
                                        itemstatus--;
                                        if(itemnames == "membership" & keySanity != null)
                                        {
                                            keySanity.Set_GF(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                switch (itemstatus)
                                {
                                    default:
                                        if(itemstatus == itemmax)
                                        {
                                            button.ForeColor = Color.White;
                                            itemstatus--;
                                            
                                            button.Text = itemstatus.ToString();
                                            items[pos][4] = button.Text;
                                        }
                                        else
                                        {
                                            if (itemstatus != 0)
                                            {
                                                itemstatus--;
                                                button.Text = itemstatus.ToString();
                                                items[pos][4] = button.Text;
                                            }
                                        }
                                        break;
                                    case 1:
                                        itemstatus--;
                                        button.Text = "";
                                        items[pos][4] = button.Text;
                                        if (!itemuncheck) button.Image = SetImageOpacity(button.Image, 0.2F);
                                        break;
                                }
                                break;
                            case 2:
                                if (itemstatus == itemmax)
                                {
                                    button.ForeColor = Color.White;
                                    itemstatus -= 10;
                                    button.Text = itemstatus.ToString();
                                    items[pos][4] = button.Text;
                                }
                                else
                                if(itemstatus == itemmin)
                                {
                                    itemstatus = 0;
                                    button.Text = "";
                                    items[pos][4] = button.Text;
                                    button.Image = SetImageOpacity(button.Image, 0.2F);
                                }
                                else
                                if (itemstatus != 0)
                                {
                                    itemstatus -= 10;
                                    button.Text = itemstatus.ToString();
                                    items[pos][4] = button.Text;
                                }
                                break;
                            case 3:
                                switch (itemstatus)
                                {
                                    case 1:
                                        if (!itemuncheck) button.Image = SetImageOpacity(button.Image, 0.2F);
                                        button.Text = itemtext;
                                        items[pos][4] = button.Text;
                                        itemstatus--;
                                        break;
                                    default:
                                        if (itemstatus >itemmin)
                                        {
                                            itemstatus--;
                                            itempictures = Array_Auslesen(items[pos]);
                                            button.Image = (Bitmap)rm.GetObject(itempictures[itemstatus - 1].ToString());

                                            Button_Change(button, itempictures[itemstatus - 1]);
                                        }
                                        break;
                                }
                                break;
                            case 4:
                                if (itemstatus == 0)
                                {
                                    Dungeon_Change(button);
                                }
                                if (itemstatus != 0)
                                {
                                    if (!itemuncheck)
                                    {
                                        button.Image = SetImageOpacity(button.Image, 0.2F);
                                        itemstatus--;
                                        button.ForeColor = Color.DarkGray;
                                    }
                                }
                                break;
                            case 5:
                                if (itemstatus != 0)
                                {
                                    if (!itemuncheck)
                                    {
                                        button.Image = SetImageOpacity(button.Image, 0.2F);
                                        itemstatus--;
                                        button.ForeColor = Color.DarkGray;
                                    }
                                }
                                break;
                        }
                        break;
                    case MouseButtons.Left:
                        switch (tracktype)
                        {
                            case 0:
                                if (itemstatus != 1)
                                {
                                    button.Image = SetImageOpacity(button.Image, 10F);
                                    itemstatus++;
                                    if (itemnames == "membership" & keySanity != null)
                                    {
                                        keySanity.Set_GF(true);
                                    }
                                }
                                break;
                            case 1:
                                switch (itemstatus)
                                {
                                    case 0:
                                        button.Image = SetImageOpacity(button.Image, 10F);
                                        itemstatus++;
                                        button.Text = itemstatus.ToString();
                                        items[pos][4] = button.Text;
                                        button.TextAlign = ContentAlignment.BottomRight;
                                        break;
                                    default:
                                        if (itemstatus < Convert.ToInt32(items[pos][6]))
                                        {
                                            itemstatus++;
                                            button.Text = itemstatus.ToString();
                                            items[pos][4] = button.Text;
                                            if (itemstatus == Convert.ToInt32(items[pos][6])) button.ForeColor = Color.FromArgb(54, 255, 54); 
                                        }
                                        break;
                                }
                                break;
                            case 2:
                                switch (itemstatus)
                                {
                                    case 0:
                                        button.Image = SetImageOpacity(button.Image, 10F);
                                        itemstatus += itemmin;
                                        button.Text = itemstatus.ToString();
                                        items[pos][4] = button.Text;
                                        button.TextAlign = ContentAlignment.BottomRight;
                                        break;
                                    default:
                                        if (itemstatus < Convert.ToInt32(items[pos][6]))
                                        {
                                            itemstatus +=10;
                                            button.Text = itemstatus.ToString();
                                            items[pos][4] = button.Text;
                                            if (itemstatus == Convert.ToInt32(items[pos][6])) button.ForeColor = Color.FromArgb(54, 255, 54);
                                        }
                                        break;
                                }
                                break;
                            case 3:
                                switch (itemstatus)
                                {
                                    case 0:
                                        button.Image = SetImageOpacity(button.Image, 10F);
                                        itemstatus++;
                                        Button_Change(button, itempictures[itemstatus - 1]);
                                        break;
                                    default:
                                        if (itemstatus < itemmax)
                                        {
                                            itemstatus++;
                                            itempictures = Array_Auslesen(items[pos]);
                                            button.Image = (Bitmap)rm.GetObject(itempictures[itemstatus-1].ToString());
                                            Button_Change(button, itempictures[itemstatus - 1]);
                                        }
                                        break;
                                }
                                break;
                            case 4:
                                if (itemstatus != 1)
                                {
                                    button.Image = SetImageOpacity(button.Image, 10F);
                                    itemstatus++;
                                    button.ForeColor = Color.White;
                                }


                                break;
                            case 5:
                                if (itemstatus != 1)
                                {
                                    button.Image = SetImageOpacity(button.Image, 10F);
                                    itemstatus++;
                                    button.ForeColor = Color.White;
                                }
                                break;
                        }
                        break;
                }
                items[pos][1] = itemstatus;
            }
            //MessageBox.Show("Auf Positon: " + pos + " Folgender Status: " + Convert.ToInt32(items[pos].ToArray()[1]).ToString());
        }

        private void Button_Change(Button button, string item)
        {
            switch (item)
            {
                case "wallet_default":
                    button.Text = "99";
                    break;
                case "wallet_silver":
                    button.Text = "200";
                    button.ForeColor = Color.White;
                    break;
                case "wallet_gold":
                    button.Text = "500";
                    button.ForeColor = Color.FromArgb(54, 255, 54);
                    break;
                case "wallet_tycoon":
                    button.Text = "999";
                    button.ForeColor = Color.FromArgb(54, 255, 54);
                    break;
                case "scale_silver":
                    button.Text = "S";
                    break;
                case "scale_gold":
                    button.Text = "G";
                    break;
                case "magic_power_small":
                    button.Text = "";
                    break;
                case "magic_power_big":
                    button.Text = "+";
                    break;
            }
        }

        private void Dungeon_Change(Button button)
        {
            button.Font = new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Regular);
            switch (button.Text)
            {
                case "???":
                    Switch_Dungeons(button, -1);
                    break;
                case "FREE":
                    Switch_Dungeons(button, 0);
                    break;
                case "DEKU":
                    Switch_Dungeons(button, 1);
                    break;
                case "DCVN":
                    Switch_Dungeons(button, 2);
                    break;
                case "JABU":
                    Switch_Dungeons(button, 3);
                    break;
                case "FRST":
                    Switch_Dungeons(button, 4);
                    break;
                case "FIRE":
                    Switch_Dungeons(button, 5);
                    break;
                case "WATR":
                    Switch_Dungeons(button, 6);
                    break;
                case "SHDW":
                    Switch_Dungeons(button, 7);
                    break;
                case "SPRT":
                    Switch_Dungeons(button, 8);
                    break;
            }
        }

        private void Switch_Dungeons(Button button, int akt_dungeon)
        {
            int z = 0;
            if(akt_dungeon != -1) z = akt_dungeon;
            
            for (int i = z;  i < dungeon_state.Count(); i++)
            {
                if (dungeon_state[i] == 0)
                {
                    button.Text = dungeon_name[i];
                    dungeon_state[i] = 1;
                    if (akt_dungeon != i & akt_dungeon != -1) dungeon_state[akt_dungeon] = 0;
                    break;
                }
                if(dungeon_state.Count() - 1 == i)
                {
                    if (akt_dungeon != -1)
                    {
                        dungeon_state[akt_dungeon] = 0;
                    }
                    button.Text = "???";
                }
            }
        }

        public void Set_GF(Boolean active)
        {
            for(int i = 0; i < items.Count; i++)
            {
                string itemnames = items[i][0].ToString();
                int itemstatus = Convert.ToInt32(items[i][1]);
                Button button = (Button)items[i][8];
                if(itemnames == "membership")
                {
                    if(active)
                    {
                        items[i][1] = 1;
                        button.Image = SetImageOpacity(button.Image, 10F);
                    }
                    else
                    {
                        items[i][1] = 0;
                        button.Image = SetImageOpacity(button.Image, 0.2F);
                    }
                }
            }
        }

        public Boolean Get_GF()
        {
            for (int i = 0; i < items.Count; i++)
            {
                string itemnames = items[i][0].ToString();
                int itemstatus = Convert.ToInt32(items[i][1]);
                if (itemnames == "membership")
                {
                    if(itemstatus == 0)
                        return false;
                    if (itemstatus == 1)
                        return true;
                }
            }
            return false;
        }
    }
}
