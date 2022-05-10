using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace Ping_radius
{
    public partial class Form1 : Form
    {
        List<IPadresa> lIP = new List<IPadresa>();
        public Form1()
        {
            InitializeComponent();
        }
        public static void PingHost(IPadresa ipadresa)
        {
            bool pingnuto = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply odpoved = pinger.Send(ipadresa.IP);
                ipadresa.Alive = odpoved.Status == IPStatus.Success;
            }
            catch (PingException)
            {
            
            }
        }

        int pocPrvni, pocDruha, pocTreti, pocCtvrta, prvni;
        int endPrvni, endDruha, endTreti, endCtvrta, posledni;





        //192.168.2.1 - 192.168.2.10
        //inicializae listu - 
        // listIP.Add( new IpAdresa{IP = 'kombinace', '', false});


        //naplneni bude 
        // foreach (var item in listIP)
        // Pingni(item.Ip) // funkce která nastaví Alive
        // item.Alive = true;

        bool done  = true;

    
        private void Test()
        {



            string pocatekIP = string.Format("{0}.{1}.{2}.", pocPrvni,pocDruha,pocTreti);
            string konecIP = string.Format("{0}.{1}.{2}.", pocPrvni, pocDruha, pocTreti);
            int pocet; // rozdil mezi pocatek konec
            pocet = endCtvrta - pocCtvrta;
      
                for (int i = 0; i <= pocet; i++)
                {
                lIP.Add(new IPadresa { IP = pocatekIP + pocCtvrta.ToString() });
                // listBox1.Items.Add(PingHost(pocatekIP + pocCtvrta.ToString()));
                    pocCtvrta++;
                };

            foreach (var item in lIP)
            {
                PingHost(item);
                listBox1.Items.Add(item.IP + " - " + item.Alive.ToString());
            }
            int counter = 0;
            //while (done)
            //{
            //   // Thread vlakno0 = new Thread(new ThreadStart(pocitadlo()));
            //   // Thread vlakno1 = new Thread(new ThreadStart(pocitadlo()));
            //   // Thread vlakno2 = new Thread(new ThreadStart(pocitadlo()));
            //  //  Thread vlakno3 = new Thread(new ThreadStart(pocitadlo()));
            //  //  Thread vlakno4 = new Thread(new ThreadStart(pocitadlo()));


            //    counter++;
            //    if (counter == 10)    counter = 0;
            //}

        }
        private void filler()
        {
            pocPrvni = int.Parse(textBox1.Text);
            pocDruha = int.Parse(textBox3.Text);
            pocTreti = int.Parse(textBox5.Text);
            pocCtvrta = int.Parse(textBox4.Text);

            endPrvni = int.Parse(textBox8.Text);
            endDruha = int.Parse(textBox7.Text);
            endTreti = int.Parse(textBox6.Text);
            endCtvrta = int.Parse(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            filler();
            Test();
        }
    }
}
