using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystemPT
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect con = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //for Member Login
            SqlCommand cmd = new SqlCommand("sp_UserLogin", con.GetCon());
            con.OpenCon();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@member_id", txtMemberID.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Login Succesfully','success')", true);
                    Session["role"] = "user";
                    Session["fullname"] = dr.GetValue(0).ToString();
                    Session["username"] = dr.GetValue(1).ToString();
                    Session["status"] = dr.GetValue(3).ToString();
                    Session["mid"] = txtMemberID.Text;
                }
                Response.Redirect("~/UserScreen/UserHome.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Invalid credentials...try again','error')", true);
            }

        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            //Admin Login Button
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", con.GetCon());
            con.OpenCon();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", txtAdminID.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtAdminPassword.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Login Succesfully','success')", true);
                    Session["Adminrole"] = "Admin";
                    Session["Adminusername"] = dr.GetValue(0).ToString();
                    Session["Adminfullname"] = dr.GetValue(2).ToString();

                }
                Response.Redirect("~/Admin/AdminHome.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Invalid credentials...try again','error')", true);
            }
        }
    }
}