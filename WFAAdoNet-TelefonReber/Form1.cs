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
    public partial class Form1 : Form
    {
        KisiRepository kisiRepository;
        Kisiler kisiler;
        public Form1()
        {
            InitializeComponent();
            kisiRepository = new KisiRepository();
            kisiler = new Kisiler();  
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPerson();
        }
        private void ShowPerson()
        {
            listView1.Items.Clear();
            ListViewItem listViewItem;
            List<Kisiler> kisilerList = kisiRepository.Get();
            foreach (Kisiler item in kisilerList)//kisiRepository.get methodundan alınan listeyi lisViewa yazdırmak
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = item.KisiID.ToString();
                listViewItem.SubItems.Add(item.Ad).ToString();
                listViewItem.SubItems.Add(item.Soyad).ToString();
                listViewItem.SubItems.Add(item.Telefon).ToString();
                listViewItem.Tag = item.KisiID;
                listView1.Items.Add(listViewItem);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" || txtSoyad.Text != "" || masktxtTel.Text != "")
            {
                kisiler.Ad = txtAd.Text;
                kisiler.Soyad = txtSoyad.Text;
                kisiler.Telefon = masktxtTel.Text;
                int affected = 0;
                affected = kisiRepository.Add(kisiler);
                MessageBox.Show("Kişi Kaydı Gerçekleşti" + kisiler.Ad + " " + kisiler.Soyad);
                ShowPerson();
                Clean();
            }
            else
                MessageBox.Show("Lütfen Veri Girişi Yapın");
            
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" || txtSoyad.Text != "" || masktxtTel.Text != "")
            {
                int kisiID = Convert.ToInt32(listView1.SelectedItems[0].Tag);

                kisiler.KisiID = kisiID;
                kisiler.Ad = txtAd.Text;
                kisiler.Soyad = txtSoyad.Text;
                kisiler.Telefon = masktxtTel.Text;
                int affected = 0;
                affected = kisiRepository.Update(kisiler);
                MessageBox.Show("Kişi Güncellendi");
                ShowPerson();
                Clean();
                btnKaydet.Enabled = true;
            }
            else
                MessageBox.Show("Lütfen Veri Girişi Yapın");
        }
        private void txtrAra_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem listViewItem;
            string ara = txtrAra.Text;
            List<Kisiler> searchedList = kisiRepository.Search(txtrAra.Text);
            foreach (Kisiler item in searchedList)//kisiRepository.get methodundan alınan listeyi lisViewa yazdırmak
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = item.KisiID.ToString();
                listViewItem.SubItems.Add(item.Ad).ToString();
                listViewItem.SubItems.Add(item.Soyad).ToString();
                listViewItem.SubItems.Add(item.Telefon).ToString();
                listViewItem.Tag = item.KisiID;//Şurda bi dursun lazım olacak
                listView1.Items.Add(listViewItem);
            }
        }      
        private void adresEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kisiID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            
            AdresEkleForm2 adresEkleForm2 = new AdresEkleForm2(kisiID);
            adresEkleForm2.ShowDialog();
        }
        void Clean()
        {
            if (txtAd.Text != "" || txtSoyad.Text != "" || masktxtTel.Text != "" || txtrAra.Text != "")
            {
                txtAd.Text = "";
                txtSoyad.Text = "";
                txtrAra.Text = "";
                masktxtTel.Text = "";
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtAd.Text = item.SubItems[1].Text;
                txtSoyad.Text = item.SubItems[2].Text;
                masktxtTel.Text = item.SubItems[3].Text;
                btnKaydet.Enabled = false;
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kisiID = Convert.ToInt32(listView1.SelectedItems[0].Tag); 
            kisiRepository.DeleteKisilerVeAdresleri(kisiID);
            kisiRepository.DeleteKisiler(kisiID);
            int adresID = kisiRepository.GetbyKisiIDKisilerVeAdresleri(kisiID);
            kisiRepository.DeleteAdres(adresID);
            MessageBox.Show("Kişi ve Adres Bilgileri Silindi");
            ShowPerson();
            Clean();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminPaneli adminPaneli = new AdminPaneli();
            adminPaneli.ShowDialog();
        }
    }
}
    
