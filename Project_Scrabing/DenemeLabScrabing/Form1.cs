using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace DenemeLabScrabing
{
    public partial class Form1 : Form
    {
        HtmlWeb htmlWeb = new HtmlWeb();
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            cmbPrice.SelectedIndexChanged += CmbPrice_SelectedIndexChanged;
        
        }

        private void CmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            PriceFilter = Convert.ToInt32(cmbPrice.SelectedIndex);
            if (PriceFilter == 0)
            {
                dataGridView1.Rows.Clear();
                var q1 = ProductsList.Where(x => (Convert.ToDouble(x.ProductPrice) > 1));
                foreach (var pr in q1)
                {
                    dataGridView1.Rows.Add(pr.ProductId, pr.ProductUri, pr.ProductImageUri, pr.ProductTitle, pr.ProductCode, pr.ProductPrice);
                }
            }
            if (PriceFilter == 1)
            {
                dataGridView1.Rows.Clear();
                var q1 = ProductsList.Where(x => (Convert.ToDouble(x.ProductPrice) < 5000));
                foreach (var pr in q1)
                {
                    dataGridView1.Rows.Add(pr.ProductId, pr.ProductUri, pr.ProductImageUri, pr.ProductTitle, pr.ProductCode, pr.ProductPrice);
                }
            }
            if (PriceFilter == 2)
            {
                dataGridView1.Rows.Clear();
                var q2 = ProductsList.Where(x => (Convert.ToDouble(x.ProductPrice) > 5000 && Convert.ToDouble(x.ProductPrice) < 10000));
                foreach (var pr in q2)
                {
                    dataGridView1.Rows.Add(pr.ProductId, pr.ProductUri, pr.ProductImageUri, pr.ProductTitle, pr.ProductCode, pr.ProductPrice);
                }
            }
            if (PriceFilter == 3)
            {
                dataGridView1.Rows.Clear();
                var q3 = ProductsList.Where(x => (Convert.ToDouble(x.ProductPrice) > 10000));
                foreach (var pr in q3)
                {
                    dataGridView1.Rows.Add(pr.ProductId, pr.ProductUri, pr.ProductImageUri, pr.ProductTitle, pr.ProductCode, pr.ProductPrice);
                }
            }
        }

        int PriceFilter;

     

        public List<Product> ProductsList = new List<Product>(); // products list

        private void Form1_Load(object sender, EventArgs e)
        {
            
             GetDataLoad(); //  Get Data  Method
            JsonWrite(ProductsList); // Write Json File Method

            cmbPrice.DataSource = PriceList();
            cmbPrice.DisplayMember = "PriceName";
            cmbPrice.ValueMember = "PriceId";
        }

        public List<Price> priceLists= new List<Price>();  
        public List<Price> PriceList()
        {
            priceLists.Add(new Price(1, "-Price-"));
            priceLists.Add(new Price(1, "0 - 5000"));
            priceLists.Add(new Price(2, "5000 - 10000"));
            priceLists.Add(new Price(3, "10000 - Max"));

            return priceLists;

        }

        public void JsonWrite(List<Product> Products)
        {
            // Write json Data
            try
            {
                using (FileStream fs = File.Open(@"products.json", FileMode.Append))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented; 

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, Products);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void GetDataLoad()
        {
         
                string page = "?page=";
                //string urlAddress = "https://www.vatanbilgisayar.com/bilgisayar/"+page.Trim();
                string urlAddress = "https://www.vatanbilgisayar.com/bilgisayar/";
                int pageNumber = 1;
                int itemNumber = 1;
                htmlWeb.PreRequest += PreRequest;
                string query = "//div[@id='productsLoad']//div[@class='product-list product-list--list-page']";
                

               while (true)
               {
                 try
                 {

                    NameValueCollection nvc = new NameValueCollection();
                    nvc["page"] = pageNumber.ToString();
                    string preparedUri = urlAddress + ToQueryString(nvc);
                    HtmlDocument doc = htmlWeb.Load(preparedUri);
                    var products = doc.DocumentNode.SelectNodes(query);
                    //------------------------------------------------------
                    int productid = 0;
                    //var doc = htmlWeb.Load(urlAddress+ pageNumber.ToString());
                    if (products == null)
                    {
                        MessageBox.Show("Bitti");
                        break;
                    }


                    foreach (var item in products)
                    {
                        string urlImage = item.SelectSingleNode(".//img[@class='lazyimg']").GetAttributeValue("data-src", null).Trim();

                        string url = item.SelectSingleNode(".//a[@class='product-list__image-safe-link sld']").GetAttributeValue("href", null).Trim();

                        string title = item.SelectSingleNode(".//div[@class='product-list__product-name']//h3").InnerText.Trim();
                        string price = item.SelectSingleNode(".//span[@class='product-list__price']").InnerText.Trim();
                        //int priceInteger= Convert.ToInt32(price);   
                        string productCode = item.SelectSingleNode(".//div[@class='product-list__product-code']").InnerText.Trim();
                        productid += 1;
                        string firstLink = "https://www.vatanbilgisayar.com";
                        ProductsList.Add(new Product
                        {
                            ProductId = productid,
                            ProductImageUri = urlImage,
                            ProductUri = firstLink + url,
                            ProductPrice = Convert.ToDouble(price),
                            ProductTitle = title,
                            ProductCode = productCode

                        });

                    }
                    pageNumber++;
                

                 }
                 catch (Exception)
                 {

                    throw;
                 }

                
                 
               }

            foreach (var pr in ProductsList)
            {
                dataGridView1.Rows.Add(pr.ProductId, pr.ProductUri, pr.ProductImageUri, pr.ProductTitle, pr.ProductCode, pr.ProductPrice);
            }
            MessageBox.Show(ProductsList.Count.ToString());
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get Selected Row Product Image
            try
            {
                pictureBox1.ImageLocation = ProductsList[dataGridView1.CurrentCell.RowIndex].ProductImageUri;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openProductLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index=dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow SelectedRow= dataGridView1.Rows[index];
                string urlProductAddress = SelectedRow.Cells[1].Value.ToString();
                System.Diagnostics.Process.Start(urlProductAddress);
            }

        }

        private void openImageLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow SelectedRow = dataGridView1.Rows[index];
                string urlProductImageAddress = SelectedRow.Cells[2].Value.ToString();
                System.Diagnostics.Process.Start(urlProductImageAddress);
            }
        }

        private static bool PreRequest(HttpWebRequest request)
        {
            request.AllowAutoRedirect = false;
            return true;
        }

        public static string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select string.Format(
                    "{0}={1}",
                    HttpUtility.UrlEncode(key),
                    HttpUtility.UrlEncode(value))
            ).ToArray();
            return "?"+string.Join("&",array);
        }

       
    }
}
