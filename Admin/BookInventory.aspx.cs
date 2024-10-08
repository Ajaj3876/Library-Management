using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystemPT.Admin
{
    public partial class BookInventory : System.Web.UI.Page
    {
        DBConnect dbCon = new DBConnect();
        SqlCommand cmd;
        static int actual_stock, current_stock, issued_books;
        static string filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Autogenrate();
                Bind_Author_Publisher();
                BindGridData();
            }
        }

        private void Bind_Author_Publisher()
        {
            cmd = new SqlCommand("spGetAuthor", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ddlAuthorName.DataSource = dbCon.Load_Data(cmd);
            ddlAuthorName.DataValueField = "author_name";
            ddlAuthorName.DataBind();
            ddlAuthorName.Items.Insert(0, new ListItem("-- Select --"));

            cmd = new SqlCommand("sp_getPublisher", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ddlPublisherName.DataSource = dbCon.Load_Data(cmd);
            ddlPublisherName.DataValueField = "publisher_name";
            ddlPublisherName.DataBind();
            ddlPublisherName.Items.Insert(0, new ListItem("-- Select --"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkDuplicateBook())
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Book already exists...try Some other Book','error')", true);
            }
            else
            {
                AddBooks();
                BindGridData();
            }
        }

        private bool checkDuplicateBook()
        {
            cmd = new SqlCommand("spgetBookByID", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text);
            DataTable dt2 = new DataTable();
            dt2 = dbCon.Load_Data(cmd);
            if (dt2.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {            
            if (checkDuplicateBook())
            {
                UpdateBooks();
                BindGridData();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Invalid Book ID...try again','error')", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkDuplicateBook())
            {
                DeleteBooks();
                BindGridData();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Invalid Book ID...try again','error')", true);
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }
        private void AddBooks()
        {
            String genres = "";
            foreach (int i in lstBoxGenre.GetSelectedIndices())
            {
                genres = genres + lstBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);

            string filepath = "~/book_img/book2.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/book_img/" + filename));
            filepath = "~/book_img/" + filename;

            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            AddParameter();
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            cmd.Parameters.AddWithValue("@genre", genres);
            cmd.Parameters.AddWithValue("@book_img_link", filepath);
            if (dbCon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Added Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not Inserted...try again','error')", true);

            }
            ClearControl();
            Autogenrate();
        }
        private void UpdateBooks()
        {
            int A_Stock = Convert.ToInt32(txtActualStock.Text.Trim());
            int C_Stock = Convert.ToInt32(txtCurrectStock.Text.Trim());
            if (actual_stock == A_Stock)
            {

            }
            else
            {
                if( A_Stock < actual_stock)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Actual Stock Value can not be less than issued books...try again','error')", true);
                    return;
                }
                else
                {
                    current_stock = actual_stock - issued_books;
                    txtCurrectStock.Text = C_Stock + "";
                }
            }
            String genres = "";
            foreach (int i in lstBoxGenre.GetSelectedIndices())
            {
                genres = genres + lstBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);

            string F_path = "~/book_img/book2.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (filename =="" || filename == null)
            {
                F_path = filepath;
            }
            else
            {
                FileUpload1.SaveAs(Server.MapPath("~/book_img/" + filename));
                F_path = "~/book_img/" + filename;
            }
           
            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "Update");  
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text);
            cmd.Parameters.AddWithValue("@book_name", txtBookName.Text);
            cmd.Parameters.AddWithValue("@author_name", ddlAuthorName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_name", ddlPublisherName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_date", txtPublishDate.Text);
            cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@edition", txtEdition.Text);
            cmd.Parameters.AddWithValue("@book_cost", txtBookCost.Text);
            cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text);
            cmd.Parameters.AddWithValue("@book_description", txtBookDesc.Text);
            cmd.Parameters.AddWithValue("@genre", genres);
            cmd.Parameters.AddWithValue("@actual_stock", A_Stock.ToString());
            cmd.Parameters.AddWithValue("@currect_stock", C_Stock.ToString());
            cmd.Parameters.AddWithValue("@book_img_link", F_path);
            if (dbCon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Updated Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not Updated...try again','error')", true);

            }
            ClearControl();
            Autogenrate();
        }
        private void DeleteBooks()
        {
            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            if (dbCon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Deleted Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not Deleted...try again','error')", true);

            }
            ClearControl();
            Autogenrate();
        }
        public void Autogenrate()
        {
            int r;
            dbCon.OpenCon();
            cmd = new SqlCommand("select max (book_id)as ID from book_master_tbl", dbCon.GetCon());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    txtBookID.Text = "101";
                }
                else
                {
                    r = Convert.ToInt32(dr[0].ToString());
                    r = r + 1;
                    txtBookID.Text = r.ToString();
                }
                //txtBookID.ReadOnly = true;
                txtBookID.BackColor = System.Drawing.Color.YellowGreen;
            }
            dbCon.CloseCon();
        }
        private void ClearControl()
        {
            txtBookName.Text = txtActualStock.Text = txtBookCost.Text = txtCurrectStock.Text = txtEdition.Text = txtIssuedBooks.Text = txtPages.Text = txtPublishDate.Text = txtBookDesc.Text = string.Empty;
            ddlAuthorName.SelectedIndex = -1;
            ddlPublisherName.SelectedIndex = -1;
            FileUpload1.PostedFile.InputStream.Dispose();
            ImgPhoto.ImageUrl = "~/imgs/Books.png";
        }
        public void AddParameter()
        {
            cmd.Parameters.Clear();          
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text);
            cmd.Parameters.AddWithValue("@book_name", txtBookName.Text);            
            cmd.Parameters.AddWithValue("@author_name", ddlAuthorName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_name", ddlPublisherName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_date", txtPublishDate.Text);
            cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@edition", txtEdition.Text);
            cmd.Parameters.AddWithValue("@book_cost", txtBookCost.Text);
            cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text);
            cmd.Parameters.AddWithValue("@book_description", txtBookDesc.Text);
            cmd.Parameters.AddWithValue("@actual_stock", txtActualStock.Text);
            cmd.Parameters.AddWithValue("@currect_stock", txtActualStock.Text);           
        }
        private void SearchBooks()
        {
            cmd = new SqlCommand("spgetBookByID", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();            
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text);
            DataTable dt2 = new DataTable();
            dt2 = dbCon.Load_Data(cmd);
            if (dt2.Rows.Count >= 1)
            {
                txtBookName.Text = dt2.Rows[0]["book_name"].ToString();
                txtPublishDate.Text = dt2.Rows[0]["publisher_date"].ToString();
                txtEdition.Text = dt2.Rows[0]["edition"].ToString();
                txtBookCost.Text = dt2.Rows[0]["book_cost"].ToString();
                txtPages.Text = dt2.Rows[0]["no_of_pages"].ToString();
                txtActualStock.Text = dt2.Rows[0]["actual_stock"].ToString();
                txtCurrectStock.Text = dt2.Rows[0]["currect_stock"].ToString();
                txtBookDesc.Text = dt2.Rows[0]["book_description"].ToString();
                txtIssuedBooks.Text = "" + (Convert.ToInt32(dt2.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt2.Rows[0]["currect_stock"].ToString()));

                ddlLanguage.SelectedValue = dt2.Rows[0]["language"].ToString().Trim();
                ddlPublisherName.SelectedValue = dt2.Rows[0]["publisher_name"].ToString().Trim();
                ddlAuthorName.SelectedValue = dt2.Rows[0]["author_name"].ToString().Trim();

                lstBoxGenre.ClearSelection();
                string[] genre = dt2.Rows[0]["genre"].ToString().Trim().Split(',');
                for (int i =0; i < genre.Length; i++)
                {
                    for (int j=0; j < lstBoxGenre.Items.Count; j++)
                    {
                        if (lstBoxGenre.Items[j].ToString() == genre[i])
                        {
                            lstBoxGenre.Items[j].Selected = true;
                        }
                    }
                }
                actual_stock = Convert.ToInt32(dt2.Rows[0]["actual_stock"].ToString().Trim());
                current_stock = Convert.ToInt32(dt2.Rows[0]["currect_stock"].ToString().Trim());
                issued_books = actual_stock - current_stock;
                filepath = dt2.Rows[0]["book_img_link"].ToString();
                if(filepath!="" || filepath!=null)
                {
                    ImgPhoto.ImageUrl = filepath;
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
                ClearControl();
            }
        }
        private void BindGridData()
        {
            cmd = new SqlCommand("sp_Insert_Up_Del_BookInventory", dbCon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "select");
            GridView1.DataSource = dbCon.Load_Data(cmd);
            GridView1.DataBind();
        }
    }
}