<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organisation.aspx.cs" Inherits="Ozserver.WebForm5" MasterPageFile="~/SiteOzserver.Master" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
           	<div class="page-header">
					<div class="row">
						<div class="col-sm-12">
							<h3 class="page-title">ORGANISATION</h3>
							<ul class="breadcrumb">
                                 <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
								<li class="breadcrumb-item active">ORGANISATION</li>
							</ul>
						</div>
					</div>
				</div>
            <!-- Page Header -->
                
            <div class="text-center">
                <div class="col-lg-12 col-md-6 col-sm-3">
                    <div class="card">
                       <div class="card-header">
  
                          <% if (IsTransmissionFrom("ORGANISATION")) { %>
                               <h4 class="card-title">UPDATE</h4>

                         <% } else { %>
                                 <h4 class="card-title">ADD</h4>
                         <% } %>
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
                      
                         <!-- Add Label control for error messages -->
                            <% if (IsTransmissionFrom("ORGANISATION")) { %>
                              
                           <div>
                               
                            <div class=" text-center"> 
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
                                    UPDATE
                                </button>

                                <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header text-center"> 
                                                <h5 class="modal-title font-weight-bold" id="exampleModalCenterTitle">UPDATE</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                Are you sure you want to UPDATE?
                                            </div>
                                            <div class="modal-footer justify-content-center"> 
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button> 
                                               <asp:button runat="server" Text="UPDATE" Cssclass="btn btn-primary" Onclick="btn_ClickUPDATE"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
     
                    <% } else{ %>
                         <div>
                               
                            <div class=" text-center"> 
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
                                    ADD
                                </button>

           

                                <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header text-center"> 
                                                <h5 class="modal-title font-weight-bold" id="exampleModalCenterTitle">ADD</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                Are you sure you want to ADD?
                                            </div>
                                            <div class="modal-footer justify-content-center"> 
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button> 
                                                <asp:button runat="server" Text="ADD" Cssclass="btn btn-primary" Onclick="btnADD_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                       <% } %>    
                       
                </div>
            </div>
          </div>
        </div>
  
</asp:Content>
