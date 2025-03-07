using System.IO.Ports;
using Code4Bugs.Utils.IO;
using Code4Bugs.Utils.IO.Modbus;
using Code4Bugs.Utils.Types;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System;
using Newtonsoft.Json.Linq;


namespace mideasav
{

    public partial class Form1 : Form
    {
        int[] TabData = new int[275];
        public static dynamic[] filtab = new dynamic[288000];
        public static int BlockLigne = 0;
        public static int lireblock;

        public static string PcomS = "COM1";
        public static string PdevS = "1";

        public static byte chk_tempin = 1;
        public static byte chk_tempout = 1;
        public static byte chk_freq = 1;
        public static byte chk_debit = 1;
        public static byte chk_echext = 1;



        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "";


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "dat (*.dat)|*.dat";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    timer1.Enabled = false;
                    filePath = openFileDialog.FileName;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        BlockLigne = 0;
                        lireblock = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line != null)
                            {
                                dynamic data = JsonConvert.DeserializeObject(line);
                                if (data != null)
                                    filtab[BlockLigne++] = data;
                            }
                        }


                        trackBar1.Maximum = BlockLigne - 1;
                        trackBar1.Value = lireblock;

                        LireTable();

                    }
                }
            }





        }

        void LireTable()
        {
            foreach (dynamic item in filtab[lireblock])
            {
                //rbx.Text += "\n" + item.Name+"=>"+item.Value;
                if (item.Name != "TIME")
                    TabData[Convert.ToInt16(item.Name)] = item.Value;
                else
                    Time.Text = item.Value;
            }

            Val_OutTemp.Text = TabData[105].ToString() + "°c";
            Val_Intemp.Text = TabData[104].ToString() + "°c";
            Val_Exterieur.Text = TabData[107].ToString() + "°c";
            Val_Hp.Text = (Convert.ToDouble(TabData[116]) / 100).ToString("0.0") + "B";
            Val_Bp.Text = (Convert.ToDouble(TabData[117]) / 100).ToString("0.0") + "B";
            Val_Hz.Text = TabData[100].ToString() + "HZ";
            Val_Intensite.Text = TabData[118].ToString() + "A";
            Val_PuissanceKw.Text = (Convert.ToDouble(TabData[140]) / 100).ToString("0.00") + "Kw/h";
            Val_Debit.Text = (Convert.ToDouble(TabData[138]) / 100).ToString("0.00") + "m3/h";
            Val_FanV.Text = TabData[102].ToString() + "r/s";
            Val_TempRef.Text = TabData[108].ToString() + "°c";
            Val_Echangeur.Text = TabData[106].ToString() + "°c";
            Val_T1.Text = TabData[110].ToString() + "°c";
            Val_lev.Text = TabData[103].ToString() + "Pls";
            Val_Tension.Text = TabData[119].ToString() + "V";
            Val_T2.Text = TabData[112].ToString() + "°c";
            Val_T2b.Text = TabData[113].ToString() + "°c";

            //foreach (int i in TabData)
            //rbx.Text += i + " ,";
        }


        private void ModBusRead()
        {
            SerialPort port = new SerialPort(pCOM.Text, 9600, Parity.None, 8, StopBits.One);
            rbx.Text = "\nConfiguration du " + "COM1\n";

            SerialPort serialPort = new SerialPort(pCOM.Text);
            var Device = Int16.Parse(PacDevice.Text);

            string datetime = DateTime.Now.ToString("HH-mm-ss");

            Time.Text = datetime;

            try
            {
                //Recuperation Data ModBus Rtu
                serialPort.Open();
                serialPort.ReadTimeout = 5000;
                var stream = new SerialStream(serialPort);
                var responseBytes = stream.RequestFunc3(Device, 0x0000, 0x001E);
                var data1 = responseBytes.ToResponseFunc3().Data;
                responseBytes = stream.RequestFunc3(Device, 0x0064, 0x0030);
                var data2 = responseBytes.ToResponseFunc3().Data;
                responseBytes = stream.RequestFunc3(Device, 0x00C8, 0x0049);
                var data3 = responseBytes.ToResponseFunc3().Data;

                serialPort.Close();


                string Jobj = @"{""TIME"":""" + datetime + @"""";

                int Adresse1 = 0;
                int Adresse2 = 100;
                int Adresse3 = 200;
                for (int i = 0; i < data1.Length - 1; i++)
                {
                    Jobj += @",""" + Adresse1 + @""":" + data1.ToInt16(i) + "";
                    TabData[Adresse1++] = data1.ToInt16(i++);
                }
                for (int i = 0; i < data2.Length - 1; i++)
                {
                    Jobj += @",""" + Adresse2 + @""":" + data2.ToInt16(i) + "";
                    TabData[Adresse2++] = data2.ToInt16(i++);
                }
                for (int i = 0; i < data3.Length - 1; i++)
                {
                    Jobj += @",""" + Adresse3 + @""":" + data3.ToInt16(i) + "";
                    TabData[Adresse3++] = data3.ToInt16(i++);
                }

                Jobj += "}";


                StreamWriter sw = new StreamWriter(NomFiles.Text, true);
                sw.WriteLine(Jobj);
                sw.Close();

                dynamic data = JsonConvert.DeserializeObject(Jobj);
                if (data != null)
                    filtab[BlockLigne++] = data;


                trackBar1.Maximum = BlockLigne - 1;
                if (CKB1.Checked == true) lireblock = BlockLigne - 1;
                trackBar1.Value = lireblock;

                LireTable();

                //Affiche les donnes tableau
                //foreach (int i in TabData) rbx.Text += i + " ,";


            }
            catch (Exception ex)
            {
                if (ex is DataCorruptedException)
                {
                    rbx.Text += "checksum non correct\n" + ex;
                }
                else if (ex is EmptyResponsedException)
                {
                    rbx.Text += "timeout de la demande\n" + ex;
                }
                else if (ex is MissingDataException)
                {
                    rbx.Text += "Mauvaise reponce Modbus\n" + ex;
                }
                else
                {
                    rbx.Text += "Erreur controle\n" + ex;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ModBusRead();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            lireblock++;
            if (lireblock >= BlockLigne) lireblock = BlockLigne - 1;
            trackBar1.Value = lireblock;
            CKB1.Checked = false;
            LireTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (lireblock > 0) lireblock--;
            trackBar1.Value = lireblock;
            CKB1.Checked = false;
            LireTable();


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lireblock = trackBar1.Value;
            CKB1.Checked = false;
            LireTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetingCom form2 = new SetingCom();
            form2.Show();



        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filePath = "";

            using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                SaveFileDialog.Filter = "dat (*.dat)|*.dat";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    timer1.Enabled = false;
                    filePath = SaveFileDialog.FileName;
                    NomFiles.Text = filePath;
                    timer1.Enabled = true;
                    CKB1.Checked = true;
                    BlockLigne = 0;
                    lireblock = 0;
                    StreamWriter sw = new StreamWriter(NomFiles.Text, false);
                    sw.Close();
                    ModBusRead();


                }
            }
        }

        private void MajCom_Tick(object sender, EventArgs e)
        {
            pCOM.Text = PcomS;
            PacDevice.Text = PdevS;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphique FromGraph = new Graphique();
            FromGraph.Show();
        }
    }

}
