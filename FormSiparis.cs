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
    public partial class FormSiparis : Form
    {
        public FormSiparis()
        {
            InitializeComponent();
        }
        //Local Alan
        public string satir;
        public static Urun U = new Urun();
        StokKontrol stk = new StokKontrol();

        private void FormSiparis_Load(object sender, EventArgs e)
        {
            //ÜRÜN OKUTUP LİSTBOXA EKLEME
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
            //////////////////////////////
        }
        //Stok Kontrolü Bölümü
        private void BtnSepeteEkle_Click(object sender, EventArgs e)
        {
            string[] Dizi = File.ReadAllLines("Stok.txt");
            string deger = Dizi[stk.Secili];
            int tutucu = Convert.ToInt32(deger);
            int aradeger = tutucu;
            tutucu = tutucu - Convert.ToInt32(nudAdet.Value);
            if (tutucu <0)
            {
                    MessageBox.Show(" Son" + aradeger + " Adet:");
            }
            
            else
            {
                string yeniDeger = Convert.ToString(tutucu);
                Dizi[stk.Secili] = yeniDeger;
                File.WriteAllLines("Stok.txt", Dizi);
                //Stok adeti kontol mesajı
                string[] Dizi1 = File.ReadAllLines("Stok.txt");
                string deger1 = Dizi1[stk.Secili];
                int tutcu1 = Convert.ToInt32(deger1);

                if (tutcu1 <0)
                {
                    MessageBox.Show("STOK Kalmadı");
                }

                else
                {
                    //SiparişDetay Sınıfı Ataması
                    SiparisDetay siparis = new SiparisDetay();
                    siparis.Adet = Convert.ToInt32(nudAdet.Value);
                    siparis.Vergi_Durumu = 18;
                    //Urun Sınıfı Atamaları
                    U.Kargo_Agirligi = Convert.ToInt16(listboxKargoAgirligi.SelectedItem);


                    //Listview Atamaları
                    ListViewItem list = new ListViewItem();
                    int temp1 = Convert.ToInt32(nudAdet.Value);
                    int temp = Convert.ToInt32(listboxFiyat.Items[listboxFiyat.SelectedIndex].ToString());
                    if (temp1==0)
                    {
                        MessageBox.Show("Lütfen Bir Ürün Seçiniz!!!");
                    }
                    //Listview Kolon Eklemeleri
                    list.Text = FormMusteriBilgileri.customer.Ad + " " + FormMusteriBilgileri.customer.Soyad;//Adı Soyadı
                    list.SubItems.Add(listboxUrun.Items[listboxUrun.SelectedIndex].ToString());//Ürün Adı
                    list.SubItems.Add(nudAdet.Value.ToString());//Ürün Adeti
                    list.SubItems.Add(DateTime.Now.ToString());//Tarih
                    list.SubItems.Add(listboxFiyat.Items[listboxFiyat.SelectedIndex].ToString());//Fiyat
                    list.SubItems.Add(FormMusteriBilgileri.customer.Email);//Email
                    list.SubItems.Add(FormMusteriBilgileri.customer.Adres);//Adres
                    list.SubItems.Add(FormMusteriBilgileri.customer.Telefon);//Telefon
                    list.SubItems.Add("%" + siparis.Vergi_Durumu);//Vergi
                    list.SubItems.Add(siparis.Ara_Toplam(temp, siparis.Adet).ToString());//Ara Toplam Hesaplatma
                    list.SubItems.Add(listboxKargoAgirligi.Items[listboxKargoAgirligi.SelectedIndex].ToString());//Ürün Ağırlığı
                    list.SubItems.Add(U.Kargo_Agirlik_Hesapla(temp1).ToString());//Ürün Kargo Ağırlığı
                    list.SubItems.Add(U.Urun_Fiyati(temp, siparis.Adet).ToString());//Ürün Toplam Fiyatı
                    lwSepet.Items.Add(list);
                }
            }
        }
        //Listbox İndex Eşitlemeleri
        private void listboxUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxUrunAgirlik.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex;
            int index = listboxUrun.SelectedIndex;
            stk.Secili = index;
        }

        private void listboxUrunAgirlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxUrunAgirlik.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex;
        }

        private void listboxKargoAgirligi_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxUrunAgirlik.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex;
        }

        private void listboxVergiOrani_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxUrunAgirlik.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex;
        }

        private void listboxFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxUrunAgirlik.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxVergiOrani.SelectedIndex = listboxKargoAgirligi.SelectedIndex = listboxFiyat.SelectedIndex = listboxUrun.SelectedIndex;
        }

        //Muşterinin vermiş olduğu tüm sipariş bilgerini txt dosyasına yazdırma
        private void btnOdeme_Click(object sender, EventArgs e)
        {
            const int SUBITEM1_POS = 0;
            const int SUBITEM2_POS = 1;
            const int SUBITEM3_POS = 2;
            const int SUBITEM4_POS = 3;
            const int SUBITEM6_POS = 5;
            const int SUBITEM7_POS = 6;
            const int SUBITEM8_POS = 7;
            const int SUBITEM12_POS = 11;
            const int SUBITEM13_POS = 12;


            StreamWriter sw = File.AppendText("MusteriTakip.txt");

            for (int i = 0; i < lwSepet.Items.Count; i++)
            {
                string currentSubItem1 = lwSepet.Items[i].SubItems[SUBITEM1_POS].Text;
                string currentSubItem2 = lwSepet.Items[i].SubItems[SUBITEM2_POS].Text;
                string currentSubItem3 = lwSepet.Items[i].SubItems[SUBITEM3_POS].Text;
                string currentSubItem4 = lwSepet.Items[i].SubItems[SUBITEM4_POS].Text;
                string currentSubItem6 = lwSepet.Items[i].SubItems[SUBITEM6_POS].Text;
                string currentSubItem7 = lwSepet.Items[i].SubItems[SUBITEM7_POS].Text;
                string currentSubItem8 = lwSepet.Items[i].SubItems[SUBITEM8_POS].Text;
                string currentSubItem12 = lwSepet.Items[i].SubItems[SUBITEM12_POS].Text;
                string currentSubItem13 = lwSepet.Items[i].SubItems[SUBITEM13_POS].Text;

                //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
                sw.WriteLine("Adı Soyadı :"+currentSubItem1 +"     Ürün Adı :"+ currentSubItem2 +"     Ürün Adeti :"+ currentSubItem3 
                    +"     Sipariş Tarihi :"+ currentSubItem4 +"     Mail Adresi :"+  currentSubItem6 +"     Kargo Adresi :"+ currentSubItem7 
                    +"     Gsm :"+ currentSubItem8 + "     Kargo Ağırlığı :"+currentSubItem12 + "     Toplam Fiyat :"+currentSubItem13);

                //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            }
            sw.Close();

            // bütün ürünlerin tutarını tek değişkene atama işlemi
            decimal Toplam2 = 0;

            //int dizitemp=0;//dizi indis adeti  için bir değişken
            for (int j= 0; j < lwSepet.Items.Count; j++)
            {
                string toplam = lwSepet.Items[j].SubItems[12].Text;
                decimal Toplam1 = Convert.ToDecimal(toplam);
                Toplam2 = Toplam2 + Toplam1;
            }
             U.TumToplam = Toplam2;//toplam fiyatı urun dizisine attık

            string metin1;
            string metin2;
            string metin3;

            // SepettekiUrunler.txt dosyasında daha önceki kayıtları siliyoruz.
            TextWriter tw = new StreamWriter("SepettekiUrunler.txt");
            tw.Write("");
            tw.Close();

            // SepettekiUrunler.txt Dosyasına yeni kayıtları giriyoruz.
            for (int j = 0; j <lwSepet.Items.Count; j++)
            {
                metin1 = lwSepet.Items[j].SubItems[1].Text;
                metin2 = lwSepet.Items[j].SubItems[2].Text;
                metin3 = lwSepet.Items[j].SubItems[12].Text;

                StreamWriter SWSepet= File.AppendText("SepettekiUrunler.txt");
                SWSepet.WriteLine("Ürün Adı : "+metin1+"      Ürün Adedi :"+metin2+"      Fiyat :"+metin3);
                SWSepet.Close();
            }
            FormOdeme form = new FormOdeme();
            form.Show();
        }
    }
}
