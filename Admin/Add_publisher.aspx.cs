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
    public partial class Add_publisher : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Autogenrate();
                BindRecord();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                insertpublisher();
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Validation Error! please enter valid data...try again','error')", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_UpdatePublisher", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtpublisherID.Text);
            cmd.Parameters.AddWithValue("@name", txtpublisherName.Text);
            dbCon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Updated Author Succesfully','success')", true);
                dbCon.CloseCon();
                clrcontrol();
                BindRecord();
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
        public void Autogenrate()
        {
            try
            {
                int r;
                dbCon.OpenCon();
                cmd = new SqlCommand("select max(publisher_id)as ID from publisher_master_tbl", dbCon.GetCon());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string d = dr[0].ToString();
                    if (d == "")
                    {
                        txtpublisherID.Text = "101";
                    }
                    else
                    {
                        r = Convert.ToInt32(dr[0].ToString());
                        r = r + 1;
                        txtpublisherID.Text = r.ToString();
                    }
                    txtpublisherID.ReadOnly = true;
                    txtpublisherID.BackColor = System.Drawing.Color.Chocolate;
                }
                dbCon.CloseCon();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }
        protected void BindRecord()
        {
            cmd = new SqlCommand("sp_getPublisher", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);           
            RptPublisher.DataSource = dt;
            RptPublisher.DataBind();
        }
        private void clrcontrol()
        {
            txtpublisherName.Text = txtpublisherID.Text = string.Empty;
            txtpublisherID.Focus();
        }
        protected void SearchRecordBy_ID(string idd)
        {
            cmd = new SqlCommand("sp_getPublisherByID", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", idd);
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds, "dt");
            dbCon.CloseCon();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtpublisherID.Text = ds.Tables[0].Rows[0]["publisher_id"].ToString();
                txtpublisherName.Text = ds.Tables[0].Rows[0]["publisher_name"].ToString();
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not found...try again','error')", true);
            }
        }
        protected void insertpublisher()
        {
            cmd = new SqlCommand("sp_InsertPublisher", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtpublisherID.Text);
            cmd.Parameters.AddWithValue("@name", txtpublisherName.Text);
            dbCon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Added Author Succesfully','success')", true);
                dbCon.CloseCon();
                clrcontrol();
                BindRecord();
                Autogenrate();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not inserted...try again','error')", true);
                dbCon.CloseCon();
            }
        }

        protected void RptPublisher_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SearchRecordBy_ID((id));
            }
            else if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                cmd = new SqlCommand("sp_DeletePublisherByID", dbCon.GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                dbCon.OpenCon();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Deleted Author Succesfully','success')", true);
                    dbCon.CloseCon();
                    clrcontrol();
                    BindRecord();
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
    }
}