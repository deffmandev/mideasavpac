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

            cb1.Checked = Form1.chk_tempin == 1;
            cb2.Checked = Form1.chk_tempout == 1;
            cb3.Checked = Form1.chk_freq == 1;
            cb4.Checked = Form1.chk_debit == 1;
            cb5.Checked = Form1.chk_echext == 1;
        }


        private void BtnValide_Click(object sender, EventArgs e)
        {
  
            Form1.PcomS = PortCom.Text;
            Form1.PdevS = (SelDevicePac.SelectedIndex + 1).ToString();

            Form1.chk_tempin = (byte)(cb1.Checked ? 1 : 0);
            Form1.chk_tempout = (byte)(cb2.Checked ? 1 : 0);
            Form1.chk_freq = (byte)(cb3.Checked ? 1 : 0);
            Form1.chk_debit = (byte)(cb4.Checked ? 1 : 0);
            Form1.chk_echext = (byte)(cb5.Checked ? 1 : 0);

            this.Close();

        }
    }
}
