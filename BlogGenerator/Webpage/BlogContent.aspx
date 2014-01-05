<%@ Page Language="C#" masterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogContent.aspx.cs" Inherits="BlogGenerator.Webpage.BlogContent" validateRequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server" >

<!DOCTYPE html>

    <div class="panel panel-default">
        <form id="form1" runat="server" class="panel-body">
            <h3>Article Title:</h3>
            <asp:TextBox ID="txtBlogTitle" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
            <hr >
            <h3>Article Label:</h3>
            <asp:TextBox ID="txtBlogLabel" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
            <hr >
            <h3>Brief Introduction:</h3>
            <asp:TextBox ID="txtBriefIntro" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
            <hr >
            <h3>Article Content:</h3>
            <FTB:FreeTextBox id="FreeTextBox1" runat="Server"/>
            <hr >
            <asp:Button ID="btnSend" runat="server" Text="Save" class="btn btn-default pull-right" OnClick="btnSend_Click" />
            <asp:Label ID="lblUid" runat="server" Text="" Visible="False"></asp:Label>

        </form>
    </div>

    <div class="footer">
        <p>&copy; WebGroup: Jun Yin, Yue Wang, Lee-Yin Wang, Huan Wang.  2013</p>
    </div>

</asp:Content>
