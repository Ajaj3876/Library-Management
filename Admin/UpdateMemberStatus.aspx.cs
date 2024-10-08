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
    public partial class UpdateMemberStatus : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGridview();
                
            }
        }

        private void BindGridview()
        {
            cmd = new SqlCommand("sp_getMember_AllRecords", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            GridView1.DataSource = dbCon.Load_Data(cmd);
            GridView1.DataBind();
        }

        protected void btnSearchMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Search_MemberRecord();
            }
           
        }

        private void Search_MemberRecord()
        {
            cmd = new SqlCommand("sp_getMemberByID", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtMemberID.Text.Trim());
            dbCon.OpenCon();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    txtFullName.Text = dr.GetValue(0).ToString();
                    txtDOB.Text = dr.GetValue(1).ToString();
                    txtContactNo.Text = dr.GetValue(2).ToString();
                    txtEmail.Text = dr.GetValue(3).ToString();
                    ddlState.SelectedValue = dr.GetValue(4).ToString();
                    txtCity.Text = dr.GetValue(5).ToString();
                    txtPIN.Text = dr.GetValue(6).ToString();
                    txtAddress.Text = dr.GetValue(7).ToString();

                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record Not Found...try again','error')", true);
            }
            dbCon.CloseCon();
        }

        protected void btnActiveMember_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                UpdateMemberStatus_ByID("Active");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Validation Error...try again','error')", true);
            }
        }

        private void UpdateMemberStatus_ByID(string varStatus )
        {
            if(CheckMemberExist_OR_Not())
            {
                cmd = new SqlCommand("sp_UpdateMemberStatus_ByID", dbCon.GetCon());
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtMemberID.Text.Trim());
                cmd.Parameters.AddWithValue("@qrtype", varStatus);
                dbCon.OpenCon();
                if ( cmd.ExecuteNonQuery() > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Member Status Updated Succesfully','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record Not Updated...try again','error')", true);

                }
                dbCon.CloseCon();
                BindGridview();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record Not Found...try again','error')", true);
            }
        }

        private bool CheckMemberExist_OR_Not()
        {
            dbCon.OpenCon();
            cmd = new SqlCommand("sp_getMemberByID", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtMemberID.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dbCon.CloseCon();
            if (dt.Rows.Count >= 1)      
                return true;
            
            else
            
                return false;
                      
        }

        protected void btnPendingMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UpdateMemberStatus_ByID("Pending");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Validation Error...try again','error')", true);
            }
        }

        protected void btnDeactiveMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UpdateMemberStatus_ByID("Deactive");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Validation Error...try again','error')", true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridview();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridview();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridview();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {           
            Label mid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDisplayID");
            int ID = Convert.ToInt32(mid.Text);

            TextBox updatetxtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditName");
            TextBox updatetxtdob = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditdob");
            TextBox updatetxtcontact = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditcontact");
            TextBox updatetxtemail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditemail");

            DropDownList updateddlstate = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlEditState");

            TextBox updatetxtcity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditCity");
            TextBox updatetxtpincode = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditPinCode");
            TextBox updatetxtaddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditAddress");

            cmd = new SqlCommand("sp_UpdateMember_Records", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@full_name", updatetxtName.Text);
            cmd.Parameters.AddWithValue("@dob", updatetxtdob.Text);
            cmd.Parameters.AddWithValue("@contact_no", updatetxtcontact.Text);
            cmd.Parameters.AddWithValue("@email", updatetxtemail.Text);
            cmd.Parameters.AddWithValue("@state", updateddlstate.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@city", updatetxtcity.Text);
            cmd.Parameters.AddWithValue("@pincode", updatetxtpincode.Text);
            cmd.Parameters.AddWithValue("@full_address", updatetxtaddress.Text);

            cmd.Parameters.AddWithValue("@member_id", ID);
            dbCon.OpenCon();
            cmd.ExecuteNonQuery();
            dbCon.CloseCon();
            GridView1.EditIndex = -1;
            BindGridview();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label mid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDisplayID");
            int ID = Convert.ToInt32(mid.Text);
            cmd = new SqlCommand("sp_deleteMemberByID", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
           
            cmd.Parameters.AddWithValue("@member_id", ID);
            dbCon.OpenCon();
            cmd.ExecuteNonQuery();
            dbCon.CloseCon();
            BindGridview();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlEditState_value =(DropDownList) e.Row.FindControl("ddlEditState");
                Label lblstate = (Label)e.Row.FindControl("lblEditState");
                ddlEditState_value.SelectedValue = lblstate.Text;
            }
        }
    }
}