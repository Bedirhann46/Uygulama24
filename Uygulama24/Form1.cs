using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama24
{
    
    public partial class Form1 : Form
    {
        
        List<Ogrenciler> liste = new List<Ogrenciler>();
        public Form1()
        {
            InitializeComponent();
            btnSil.Click += btnSil_Click;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenciler ogrenci = new Ogrenciler();
            ogrenci.Numara = int.Parse(textBox1.Text);
            ogrenci.AdSoyad = textBox2.Text;
            ogrenci.DersNotu = int.Parse(textBox3.Text);
            liste.Add(ogrenci);
            Bagla();
        }
        private void Bagla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                
                var dataSource = dataGridView1.DataSource;

                
                if (dataSource is BindingSource bindingSource)
                {
                    
                    if (bindingSource.List is IList list)
                    {
                        
                        list.RemoveAt(selectedIndex);

                        
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource;
                    }
                }
                else if (dataSource is IList list)
                {
                    
                    list.RemoveAt(selectedIndex);

                 
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Veri kaynağı doğru formatta değil!");
                }
            }
            
        }

    }

       
    
}
