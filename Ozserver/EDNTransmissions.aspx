<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOzserver.Master" AutoEventWireup="true" CodeBehind="EDNtransmissions.aspx.cs" Inherits="Ozserver.EDNtransmissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">List of EDN Transmissions</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">EDN Transmission</li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- /Page Header -->
           
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body">
                                 <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>DpiId</th>
                                            <th>Version</th>
                                            <th>Sent Date/Time</th>
                                            <th>Received Date/Time</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #f2f2f2;" : "background-color: #ffffff;" %>'>
                                                    <td><%# Eval("Id") %></td>
                                                    <td><%# Eval("DpiId") %></td>
                                                    <td><%# Eval("Version") %></td>
                                                    <td><%# Eval("SDateTime", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                                    <td><%# Eval("RDateTime", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                                    <td><%# Eval("Status") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
               
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">View Messages</h4>
                    </div>
                    <div class="card-body" style="display: flex; justify-content: space-between;">
                        <button type="button" class="btn btn-rounded btn-outline-primary" style="padding: 10px 100px;">View EDI from EDNDOCS</button>
                        <button type="button" class="btn btn-rounded btn-outline-success" style="padding: 10px 100px;">View EDI to EDNDOCS</button>
                        <button type="button" class="btn btn-rounded btn-outline-dark" style="padding: 10px 100px;">View EDI from ICS</button>
                    </div>
                </div>
          
        </div>
    </div>
    </div>
</asp:Content>
