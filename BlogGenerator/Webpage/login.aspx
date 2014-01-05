<%@ Page Language="C#" masterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="login.aspx.cs" Inherits="BlogGenerator.Webpage.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >


    <div class="row marketing" >
        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                <div class="col-sm-10">
                    <input type="email" class="form-control" id="inputEmail3" placeholder="Email" runat="server">
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="inputPassword3" placeholder="Password" runat="server">
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" runat="server"> Remember me
                      
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    
                    <asp:Button ID="signin" runat="server" Text="Sign in" class="btn btn-default" OnClick="signin_Click" />
                </div>
            </div>
        </form>
    </div>

    <div class="footer">
        <p>&copy; WebGroup: Jun Yin, Yue Wang, Lee-Yin Wang, Huan Wang.  2013</p>
    </div>


</asp:Content>

