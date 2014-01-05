using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Diagnostics;  

namespace BlogGenerator.Webpage
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ((Label)Master.FindControl("Label_sign")).Text = "Sign In"; 
            string struid = (Session["uid"] == null ? string.Empty : Session["uid"].ToString());
           string stremail = (Session["uemail"] == null ? string.Empty : Session["uemail"].ToString());
           string struname = (Session["uname"] == null ? string.Empty : Session["uname"].ToString());
           if (String.IsNullOrWhiteSpace(struid) && (!String.IsNullOrWhiteSpace(stremail)))
            {
                
                string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
                string sql1 = "select * from userinfo where uemail='" + Session["uemail"].ToString() + "'";
                SqlConnection con1 = new SqlConnection(connString);
                SqlCommand cmd1 = con1.CreateCommand();
                cmd1.CommandText = sql1;
                con1.Open();
                SqlDataReader sread = cmd1.ExecuteReader();
                if (sread.Read())
                {
                    int uid = (int)sread["uid"];
                    Session["uid"] = uid;
                    string username = (string)sread["username"];
                    Session["uname"] = username;
                }
            }


          if (!String.IsNullOrWhiteSpace(struid))
          {
              ((Label)Master.FindControl("Label_sign")).Text = "Sign Out";
                ((Label)Master.FindControl("Label_Name")).Text = stremail;
              this.Bind();
            }
          

         
                
        }
        private void Bind()
        {
            string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            string sql = "select blogid, blogtitle, bloglabel, briefintro, createdate from bloginfo where uid=@pUid";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;
            
            cmd.Parameters.Add("@pUid", SqlDbType.Int);
            cmd.Parameters["@pUid"].Value = Session["uid"];
            adapter.Fill(ds, "ds");
            this.DataList1.DataSource = ds;           
            
            this.DataList1.DataBind();
            con.Close();

        }

        protected void sendtomeList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Response.Write("<script language='JavaScript'> alert('Confirm deletion?');</script>");
                //打开数据库连接
                //SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["connStr"]);
                string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();

                string bid = DataList1.DataKeys[e.Item.ItemIndex].ToString();//获取id
                SqlCommand comm1 = new SqlCommand("delete from bloginfo where blogid=" + bid, con);
               
               
                int count =  comm1.ExecuteNonQuery();
                if (count != 0) 
                    Response.Write("<script language='JavaScript'> alert('Delete this blog successfully!');</script>");
                else Response.Write("<script language='JavaScript'> alert('Unable to delete this blog. Please try again!');</script>");

              
                con.Close();
                Bind();
            }
            if (e.CommandName == "Edit")
            {
                string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string bid = DataList1.DataKeys[e.Item.ItemIndex].ToString();//获取id
                Session["blogid"] = bid;
                SqlCommand comm2 = new SqlCommand("select * from bloginfo where blogid=" + bid, conn);
                SqlDataReader sread1 = comm2.ExecuteReader();
                if (sread1.Read())
                {
                    string blogtitle = (string)sread1["blogtitle"];
                    Session["blogtitle"] = blogtitle;
                    string blogcontent = (string)sread1["blogcontent"];
                    Session["blogcontent"] = blogcontent;
                    string bloglabel = (string)sread1["bloglabel"];
                    Session["bloglabel"] = bloglabel;
                    string briefinfo = (string)sread1["briefintro"];
                    Session["briefinfo"] = briefinfo;
                    Response.Redirect("BlogContent.aspx", false);
                }
            }

        }

        protected void start_Click(object sender, EventArgs e)
        {
             string strUid = (Session["uid"] == null ? string.Empty : Session["uid"].ToString());
            
            if (strUid.Length == 0)
            {
                Response.Write("<script language='JavaScript'>alert('Please log in !');location.href='login.aspx';</script>");
                //Response.Redirect("login.aspx", true);
            
            }
            else {
            int uid = Convert.ToInt32(strUid);
            string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand comm2 = new SqlCommand("select * from userinfo where uid=" + uid, conn);
            SqlDataReader sread1 = comm2.ExecuteReader();
            if (sread1.Read())
            {
                string blogname=null;
                if (sread1["blogname"] != System.DBNull.Value)
                { blogname = (string)sread1["blogname"]; }
                //strBlogName = (Session["BlogName"] == null ? string.Empty : Session["BlogName"].ToString());
                if (blogname == null)
                    Response.Redirect("BlogName.aspx", true);
                else
                {
                    Session["BlogName"] = blogname;
                    Response.Redirect("BlogContent.aspx", true);
                   
                }
                
                
            }


            }
        }

        protected void CopyDirectory(string sourceDirName, string destDirName)
        {
            try
            {
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                    File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));

                }

                if (destDirName[destDirName.Length - 1] != Path.DirectorySeparatorChar)
                    destDirName = destDirName + Path.DirectorySeparatorChar;

                string[] files = Directory.GetFiles(sourceDirName);
                foreach (string file in files)
                {
                    if (File.Exists(destDirName + Path.GetFileName(file)))
                        continue;
                    File.Copy(file, destDirName + Path.GetFileName(file), true);
                    File.SetAttributes(destDirName + Path.GetFileName(file), FileAttributes.Normal);

                }

                string[] dirs = Directory.GetDirectories(sourceDirName);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, destDirName + Path.GetFileName(dir));
                }
            }
            catch
            {
                AlertSussTranscation("index.aspx");
                //do something here
            }
        }

        protected string Execute(string command, int seconds)
        {
            string output = ""; //输出字符串  
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令  
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动  
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程  
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束  
                        }
                        else
                        {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒  
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }
                }
                catch
                {
                    AlertSussTranscation("index.aspx");
                    //do something here
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }

        protected void generate(object sender, EventArgs e)
        {
            string useremail = (Session["uemail"] == null ? string.Empty : Session["uemail"].ToString());
            if (useremail == "")
            {
                Response.Write("<script language='JavaScript'>alert('Please log in !');location.href='login.aspx';</script>");
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;

            //定义SQL Server连接对象 打开数据库  
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            string sql = "SELECT * From [bloggenerator].[dbo].[userinfo] where uemail='" + useremail + "'";


            //定义查询命令:表示对数据库执行一个SQL语句或存储过程  
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = con;
            sqlcmd.CommandText = sql;
            int uid = 1;
            Int16 style = 0;
            string blogame = null;
            string username = null;
            string linkurl1 = null;
            string linkurl2 = null;
            string linkurl3 = null;
            string linkname1 = null;
            string linkname2 = null;
            string linkname3 = null;
            SqlDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.Read())
            {
                uid = (int)dataReader["uid"];
                username = (string)dataReader["username"];
                style=Convert.ToInt16(dataReader["style"]); //receive tinyint data

                if (dataReader["blogname"] != System.DBNull.Value)
                { blogame = (string)dataReader["blogname"]; }

                if (dataReader["linkurl1"] != System.DBNull.Value)
                { linkurl1 = (string)dataReader["linkurl1"]; }
                if (dataReader["linkurl2"] != System.DBNull.Value)
                { linkurl2 = (string)dataReader["linkurl2"]; }
                if (dataReader["linkurl3"] != System.DBNull.Value)
                { linkurl3 = (string)dataReader["linkurl3"]; }
                if (dataReader["linkname1"] != System.DBNull.Value)
                { linkname1 = (string)dataReader["linkname1"]; }
                if (dataReader["linkname2"] != System.DBNull.Value)
                { linkname2 = (string)dataReader["linkname2"]; }
                if (dataReader["linkname3"] != System.DBNull.Value)
                { linkname3 = (string)dataReader["linkname3"]; }
            }
            sqlcmd.Dispose();
            dataReader.Close();
            string filepathname = "C:/temp/" + username;
            DirectoryInfo di;
            if (Directory.Exists(@"c:/temp/_site"))
            {
                di = new DirectoryInfo("c:/temp/_site");
                di.Delete(true);
            }

            if (!Directory.Exists(@filepathname)) //判断文件夹是否已经存在
            {
                Directory.CreateDirectory(@filepathname);//创建文件夹
            }
            else
            {
                di = new DirectoryInfo(filepathname);
                di.Delete(true);
                di = new DirectoryInfo("c:/wamp/www/" + username);
                di.Delete(true);

            }
            switch (style)
            {
                case 1:
                    CopyDirectory("c:/temp/template1", "c:/temp/" + username);
                    break;
                case 2:
                    CopyDirectory("c:/temp/template2", "c:/temp/" + username);
                    break;
                case 3:
                    CopyDirectory("c:/temp/template3", "c:/temp/" + username);
                    break;
                case 4:
                    CopyDirectory("c:/temp/template4", "c:/temp/" + username);
                    break;
                default:
                    CopyDirectory("c:/temp/template2", "c:/temp/" + username);
                    break;
            }
            //循环创建md文件
            sql = "SELECT TOP 1000 [blogid],[blogtitle],[bloglabel],[briefintro],[blogcontent],[createdate] FROM [bloggenerator].[dbo].[bloginfo] where uid=" + uid;


            //定义查询命令:表示对数据库执行一个SQL语句或存储过程  
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = con;
            sqlComm.CommandText = sql;

            SqlDataReader dataReader2 = sqlComm.ExecuteReader();
            StreamWriter sw;
            string mdfileName = null;

            while (dataReader2.Read())
            {

                mdfileName = "c:/temp/" + username + "/_posts/" + (string)dataReader2["createdate"] + "-" + (string)dataReader2["blogtitle"] + ".md";
                sw = new StreamWriter(@mdfileName, false, Encoding.ASCII);
                string s = "---";
                sw.WriteLine(s);
                string[] strs = {"layout: default","title: "+dataReader2["blogtitle"],
                    "label: "+dataReader2["bloglabel"],"time: "+dataReader2["createdate"],
                    "brief: "+dataReader2["briefintro"] };
                foreach (var si in strs)
                {
                    sw.WriteLine(si);
                }
                sw.WriteLine(s);

                s = "#{{ page.title }}";
                sw.WriteLine(s);
                s = "> {{ page.brief }}";
                sw.WriteLine(s);
                sw.WriteLine("");
                s = (string)dataReader2["blogcontent"];
                sw.WriteLine(s);
                sw.Close();


            }


            con.Close();                    //关闭连接  
            con.Dispose();                  //释放连接  
            //sread.Dispose();                //释放资源  

            string line;
            try
            {
                string userpath = "c:/temp/" + username + "/_layouts/default.html";
                StreamReader sr = new StreamReader(userpath);
                line = sr.ReadToEnd();
                Console.Write(line);
                sr.Close();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());  //处理异常信息  
            }

            //修改default.html

            if (line.Contains("blogtitle"))
            {
                //insert users’ information into default.html, which is the template of whole blog.
                line = line.Replace("/stylesheets", "/" + username + "/stylesheets");
                line = line.Replace("userlink", "localhost/" + username);
                line = line.Replace("blogtitle", blogame);
                line = line.Replace("linkurl1", linkurl1);
                line = line.Replace("linkname1", linkname1);
                line = line.Replace("linkurl2", linkurl2);
                line = line.Replace("linkname2", linkname2);
                line = line.Replace("linkurl3", linkurl3);
                line = line.Replace("linkname3", linkname3);
                Console.Write(line);
            }
            sw = new StreamWriter(@"c:/temp/" + username + "/_layouts/default.html", false, Encoding.ASCII);
            sw.Write(line);
            sw.Close();


            //修改index.html
            try
            {
                string userpath = "c:/temp/" + username + "/index.html";
                StreamReader sr = new StreamReader(userpath);
                line = sr.ReadToEnd();
                Console.Write(line);
                sr.Close();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());  //处理异常信息  
            }

            if (line.Contains("post.url"))
            {
                line = line.Replace("{{ post.url }}", "/" + username + "{{ post.url }}");
                Console.Write(line);
            }
            sw = new StreamWriter(@"c:/temp/" + username + "/index.html", false, Encoding.ASCII);
            sw.Write(line);
            sw.Close();



            //jekyll

            Execute("jekyll build -s c:/temp/" + username + " -d c:/temp/_site", 0);
            CopyDirectory("c:/temp/_site", "c:/wamp/www/" + username);

            AlertSussTranscation("http://localhost/" + username);
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