using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tik_tok_Spiel
{
    public partial class Form1 : Form
    {

        public enum Spieler
        {
            x, o
        }
        Spieler AktuelleSpeiler;
        private Random random = new Random();

        int SpierlGewinnenCount = 0;
        int PcGewinnenCount = 0;
        List<Button> buttons;



        public Form1()
        {
            InitializeComponent();
            NochmalStraten();
        }





        private void PC_Bewegung(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                AktuelleSpeiler = Spieler.o;
                buttons[index].Text = AktuelleSpeiler.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckSpiel();
                PC_Timer.Stop();

            }

        }

        private void SpielerClickTaste(object sender, EventArgs e)
        {
            var button = (Button)sender;
            AktuelleSpeiler = Spieler.x;
            button.Text = AktuelleSpeiler.ToString();
            button.Enabled = false;
            button.BackColor = Color.Red;
            buttons.Remove(button);
            CheckSpiel();
            PC_Timer.Start();


        }

        private void NochmalStraten(object sender, EventArgs e)
        {
            NochmalStraten();
        }

        private void CheckSpiel()
        {
            if (button1.Text == "x" && button2.Text == "x" && button3.Text == "x" ||
                button4.Text == "x" && button5.Text == "x" && button6.Text == "x" ||
                button7.Text == "x" && button8.Text == "x" && button9.Text == "x" ||
                button1.Text == "x" && button4.Text == "x" && button7.Text == "x" ||
                button2.Text == "x" && button5.Text == "x" && button8.Text == "x" ||
                button3.Text == "x" && button6.Text == "x" && button8.Text == "x" ||
                button1.Text == "x" && button5.Text == "x" && button9.Text == "x" ||
                button3.Text == "x" && button5.Text == "x" && button7.Text == "x")
            { 
                PC_Timer.Stop();
            MessageBox.Show("Spieler Gewinnet.");
                SpierlGewinnenCount++;
                label1.Text = "Spieler Gewinnen: " + SpierlGewinnenCount;
                NochmalStraten();
            }
        else if(button1.Text == "o" && button2.Text == "o" && button3.Text == "o" ||
                button4.Text == "o" && button5.Text == "o" && button6.Text == "o" ||
                button7.Text == "o" && button8.Text == "o" && button9.Text == "o" ||
                button1.Text == "o" && button4.Text == "o" && button7.Text == "o" ||
                button2.Text == "o" && button5.Text == "o" && button8.Text == "o" ||
                button3.Text == "o" && button6.Text == "o" && button8.Text == "o" ||
                button1.Text == "o" && button5.Text == "o" && button9.Text == "o" ||
                button3.Text == "o" && button5.Text == "o" && button7.Text == "o")
            {
                PC_Timer.Stop();
            MessageBox.Show("PC Gewinnet.");
                PcGewinnenCount++;
                label2.Text = "PC Gewinnen: " + PcGewinnenCount;
                NochmalStraten();
            }
            //else { MessageBox.Show("Das Ergebnis ist ein Unentscheiden..."); }
            

        }
        public void NochmalStraten()
        {
            buttons = new List<Button>
{
    button1, button2, button3, button4, button5,
    button6, button7, button8, button9
};

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;


            }
        }

       
    }
}
