using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogGenerator.Model
{
    public class userinfo
    {

        /// <summary>
        /// uid
        /// </summary>		
        private int _uid;
        public int uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        /// <summary>
        /// uemail
        /// </summary>		
        private string _uemail;
        public string uemail
        {
            get { return _uemail; }
            set { _uemail = value; }
        }
        /// <summary>
        /// upassword
        /// </summary>		
        private string _upassword;
        public string upassword
        {
            get { return _upassword; }
            set { _upassword = value; }
        }
        /// <summary>
        /// username
        /// </summary>		
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// style
        /// </summary>		
        private int _style;
        public int style
        {
            get { return _style; }
            set { _style = value; }
        }
        /// <summary>
        /// blogname
        /// </summary>		
        private string _blogname;
        public string blogname
        {
            get { return _blogname; }
            set { _blogname = value; }
        }
        /// <summary>
        /// linkname1
        /// </summary>		
        private string _linkname1;
        public string linkname1
        {
            get { return _linkname1; }
            set { _linkname1 = value; }
        }
        /// <summary>
        /// linkurl1
        /// </summary>		
        private string _linkurl1;
        public string linkurl1
        {
            get { return _linkurl1; }
            set { _linkurl1 = value; }
        }
        /// <summary>
        /// linkname2
        /// </summary>		
        private string _linkname2;
        public string linkname2
        {
            get { return _linkname2; }
            set { _linkname2 = value; }
        }
        /// <summary>
        /// linkurl2
        /// </summary>		
        private string _linkurl2;
        public string linkurl2
        {
            get { return _linkurl2; }
            set { _linkurl2 = value; }
        }
        /// <summary>
        /// linkname3
        /// </summary>		
        private string _linkname3;
        public string linkname3
        {
            get { return _linkname3; }
            set { _linkname3 = value; }
        }
        /// <summary>
        /// linkurl3
        /// </summary>		
        private string _linkurl3;
        public string linkurl3
        {
            get { return _linkurl3; }
            set { _linkurl3 = value; }
        }


        public userinfo(string uemail, string upassword, string username, int style, string blogname, string linkname1, string linkurl1, string linkname2, string linkurl2, string linkname3, string linkurl3)
            {
               
                this.uemail = uemail;
                this.upassword = upassword;
                this.username = username;
                this.style = style;
                this.blogname = blogname;
                this.linkname1 = linkname1;
                this.linkurl1 = linkurl1;
                this.linkname2 = linkname2;
                this.linkurl2 = linkurl2; 
                this.linkname3 = linkname3;
                this.linkurl3 = linkurl3;
                
             }
        public userinfo(string uemail, string upassword, string username)
        {

            this.uemail = uemail;
            this.upassword = upassword;
            this.username = username;

        }
       
    }

}