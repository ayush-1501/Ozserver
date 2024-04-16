﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organisation.aspx.cs" Inherits="Ozserver.WebForm5" MasterPageFile="~/SiteOzserver.Master" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Organization</h3>
                       
                    </div>
                </div>
            </div>
            <!-- Page Header -->
                
            <div class="text-center">
                <div class="col-lg-12 col-md-6 col-sm-3">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">UPDATE</h4>
                        </div>
                           <% if (IsTransmissionFrom("ORGANISATION")) { %>
                                  <div class="card-body">
                                            <div class="form-group row">
                                                <label class="col-form-label col-md-2">Office Id</label>
                                                <div class="col-md-10">
                                                    <input type="text" class="form-control" id="OfficeId" runat="server" placeholder="Office Id" readonly>
                                                </div>
                                            </div>
                                        </div>

                                  <% } else { %>
                                     <div class="card-body">
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">Office Id</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="OfficeId1" runat="server" placeholder="Office Id">
                                            </div>
                                        </div>
                                  <% } %>
                        
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">Company Name</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="CompanyName" runat="server" placeholder="Company Name">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">Email Address</label>
                                <div class="col-md-10">
                                    <input type="email" class="form-control" id="EmailAddress" runat="server" placeholder="Email Address">
                                </div>
                            </div>
                        </div>
                         <!-- Add Label control for error messages -->
                            <% if (IsTransmissionFrom("ORGANISATION")) { %>
                               <asp:Label ID="Label1" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                    <div>
                                        <div class="card-footer">
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="UPDATE" OnClick="btn_ClickUPDATE" CausesValidation="False" />
                                        </div>
                                    </div>
                                </div>

                        

                             <% } else { %>
                                   <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                    <div>
                                        <div class="card-footer">
                                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Text="ADD" OnClick="btnLogin_Click" CausesValidation="False" />
                                        </div>
                                    </div>
                                </div>
                             <% } %>
                       
                </div>
            </div>
        </div>
    </div>
</asp:Content>
