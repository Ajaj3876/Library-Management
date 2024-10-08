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
    public partial class ViewBooks : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindRepeater();
                BindGridData();
            }
        }
        private void BindRepeater()
        {
            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "select");
            Repeater1.DataSource = dbCon.Load_Data(cmd);
            Repeater1.DataBind();
        }
        private void BindGridData()
        {
            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            GridView1.DataSource = dbCon.Load_Data(cmd);
            GridView1.DataBind();
        }
    }
}