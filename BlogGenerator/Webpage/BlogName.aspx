<%@ Page Language="C#" masterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogName.aspx.cs" Inherits="BlogGenerator.Webpage.BlogName" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >

    <div class="panel panel-default">
        <form id="form1" runat="server" class="panel-body">
            <div class="page-header">
                 <h1>First Step <small>Come up with a name of your blog</small></h1>
             </div>

            <asp:TextBox ID="txtBlogName" runat="server" class="form-control" MaxLength="40"></asp:TextBox>
                <hr >
            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-default pull-right" OnClick="btnSave_Click"/>
            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-default pull-right" OnClick="btnSave_Click" />
            <asp:Label ID="lblUid" runat="server" Text="" Visible="False"></asp:Label>
        </form>
    </div>

    <div class="footer">
        <p>&copy; WebGroup: Jun Yin, Yue Wang, Lee-Yin Wang, Huan Wang.  2013</p>
    </div>



</asp:Content>
