<%@ Page Language="C#" MasterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BlogGenerator.Webpage.index" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server" >





    <form id="form1" runat="server">





         <div id="cytoscapeweb" class="jumbotron">
            Cytoscape Web will replace the contents of this div with your graph.
        </div>
        <div >
            <span class="link" id="color">Color me surprised</span>
            <br/ >
            <span class="link" id="colordefault">Default Color</span>
        </div>
        <div id="note">
            
        </div>
        
    <div class="footer">
        <p>&copy; WebGroup: Jun Yin, Yue Wang, Lee-Yin Wang, Huan Wang.  2013</p>
    </div>



    </form>



</asp:Content>