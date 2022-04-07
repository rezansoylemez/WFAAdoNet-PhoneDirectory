using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAAdoNet_TelefonReber.Entities;
using WFAAdoNet_TelefonReber.Repositories;

namespace WFAAdoNet_TelefonReber
{
    public partial class AdresEkleForm2 : Form
    {
        AdreslerRepository adreslerRepository;
        KisiRepository kisiRepository;
        Adres adres;
        int kisiID = 0;     
        public AdresEkleForm2()
        {
            InitializeComponent();
            kisiRepository = new KisiRepository();
        }
        public AdresEkleForm2(int _kisiID)
        {
            InitializeComponent();
            kisiID = _kisiID;
            adreslerRepository = new AdreslerRepository();
            adres = new Adres();
        }
        private void AdresEkleForm2_Load(object sender, EventArgs e)
        {
            ShowAdress();
        }
       
        private void ShowAdress()
        {      
            listView1.Items.Clear();
            List<Adres> adreslerList = adreslerRepository.GetByKisiID(kisiID);
            
            ListViewItem listViewItem;
            foreach (Adres item in adreslerList)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = item.Il.ToString();
                listViewItem.SubItems.Add(item.Ilce).ToString();
                listViewItem.SubItems.Add(item.AdresDetay).ToString();
                listViewItem.Tag = item.AdresID;//Şurda bi dursun lazım olacak
                
                listView1.Items.Add(listViewItem);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSehir.Text!=""|| txtİlce.Text != "" || txtAdresDeteay.Text != "")
            {
                adres.Il = txtSehir.Text;
                adres.Ilce = txtİlce.Text;
                adres.AdresDetay = txtAdresDeteay.Text;

                int affected1 = 0;
                int affected3 = 0;
                //Once yeni bir adres kaydı gerçekleşti
                affected1 = adreslerRepository.AdressAdd(adres);
                //kaydedilen adresten sonra txtSehir deki bilgiyle GetAdresID den ID bilgisi affectec2 e kaydedildi
                int affected2 = adreslerRepository.GetAdresID(txtSehir.Text);
                //Gelen affected2 Id bilgisi ve kisiID bilgisi ile KisilerVeAdresleri tablosuna ekleme yapıldı
                affected3 = adreslerRepository.KisiVeADresleriAdd(kisiID, affected2);
                MessageBox.Show("Adres Kaydı Gerçekleşti");
                Clean();
                ShowAdress();
            }
            else
                MessageBox.Show("Lütfen Bir Adres Seçin");
        }

        private void btmGuncelle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int adresID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                adres.AdresID = adresID;
                adres.Il = txtSehir.Text;
                adres.Ilce = txtİlce.Text;
                adres.AdresDetay = txtAdresDeteay.Text;
                adreslerRepository.Update(adres);
                ShowAdress();
                Clean();
                MessageBox.Show("Adres Güncellendi");
            }
            else
                MessageBox.Show("Lütfen Bir Adres Seçin");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count!=0)
            {
                int adresID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                adreslerRepository.DeleteAdres(adresID);
                //Foreignkey probleminden oluşan delete ve update edememe problemi KisilerVeAdresleri tablosunun desing ve Relationship sekmesinden update ve delete cescade yapılarak izin verildi
                ShowAdress();
                MessageBox.Show("Adres Silindi");
            }
            else
                MessageBox.Show("Lütfen Bir Adres Seçin");
        }
        void Clean()
        {
            if (txtSehir.Text != "" || txtİlce.Text != "" || txtAdresDeteay.Text != "")
            {
                txtSehir.Text = "";
                txtİlce.Text = "";
                txtAdresDeteay.Text = ""; 
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtSehir.Text = item.SubItems[1].Text;
                txtİlce.Text = item.SubItems[2].Text;
            }
            else
                MessageBox.Show("Lütfen Bir Adres Seçin");
        }
    }
}
