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
    public partial class bookIssueReturn : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {                
                BindGridData();
            }
        }

        private void BindGridData()
        {
            cmd = new SqlCommand("sp_GetIssueBook", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@StatementType", "select");
            GridView1.DataSource = dbCon.Load_Data(cmd);
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                GetMemName();
                GetBookName();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Please ender Member ID or Book ID...try again','error')", true);
            }
        }

        private void GetBookName()
        {
            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "SelectByID");
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            DataTable dtt = dbCon.Load_Data(cmd);
            if(dtt.Rows.Count >= 1)
            {
                txtBookName.Text = dtt.Rows[0]["book_name"].ToString();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Wrong Book ID...try again','error')", true);
            }
        }

        private void GetMemName()
        {
            cmd = new SqlCommand("sp_getMember_ByID", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", txtMemID.Text.Trim());
            DataTable dtt = dbCon.Load_Data(cmd);
            if (dtt.Rows.Count >= 1)
            {
                txtMemName.Text = dtt.Rows[0]["full_name"].ToString();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Wrong Member ID...try again','error')", true);
            }
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if(IsBookExist() && IsMemberExist())
            {
                if(IsIssueEntryExist())
                {
                    Response.Write("<script>alert('This member already has this book');</script>");
                }
                else
                {
                    issueBook();
                    BindGridData();
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Wrong Member ID or Book ID...try again','error')", true);
            }
        }

        private void issueBook()
        {
            cmd = new SqlCommand("sp_InsertBookIssue", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_name", txtMemName.Text.Trim());
            cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
            cmd.Parameters.AddWithValue("@issue_date", txtIssueDate.Text.Trim());
            cmd.Parameters.AddWithValue("@due_date", txtDueDate.Text.Trim());
            //@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date
            if (dbCon.InsertUpdateData(cmd))
            {
                updateBookStock();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Book not Isue...try again','error')", true);

            }
        }

        private void updateBookStock()
        {
            cmd = new SqlCommand("sp_UpdateIssueBookStock", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            if (dbCon.InsertUpdateData(cmd))
            {                
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Issue Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Current Stock not updated...try again','error')", true);

            }
        }

        private bool IsIssueEntryExist()
        {
            cmd = new SqlCommand("sp_CheckIssueExist", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@bid", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@mid", txtMemID.Text.Trim());
            DataTable dtt = dbCon.Load_Data(cmd);
            if (dtt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsBookExist()
        {
            cmd = new SqlCommand("sp_CheckBookStockExist", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            DataTable dtt = dbCon.Load_Data(cmd);
            if(dtt.Rows.Count >=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsMemberExist()
        {
            cmd = new SqlCommand("sp_getMember_ByID", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", txtMemID.Text.Trim());
            DataTable dtt = dbCon.Load_Data(cmd);
            if (dtt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (IsBookExist() && IsMemberExist())
            {
                if (IsIssueEntryExist())
                {
                    if (CheckFine())
                    {
                        ReturnBook();
                        BindGridData();
                    }
                    else
                    {
                        // Open Fine Page where user can paid fine
                        Response.Redirect("BookFineEntry.aspx?bid="+txtBookID.Text+ "&mid"+txtMemID.Text+ "&day="+ Session["day"].ToString());

                    }
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");                    
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Wrong Member ID or Book ID...try again','error')", true);
            }
        }

        private void ReturnBook()
        {
            cmd = new SqlCommand("sp_returnBook_UpdateStock", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemID.Text.Trim());
            if (dbCon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Return Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Book not Return...try again','error')", true);

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Check Condition Due Date for Issue Book
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime Today = DateTime.Today;
                    if (Today > dt)
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
        private bool CheckFine()
        {
            int days;
            cmd = new SqlCommand("sp_GetNumOfDay", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemID.Text.Trim());
            DataTable dtt = dbCon.Load_Data(cmd);
            if (dtt.Rows.Count >= 1)
            {
                days = Convert.ToInt32( dtt.Rows[0]["number_of_day"].ToString());
                Session["day"] = days;
                if(days <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}