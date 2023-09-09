using System;
using System.Windows.Forms;
using System.Xml;

namespace Döviz_uyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun_tarih = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xml_dosya = new XmlDocument();
            xml_dosya.Load(bugun_tarih);

            string dolar_alis = xml_dosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolar_al_lbl.Text = dolar_alis;

            string dolar_satis = xml_dosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolar_sat_lbl.Text = dolar_satis;

            string euro_alis = xml_dosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euro_al_lbl.Text = euro_alis;

            string euro_satis = xml_dosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euro_sat_lbl.Text = euro_satis;
        }

        private void dolar_al_btn_Click(object sender, EventArgs e)
        {
            kur_textBox.Text = dolar_al_lbl.Text;
        }

        private void dolar_sat_btn_Click(object sender, EventArgs e)
        {
            kur_textBox.Text = dolar_sat_lbl.Text;
        }

        private void euro_al_btn_Click(object sender, EventArgs e)
        {
            kur_textBox.Text = euro_al_lbl.Text;
        }

        private void euro_sat_btn_Click(object sender, EventArgs e)
        {
            kur_textBox.Text = euro_sat_lbl.Text;
        }

        private void satis_yap_btn_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(kur_textBox.Text);
            miktar = Convert.ToDouble(miktar_textBox.Text);
            tutar = kur * miktar;
            tutar_textBox.Text = tutar.ToString();

        }

        private void satis_yap2_btn_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(kur_textBox.Text);
            int miktar = Convert.ToInt32(miktar_textBox.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            tutar_textBox.Text = tutar.ToString();
            double kalan;
            kalan = miktar % tutar;
            kalan_textBox.Text = kalan.ToString();
        }
    }
}
