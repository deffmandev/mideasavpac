using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static mideasav.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace mideasav
{
    public partial class Graphique : Form
    {
        int[] TabData = new int[275];
        string TimeText = "";
        int LireBlockSystem = 0;


        public Graphique()
        {
            InitializeComponent();
        }

        private void Graphique_Load(object sender, EventArgs e)
        {
            double[] Base = new double[BlockLigne];
            string[] NameBase = new string[BlockLigne];

            double[] TempOut = new double[BlockLigne];
            double[] TempIn = new double[BlockLigne];
            double[] FreqHz = new double[BlockLigne];
            double[] Debit = new double[BlockLigne];
            double[] Degivrage = new double[BlockLigne];

            for (LireBlockSystem = 0; LireBlockSystem < BlockLigne; LireBlockSystem++)
            {
                foreach (dynamic item in Form1.filtab[LireBlockSystem])
                {
                    if (item.Name != "TIME")
                        TabData[Convert.ToInt16(item.Name)] = item.Value;
                    else
                        TimeText = item.Value;
                }

                Base[LireBlockSystem] = LireBlockSystem;
                NameBase[LireBlockSystem] = TimeText;

                TempOut[LireBlockSystem] = (double)TabData[105];
                TempIn[LireBlockSystem] = (double)TabData[104];
                FreqHz[LireBlockSystem] = (double)TabData[100];
                Debit[LireBlockSystem] = (double)TabData[138]/100;
                Degivrage[LireBlockSystem] = (double)TabData[106];

                if (LireBlockSystem > 3)
                {

                    TempIn[LireBlockSystem] = (TempIn[LireBlockSystem - 3] + TempIn[LireBlockSystem - 2] + TempIn[LireBlockSystem - 1] + (TempIn[LireBlockSystem] * 4)) / 7;
                    TempOut[LireBlockSystem] = (TempOut[LireBlockSystem - 3] + TempOut[LireBlockSystem - 2] + TempOut[LireBlockSystem - 1] + TempOut[LireBlockSystem] * 4) / 7;
                    Degivrage[LireBlockSystem] = (Degivrage[LireBlockSystem - 3] + Degivrage[LireBlockSystem - 2] + Degivrage[LireBlockSystem - 1] + Degivrage[LireBlockSystem] * 4) / 7;


                }
            }




            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Axes.Bottom.SetTicks(Base, NameBase);

            var sig1 = formsPlot1.Plot.Add.Scatter(Base, TempOut);
            var sig2 = formsPlot1.Plot.Add.Scatter(Base, TempIn);
            var sig3 = formsPlot1.Plot.Add.Scatter(Base, FreqHz);
            var sig4 = formsPlot1.Plot.Add.Scatter(Base, Debit);
            var sig5 = formsPlot1.Plot.Add.Scatter(Base, Degivrage);

            sig1.Smooth = true;
            sig2.Smooth = true;
            sig5.Smooth = true;

            formsPlot1.Plot.Axes.AntiAlias(true);



            sig1.LegendText = "Sortie d'eau";
            sig2.LegendText = "Entree d'eau";
            sig3.LegendText = "Freq Compresseur";
            sig4.LegendText = "débit";
            sig5.LegendText = "Echangeur Exterieur";



            formsPlot1.Plot.ShowLegend();
            formsPlot1.Plot.Axes.Hairline(true);

            if (Form1.chk_tempin == 0) formsPlot1.Plot.Remove(sig2);
            if (Form1.chk_tempout == 0) formsPlot1.Plot.Remove(sig1);
            if (Form1.chk_freq == 0) formsPlot1.Plot.Remove(sig3);
            if (Form1.chk_debit == 0) formsPlot1.Plot.Remove(sig4);
            if (Form1.chk_echext == 0) formsPlot1.Plot.Remove(sig5);



            formsPlot1.Refresh();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
    }
}
