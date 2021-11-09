using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OOP
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\OOP\dboop.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Insert into tb_barang (kode_barang,nama_barang,harga,jenis) values('" + txtkode.Text + "', '" + txtnama.Text + "', '" + txtharga.Text + "', '" + txtjenis.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil Ditambahkan");
                cmd.Dispose();

                cleartext();
                fillgrid();
            }
            catch (Exception)
            { 
                MessageBox.Show("Data Gagal Ditambahkan");
            }
            
        }

        void fillgrid()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tb_barang order by ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridview.DataSource = dt;
            con.Close();
        }

        void cleartext()
        {
            txtkode.Text = "";
            txtnama.Text = "";
            txtharga.Text = "";
            txtjenis.Text = "";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Update tb_barang set kode_barang='" + txtkode.Text + "', nama_barang='" + txtnama.Text + "', harga='" + txtharga.Text + "', jenis='" + txtjenis.Text + "' where kode_barang = '" + txtkode.Text + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil Diedit");
                cmd.Dispose();

                cleartext();
                fillgrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Gagal Diupdatet");
            }
            

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Delete from tb_barang where kode_barang = '" + txtkode.Text + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil Didelete");
                cmd.Dispose();

                cleartext();
                fillgrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Gagal Didelete");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from tb_barang";
                OleDbCommand cmd= new OleDbCommand(query, con);
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(ds, "res");
                datagridview.DataSource = ds.Tables["res"];
                adapter.Dispose();
                cmd.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Menampilkan Data");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Delete * from tb_barang ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil Diclear");
                cmd.Dispose();

                cleartext();
                fillgrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Gagal Diclear");
            }
        }

        private void tbcari_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string perintah = "select * from tb_barang where nama_barang='" + tbcari.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(perintah, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridview.DataSource = dt;
            con.Close();
        }

        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
