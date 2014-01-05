using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;  
namespace BlogGenerator.Webpage
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            ((Label)Master.FindControl("Label_register")).Text = "Register";

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            string useremail = inputEmail3.Value.Trim();
            string password = inputPassword3.Value.Trim();
            int uid;
            if (useremail == "" || password == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "emailOrPwdNull", "alert('Please enter your email or passord！');", true);
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;


            //定义SQL查询语句:用户名 密码  
            string sql = "select * from userinfo where uemail=@pUseremail and upassword= @pPass";

            //定义SQL Server连接对象 打开数据库  
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //定义查询命令:表示对数据库执行一个SQL语句或存储过程  

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pUseremail", SqlDbType.Char);
            cmd.Parameters.Add("@pPass", SqlDbType.Char);

            cmd.Parameters["@pUseremail"].Value = useremail;
            cmd.Parameters["@pPass"].Value = password;
            
            //执行查询:提供一种读取数据库行的方式  
            SqlDataReader sread = cmd.ExecuteReader();
           // int i = Convert.ToInt32(cmd.ExecuteScalar());

            try
            {
                //如果存在用户名和密码正确数据执行进入系统操作  
               if (sread.Read())
                {
                    Session["uemail"] = useremail;
                    uid = (int)sread["uid"];
                    Session["uid"] = uid;
                    Response.Redirect("index.aspx",false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "emailOrPwdError", "alert('Wrong email or password!');", true);
                }
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());  //处理异常信息  
            }
            finally
            {
                con.Close();                    //关闭连接  
                con.Dispose();                  //释放连接  
                //sread.Dispose();                //释放资源  
            }  
        }

        
     
      
        
       

        
    }
}