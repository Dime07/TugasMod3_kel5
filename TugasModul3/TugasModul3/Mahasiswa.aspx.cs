using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TugasModul3
{
    public partial class Mahasiswa : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=LAPTOP-G614RP2S\\SQLEXPRESS;Initial Catalog=TugasMod3;Integrated Security=True";
            con.Open();
            if (!Page.IsPostBack)
            {
                DataShow();
            }

        }

        private void DataShow()
        {
            ClearData();
            ds = new DataSet();
            cmd.CommandText = "SELECT A.nim, A.nama_mhs, A.id_hobi, A.id_ortu, A.is_delete, B.nama_hobi, C.nama_ortu FROM mahasiswa AS A INNER JOIN hobi AS B ON  A.id_hobi = B.id_hobi INNER JOIN orangtua AS C ON A.id_ortu = C.id_ortu WHERE is_delete = 0";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM hobi";
            comm.Connection = con;
            DataSet dst = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dst);
            gvHobi.DataSource = dst;
            gvHobi.DataBind();

            SqlCommand comm2 = new SqlCommand();
            comm2.CommandText = "SELECT * FROM orangtua";
            comm2.Connection = con;
            DataSet dst2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(comm2);
            da2.Fill(dst2);
            gvOrtu.DataSource = dst2;
            gvOrtu.DataBind();



            con.Close();
        }

        private void ClearData()
        {
            txtNim.Text = null;
            txtMahasiswa.Text = null;
            txtIdHobi.Text = null;
            txtIdOrtu.Text = null;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "INSERT INTO mahasiswa VALUES('" + txtNim.Text + "'," +
                "'" + txtMahasiswa.Text + "','" + txtIdHobi.Text + "' ,'" + txtIdOrtu.Text + "' ,0) ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE mahasiswa SET is_delete = 1 WHERE nim = '" + txtNim.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE mahasiswa SET nama_mhs = '" + txtMahasiswa.Text + "', id_hobi = '" + txtIdHobi.Text + "',id_ortu = '" + txtIdOrtu.Text + "' WHERE nim = '" + txtNim.Text + "' ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void GridViewJoin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewJoin, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void GridViewJoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nim = GridViewJoin.SelectedRow.Cells[0].Text;
            string nama = GridViewJoin.SelectedRow.Cells[1].Text;
            string hobi = GridViewJoin.SelectedRow.Cells[2].Text;
            string ortu = GridViewJoin.SelectedRow.Cells[3].Text;
            txtNim.Text = nim;
            txtMahasiswa.Text = nama;
            txtIdHobi.Text = hobi;
            txtIdOrtu.Text = ortu;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}