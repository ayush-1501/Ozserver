﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Ozserver.WebForm6" MasterPageFile="~/SiteOzserver.Master" EnableViewState="false" %>



<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">USER</h3>
                    </div>
                </div>
            </div>
            <!-- Page Header -->
                
            <div class="text-center">
                <div class="col-lg-12 col-md-6 col-sm-3">
                    <div class="card">
                        <div class="card-header">
                          
                              <% if (IsTransmissionFrom("USER")) { %>
                                   <h4 class="card-title">UPDATE</h4>

                             <% } else { %>
                                     <h4 class="card-title">ADD</h4>
                             <% } %>
                        </div>
                        <div class="card-body">
                             <% if (IsTransmissionFrom("USER")) { %>
                                 <div class="form-group row">
                                        <label class="col-form-label col-md-2" for="OrgName">Organisation Name</label>
                                        <div class="col-md-10">
                                            <select class="form-control" id="OrgName" runat="server" data-selected-value="<%# OrgNameValue %>">
                                                <option value="ANZCO">ANZCO</option>
                                                <option value="ANZCO1">ANZCO1</option>
                                                <option value="ANZCO2">ANZCO2</option>
                                                <option value="ANZCO3">ANZCO3</option>
                                            </select>
                                        </div>
                                    </div>


                                <% } else { %>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2" for="OrgName">Organisation Name</label>
                                        <div class="col-md-10">
                                            <select class="form-control" id="Select1" runat="server">
                                                <option value="">Select an Organisation</option>
                                                <option value="user1">ANZCO</option>
                                                <option value="user2">User 2</option>
                                                <option value="user3">User 3</option>
                                            </select>
                                        </div>
                                    </div>
                                <% } %>

                         

                           
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">User Id</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="UserId" runat="server" placeholder="UserId">
                                </div>
                            </div>
                             <div class="form-group row">
                                 <label class="col-form-label col-md-2">Password</label>
                                 <div class="col-md-10">
                                     <input type="text" class="form-control" id="Password" runat="server" placeholder="Password">
                                 </div>
                             </div>
                        </div>
                         <% if (IsTransmissionFrom("USER")) { %>
                                 <div>
                                    <div class="card-footer">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="UPDATE" OnClick="btn_ClickUPDATE" CausesValidation="False" />
                                    </div>
                                </div>

                            <% } else { %>
                                   <div>
                                     <div class="card-footer">
                                         <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Text="ADD" OnClick="btn_ClickADD" CausesValidation="False" />
                                     </div>
                                 </div>
                            <% } %>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
