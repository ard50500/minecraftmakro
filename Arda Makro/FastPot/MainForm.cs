using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastPot
{
    public partial class MainForm : Form
    {
        public static MainForm MainFr;
        ThrowPot ThrowPot;
        public MainForm()
        {
            MainFr = this;
            InitializeComponent();
            button1.Click += OnClick;
            button2.Click += OnClick;
            button3.Click += OnClick;
            button4.Click += OnClick;
            button5.Click += OnClick;
            button6.Click += OnClick;
            button1.KeyUp += OnRelease;
            button2.KeyUp += OnRelease;
            button3.KeyUp += OnRelease;
            button4.KeyUp += OnRelease;
            button5.KeyUp += OnRelease;
            button6.KeyUp += OnRelease;
        }
        void OnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Text = "...";
            if (button.Name == "button5") ThrowPot.IsReadyToPot = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ThrowPot = new ThrowPot();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            ThrowPot.KeyBind = Utility.ConvertToBindable(e);
            button1.Text = ThrowPot.KeyBind.ToString().StartsWith("TUŞ_") ? $"MAKROYU AÇ [{ThrowPot.KeyBind.ToString().Substring(4)}]" : $"MAKROYU AÇ [{ThrowPot.KeyBind.ToString()}]";
        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            ThrowPot.ThrowPotKey = Utility.ConvertToBindable(e);
            button5.Text = ThrowPot.ThrowPotKey.ToString().StartsWith("TUŞ_") ? $"OLTAYI AT [{ThrowPot.ThrowPotKey.ToString().Substring(4)}]" : $"OLTAYI AT [{ThrowPot.ThrowPotKey.ToString()}]";
        }

        private void OnRelease(object sender, KeyEventArgs e)
        {
            ThrowPot.IsReadyToPot = false;
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            ThrowPot.InventoryKey = Utility.ConvertToBindable(e);
            button2.Text = ThrowPot.InventoryKey.ToString().StartsWith("TUŞ_") ? $"ENVANTER TUŞU [{ThrowPot.InventoryKey.ToString().Substring(4)}]" : $"ENVANTER TUŞU [{ThrowPot.InventoryKey.ToString()}]";
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            ThrowPot.FirstPot = Utility.ConvertToBindable(e);
            button4.Text = ThrowPot.FirstPot.ToString().StartsWith("TUŞ_") ? $"OLTANIN YERİ [{ThrowPot.FirstPot.ToString().Substring(4)}]" : $"OLTANIN YERİ [{ThrowPot.FirstPot.ToString()}]";
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            ThrowPot.LastPot = Utility.ConvertToBindable(e);
            button3.Text = ThrowPot.LastPot.ToString().StartsWith("TUŞ_") ? $"KILICIN YERİ [{ThrowPot.LastPot.ToString().Substring(4)}]" : $"KILICIN YERİ [{ThrowPot.LastPot.ToString()}]";
        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            ThrowPot.Sword = Utility.ConvertToBindable(e);
            button6.Text = ThrowPot.Sword.ToString().StartsWith("TUŞ_") ? $"KILICIN YERİ [{ThrowPot.Sword.ToString().Substring(4)}]" : $"KILICIN YERİ [{ThrowPot.Sword.ToString()}]";
        }
    }
}
