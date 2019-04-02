using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlimaPublisherSubscriber.BusinessLogic;

namespace KlimaPublisherSubscriber
{
    public partial class Form1 : Form
    {
        Termometar termometar = new Termometar();


        public Form1()
        {
            InitializeComponent();

            Klima klima1 = new Klima(25, 15);

            klima1.changedStatus += this.indikator1;
            termometar.Add(klima1);
            

            Klima klima2 = new Klima(27,12);
            termometar.Add(klima2);
            klima2.changedStatus += this.indikator2;


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.termometar.Temperatura = Convert.ToDouble(numericUpDown1.Value);

        }

        public void indikator1(Klima sender, KlimaEventArgs e)
        {
            if(e.status == StanjeKlime.Hladjenje)
                panel1.BackColor = Color.Aqua;
            else if (e.status == StanjeKlime.Grejanje)
                panel1.BackColor = Color.Red;
            else
                panel1.BackColor = Color.White;
            
        }
        public void indikator2(Klima sender, KlimaEventArgs e)
        {
            if (e.status == StanjeKlime.Hladjenje)
                panel2.BackColor = Color.Aqua;
            else if (e.status == StanjeKlime.Grejanje)
                panel2.BackColor = Color.Red;
            else
                panel2.BackColor = Color.White;
        }
    }
}
