<%@ Page Language="C#" MasterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BlogGenerator.Webpage.index" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server" >
    <form id="form1" runat="server">




    <div class="jumbotron">
        <h1>Start your blog journey</h1>
        <p class="lead">Click "Create New Article" to add a new blog article. If you have done modification then click "Generate Blog" to view your new blog page</p>
        <p>
            <asp:Button ID="btNewBlog" runat="server" Text="Create New Article" class="btn btn-lg btn-success" OnClick="start_Click"/></p>
        <asp:Button ID="generator" runat="server" Text="Generate Blog" class="btn btn-lg btn-success" OnClick="generate" />
    
    </div>

    <div class="row marketing">

        <asp:DataList ID="DataList1" runat="server" width="100%" OnItemCommand="sendtomeList_ItemCommand" DataKeyField="blogid" BorderColor="Silver" BorderWidth="1px" CellPadding="6" ForeColor="#333333" GridLines="Both" RepeatDirection="Horizontal" CellSpacing="6" >
         
           <HeaderTemplate >
               <table width="100%" >
                   <tr><td width="15%"><h4>Title:</h4></td>
                       <td width="15%"><h4>Tags:</h4></td>
                       <td width="34%"><h4>Brief:</h4></td>
                       <td width="12%"><h4>On:</h4></td>
                       <td width="12%"><h4></h4></td>
                       <td width="12%"><h4></h4></td></tr>
           </HeaderTemplate>
            <ItemTemplate>
                <tr><td><asp:Label ID="blogidLabel1" runat="server" Text='<%# Eval("blogid") %>' display="none" Visible="<%# false %>"/>
                    <p><asp:Label ID="blogtitleLabel" runat="server" Text='<%# Eval("blogtitle") %>' /></p></td>
                    <td> <p><asp:Label ID="bloglabelLabel" runat="server" Text='<%# Eval("bloglabel") %>' /></p></td>
                     <td><p><asp:Label ID="briefintroLabel" runat="server" Text='<%# Eval("briefintro") %>' /></p></td>
                    <td><p><asp:Label ID="createdateLabel" runat="server" Text='<%# Eval("createdate") %>' /></p></td>
                <td><p><asp:LinkButton ID="LBtnEdit" runat="server" CommandName="Edit" >Edit</asp:LinkButton></p></td>
                <td><p><asp:LinkButton ID="LinkDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton></p></td>
                </tr>

            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>


    </div>
         <div id="cytoscapeweb">
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