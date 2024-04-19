<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Ozserver.WebForm6" MasterPageFile="~/SiteOzserver.Master" EnableViewState="false" %>




<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" EnablePageMethods="true">
      <asp:HiddenField ID="HiddenErrorMessage" runat="server" />
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            	<div class="page-header">
			<div class="row">
				<div class="col-sm-12">
					<h3 class="page-title">USER</h3>
					<ul class="breadcrumb">
                         <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
						<li class="breadcrumb-item active">USER</li>
					</ul>
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
                                                <option value="ANZCO5">ANZCO5</option>
                                                <option value="ANZCO">ANZCO</option>
                                                <option value="ANZCO1">ANZCO8</option>
                                                <option value="ANZCO3">ANZCO9</option>
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
                      
                         <% if (IsTransmissionFrom("USER")){ %>
                                
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
                                                        <asp:button runat="server" Text="ADD" Cssclass="btn btn-primary" Onclick="btn_ClickADD"/>
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
    
    <script>
        function showErrorPopup() {
            // Get the error message from the hidden field
            var errorMessage = document.getElementById('<%= HiddenErrorMessage.ClientID %>').value;

            // If there is an error message, display it in a JavaScript alert
            if (errorMessage) {
                alert(errorMessage);
            }
        }

        // Call the function when the page loads
        window.onload = function () {
            showErrorPopup();
        };
    </script>
              

         

</asp:Content>
