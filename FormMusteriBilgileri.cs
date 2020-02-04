using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOrijinal
{
    public partial class FormMusteriBilgileri : Form
    {
        public FormMusteriBilgileri()
        {
            InitializeComponent();
        }
        //Local Nesne Oluşturma 
        public static Musteri customer = new Musteri();

       
        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            //Classlara Atamalar
            customer.Ad = txtAd.Text;
            customer.Soyad = txtSoyad.Text;
            customer.Telefon = mtTel.Text;
            customer.Email = txtMail.Text;
            customer.Adres = rtAdres.Text;
            //Form Gizleme Gösterme
            this.Hide();
            

            FormSiparis FS = new FormSiparis();
            FS.Show();
        }

        private void FormMusteriBilgileri_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen Sipariş Vermeden Önce Bilgilerini Doğru Bir Şekilde Giriniz !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
