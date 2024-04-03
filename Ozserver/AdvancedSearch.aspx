﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOzserver.Master" AutoEventWireup="true" CodeBehind="AdvancedSearch.aspx.cs" Inherits="Ozserver.WebForm2" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Please Select The Criteria</h3>
                    </div>
                </div>
            </div>
            <!--Page Header-->
           
              <% if (IsTransmissionFrom("EDN"))  { %>
         <div class="text-center">
             <div class="col-lg-12 col-md-6 col-sm-3">
                 <div class="card">
                     <div class="card-header">
                         <h4 class="card-title">All Transaction </h4>
                     </div>
                     <div class="card-body">
                         <form action="#">
                             <div class="form-group row">
                                 <label class="col-form-label col-md-2">By Date</label>
                                 <div class="col-md-10">
                                     <input type="text" class="form-control" placeholder="From Date...">
                                     <input type="text" class="form-control" placeholder="To Date...">
                                 </div>
                             </div>
                             <div class="form-group row">
                                 <label class="col-form-label col-md-2">Ref Id</label>
                                 <div class="col-md-10">
                                     <input type="text" class="form-control">
                                 </div>
                             </div>
                             <div class="form-group row">
                                 <label class="col-form-label col-md-2">EDN</label>
                                 <div class="col-md-10">
                                     <input type="text" class="form-control">
                                 </div>
                             </div>
                         </form>
                     </div>
                     <div>
                           
                              <div class="card-footer">
                                  <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_Click1" CausesValidation="False" />
                              </div>
                          
                     </div>
                 </div>
             </div>
         </div>

   <% } %>
   <% if (IsTransmissionFrom("AQIS"))  { %>
             <div class="text-center">
    <div class="col-lg-12 col-md-6 col-sm-3">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">All Transaction </h4>
            </div>
            <div class="card-body">
                <form action="#">
                    <div class="form-group row">
                        <label class="col-form-label col-md-2">By Date</label>
                        <div class="col-md-10">
                            <input type="text" class="form-control" placeholder="From Date...">
                            <input type="text" class="form-control" placeholder="To Date...">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-form-label col-md-2">Document Id</label>
                        <div class="col-md-10">
                            <input type="text" class="form-control">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-form-label col-md-2">Document Ref</label>
                        <div class="col-md-10">
                            <input type="text" class="form-control">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-form-label col-md-2">REP</label>
                        <div class="col-md-10">
                            <input type="text" class="form-control">
                        </div>
                    </div>
                  
                   
                    <div>
                  
                          <div class="card-footer">
                              <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_Click1" CausesValidation="False" />
                          </div>
                   
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

   <% } %>
   <% if (IsTransmissionFrom("PRA"))  { %>
                    
      
     <div class="text-center">
         <div class="col-lg-12 col-md-6 col-sm-3">
             <div class="card">
                 <div class="card-header">
                     <h4 class="card-title">All Transaction </h4>
                 </div>
                 <div class="card-body">
                     <div class="form-group row">
                         <label class="col-form-label col-md-2">By Date</label>
                         <div class="col-md-10">
                             <input type="text" class="form-control" placeholder="From Date..." id="FromDateTextBox" runat="server">
                             <input type="text" class="form-control" placeholder="To Date..." id="ToDateTextBox" runat="server">
                         </div>
                     </div>
                     <div class="form-group row">
                         <label class="col-form-label col-md-2">Ref Id</label>
                         <div class="col-md-10">
                             <input type="text" class="form-control" id="RefIdTextBox" runat="server">
                         </div>
                     </div>
                     <div class="form-group row">
                         <label class="col-form-label col-md-2">Container No</label>
                         <div class="col-md-10">
                             <input type="text" class="form-control" id="ContainerNoTextBox" runat="server">
                         </div>
                     </div>
                 </div>
                 <div class="card-footer">
                     <asp:Button ID="SearchButton" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_Click1" />
                 </div>
             </div>
         </div>
     </div>

   <% } %>
        </div>
    </div>
</asp:Content>



