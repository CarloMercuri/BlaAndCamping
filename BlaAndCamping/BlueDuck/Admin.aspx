<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" MasterPageFile="../Booking.Master" Inherits="BlaAndCamping.BlueDuck.Admin" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-background">
        <div class="loginBox">
            
                    <label id="loginHeader">Login</label>

                    <div id="userPassDiv">
                        <input runat="server" ID="input_username" type="text" class="infoInput" name="email" placeholder="Indtast e-mail-adresse her..." required><br>
                        <input runat="server" id="input_password" type="password" class="infoInput" name="adgangskode" placeholder="Indtast adgangskode her…" required>
                    </div>

                    <%--<input type="submit" runat="server" class="infoButtonSubmit" id="infoButton" value="Login">--%>
            <asp:Button Text="Login" runat="server" ID="btn_Submit" CssClass="infoButtonSubmit" />

                </div>
        </div>

</asp:Content>
