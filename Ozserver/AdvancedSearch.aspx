<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOzserver.Master" AutoEventWireup="true" CodeBehind="AdvancedSearch.aspx.cs" Inherits="Ozserver.WebForm2" %>

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
                 <% if (IsTransmissionFrom("MASTER"))  { %>
        
                          <div class="text-center">
                            <div class="col-lg-12 col-md-6 col-sm-3">
                                <div class="card">
                                    <div class="card-header">
                                        <h4 class="card-title">All Transaction</h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">From Date</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="FromDate" runat="server" placeholder="From Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">To Date</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="ToDate" runat="server" placeholder="To Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">Doc Id</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="DocId" runat="server" placeholder="Doc Id">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">Invoice No</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="InvoiceNo" runat="server" placeholder="Invoice No">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">Invoice From Date</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="FromDateInvoice" runat="server" placeholder=" From Date..." onfocus="(this.type='date')" onblur="(this.type='text')">

                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">Invoice To Date</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="ToDateInvoice" runat="server" placeholder="  To Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">Exporter</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="Exporter" runat="server" placeholder="Exporter">
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-2">EDN No</label>
                                            <div class="col-md-10">
                                                <input type="text" class="form-control" id="EDNNo" runat="server" placeholder="EDN No">
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div class="card-footer">
                                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_ClickMASTER" CausesValidation="False" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                     
                 <% } %>
              <% if (IsTransmissionFrom("EDN"))  { %>
                    <div class="text-center">
                        <div class="col-lg-12 col-md-6 col-sm-3">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">All Transaction</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2">From Date</label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="FromDateTextBoxEDN" runat="server" placeholder="From Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2">To Date</label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="ToDateTextBoxEDN" runat="server" placeholder="To Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2">Sender ref</label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="SenderRefTextBox" runat="server" placeholder="Sender ref">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2">EDN</label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="EDNTextBox" runat="server" placeholder="EDN">
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <div class="card-footer">
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_ClickEDN" CausesValidation="False" />
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
                                <h4 class="card-title">All Transaction</h4>
                            </div>
                            <div class="card-body">
                                <div class="form-group row">
                                    <label class="col-form-label col-md-2">From Date</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" id="FromDateTextBoxAQIS" runat="server" placeholder="From Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-2">To Date</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" id="ToDateTextBoxAQIS" runat="server" placeholder="To Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-2">AQIS Id</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" id="AQISIdTextBox" runat="server" placeholder="AQIS Id">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-2">RFP No</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" id="RfpNoTextBox" runat="server" placeholder="RFP No">
                                    </div>
                                </div>
                            </div>
                            <div>
                                <div class="card-footer">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_ClickAQIS" CausesValidation="False" />
                                </div>
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
                            <h4 class="card-title">All Transaction</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">From Date</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="FromDateTextBoxPRA" runat="server" placeholder="From Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">To Date</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="ToDateTextBoxPRA" runat="server" placeholder="To Date..." onfocus="(this.type='date')" onblur="(this.type='text')">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">1-Stop Ref</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="StopRefTextBox" runat="server" placeholder="1-Stop Ref">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-form-label col-md-2">Shipper Ref</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="ShipperRefTextBox" runat="server" placeholder="Shipper Ref">
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="card-footer">
                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnLogin_ClickPRA" CausesValidation="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

               <% } %>
        </div>
    </div>
        <div class="card">
             <div class="card-header">
        
             </div>
    
         </div>
        </div>
      <style>
      /* Custom CSS for form alignment */
       .form-group {
           margin-bottom: 15px; /* Add margin for spacing between rows */
       }

       /* Align text within label to the left */
       .col-form-label {
           text-align: left;
       }

       /* Ensure input elements stretch across their columns and are aligned consistently */
       .form-control {
           width: 100%; /* Make inputs span the full width of the column */
       }

  </style>
</asp:Content>



