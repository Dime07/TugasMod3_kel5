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
    public partial class Recycle : System.Web.UI.Page
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
            DataSet ds3 = new DataSet();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT * FROM mahasiswa WHERE is_delete = 1";
            cmd3.Connection = con;
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            sda3.Fill(ds3);
            cmd3.ExecuteNonQuery();
            gvRecycle.DataSource = ds3;
            gvRecycle.DataBind();

            con.Close();
        }

        protected void gvRecycle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvRecycle, "Select$" + e.Row.RowIndex);
                e.Row.Cells[4].Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvRecycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvRecycle.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE mahasiswa SET is_delete = 0 WHERE nim = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

    }
}