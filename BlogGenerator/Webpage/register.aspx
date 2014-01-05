<%@ Page Language="C#" masterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BlogGenerator.Webpage.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="row marketing">
        <form class="form-horizontal" role="form" runat="server">

            <div class="form-group">
                <label for="inputPassword3" class="col-sm-2 control-label">Username</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" placeholder="Username" runat="server" id="inputUserName">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="This name already exists. Please choose another name."
                            ControlToValidate="inputUserName" 
                              Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <div class="form-group">
                <label for="inputPassword" class="col-sm-2 control-label">Password</label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="inputPassword" placeholder="Password" runat="server">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                  ControlToValidate="inputPassword"  ErrorMessage="please enter your password" InitialValue="">
                              </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="confirm" class="col-sm-2 control-label">Confirm</label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="confirm" placeholder="Confirm password" runat="server">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                  ControlToValidate="confirm"  ErrorMessage="comfirm your password" InitialValue="">
                              </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                <div class="col-sm-10">
                    <input type="email" class="form-control" id="inputEmail" placeholder="Email" runat="server">
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="This email has already been used."
                            ControlToValidate="inputEmail" 
                              Display="Dynamic" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox"> Remember me
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    
                    <asp:Button ID="BtnRegister" runat="server" Text="Create Account" OnClick="BtnRegister_Click" />
                </div>
                
            </div>
        </form>
    </div>

    <div class="footer">
        <p>&copy; WebGroup: Jun Yin, Yue Wang, Lee-Yin Wang, Huan Wang.  2013</p>
    </div>
    
</asp:Content>

