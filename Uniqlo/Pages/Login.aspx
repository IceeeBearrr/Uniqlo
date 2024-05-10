﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Uniqlo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Uniqlo.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
 <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <!-- CSS -->
     <link href="../css/Login.css" rel="stylesheet" />
                
        <!-- Boxicons CSS -->
        <link href='https://unpkg.com/boxicons@2.1.2/css/boxicons.min.css' rel='stylesheet'>
                        
 </head>
        <section class="container forms">
            <div class="form login">
                <div class="form-content">
                    <header>Login</header>
                    <form action="#">
                        <asp:Label ID="errorMSG" runat="server" Text=""></asp:Label>
                        <div class="field input-field">
                            <asp:TextBox ID="txtEmail" type="email" placeholder="Email" class="input" runat="server"></asp:TextBox>
                        </div>
                        <div class="field input-field">
                            <asp:TextBox ID="txtPassword" type="password" placeholder="Password" class="password" runat="server"></asp:TextBox>
                            <i class='bx bx-hide eye-icon'></i>
                        </div>
                        <div class="form-link">
                            <a href="ForgotPassword.aspx" class="forgot-pass">Forgot password?</a>
                        </div>
                        <div class="field button-field">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                        </div>
                    </form>
                    <div class="form-link">
                 <span>Don't have an account?</span>
                        <asp:HyperLink ID="signUpLink" runat="server" NavigateUrl="SignUp.aspx">Sign Up</asp:HyperLink>
                </div>
                </div>
                <div class="line"></div>
                <div class="media-options">
                    <a href="#" class="field facebook">
                        <i class='bx bxl-facebook facebook-icon'></i>
                        <span>Login with Facebook</span>
                    </a>
                </div>
               <div class="media-options">
        <a href="google.com" class="field google">
            <i class="fa-brands fa-google"></i>  
            <span>Login with Google</span>
        </a>
    </div>
                </div>
      




        </section>
        <!-- JavaScript -->
    <script src="../Javascript/Login.js"></script>



    </span>



</asp:Content>