using Code4Bugs.Utils.Types;
using static mideasav.Form1;

namespace mideasav
{
    public partial class SetingCom : Form
    {
        public SetingCom()
        {
            InitializeComponent();
        }

        private void seting_Load(object sender, EventArgs e)
        {
             PortCom.Text= Form1.PcomS;
             SelDevicePac.SelectedIndex= Form1.PdevS.ToInt()-1;
        }


        private void BtnValide_Click(object sender, EventArgs e)
        {
  
            Form1.PcomS = PortCom.Text;
            Form1.PdevS = (SelDevicePac.SelectedIndex + 1).ToString();

            this.Close();

        }
    }
}
