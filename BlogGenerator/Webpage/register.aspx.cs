using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogGenerator.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace BlogGenerator.Webpage
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("Label_sign")).Text = "Sign in";

        }
        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string uname = args.Value;//获取用户名 
            string str = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "select count(*) from userinfo WHERE username= '" + uname + "'";
            //cmd.CommandText = "select count(*) from Customer_Info WHERE CustomerUserName= '" + UserName + "'";
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            if (count > 0)//查找到数据库已经存在该用户名，则反馈不通过，否则通过 
            {
                args.IsValid = false;//表示网页的控件有一个没通过则为false，都通过为true 

            }
            else
            {
                args.IsValid = true;
            }

        }

        protected void CustomValidator2_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string uemail = args.Value;//获取用户名 
            string str = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "select count(*) from userinfo WHERE uemail= '" + uemail + "'";
            //cmd.CommandText = "select count(*) from Customer_Info WHERE CustomerUserName= '" + UserName + "'";
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            if (count > 0)//查找到数据库已经存在该用户名，则反馈不通过，否则通过 
            {
                args.IsValid = false;//表示网页的控件有一个没通过则为false，都通过为true 

            }
            else
            {
                args.IsValid = true;
            }

        }


        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (inputPassword.Value.Trim() != confirm.Value.Trim())
                {
                    Response.Write("<script language='JavaScript'>alert('Please check that your passwords match and try again.');</script>");
                    return;
                }
                else
                {
                    userinfo user1 = new userinfo(    inputEmail.Value.Trim(),
                                                      inputPassword.Value.Trim(),
                                                      inputUserName.Value.Trim()
                                                           );

                    string str = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(str);
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into userinfo(uemail,upassword,username,style) Values(@uemail,@upassword,@username,2)";

                    int count = 0;

                    cmd.Parameters.AddWithValue("@uemail", user1.uemail);
                    cmd.Parameters.AddWithValue("@upassword", user1.upassword);
                    cmd.Parameters.AddWithValue("@username", user1.username);

                    conn.Open();
                    count = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    if (count != 0)
                    {
                        Session["uemail"] = inputEmail.Value.Trim();
                    //  string email000000000000 = Session["uemail"].ToString();
                        Session["uname"] = inputUserName.Value.Trim();
                        Session["upassword"] = inputPassword.Value.Trim();
                        //Response.Buffer = false;
                        Response.Write("<script language='JavaScript'>alert('Create successfully !');</script>");
                        Response.Redirect("index.aspx", true);

                    }
                    else
                    {
                        Response.Write("<script language='JavaScript'>alert('Error, please create again!');</script>");
                    }
                }
            }
        }
    }
}