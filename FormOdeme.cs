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
    public partial class FormOdeme : Form
    {
         //FormMusteriBilgileri frm = new FormMusteriBilgileri();
        public FormOdeme()
        {
            InitializeComponent();
        }
        //Local Alan
        string satir;
        Kredi krediodeme = new Kredi();
        Kapıda kapidaodeme = new Kapıda();
        Cek cekodeme = new Cek();
        decimal FiyatKontrol = 0;
        ////////////////////
        private void FormOdeme_Load(object sender, EventArgs e)
        {
            
            labelTutar.Text = Convert.ToString(FormSiparis.U.TumToplam);//toplam tutarı ekrandaki  label'a attık 
      
            //Alınacak Ürünler Listbox'ı
            StreamReader Sw1 = new StreamReader(Application.StartupPath + "\\SepettekiUrunler.txt");
            while ((satir = Sw1.ReadLine()) != null)
            {
                listBoxSEPET.Items.Add(satir);
            }
            Sw1.Close();
            
            //Müşteri Bilgilerini Labellara Ekleme
            lblAdiSoyadi.Text = FormMusteriBilgileri.customer.Ad + " " + FormMusteriBilgileri.customer.Soyad;
            lblGsm.Text = FormMusteriBilgileri.customer.Telefon;
            lblEmail.Text = FormMusteriBilgileri.customer.Email;
            lblAdres.Text = FormMusteriBilgileri.customer.Adres;
            
            //Kart İle ödeme visible kontrolü başlangışta kapalı
            txtTutarKart.Visible = false;
            cmbAy.Visible = false;
            cmbYil.Visible = false;
            cmbKartTipi.Visible = false;
            maskedCVV.Visible = false;
            txtKartNo.Visible = false;

            //kapıda  ödeme visible kontrolü başlangışta kapalı
            txtTutarKapida.Visible = false;
            txtAdresKapidaOdeme.Visible = false;

            // Çek İle odeme visible başlangıçta kapalı
            txtTutarCek.Visible = false;
            txtCekSahibi.Visible = false;
            maskedCekTarih.Visible = false;
            txtCekNumarasi.Visible = false;


        }

        private void btnOdemeTamamla_Click(object sender, EventArgs e)
        {
            //Kredi Kartı İşlemleri 
                krediodeme.fiyat(Convert.ToDecimal(txtTutarKart.Text));
                krediodeme.CVV = maskedCVV.Text;
                krediodeme.KartNo = txtKartNo.Text;
                krediodeme.Tarih = cmbAy.Text + " " + cmbYil.Text;

            //Çek le Ödeme İşlemleri
            cekodeme.fiyat(Convert.ToDecimal(txtTutarCek.Text));    
            cekodeme.BasımTarihi = maskedCekTarih.Text;
            cekodeme.CekSahibi = txtCekSahibi.Text;
            cekodeme.CekNo = txtCekNumarasi.Text;
           
            //Kapıda Ödeme İşlemleri
            kapidaodeme.fiyat( Convert.ToDecimal(txtTutarKapida.Text));
            kapidaodeme.adres = txtAdresKapidaOdeme.Text;

                decimal temp = Convert.ToDecimal(labelTutar.Text);
            
                //Üçlü Ödeme Kodları
                FiyatKontrol = Convert.ToDecimal(txtTutarKapida.Text) + Convert.ToDecimal(txtTutarCek.Text) + Convert.ToDecimal(txtTutarKart.Text);
            string FiyatGenelOdeme;
                if (FiyatKontrol == temp)
                {
                    FiyatGenelOdeme =Convert.ToString(krediodeme.Fiyat + kapidaodeme.Fiyat + cekodeme.Fiyat);
                    MessageBox.Show("Komisyon ve Kesintiler Dahil Ödenecek Tutar :" + FiyatGenelOdeme + "₺", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Ödeme Başarıyla Tamamlandı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Fiyat Değerlerini Kontrol Ediniz","HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            

            //Ödeme Tipini Texte Yazdırma
            StreamWriter Yaz = File.AppendText("MusteriTakip.txt");
            //ÇEK ÖDEME
            if (chechCek.Checked == true)
            {
                Yaz.Write(FormMusteriBilgileri.customer.Ad+"  "+FormMusteriBilgileri.customer.Soyad+"  Çek İle " + cekodeme.Fiyat + "₺  Ödendi");
            }
            //KART ÖDEME
            if (checkKart.Checked == true)
            {
                Yaz.Write("    Kart İle " + krediodeme.Fiyat + "₺  Ödendi");
            }
            //KAPIDA ÖDEME
            if (checkKapida.Checked == true)
            {
                Yaz.Write("    Kapıda Ödeme İle " + kapidaodeme.Fiyat + "₺  Ödenecek");
            }
            Yaz.Close();

            //Textboxları Boşaltma
            txtAdresKapidaOdeme.Clear();
            txtTutarKapida.Clear();
            txtTutarKart.Clear();
            txtKartNo.Clear();
            cmbAy.Text = "";
            cmbYil.Text = "";
            cmbKartTipi.Text = "";
            maskedCVV.Clear();
            txtCekSahibi.Clear();
            txtTutarCek.Clear();
            txtCekNumarasi.Clear();
            maskedCekTarih.Clear();
        }

        private void checkKart_CheckedChanged(object sender, EventArgs e)
        {
            //Check İşaret İşlemleri Kredi Kartı
            if (checkKart.Checked == true)
            {
                txtTutarKart.Visible = true;
                cmbAy.Visible = true;
                cmbYil.Visible = true;
                cmbKartTipi.Visible = true;
                maskedCVV.Visible = true;
                txtKartNo.Visible = true;
            }
            if (checkKart.Checked == false)
            {
                txtTutarKart.Visible = false;
                cmbAy.Visible = false;
                cmbYil.Visible = false;
                cmbKartTipi.Visible = false;
                maskedCVV.Visible = false;
                txtKartNo.Visible = false;
            }
        }

        //Check İşaret İşlemleri Kapıda Ödeme
        private void checkKapida_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkKapida.Checked == true)
            {
                txtTutarKapida.Visible = true;
                txtAdresKapidaOdeme.Visible =true;
            }
            if (checkKapida.Checked == false)
            {
                txtTutarKapida.Visible = false;
                txtAdresKapidaOdeme.Visible = false;
            }

        }
        //Check İşaret İşlemleri Çek ile Ödeme
        private void chechCek_CheckedChanged(object sender, EventArgs e)
        {
            if (chechCek.Checked == true)
            {
                txtTutarCek.Visible = true;
                txtCekSahibi.Visible = true;
                maskedCekTarih.Visible = true;
                txtCekNumarasi.Visible = true;
            }
            if (chechCek.Checked == false)
            {
                txtTutarCek.Visible = false;
                txtCekSahibi.Visible = false;
                maskedCekTarih.Visible = false;
                txtCekNumarasi.Visible = false;
            }
        }
    }
}

