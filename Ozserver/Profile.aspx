<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Ozserver.WebForm1"  MasterPageFile="~/SiteOzserver.Master"  %>


<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Profile section styles */
        .profile-list {
            margin-top: 20px;
        }

        .profile-item {
            margin-bottom: 10px;
            display: flex;
            align-items: center;
        }

        .profile-label {
            flex: 1;
            font-weight: bold;
        }

        .profile-value {
            flex: 3;
        }

        /* Responsive adjustments */
        @media screen and (max-width: 768px) {
            .profile-item {
                flex-direction: column;
                align-items: flex-start;
            }

            .profile-value {
                flex: none;
            }
        }
    </style>

    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Profile</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">Profile</li>
                        </ul>
                    </div>
                </div>
            </div>

            <asp:ListView ID="lvUserProfile" runat="server" >
                <ItemTemplate>
                    <div class="profile-item">
                        <div class="profile-label">ID:</div>
                        <div class="profile-value"><%# Eval("Id") %></div>
                    </div>
                    <div class="profile-item">
                        <div class="profile-label">Organization ID:</div>
                        <div class="profile-value"><%# Eval("OrgId") %></div>
                    </div>
                    <div class="profile-item">
                        <div class="profile-label">Office ID:</div>
                        <div class="profile-value"><%# Eval("OfficeId") %></div>
                    </div>
                    <div class="profile-item">
                        <div class="profile-label">Company Name:</div>
                        <div class="profile-value"><%# Eval("CompanyName") %></div>
                    </div>
                    <div class="profile-item">
                        <div class="profile-label">Email Address:</div>
                        <div class="profile-value"><%# Eval("EmailAddress") %></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
