using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAAdoNet_TelefonReber.Entities;
using WFAAdoNet_TelefonReber.Repositories;

namespace WFAAdoNet_TelefonReber
{
    public partial class AdminPaneli : Form
    {
        Adres adres;
        AdreslerRepository adreslerRepository;
        public AdminPaneli()
        {
            InitializeComponent();
            adres = new Adres();
            adreslerRepository = new AdreslerRepository();
        }
        SqlConnection connection = new SqlConnection("Server=REZANHPPC\\SQLEXPRESS;Database=Personel;Trusted_Connection=True");
        private void txtAranan_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem listViewItem;
            string ara = txtAranan.Text;
            if (radioSeihr.Checked == true)
            {
                List<Adres> searchedList = adreslerRepository.Search1(txtAranan.Text, Convert.ToInt32(listKisiler.SelectedValue));
                listView1.Items.Clear();
                foreach (Adres item in searchedList)
                {
                    listViewItem = new ListViewItem();
                    listViewItem.Text = item.Il.ToString();
                    listViewItem.SubItems.Add(item.Ilce);
                    listViewItem.SubItems.Add(item.AdresDetay);
                    listViewItem.Tag = item.AdresID;
                    listView1.Items.Add(listViewItem);
                }
            }
            else if (radioIlce.Checked == true)
            {
                List<Adres> searchedList1 = adreslerRepository.Search2(txtAranan.Text, Convert.ToInt32(listKisiler.SelectedValue));
                listView1.Items.Clear();
                foreach (Adres item in searchedList1)
                {
                    listViewItem = new ListViewItem();
                    listViewItem.Text = item.Il;
                    listViewItem.SubItems.Add(item.Ilce);
                    listViewItem.SubItems.Add(item.AdresDetay);
                    listView1.Items.Add(listViewItem);
                }
            }
            else
                MessageBox.Show("Aranacak Bir Bilgi Seçin");
        }
        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Ad,KisiID From Kisiler ", connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            listKisiler.DataSource = dataSet.Tables[0];
            listKisiler.DisplayMember = "Ad";
            listKisiler.ValueMember = "KisiID";
        }
        private void listKisiler_MouseClick(object sender, MouseEventArgs e)
        {
            if (listKisiler.SelectedIndex > -1)
            {
                List<Adres> adresList = new List<Adres>();
                adresList = adreslerRepository.GetByKisiID(Convert.ToInt32(listKisiler.SelectedValue));
                listView1.Items.Clear();
                foreach (Adres item in adresList)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = item.Il;
                    listViewItem.SubItems.Add(item.Ilce);
                    listViewItem.SubItems.Add(item.AdresDetay);
                    listView1.Items.Add(listViewItem);
                }
            }
            else
                MessageBox.Show("Lütfen Bir Adres Seçiniz");
        }
    }
}
