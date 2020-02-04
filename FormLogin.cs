using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjeOrijinal
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

     
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                //Text'e Kayıt Ekleme
                StreamWriter SW = File.AppendText("login.txt");
                SW.WriteLine("Kullanıcı Adı : " + txtKadi.Text + "  Sifre: " + mtSifre.Text);
                SW.Close();

                MessageBox.Show("Kayıt Başarılı !");
                //Kutuları Temizleme
                txtAd.Clear();
                txtSoyad.Clear();
                txtMail.Clear();
                txtKadi.Clear();
                mtSifre.Clear();
                mtTel.Clear();
                txtAd.Focus();
            }
            catch
            {
                MessageBox.Show("HATA!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnYoneticiGiris_Click(object sender, EventArgs e)
        {
            //Yonetici Paneli Giriş İD || ŞİFRESİ
            if (txtYoneticiAdi.Text == "admin")
            {
                if (txtYoneticiSifre.Text == "00000")
                {
                    FormYonetici FY = new FormYonetici();
                    FY.Show();
                    
                    FormSiparis FS = new FormSiparis();
                    FS.Show();
                }
            }
            else
            {
                MessageBox.Show("HATALI YONETİCİ GİRİSİ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            //Kullanıcı Adı Şifre Boş Olup Olmadığı Kontrolü
            string control1, control2;
            control1 = txtKullaniciAdi.Text;
            control2 = txtParola.Text;
            if (control1 == "" || control2 == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifrenizi Giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Kullanıcı Adı Şifre Kayıt Kontrolü
            string temp = "";
            temp = File.ReadAllText("login.txt", Encoding.GetEncoding("windows-1254"));

            if (control1 != "" || control2 != "")
            {
                if (temp.IndexOf(txtKullaniciAdi.Text) != -1)
                {
                    if (temp.IndexOf(txtParola.Text) != -1)
                    {
                        MessageBox.Show("Giriş Başarılı","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Hide();
                        FormMusteriBilgileri form = new FormMusteriBilgileri();
                        form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        
       
    }
}
