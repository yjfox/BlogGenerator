using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BlogGenerator.Model;
using System.Data.SqlClient;
namespace BlogGenerator.Webpage
{
    public partial class editUserInfor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userid = 0;
                if (Session["uid"] == null)
                { AlertSussTranscation("login.aspx"); }
                else
                { userid = Convert.ToInt32(Session["uid"].ToString());
                ((Label)Master.FindControl("Label_sign")).Text = "Sign Out";
                }
                //int userid = 1;
                string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand comm2 = new SqlCommand("select * from userinfo where uid=" + userid, conn);
                SqlDataReader sread1 = comm2.ExecuteReader();
                if (sread1.Read())
                {
                    int themestyle = Convert.ToInt32(sread1["style"]);
                    switch (themestyle)
                    {
                        case 1:
                            RadioButton1.Checked = true;
                            break;
                        case 2:
                            RadioButton2.Checked = true;
                            break;
                        case 3:
                            RadioButton3.Checked = true;
                            break;
                        case 4:
                            RadioButton4.Checked = true;
                            break;
                        default:
                            RadioButton1.Checked = true;
                            break;
                    }
                    if (sread1["blogname"] != System.DBNull.Value)
                    { blogname.Text = (string)sread1["blogname"]; }
                    if (sread1["linkname1"] != System.DBNull.Value)
                    { linkname1.Value = (string)sread1["linkname1"]; }
                    if (sread1["linkurl1"] != System.DBNull.Value)
                    { linkurl1.Value = (string)sread1["linkurl1"]; }
                    if (sread1["linkname2"] != System.DBNull.Value)
                    { linkname2.Value = (string)sread1["linkname2"]; }
                    if (sread1["linkurl2"] != System.DBNull.Value)
                    { linkurl2.Value = (string)sread1["linkurl2"]; }
                    if (sread1["linkname3"] != System.DBNull.Value)
                    { linkname3.Value = (string)sread1["linkname3"]; }
                    if (sread1["linkurl3"] != System.DBNull.Value)
                    { linkurl3.Value = (string)sread1["linkurl3"]; }

                }
            }

        }
        private int radiobuttoncheck()
        {
            int theme = 1;
            if (RadioButton1.Checked == true)
                theme = 1;
            else if (RadioButton2.Checked == true)
                theme = 2;
            else if (RadioButton3.Checked == true)
                theme = 3;
            else if (RadioButton4.Checked == true)
                theme = 4;
            return theme;
        }

        protected void save_Click(object sender, EventArgs e)
        {
            int uid=0;
            string str = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update userinfo set  blogname=@blogname,style=@style,linkname1=@linkname1,linkurl1=@linkurl1,linkname2=@linkname2,linkurl2=@linkurl2,linkname3=@linkname3,linkurl3=@linkurl3 where uid=@uid";
            if (Session["uid"] == null)
            { AlertSussTranscation("login.aspx"); }
            else
            { uid = Convert.ToInt32(Session["uid"].ToString()); }
            // int uid = 1;
            string bname = blogname.Text.ToString().Trim();
            int style = radiobuttoncheck();
            string lname1 = linkname1.Value.ToString().Trim();
            string lurl1 = linkurl1.Value.ToString().Trim();
            string lname2 = linkname2.Value.ToString().Trim();
            string lurl2 = linkurl2.Value.ToString().Trim();
            string lname3 = linkname3.Value.ToString().Trim();
            string lurl3 = linkurl3.Value.ToString().Trim();

            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@blogname", bname);
            cmd.Parameters.AddWithValue("@style", style);
            cmd.Parameters.AddWithValue("@linkname1", lname1);
            cmd.Parameters.AddWithValue("@linkurl1", lurl1);
            cmd.Parameters.AddWithValue("@linkname2", lname2);
            cmd.Parameters.AddWithValue("@linkurl2", lurl2);
            cmd.Parameters.AddWithValue("@linkname3", lname3);
            cmd.Parameters.AddWithValue("@linkurl3", lurl3);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            Response.Write("<script language='JavaScript'>alert('Update Successfully !');location.href='index.aspx';</script>");
        }

        protected void AlertSussTranscation(string url)
        {
            string _strJS = "<script language=javascript>\n";
            _strJS += "location.href = \"" + url + "\";\n";
            _strJS += "</script>";

            HttpContext.Current.Response.Write(_strJS);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }
}