using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace BlogGenerator.Webpage
{
    public partial class BlogName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("Label_sign")).Text = "Sign out";
            if (!IsPostBack)
            {
                int intUid = (Session["uid"] == null ? 0 : Convert.ToInt32(Session["uid"]));
                if (intUid == 0)
                { AlertSussTranscation("Please login again！", "login.aspx"); }
                lblUid.Text = intUid.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CheckBlogName();
            int intSaveResult = -1;
            intSaveResult = SaveTitle(txtBlogName.Text, Convert.ToInt32(lblUid.Text));

            if (intSaveResult == 0)
            {
                AlertSussTranscation("Save your blog name successly！", "BlogContent.aspx");
            }
            else
            {
                AlertSussTranscation("Sorry！Please try again" + intSaveResult, "login.aspx");
            }
        }

        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    CheckBlogName();
        //    Session["BlogName"] = txtBlogName.Text;
        //    Response.Redirect("BlogContent.aspx", true);
        //}

        #region// insert blog name into database
        protected int SaveTitle(string strBlogName, int intUid)
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["BlogGeneratorConnectionString"].ConnectionString;
            int intResult = -9;
            string strError = string.Empty;
            string strSQL = @"UPDATE userinfo SET blogname = @blogname WHERE uid=@uid";
            SqlConnection con = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strSQL, con);

            try
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 90;

                cmd.Parameters.Add("@blogname", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@uid", SqlDbType.Int);
                cmd.Parameters["@blogname"].Value = strBlogName;
                cmd.Parameters["@uid"].Value = intUid;
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


        protected void CheckBlogName()
        {
            string strBlogName = txtBlogName.Text;
            if (strBlogName.Length == 0)
            { AlertMsg("Please input your blog name!"); }
        }

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