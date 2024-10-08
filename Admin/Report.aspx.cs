using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystemPT.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Adminusername"].ToString() == "" || Session["Adminusername"] == null)
            {
                Response.Redirect("~/signout.aspx");

            }
            else
            {
                if (!this.IsPostBack)
                {
                    BindGridData();
                }
            }
        }
        private void BindGridData()
        {
            cmd = new SqlCommand("sp_GetBookDetail__ForAdmin", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@mid", Session["mid"].ToString());
            GridView1.DataSource = dbCon.Load_Data(cmd);
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}