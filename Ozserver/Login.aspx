<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ozserver.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
    <title>Ozdocs - Login</title>
    
    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="images/ABOUT.BMP">

    <!-- CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets/css/style.css">

    <!--[if lt IE 9]
        <script src="assets/js/html5shiv.min.js"></script>
        <script src="assets/js/respond.min.js"></script>
    <![endif]-->

    <!-- JavaScript Function to Validate the Form -->
    <script type="text/javascript">
        function validateForm() {
            var username = document.getElementById('<%= user_id.ClientID %>').value;
            var password = document.getElementById('<%= txtPassword.ClientID %>').value;

            if (username.trim() === "" || password.trim() === "") {
                alert("Please fill out both Username and Password fields.");
                return false;
            }
            return true;
        }
    </script>
</head>

<body>
    <!-- Main Wrapper -->
    <div class="main-wrapper login-body">
        <div class="login-wrapper">
            <div class="container">
                <div class="loginbox">
                    <div class="login-left">
                        <img class="img-fluid" src="images/ABOUT.BMP" alt="Logo">
                    </div>
                    <div class="login-right">
                        <div class="login-right-wrap">
                            <h1>Login</h1>
                            <p class="account-subtitle">Access our dashboard</p>

                            <!-- Form -->
                            <form runat="server" onsubmit="return validateForm();">
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="user_id" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                                </div>
                            </form>
                            <!-- /Form -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /Main Wrapper -->

    <!-- JavaScript -->
    <script src="assets/js/jquery-3.2.1.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/script.js"></script>
</body>
</html>
