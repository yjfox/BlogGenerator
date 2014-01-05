using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace BlogGenerator.Webpage
{
    public partial class BlogContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("Label_sign")).Text = "Sign out";
            if (!IsPostBack)
            {
                int intUid = (Session["uid"] == null ? 0 : Convert.ToInt32(Session["uid"]));
                //if (intUid == 0)
                //{ AlertSussTranscation("Please login again！", "login.aspx"); }
                lblUid.Text = intUid.ToString();
                int intBlogid = (Session["blogid"] == null ? 0 : Convert.ToInt32(Session["blogid"]));
                if (intBlogid != 0)
                {
                    txtBlogTitle.Text = Session["blogtitle"].ToString(); ;
                    txtBlogLabel.Text = Session["bloglabel"].ToString();
                    txtBriefIntro.Text = Session["briefinfo"].ToString();
                    FreeTextBox1.Text = Session["blogcontent"].ToString();
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string strBlogTitle = txtBlogTitle.Text;
            string strBlogLabel = txtBlogLabel.Text;
            string strBriefIntro = txtBriefIntro.Text;
            //fckContent.Value = HttpUtility.HtmlEncode(fckContent.Value);
            //string strBlogContent = HttpUtility.HtmlDecode(fckContent.Value);
            string strBlogContent = FreeTextBox1.Xhtml;
            string strDate = DateTime.Today.ToString("yyyy-MM-dd");
            string strMsg = string.Empty;
            if (strBlogTitle.Length == 0)
            { strMsg = "Please input your blog title! \\n"; }
            if (strBlogLabel.Length == 0)
            { strMsg += "Please input your blog label! \\n"; }
            if (strBlogContent.Length == 0)
            { strMsg += "Please input your blog content! \\n"; }
            if (strBriefIntro.Length == 0)
            { strMsg += "Please input your brief intro of your blog! \\n"; }
            
            if (strMsg.Length > 0)
            { AlertMsg(strMsg); }
            else
            {
                int intBlogid = (Session["blogid"] == null ? 0 : Convert.ToInt32(Session["blogid"]));
                string strSaveStyle = string.Empty;
                if (intBlogid != 0)
                { 
                    strSaveStyle = "update";
                    Session["blogid"] = null;
                }
                else
                { strSaveStyle = "create"; }
                
                int intSaveResult = -1;
                intSaveResult = SaveBlog(strSaveStyle, intBlogid, Convert.ToInt32(lblUid.Text), strBlogTitle, strBlogLabel, strBriefIntro, strBlogContent, strDate);
                if (intSaveResult == 0)
                {
                    AlertSussTranscation("Congratulation! You have a new blog!!", "index.aspx");
                }
                else
                { AlertMsg("Sorry! Please try again!!" + intSaveResult); }
            }     
        }

        #region// insert blog into database
        protected int SaveBlog(string strSaveType, int intBlogid, int intUid, string strTitle, string strLabel, string strBriefInfo, string strContent, string strDate)
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            int intResult = -9;
            string strError = string.Empty;
            string strSQL = string.Empty;

            if (strSaveType == "update")
            { strSQL = @"UPDATE bloginfo SET uid=@uid, blogtitle=@blogtitle, bloglabel=@bloglabel, briefintro=@briefintro, blogcontent=@blogcontent, createdate=@createdate
                         WHERE blogid = @blogid"; 
                //strSQL = @"UPDATE bloginfo SET uid=2, blogtitle='AAA', bloglabel='AAA', briefintro='AAA', blogcontent='AAA', createdate='AAA'
                  //       WHERE blogid = 17";
            }
            else
            {
                strSQL = @"INSERT INTO bloginfo(uid, blogtitle, bloglabel, briefintro, blogcontent, createdate)
                           Values(@uid, @blogtitle, @bloglabel, @briefintro, @blogcontent, @createdate)";
            }
            SqlConnection con = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strSQL, con);

            try
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 90;

                cmd.Parameters.Add("@uid", SqlDbType.Int);
                cmd.Parameters.Add("@blogid", SqlDbType.Int);
                cmd.Parameters.Add("@blogtitle", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@bloglabel", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@briefintro", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@blogcontent", SqlDbType.Text);
                cmd.Parameters.Add("@createdate", SqlDbType.VarChar, 20);

                cmd.Parameters["@uid"].Value = intUid;
                cmd.Parameters["@blogid"].Value = intBlogid;
                cmd.Parameters["@blogtitle"].Value = strTitle;
                cmd.Parameters["@bloglabel"].Value = strLabel;
                cmd.Parameters["@briefintro"].Value = strBriefInfo;
                cmd.Parameters["@blogcontent"].Value = strContent;
                cmd.Parameters["@createdate"].Value = strDate;

                intResult = Convert.ToInt16(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                intResult = -8;
                strError = ex.GetType() + ";" + ex.Message;
                Response.Write(strError);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return intResult;
        }
        #endregion


        #region// 產生JavaScript Alert訊息並將視窗導往指定的Url
        /// <summary>
        /// 產生JavaScript Alert訊息並將視窗導往指定的URL
        /// </summary>
        /// <param name="query">要顯示的訊息</param>
        /// <param name="url">要導往的Url</param>
        protected void AlertSussTranscation(string query, string url)
        {
            string _strJS = "<script language=javascript>\n";
            _strJS += "alert(\"" + query + "\");\n";
            _strJS += "location.href = \"" + url + "\";\n";
            _strJS += "</script>";

            HttpContext.Current.Response.Write(_strJS);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        #endregion

        #region //產生JavaScript Alert訊息並導回前一頁
        /// <summary>
        /// 產生JavaScript Alert訊息並導回前一頁
        /// </summary>
        /// <param name="query">要顯示的訊息</param>
        public static void AlertMsg(string query)
        {
            string _strJS = "<script language=javascript>\n";
            _strJS += "alert(\"" + query + "\");\n";
            _strJS += "history.back();";
            _strJS += "</script>";

            HttpContext.Current.Response.Write(_strJS);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        #endregion

        #region//只產生JavaScript Alert訊息,不清除畫面也不停止網頁動作
        /// <summary>
        /// 只產生JavaScript Alert訊息,不清除畫面也不停止網頁動作
        /// </summary>
        /// <param name="query">要顯示的訊息</param>
        public static void Alert(string query)
        {
            string _strJS = "<script language=javascript>\n";
            _strJS += "alert(\"" + query + "\");";
            _strJS += "</script>";

            HttpContext.Current.Response.Write(_strJS);
            HttpContext.Current.Response.Flush();
        }
        #endregion

    }
}