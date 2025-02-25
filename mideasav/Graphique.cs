using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            double[] TempInW = new double[BlockLigne];

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
                TempInW[LireBlockSystem] = (double)TabData[104];

                if (LireBlockSystem> 3)
                {
             
                        TempIn[LireBlockSystem] = (TempIn[LireBlockSystem - 3] + TempIn[LireBlockSystem - 2] + TempIn[LireBlockSystem - 1]+ (TempIn[LireBlockSystem]*4))/7;
                        TempOut[LireBlockSystem] = (TempOut[LireBlockSystem - 3] + TempOut[LireBlockSystem - 2] + TempOut[LireBlockSystem - 1] + TempOut[LireBlockSystem]*4) / 7;

                }
            }




            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Axes.Bottom.SetTicks(Base, NameBase);

            var sig1 = formsPlot1.Plot.Add.Scatter(Base, TempOut);
            var sig2 = formsPlot1.Plot.Add.Scatter(Base, TempIn);
            //var sig3 = formsPlot1.Plot.Add.Scatter(Base, TempInW);

            sig1.Smooth = true;
            sig2.Smooth = true;

            formsPlot1.Plot.Axes.AntiAlias(true);

            

            sig1.LegendText = "Sortie d'eau";
            sig2.LegendText = "Entree d'eau";
            
 

            formsPlot1.Plot.ShowLegend();
            formsPlot1.Plot.Axes.Hairline(true);

            formsPlot1.Refresh();
        }

       
    }
}
