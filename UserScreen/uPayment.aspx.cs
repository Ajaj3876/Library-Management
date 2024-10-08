using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystemPT.UserScreen
{
    public partial class uPayment : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
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
            cmd = new SqlCommand("sp_FineDetails", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@member_id", Session["mid"].ToString());
            GridView1.DataSource = dbCon.Load_Data(cmd);
            GridView1.DataBind();
        }
    }
}