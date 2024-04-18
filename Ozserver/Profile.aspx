<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Ozserver.WebForm1"  MasterPageFile="~/SiteOzserver.Master"  %>


<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="page-wrapper">
    <div class="content container-fluid">
        <!-- Page Header -->
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">PROFILE</h3>
                    <ul class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                        <li class="breadcrumb-item active">PROFILE</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /Page Header -->

        <div class="text-center">
            <div class="col-lg-12 col-md-6 col-sm-3">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">PROFILE</h4>
                    </div>
                    <div class="card-body">
                        
                      
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">UserName:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="UserIdControl" runat="server" placeholder="UserId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Organization ID:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="OrgIdControl" runat="server" placeholder="UserId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Office ID:</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="OfficeIdControl" runat="server" placeholder="OfficeId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Email Address</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="EmailAddress" runat="server" placeholder="EmailAddress" readonly>
                                </div>
                            </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Styles to adjust alignment and form spacing -->
<style>
    /* Form group styling */
    .form-group {
        margin-bottom: 15px;
        display: flex;
        flex-direction: row;
    }

    /* Label styling */
    .col-form-label {
        width: 30%; /* Adjust this value for the label's width */
        text-align: left; /* Align the labels to the left */
    }

    /* Form control styling */
    .form-control {
        width: 70%; /* Adjust this value for the input's width */
    }
</style>

</asp:Content>
