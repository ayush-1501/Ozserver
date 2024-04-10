<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Ozserver.WebForm4" MasterPageFile="~/SiteOzserver.Master" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .repeater-ul {
            list-style-type: none; 
            padding: 0; 
            margin: 0; 
        }

        .repeater-li {
            line-height: 1.5; 
        }

        .repeater-li:nth-child(odd) {
            background-color: #f0f0f0; 
        }
    </style>

    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">User Info</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">User Info</li>
                        </ul>
                    </div>
                </div>
            </div>

            <asp:Repeater ID="repeaterData" runat="server">
                <ItemTemplate>
                    <ul class="repeater-ul">
                        <li class="repeater-li"><%# Container.DataItem %></li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>


