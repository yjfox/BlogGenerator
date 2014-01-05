<%@ Page Language="C#" AutoEventWireup="true"  masterPageFile="~/Site.Master"  CodeBehind="editUserInfor.aspx.cs" Inherits="BlogGenerator.Webpage.editUserInfor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
<div class="row-fluid">
     <form class="form-horizontal" role="form" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="page-header">
                     <h2>Blog Name</h2>
                </div>
                <asp:TextBox ID="blogname" class="form-control" runat="server" ></asp:TextBox>
                
             &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </div>



        </div>
       
            <div class="panel panel-default">
               <div class="panel-body">
                <div class="page-header">
                     <h2>Blog Theme</h2>
                </div>
            <div class="span4">

                <img src="../Images/concise.png" alt="concise" class="img-rounded" style="height: 110px;width: 140px;margin:5px;"/>
                <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="theme" Checked="true"/>
            </div>
            <div class="span4">
                <img src="../Images/cute.png" alt="cute" class="img-rounded" style="height:110px;width: 140px;margin:5px;"/>
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="theme" />
            </div>

            <div class="span4">
                <img src="../Images/fancy.png" alt="fancy" class="img-rounded"style="height:110px;width: 140px;margin:5px;"/>
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="theme"/>
            </div>
            <div class="span4">
                <img src="../Images/hack.png" alt="hack" class="img-rounded"style="height: 110px;width: 140px;margin:5px;"/>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="theme"/>
           
            </div>
             </div>
                </div>

            &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
      
               <div class="panel panel-default">
               <div class="panel-body">
                <div class="page-header">
                     <h2>Friend Link</h2>
                </div>
            <div class="form-group">
                <label class="col-sm-1 control-label">Link</label>
                <div class="col-sm-4">
                    <input type="text" class="form-control" placeholder="Link Name" runat="server" id="linkname1">
                </div>
                <div class="col-sm-7">
                    <input type="text" class="form-control" placeholder="URL" runat="server" id="linkurl1">
                    </div>
            </div>

            <div class="form-group">
                <label class="col-sm-1 control-label">Link</label>
                <div class="col-sm-4">
                    <input type="text" class="form-control" placeholder="Link Name" runat="server" id="linkname2">
                </div>
                <div class="col-sm-7">
                    <input type="text" class="form-control" placeholder="URL" runat="server" id="linkurl2">
                </div>
            </div>
            <div class="form-group">
                <label  class="col-sm-1 control-label">Link</label>
                <div class="col-sm-4">
                    <input type="text" class="form-control" placeholder="Link Name" runat="server" id="linkname3">
                </div>
                <div class="col-sm-7">
                    <input type="text" class="form-control" placeholder="URL" runat="server" id="linkurl3">
                </div>
            </div>


            <div class="form-group">
                <div class="col-sm-offset-1 col-sm-11">
                    <asp:Button ID="save" runat="server" Text="save" OnClick="save_Click" />
                  
                </div>
            </div>
             </div>
         </div>
     
        </form>

</div>

    <div class="footer">
        <p>&copy; WebGroup: Jun Yin, Yue Wang, Lee-Yin Wang, Huan Wang.  2013</p>
    </div>

</asp:Content>
