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
    public partial class FormYonetici : Form
    {
        public FormYonetici()
        {
            InitializeComponent();
        }
        //LOCAL ALAN
        public string satir;

        private void FormYonetici_Load(object sender, EventArgs e)
        {
            //Ürünleri Silme Listelemesi
            //Ürünler Listbox
            StreamReader SW1 = new StreamReader(Application.StartupPath + "\\Urunler.txt");
            while ((satir = SW1.ReadLine()) != null)
            {
                lbUrunler.Items.Add(satir);
            }
            SW1.Close();
            //Ürün Ağırlık Listbox
            StreamReader SW2 = new StreamReader(Application.StartupPath + "\\UrunAgirligi.txt");
            while ((satir = SW2.ReadLine()) != null)
            {
                lbUrunAgirlik.Items.Add(satir);
            }
            SW2.Close();
            //Ürün Kargo Ağırlığı Listbox
            StreamReader SW3 = new StreamReader(Application.StartupPath + "\\KargoAgirligi.txt");
            while ((satir = SW3.ReadLine()) != null)
            {
                lbKargoAgirlik.Items.Add(satir);
            }
            SW3.Close();
            //Ürün Vergi Oranı Listbox
            StreamReader SW4 = new StreamReader(Application.StartupPath + "\\VergiOrani.txt");
            while ((satir = SW4.ReadLine()) != null)
            {
                lbVergiOrani.Items.Add(satir);
            }
            SW4.Close();
            //Ürün Fiyat Listbox
            StreamReader SW5 = new StreamReader(Application.StartupPath + "\\Fiyat.txt");
            while ((satir = SW5.ReadLine()) != null)
            {
                lbFiyat.Items.Add(satir);
            }
            SW5.Close();
            //ÜRÜNÜN STOK ADETİNİ OKUDUK LİSTBOXA ATTIK
            StreamReader SWStokAdeti1 = new StreamReader(Application.StartupPath + "\\Stok.txt");
            while ((satir = SWStokAdeti1.ReadLine()) != null)
            {
                lbStok.Items.Add(satir);
            }
            SWStokAdeti1.Close();

            /////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ///////////////////////////////////////////////

            //Ürün Güncelleme Load Olayları
            StreamReader SWad = new StreamReader(Application.StartupPath + "\\Urunler.txt");
            while ((satir = SWad.ReadLine()) != null)
            {
                listboxUrun.Items.Add(satir);
            }
            SWad.Close();
            //URUN AGİRLİGİNİ OKUDUK LİSTBOXA ATTIK
            StreamReader SWUrunAgirlik = new StreamReader(Application.StartupPath + "\\UrunAgirligi.txt");
            while ((satir = SWUrunAgirlik.ReadLine()) != null)
            {
                listboxUrunAgirlik.Items.Add(satir);
            }
            SWUrunAgirlik.Close();
            //URUN FİYATINI OKUDUK LİSTBOXA ATTIK
            StreamReader SWFiyat = new StreamReader(Application.StartupPath + "\\Fiyat.txt");
            while ((satir = SWFiyat.ReadLine()) != null)
            {
                listboxFiyat.Items.Add(satir);
            }
            SWFiyat.Close();
            //KARGO AGİRLİGİNİ OKUDUK LİSTBOXA ATTIK
            StreamReader SWKargoAgirlik = new StreamReader(Application.StartupPath + "\\KargoAgirligi.txt");
            while ((satir = SWKargoAgirlik.ReadLine()) != null)
            {
                listboxKargoAgirligi.Items.Add(satir);
            }
            SWKargoAgirlik.Close();
            //URUNUN VERGİ ORANINI OKUDUK LİSTBOXA ATTIK
            StreamReader SWVergiOrani = new StreamReader(Application.StartupPath + "\\VergiOrani.txt");
            while ((satir = SWVergiOrani.ReadLine()) != null)
            {
                listboxVergiOrani.Items.Add(satir);
            }
            SWVergiOrani.Close();
            //ÜRÜNÜN STOK ADETİNİ OKUDUK LİSTBOXA ATTIK
            StreamReader SWStokAdeti = new StreamReader(Application.StartupPath + "\\Stok.txt");
            while ((satir = SWStokAdeti.ReadLine()) != null)
            {
                listboxStok.Items.Add(satir);
            }
           SWStokAdeti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //Ürün adını yazdırma
                StreamWriter SWad = File.AppendText("Urunler.txt");
                SWad.WriteLine(txtUrunAd.Text);
                SWad.Close();


                //Ürün fiyatını yazdırma
                StreamWriter SWfiyat = File.AppendText("Fiyat.txt");
                SWfiyat.WriteLine(txtUrunFiyat.Text);
                SWfiyat.Close();

                //Ürün  Agirligi yazdırma

                StreamWriter SWurunagirligi = File.AppendText("UrunAgirligi.txt");
                SWurunagirligi.WriteLine(txtUrunAgirlik.Text);
                SWurunagirligi.Close();

                //Ürün Vergi orani yazdırma 

                StreamWriter SWvergiorani = File.AppendText("VergiOrani.txt");
                SWvergiorani.WriteLine(txtUrunKDV.Text);
                SWvergiorani.Close();

                //Ürün Stok adetini yazdırma

                StreamWriter SWstokadeti = File.AppendText("Stok.txt");
                SWstokadeti.WriteLine(txtStokAdeti.Text);
                SWstokadeti.Close();


                //Ürün kargo ağırlığını yazdırma

                StreamWriter SWkargoagirlik = File.AppendText("KargoAgirligi.txt");
                SWkargoagirlik.WriteLine(txtKargoAgirlik.Text);
                SWkargoagirlik.Close();

                MessageBox.Show("Ürün Ekleme Başarılı", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ürün Ekleme Başarısız !!!", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Listbox İndex Eşitlemeleri
        private void listboxUrun_SelectedIndexChanged(object sender, EventArgs e)
        {

           listboxStok.SelectedIndex=listboxUrunAgirlik.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex =  lbStok.SelectedIndex =listboxUrun.SelectedIndex ;
        }

        private void listboxUrunAgirlik_SelectedIndexChanged(object sender, EventArgs e)
        {

            listboxStok.SelectedIndex = listboxUrunAgirlik.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex = listboxStok.SelectedIndex;
        }

        private void listboxKargoAgirligi_SelectedIndexChanged(object sender, EventArgs e)
        {

            listboxStok.SelectedIndex = listboxUrunAgirlik.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex = listboxStok.SelectedIndex;
        }

        private void listboxVergiOrani_SelectedIndexChanged(object sender, EventArgs e)
        {

            listboxStok.SelectedIndex = listboxUrunAgirlik.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex = listboxStok.SelectedIndex;
        }

        private void listboxFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {

            listboxStok.SelectedIndex = listboxUrunAgirlik.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex = listboxStok.SelectedIndex;
        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listboxStok.SelectedIndex = listboxUrunAgirlik.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex = listboxStok.SelectedIndex;
        }

        private void lbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbUrunAgirlik.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbVergiOrani.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbFiyat.SelectedIndex  = lbStok.SelectedIndex = lbUrunler.SelectedIndex;
        }

        private void lbUrunAgirlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbUrunAgirlik.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbVergiOrani.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbFiyat.SelectedIndex  = lbStok.SelectedIndex = lbUrunler.SelectedIndex;
        }

        private void lbKargoAgirlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbUrunAgirlik.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbVergiOrani.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbFiyat.SelectedIndex  = lbStok.SelectedIndex = lbUrunler.SelectedIndex;
        }

        private void lbVergiOrani_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbUrunAgirlik.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbVergiOrani.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbFiyat.SelectedIndex  = lbStok.SelectedIndex = lbUrunler.SelectedIndex;
        }

        private void lbFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbUrunAgirlik.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbVergiOrani.SelectedIndex = lbKargoAgirlik.SelectedIndex = lbFiyat.SelectedIndex = lbStok.SelectedIndex = lbUrunler.SelectedIndex;
        }
        //Güncelleme Butonu
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                //Ürünleri Silme İşlemi
                File.WriteAllLines("Fiyat.txt", File.ReadAllLines("Fiyat.txt").Where(s => !s.StartsWith(listboxFiyat.Items[listboxFiyat.SelectedIndex].ToString())));
                File.WriteAllLines("UrunAgirligi.txt", File.ReadAllLines("UrunAgirligi.txt").Where(s => !s.StartsWith(listboxUrunAgirlik.Items[listboxUrunAgirlik.SelectedIndex].ToString())));
                File.WriteAllLines("KargoAgirligi.txt", File.ReadAllLines("KargoAgirligi.txt").Where(s => !s.StartsWith(listboxKargoAgirligi.Items[listboxKargoAgirligi.SelectedIndex].ToString())));
                File.WriteAllLines("VergiOrani.txt", File.ReadAllLines("VergiOrani.txt").Where(s => !s.StartsWith(listboxVergiOrani.Items[listboxVergiOrani.SelectedIndex].ToString())));
                File.WriteAllLines("Urunler.txt", File.ReadAllLines("Urunler.txt").Where(s => !s.StartsWith(listboxUrun.Items[listboxUrun.SelectedIndex].ToString())));
                File.WriteAllLines("Stok.txt", File.ReadAllLines("Stok.txt").Where(s => !s.StartsWith(listboxStok.Items[listboxStok.SelectedIndex].ToString())));
                //Ürünleri Güncelleyip Ekleme İşlemi

                //Ürün adını yazdırma
                StreamWriter SWUrun = File.AppendText("Urunler.txt");
                SWUrun.WriteLine(txtYeniAd.Text);
                SWUrun.Close();
                //Ürün fiyatını yazdırma
                StreamWriter SWfiyat = File.AppendText("Fiyat.txt");
                SWfiyat.WriteLine(txtYeniFiyat.Text);
                SWfiyat.Close();
                //Ürün  Agirligi yazdırma
                StreamWriter SWurunagirligi = File.AppendText("UrunAgirligi.txt");
                SWurunagirligi.WriteLine(txtYeniAgirlik.Text);
                SWurunagirligi.Close();
                //Ürün Vergi orani yazdırma
                StreamWriter SWvergiorani = File.AppendText("VergiOrani.txt");
                SWvergiorani.WriteLine(txtYeniVergiOrani.Text);
                SWvergiorani.Close();
                //Kargo Ağırlığı Yazdırma
                StreamWriter SWkargoagirligi = File.AppendText("KargoAgirligi.txt");
                SWkargoagirligi.WriteLine(txtYeniKargoAgirlik.Text);
                SWkargoagirligi.Close();
                //Stok Adeti Yazdırma
                StreamWriter SWStok = File.AppendText("Stok.txt");
                SWStok.WriteLine(txtStok.Text);
                SWStok.Close();

                //Textboxların İçini Temizleme
                txtYeniAd.Clear();
                txtYeniAgirlik.Clear();
                txtYeniVergiOrani.Clear();
                txtYeniKargoAgirlik.Clear();
                txtYeniFiyat.Clear();
                txtStok.Clear();

                MessageBox.Show("BAŞARILI");
            }
            catch
            {
                MessageBox.Show("HATA");
            }
        }
        //Seçili Bilgileri Textlere Getirtme
        private void btnBilgiGetir_Click(object sender, EventArgs e)
        {
            txtYeniFiyat.Text = listboxFiyat.Items[listboxFiyat.SelectedIndex].ToString();
            txtYeniVergiOrani.Text = listboxVergiOrani.Items[listboxVergiOrani.SelectedIndex].ToString();
            txtYeniKargoAgirlik.Text = listboxKargoAgirligi.Items[listboxKargoAgirligi.SelectedIndex].ToString();
            txtYeniAgirlik.Text = listboxUrunAgirlik.Items[listboxUrunAgirlik.SelectedIndex].ToString();
            txtYeniAd.Text = listboxUrun.Items[listboxUrun.SelectedIndex].ToString();
            txtStok.Text = listboxStok.Items[listboxStok.SelectedIndex].ToString();
        }

        
       
        private void btnSilGitsin_Click(object sender, EventArgs e)
        {
           try
            {
                File.WriteAllLines("Fiyat.txt", File.ReadAllLines("Fiyat.txt").Where(s => !s.StartsWith(lbFiyat.Items[lbFiyat.SelectedIndex].ToString())));
                File.WriteAllLines("UrunAgirligi.txt", File.ReadAllLines("UrunAgirligi.txt").Where(s => !s.StartsWith(lbUrunAgirlik.Items[lbUrunAgirlik.SelectedIndex].ToString())));
                File.WriteAllLines("KargoAgirligi.txt", File.ReadAllLines("KargoAgirligi.txt").Where(s => !s.StartsWith(lbKargoAgirlik.Items[lbKargoAgirlik.SelectedIndex].ToString())));
                File.WriteAllLines("VergiOrani.txt", File.ReadAllLines("VergiOrani.txt").Where(s => !s.StartsWith(lbVergiOrani.Items[lbVergiOrani.SelectedIndex].ToString())));
                File.WriteAllLines("Urunler.txt", File.ReadAllLines("Urunler.txt").Where(s => !s.StartsWith(lbUrunler.Items[lbUrunler.SelectedIndex].ToString())));
                MessageBox.Show("Silme İşlemi Başarılı");
            }
            catch
            {
                MessageBox.Show("HATA");
            }
        }
        
        //MusteriTakip Dosyasındaki verileri yönetici listbox'ına yazdırma
        private void btnGetir_Click(object sender, EventArgs e)
        {
            StreamReader Sw1 = new StreamReader(Application.StartupPath + "\\MusteriTakip.txt");

            while ((satir = Sw1.ReadLine()) != null)
            {
                lblMusteriTakip.Items.Add(satir);
            }
            Sw1.Close();
        }

        private void FormGetir_Click(object sender, EventArgs e)
        {
            FormSiparis fs = new FormSiparis();
            fs.Show();
        }

        private void FormSiparisGetir_Click(object sender, EventArgs e)
        {
            FormSiparis fs1 = new FormSiparis();
            fs1.Show();
        }

        private void FormGetirmee_Click(object sender, EventArgs e)
        {
            FormSiparis fs2 = new FormSiparis();
            fs2.Show();
        }
    }
}
