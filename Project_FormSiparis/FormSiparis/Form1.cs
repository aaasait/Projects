using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace FormSiparis
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public string SucukName;
        public string SosisName;
        public string MantarName;
        public string KasarName;
        public string PeynirName;
        public string SebzeName;
        public double KucukBoy= 9.90;
        public double OrtaBoy=19.90;
        public double BuyukBoy=29.90;
        public double Su = 1.5;
        public double Kola = 2.5;
        public double Ayran = 3.5;
        public double SucukPrice = 3.0;
        public double SosisPrice = 2.0;
        public double MantarPrice = 2.5;
        public double KasarPrice = 4.5;
        public double PeynirPrice = 4.0;
        public double SebzePrice = 5.0;
        public double EkstraSum=0;

         public double LabelPricePizza; // Label da dinamik fiyat göstermek için
        
        public double LabelPriceIcecek;
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // ComboPizza Ekleme
                Pizza pizzaDefault = new Pizza(0, "--Pizza Seç--", 0);
                Pizza pizzaKucuk = new Pizza(1, "Küçük", KucukBoy);
                Pizza pizzaOrta = new Pizza(2, "Orta", OrtaBoy);
                Pizza pizzaBuyuk = new Pizza(3, "Buyuk", BuyukBoy);

                GetComboboxList comboPizza = new GetComboboxList();
                comboPizza.GetPizzaList(pizzaDefault);
                comboPizza.GetPizzaList(pizzaKucuk);
                comboPizza.GetPizzaList(pizzaOrta);
                comboPizza.GetPizzaList(pizzaBuyuk);

                combo_Pizza.DataSource = comboPizza.pizzaList;
                combo_Pizza.ValueMember = "pizzaId";
                combo_Pizza.DisplayMember = "pizzaName";

                // ComboIcecek Ekleme
                Icecek icecekDefault = new Icecek(0, "--İçecek Seç", 0);
                Icecek icecekSu = new Icecek(1, "Su", Su);
                Icecek icecekKoca = new Icecek(2, "Kola", Kola);
                Icecek icecekAyran = new Icecek(3, "Ayran", Ayran);


                GetComboboxList comboIcecek = new GetComboboxList();
                comboIcecek.GetIcecekList(icecekDefault);
                comboIcecek.GetIcecekList(icecekSu);
                comboIcecek.GetIcecekList(icecekKoca);
                comboIcecek.GetIcecekList(icecekAyran);


                combo_Icecek.DataSource = comboIcecek.icecekList;
                combo_Icecek.ValueMember = "icecekId";
                combo_Icecek.DisplayMember = "icecekName";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        int s_PizzaCount;
        private async void btn_SiparisAl_Click(object sender, EventArgs e)
        {
            try
            {
                string s_NameSurname = txtAdSoyad.Text;
                string s_Phone = txtTelefon.Text;
                string s_Address = txtAdres.Text;
                string pizza_id = combo_Pizza.GetItemText(combo_Pizza.SelectedValue);
                int s_Pizza = Convert.ToInt32(pizza_id);
                s_PizzaCount = Convert.ToInt32(numeric_PizzaAdet.Value);
                string icecek_id = combo_Icecek.GetItemText(combo_Icecek.SelectedValue);
                int s_Icecek = Convert.ToInt32(icecek_id);
                int s_IcecekCount = Convert.ToInt32(numeric_IcecekAdet.Value);


                string[] EkstraList = new string[6]; ; // Ekstra Göstermek için

                // Sucuk Kontrol
                bool s_Sucuk;
                if (check_Sucuk.Checked)
                {
                    s_Sucuk = true;
                    SucukPrice = 3.0;
                    EkstraSum += SucukPrice;
                    SucukName = "Sucuk ";
                    EkstraList[0] = SucukName;
                }
                else
                {
                    s_Sucuk = false;
                    SucukPrice = 0;
                    SucukName = "";
                    EkstraList[0] = SucukName;
                }
                // Sosis Kontrol
                bool s_Sosis;
                if (check_Sosis.Checked)
                {
                    s_Sosis = true;
                    SosisPrice = 2.0;
                    EkstraSum += SosisPrice;
                    SosisName = "Sosis ";
                    EkstraList[1] = SosisName;

                }
                else
                {
                    s_Sosis = false;
                    SosisPrice = 0;
                    SosisName = "";
                    EkstraList[1] = SosisName;
                }
                // Mantar Kontrol
                bool s_Mantar;
                if (check_Mantar.Checked)
                {
                    s_Mantar = true;
                    MantarPrice = 2.5;
                    EkstraSum += MantarPrice;
                    MantarName = "Mantar ";
                    EkstraList[2] = MantarName;
                }
                else
                {
                    s_Mantar = false;
                    MantarPrice = 0;
                    MantarName = "";
                    EkstraList[2] = MantarName;
                }

                // Kaşar Kontrol
                bool s_Kaşar;
                if (check_Kasar.Checked)
                {
                    s_Kaşar = true;
                    KasarPrice = 4.5;
                    EkstraSum += KasarPrice;
                    KasarName = "Kasar ";
                    EkstraList[3] = KasarName;
                }
                else
                {
                    s_Kaşar = false;
                    KasarPrice = 0;
                    KasarName = "";
                    EkstraList[3] = KasarName;
                }

                // Peynir Kontrol
                bool s_Peynir;
                if (check_Peynir.Checked)
                {
                    s_Peynir = true;
                    PeynirPrice = 4.0;
                    EkstraSum += PeynirPrice;
                    PeynirName = "Peynir ";
                    EkstraList[4] = PeynirName;
                }
                else
                {
                    s_Peynir = false;
                    PeynirPrice = 0;
                    PeynirName = "";
                    EkstraList[4] = PeynirName;
                }

                // Sebze Kontrol
                bool s_Sebze;
                if (check_Sebze.Checked)
                {
                    s_Sebze = true;
                    SebzePrice = 5.0;
                    EkstraSum += SebzePrice;
                    SebzeName = "Sebze ";
                    EkstraList[5] = SebzeName;
                }
                else
                {
                    s_Sebze = false;
                    SebzePrice = 0;
                    SebzeName = "";
                    EkstraList[5] = SebzeName;
                }

                Siparis sp = new Siparis(s_NameSurname, s_Phone,
                    s_Address, s_Pizza, s_PizzaCount,
                    s_Icecek, s_IcecekCount, s_Sucuk,
                    s_Sosis, s_Mantar, s_Kaşar, s_Peynir, s_Sebze);

                SiparisGet spGet = new SiparisGet();
                spGet.SiparisAdd(sp);

                // Seçilen Ekstralar Check Kontrolü
                bool[] ekstra = new bool[6];
                ekstra[0] = s_Sucuk;
                ekstra[1] = s_Sosis;
                ekstra[2] = s_Mantar;
                ekstra[3] = s_Kaşar;
                ekstra[4] = s_Peynir;
                ekstra[5] = s_Sebze;

                bool[] ekstraEkli = new bool[6];
                int trueCount = 0;
                for (int i = 0; i < ekstra.Length; i++)
                {
                    if (ekstra[i] == true)
                    {
                        ekstraEkli[i] = true;
                        trueCount += 1;
                    }
                    else
                    {
                        ekstraEkli[i] = false;
                    }
                }

                //  EkstraList = new string[trueCount];// Lİstview için ekstra

                // Pizza Fiyatı ALMA
                string c_pizza_id = combo_Pizza.GetItemText(combo_Pizza.SelectedValue);
                int c_Pizza = Convert.ToInt32(c_pizza_id);
                double SelectedPizzaPrice = 0;

                if (c_Pizza == 1)
                {
                    SelectedPizzaPrice = KucukBoy;
                }
                else if (c_Pizza == 2)
                {
                    SelectedPizzaPrice = OrtaBoy;
                }
                else if (c_Pizza == 3)
                {
                    SelectedPizzaPrice = BuyukBoy;
                }

                string c_icecek_id = combo_Icecek.GetItemText(combo_Icecek.SelectedValue);
                int c__Icecek = Convert.ToInt32(c_icecek_id);

                double SelectedIcecekPrice = 0;

                if (c__Icecek == 1)
                {
                    SelectedIcecekPrice = Su;
                }
                else if (c__Icecek == 2)
                {
                    SelectedIcecekPrice = Kola;
                }
                else if (c__Icecek == 3)
                {
                    SelectedIcecekPrice = Ayran;
                }

                double sumPizza = s_PizzaCount * SelectedPizzaPrice;
                double sumIcecek = s_IcecekCount * SelectedIcecekPrice;
                EkstraSum = EkstraSum * s_PizzaCount;
                double sum = sumPizza + sumIcecek + EkstraSum;
                // Pizza Türü ve Adet Alma LİSTVIEV İÇİN
                string pizzaTuru = "";

                if (c_Pizza == 1)
                {
                    pizzaTuru = "Küçük Boy " + sp.PizzaCount.ToString();
                }
                else if (c_Pizza == 2)
                {
                    pizzaTuru = "Orta Boy " + sp.PizzaCount.ToString();
                }
                else if (c_Pizza == 3)
                {
                    pizzaTuru = "Büyük Boy " + sp.PizzaCount.ToString();
                }

                // Ekstra 

                string ekstra_write = "";
                foreach (var item in EkstraList)
                {
                    ekstra_write += item;
                }

                // Icecek Türü ve Adet Alma LİSTVIEV İÇİN
                string icecekTuru = "";
                if (c__Icecek == 1)
                {
                    icecekTuru = "Su " + sp.IcecekCount.ToString();
                }
                else if (c__Icecek == 2)
                {
                    icecekTuru = "Kola " + sp.IcecekCount.ToString();
                }
                else if (c__Icecek == 3)
                {
                    icecekTuru = "Ayran " + sp.IcecekCount.ToString();
                }

                ListSiparis ls = new ListSiparis(s_NameSurname, s_Phone, s_Address, pizzaTuru, ekstra_write, icecekTuru, sum.ToString());

                ListSiparisGet spg = new ListSiparisGet();
                spg.Add(ls);
                string[] st = new string[7];
                st[0] = await spg.GetNameSurname();
                st[1] = await spg.GetPhone();
                st[2] = await spg.GetAddress();
                st[3] = await spg.GetPizzaBoyAdet();
                st[4] = await spg.GetEkstra();
                st[5] = await spg.GetIcecekAdet();
                st[6] = await spg.GetUcret();
                var listViewItem = new ListViewItem(st);
                listViewSiparis.Items.Add(listViewItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

       
       
        private async void btn_Temizle_Click(object sender, EventArgs e)
        {
            try
            {
                txtAdSoyad.Text = string.Empty;
                txtTelefon.Text = string.Empty;
                txtAdres.Text = string.Empty;
                numeric_PizzaAdet.Value = 0;
                numeric_IcecekAdet.Value = 0;
                combo_Icecek.SelectedValue = 0;
                combo_Pizza.SelectedValue = 0;
                check_Kasar.Checked = false;
                check_Sebze.Checked = false;
                check_Peynir.Checked = false;
                check_Mantar.Checked = false;
                check_Sosis.Checked = false;
                check_Sucuk.Checked = false;
                sumAll = 0;
                sumPizza = 0;
                sumIcecek = 0;
                lblPrice.Text = "0";
                lblEkstra.Text = "0";
                ekstralar = 0;
                SucukClickCount = 0;
                SosisClickCount = 0;
                MantarClickCount = 0;
                KasarClickCount = 0;
                PeynirClickCount = 0;
                SebzeClickCount = 0;
                this.Close();
                Form1 fr = new Form1();
                fr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        double ekstralar;
        bool b;
        // CHECKBOX SUCUK FİYATI      
        int SucukClickCount;
        private async void check_Sucuk_Click(object sender, EventArgs e)
        {
            try
            {
                SucukClickCount += 1;
                if (check_Sucuk.Checked)
                {

                    if (SucukClickCount % 2 == 1)
                    {
                        b = true;
                        ekstralar += SucukPrice;
                        lblEkstra.Text = ekstralar.ToString();
                    }

                }
                else
                {

                    if (SucukClickCount % 2 == 0)
                    {
                        b = false;
                        ekstralar -= SucukPrice;
                        lblEkstra.Text = ekstralar.ToString();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // CHECKBOX SOSİS FİYATI       
        int SosisClickCount;
        private async void check_Sosis_Click(object sender, EventArgs e)
        {
            try
            {
                SosisClickCount += 1;
                if (check_Sosis.Checked)
                {

                    if (SosisClickCount % 2 == 1)
                    {
                        b = true;
                        ekstralar += SosisPrice;
                        lblEkstra.Text = ekstralar.ToString();
                    }

                }
                else
                {

                    if (SosisClickCount % 2 == 0)
                    {
                        b = false;
                        ekstralar -= SosisPrice;
                        lblEkstra.Text = ekstralar.ToString();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // CHECKBOX MANTAR FİYATI
      
        int MantarClickCount;
        private async void check_Mantar_Click(object sender, EventArgs e)
        {
            try
            {
                MantarClickCount += 1;
                if (check_Mantar.Checked)
                {

                    if (MantarClickCount % 2 == 1)
                    {
                        b = true;
                        ekstralar += MantarPrice;
                        lblEkstra.Text = ekstralar.ToString();
                    }

                }
                else
                {

                    if (MantarClickCount % 2 == 0)
                    {
                        b = false;
                        ekstralar -= MantarPrice;
                        lblEkstra.Text = ekstralar.ToString();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // CHECKBOX KAŞAR FİYATI
      
        int KasarClickCount;
        private async void check_Kasar_Click(object sender, EventArgs e)
        {
            try
            {
                KasarClickCount += 1;
                if (check_Kasar.Checked)
                {

                    if (KasarClickCount % 2 == 1)
                    {
                        b = true;
                        ekstralar += KasarPrice;
                        lblEkstra.Text = ekstralar.ToString();
                    }

                }
                else
                {

                    if (KasarClickCount % 2 == 0)
                    {
                        b = false;
                        ekstralar -= KasarPrice;
                        lblEkstra.Text = ekstralar.ToString();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // CHECKBOX PEYNİR FİYATI
        
        int PeynirClickCount;
        private async void check_Peynir_Click(object sender, EventArgs e)
        {
            try
            {
                PeynirClickCount += 1;
                if (check_Peynir.Checked)
                {

                    if (PeynirClickCount % 2 == 1)
                    {
                        b = true;
                        ekstralar += PeynirPrice;
                        lblEkstra.Text = ekstralar.ToString();
                    }

                }
                else
                {

                    if (PeynirClickCount % 2 == 0)
                    {
                        b = false;
                        ekstralar -= PeynirPrice;
                        lblEkstra.Text = ekstralar.ToString();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // CHECKBOX SEBZE FİYATI
       
        int SebzeClickCount;
        private async void check_Sebze_Click(object sender, EventArgs e)
        {
            try
            {
                SebzeClickCount += 1;
                if (check_Sebze.Checked)
                {

                    if (SebzeClickCount % 2 == 1)
                    {
                        b = true;
                        ekstralar += SebzePrice;
                        lblEkstra.Text = ekstralar.ToString();
                    }

                }
                else
                {

                    if (SebzeClickCount % 2 == 0)
                    {
                        b = false;
                        ekstralar -= SebzePrice;
                        lblEkstra.Text = ekstralar.ToString();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        double sumPizza;
        double toplam;
        private async void numeric_PizzaAdet_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                int pizzaCount = Convert.ToInt32(numeric_PizzaAdet.Value);
                toplam = pizzaCount * ekstralar;

                if (combo_Pizza.SelectedIndex == 1)
                {
                    sumPizza =  KucukBoy * pizzaCount + toplam;

                }
                else if (combo_Pizza.SelectedIndex == 2)
                {
                    sumPizza = OrtaBoy * pizzaCount + toplam;
                }
                else if (combo_Pizza.SelectedIndex == 3)
                {
                    sumPizza = BuyukBoy * pizzaCount + toplam;
                }

                lblPrice.Text = sumPizza.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        double sumIcecek;
        double sumAll;
        private async void numeric_IcecekAdet_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int icecekCount = Convert.ToInt32(numeric_IcecekAdet.Value);


                if (combo_Icecek.SelectedIndex == 1)
                {
                    sumIcecek = Su * icecekCount;
                }
                else if (combo_Icecek.SelectedIndex == 2)
                {
                    sumIcecek = Kola * icecekCount;
                }
                else if (combo_Icecek.SelectedIndex == 3)
                {
                    sumIcecek = Ayran * icecekCount;
                }

                sumAll = sumIcecek + sumPizza;
                lblPrice.Text =  sumAll.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
