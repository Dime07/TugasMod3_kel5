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
    public partial class Orangtua : System.Web.UI.Page
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
            cmd.CommandText = "SELECT * FROM orangtua";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();
        }

        private void ClearData()
        {
            txtIdOrtu.Text = null;
            txtOrtu.Text = null;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "INSERT INTO orangtua VALUES('" + txtIdOrtu.Text + "'," +
                "'" + txtOrtu.Text + "') ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "DELETE orangtua WHERE id_ortu = '" + txtIdOrtu.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE orangtua SET nama_ortu = '" + txtOrtu.Text + "' WHERE id_ortu = '" + txtIdOrtu.Text + "' ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
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
            string id = GridViewJoin.SelectedRow.Cells[0].Text;
            string ortu = GridViewJoin.SelectedRow.Cells[1].Text;
            txtIdOrtu.Text = id;
            txtOrtu.Text = ortu;

        }
    }
}