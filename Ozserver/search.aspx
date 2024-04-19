<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Ozserver.WebForm4" MasterPageFile="~/SiteOzserver.Master" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <% if (IsTransmissionFrom("EDN") ||IsTransmissionFrom("EDNSEARCH") )  { %>
            	<div class="page-wrapper">
    <div class="content container-fluid">
        <!-- Page Header -->
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">EDN</h3>
                    <ul class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                        <li class="breadcrumb-item active">EDN</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /Page Header -->

        <div class="text-center">
            <div class="col-lg-12 col-md-6 col-sm-3">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">DETAIL</h4>
                    </div>
                    <div class="card-body">
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">OfficeId:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="OfficeIdEDN" runat="server" placeholder="OfficeId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">EdndocsId:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="EdndocsId" runat="server" placeholder="EdndocsId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">SenderRef:</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="SenderRef" runat="server" placeholder="SenderRef" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Version</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="VersionEDN" runat="server" placeholder="Version" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">EDN</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="EDN1" runat="server" placeholder="EDN" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">PermitNo</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="StatusEDN" runat="server" placeholder="Status" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">SDateTime</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="SDateTimeEDN" runat="server" placeholder="SDateTime" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">RDateTime</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="RDateTimeEDN" runat="server" placeholder="RDateTime" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">ControlRef</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="ControlRef" runat="server" placeholder="ControlRef" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Acknowledge</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="Acknowledge" runat="server" placeholder="Acknowledge" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">StatusDesc</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="StatusDescEDN" runat="server" placeholder="StatusDesc" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">ReasonDesc</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="ReasonDesc" runat="server" placeholder="ReasonDesc" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">File_In_Name</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="File_In_NameEDN" runat="server" placeholder="File_In_Name" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">File_In_Content</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="File_In_ContentEDN" runat="server" placeholder="File_In_Content" readonly>
                                </div>
                            </div>
                               <div class="form-group row">
                                    <label class="col-lg-3 col-form-label">File_Out_Name</label>
                                    <div class="col-lg-9">
                                       <input type="text" class="form-control" id="File_Out_NameEDN" runat="server" placeholder="File_Out_Name" readonly>
                                    </div>
                                </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">File_Out_Content</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="File_Out_ContentEDN" runat="server" placeholder="File_Out_Content" readonly>
                                </div>
                            </div>
                     
                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label">IsNew</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="IsNewEDN" runat="server" placeholder="IsNew" readonly>
                            </div>
                        </div>
                         <div class="form-group row">
                             <label class="col-lg-3 col-form-label" for="Errors">Errors:</label>
                             <div class="col-lg-9">
                                 <textarea class="form-control" id="Textarea2" runat="server" readonly placeholder="All errors" rows="15"></textarea>
                             </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
         
      
     <% } %>
     <% if (IsTransmissionFrom("AQIS") ||IsTransmissionFrom("AQISSEARCH"))  { %>
        	<div class="page-wrapper">
    <div class="content container-fluid">
        <!-- Page Header -->
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">AQIS</h3>
                    <ul class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                        <li class="breadcrumb-item active">AQIS</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /Page Header -->

        <div class="text-center">
            <div class="col-lg-12 col-md-6 col-sm-3">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">DETAIL</h4>
                    </div>
                    <div class="card-body">
                        
                      
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">OfficeId:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="OfficeIdAQIS" runat="server" placeholder="OfficeId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">AQISId:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="AQISId" runat="server" placeholder="AQISId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">RFPNo:</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="RFPNo" runat="server" placeholder="RFPNo" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Version</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="VersionAQIS" runat="server" placeholder="Version" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Status</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="Status" runat="server" placeholder="Status" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">PermitNo</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="PermitNo" runat="server" placeholder="PermitNo" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">StatusDesc</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="StatusDescAQIS" runat="server" placeholder="StatusDesc" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">SDateTime</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="SDateTimeAQIS" runat="server" placeholder="SDateTime" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">RDateTime</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="RDateTimeAQIS" runat="server" placeholder="RDateTime" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Test</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="Test" runat="server" placeholder="Test" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">ContPage</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="ContPage" runat="server" placeholder="ContPage" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">ECN</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="ECN" runat="server" placeholder="ECN" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">File_In_Name</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="File_In_NameAQIS" runat="server" placeholder="File_In_Name" readonly>
                                </div>
                            </div>
                              <div class="form-group row">
                                <label class="col-lg-3 col-form-label">File_In_Content</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="File_In_ContentAQIS" runat="server" placeholder="File_In_Content" readonly>
                                </div>
                            </div>
                               <div class="form-group row">
                                    <label class="col-lg-3 col-form-label">File_Out_Name</label>
                                    <div class="col-lg-9">
                                       <input type="text" class="form-control" id="File_Out_NameAQIS" runat="server" placeholder="File_Out_Name" readonly>
                                    </div>
                                </div>
                             <div class="form-group row">
                                <label class="col-lg-3 col-form-label">File_Out_Content</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="File_Out_ContentAQIS" runat="server" placeholder="File_Out_Content" readonly>
                                </div>
                            </div>
                           <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Spare</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="Spare" runat="server" placeholder="Spare" readonly>
                                </div>
                            </div>
                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label">IsNew</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="IsNew" runat="server" placeholder="IsNew" readonly>
                            </div>
                        </div>
                         <div class="form-group row">
                             <label class="col-lg-3 col-form-label" for="Errors">Errors:</label>
                             <div class="col-lg-9">
                                 <textarea class="form-control" id="Textarea1" runat="server" readonly placeholder="All errors" rows="15"></textarea>
                             </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
    
 
    <% } %>
     <% if (IsTransmissionFrom("PRA") ||IsTransmissionFrom("PRASEARCH"))  { %>
     	<div class="page-wrapper">
    <div class="content container-fluid">
        <!-- Page Header -->
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">PRA</h3>
                    <ul class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                        <li class="breadcrumb-item active">PRA</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /Page Header -->

        <div class="text-center">
            <div class="col-lg-12 col-md-6 col-sm-3">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">DETAIL</h4>
                    </div>
                    <div class="card-body">
                        
                      
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">OfficeId:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="OfficeIdPRA" runat="server" placeholder="OfficeId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">PradocsId:</label>
                                <div class="col-lg-9">
                                    <input type="text" class="form-control" id="PradocsId" runat="server" placeholder="PradocsId" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">ShippersRef:</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="ShippersRef" runat="server" placeholder="ShippersRef" readonly>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label">Version</label>
                                <div class="col-lg-9">
                                   <input type="text" class="form-control" id="VersionPRA" runat="server" placeholder="Version" readonly>
                                </div>
                            </div>
                             <div class="form-group row">
                               <label class="col-lg-3 col-form-label">SDateTime</label>
                               <div class="col-lg-9">
                                  <input type="text" class="form-control" id="SDateTime" runat="server" placeholder="SDateTime" readonly>
                               </div>
                           </div>
                            <div class="form-group row">
                               <label class="col-lg-3 col-form-label">RDateTime</label>
                               <div class="col-lg-9">
                                  <input type="text" class="form-control" id="RDateTime" runat="server" placeholder="RDateTime" readonly>
                               </div>
                           </div>
                            <div class="form-group row">
                               <label class="col-lg-3 col-form-label">StatusDesc</label>
                               <div class="col-lg-9">
                                  <input type="text" class="form-control" id="StatusDesc" runat="server" placeholder="StatusDesc" readonly>
                               </div>
                           </div>
                            <div class="form-group row">
                               <label class="col-lg-3 col-form-label">OneStopRef</label>
                               <div class="col-lg-9">
                                  <input type="text" class="form-control" id="OneStopRef" runat="server" placeholder="OneStopRef" readonly>
                               </div>
                           </div>
                            <div class="form-group row">
                               <label class="col-lg-3 col-form-label">LastVersion</label>
                               <div class="col-lg-9">
                                  <input type="text" class="form-control" id="LastVersion" runat="server" placeholder="LastVersion" readonly>
                               </div>
                           </div>
                           <div class="form-group row">
                               <label class="col-lg-3 col-form-label">ContainerNo</label>
                               <div class="col-lg-9">
                                  <input type="text" class="form-control" id="ContainerNo" runat="server" placeholder="ContainerNo" readonly>
                               </div>
                           </div>
                          <div class="form-group row">
                            <label class="col-lg-3 col-form-label">ContainerNo</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="Text5" runat="server" placeholder="ContainerNo" readonly>
                            </div>
                        </div>
                          <div class="form-group row">
                            <label class="col-lg-3 col-form-label">SentType</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="SentType" runat="server" placeholder="SentType" readonly>
                            </div>
                        </div>
                      
                          <div class="form-group row">
                            <label class="col-lg-3 col-form-label">File_In_Name</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="File_In_Name" runat="server" placeholder="File_In_Name" readonly>
                            </div>
                        </div>
                          <div class="form-group row">
                            <label class="col-lg-3 col-form-label">File_In_Content</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="File_In_Content" runat="server" placeholder="File_In_Content" readonly>
                            </div>
                        </div>
                          <div class="form-group row">
                            <label class="col-lg-3 col-form-label">File_Out_Name</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="File_Out_Name" runat="server" placeholder="File_Out_Name" readonly>
                            </div>
                        </div>
                          <div class="form-group row">
                            <label class="col-lg-3 col-form-label">File_Out_Content</label>
                            <div class="col-lg-9">
                               <input type="text" class="form-control" id="File_Out_Content" runat="server" placeholder="File_Out_Content" readonly>
                            </div>
                        </div>
                          <div class="form-group row">
                          <label class="col-lg-3 col-form-label" for="Errors">Errors:</label>
                          <div class="col-lg-9">
                              <textarea class="form-control" id="Errors" runat="server" readonly placeholder="All errors" rows="15"></textarea>
                          </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
    
 
    <% } %>
     <% if (IsTransmissionFrom("MASTER") ||IsTransmissionFrom("MASTERSEARCH"))  { %>
     <div class="page-wrapper">
    <div class="content container-fluid">
        <!-- Page Header -->
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">MASTER</h3>
                    <ul class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                        <li class="breadcrumb-item active">MASTER</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /Page Header -->

        <div class="text-center">
            <div class="col-lg-12 col-md-6 col-sm-3">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">DETAIL</h4>
                    </div>
                    <div class="card-body">
                        <!-- Start of two-column layout -->
                        <div class="form-row">
                            <!-- First column -->
                            <div class="col-lg-6">
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">DocumentId:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="DocumentId" runat="server" placeholder="DocumentId" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">ReferenceId:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="ReferenceId" runat="server" placeholder="ReferenceId" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Office ID:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="OfficeId" runat="server" placeholder="OfficeId" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Version:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="Version" runat="server" placeholder="Version" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Exporter:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="Exporter" runat="server" placeholder="Exporter" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Consignee:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="Consignee" runat="server" placeholder="Consignee" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Buyer:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="Buyer" runat="server" placeholder="Buyer" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">InvoiceValue:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="InvoiceValue" runat="server" placeholder="InvoiceValue" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Currency:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="Currency" runat="server" placeholder="Currency" readonly>
                                    </div>
                                </div>
                            </div>
                            <!-- Second column -->
                            <div class="col-lg-6">
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">InvoiceNo:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="InvoiceNo" runat="server" placeholder="InvoiceNo" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">InvoiceDate:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="InvoiceDate" runat="server" placeholder="InvoiceDate" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">DocumentStatus:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="DocumentStatus" runat="server" placeholder="DocumentStatus" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">EDNStatus:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="EDNStatus" runat="server" placeholder="EDNStatus" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">EDN:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="EDN" runat="server" placeholder="EDN" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">Details:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="Details" runat="server" placeholder="Details" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">ExporterRef:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="ExporterRef" runat="server" placeholder="ExporterRef" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">BuyerRef:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="BuyerRef" runat="server" placeholder="BuyerRef" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">MUserId:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="MUserId" runat="server" placeholder="MUserId" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">CreationDate:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="CreationDate" runat="server" placeholder="CreationDate" readonly>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-lg-4 col-form-label">RevisionDate:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="RevisionDate" runat="server" placeholder="RevisionDate" readonly>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End of two-column layout -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

 
<% } %>
  

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


