using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystemPT.Admin
{
    public partial class Addauthor : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Autogenrate();
                BindRepeater();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_InsertAuthor", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",txtID.Text);
            cmd.Parameters.AddWithValue("@name",txtAuthorName.Text);
            dbCon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Added Author Succesfully','success')", true);
                dbCon.CloseCon();
                clrcontrol();
                BindRepeater();
                Autogenrate();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not inserted...try again','error')", true);
                dbCon.CloseCon();
            }
            
        }
        private void clrcontrol()
        {
            txtAuthorName.Text = txtID.Text = string.Empty;
            txtID.Focus();
        }
        public void Autogenrate()
        {
            try
            {
                int r;
                dbCon.OpenCon();
                cmd = new SqlCommand("select max(author_id)as ID from author_master_tbl", dbCon.GetCon());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string d = dr[0].ToString();
                    if (d == "")
                    {
                        txtID.Text = "101";
                    }
                    else
                    {
                        r = Convert.ToInt32(dr[0].ToString());
                        r = r + 1;
                        txtID.Text = r.ToString();
                    }
                    txtID.ReadOnly = true;
                    txtID.BackColor = System.Drawing.Color.Chocolate;
                }
                dbCon.CloseCon();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SearchDataforUpdate(Convert.ToInt32(id));
            }
            else if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                cmd = new SqlCommand("sp_DeleteAuthor", dbCon.GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                dbCon.OpenCon();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Deleted Author Succesfully','success')", true);
                    dbCon.CloseCon();
                    clrcontrol();
                    BindRepeater();
                    Autogenrate();
                    btnAdd.Visible = true;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not deleted...try again','error')", true);
                    dbCon.CloseCon();
                }
            }
        }

        private void SearchDataforUpdate(int idd)
        {
            cmd = new SqlCommand("spGetAuthorByID", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID",idd);
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds, "dt");
            dbCon.CloseCon();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["AuthorID"] = ds.Tables[0].Rows[0]["author_id"].ToString();
                txtID.Text = ds.Tables[0].Rows[0]["author_id"].ToString();
                txtAuthorName.Text = ds.Tables[0].Rows[0]["author_name"].ToString();
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not found...try again','error')", true);
            }
        }

        protected void BindRepeater()
        {
            cmd = new SqlCommand("spGetAuthor", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_UpdateAuthor", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@name", txtAuthorName.Text);
            dbCon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Updated Author Succesfully','success')", true);
                dbCon.CloseCon();
                clrcontrol();
                BindRepeater();
                Autogenrate();
                btnAdd.Visible = true;
                btnCancel.Visible = false;
                btnUpdate.Visible = false;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not updated...try again','error')", true);
                dbCon.CloseCon();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}