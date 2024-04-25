<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/SiteOzserver.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Ozserver.Dashboard" %>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
							
	
    <div class="page-wrapper">
			
                <div class="content container-fluid">
					
					<!-- Page Header -->
					<div class="page-header">
						<div class="row">
							<div class="col-sm-12">
								<h3 class="page-title">Welcome Admin!</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item active">Dashboard</li>
								</ul>
							</div>
						</div>
					</div>
					<div class="row">
						<div id="cardContainer1" class="col-xl-3 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<i class="fe fe-document"></i>
										<div class="dash-count">
											<asp:Label ID="lbl4Message" runat="server"></asp:Label>
										</div>
									</div>
									<div class="dash-widget-info">
										<h6 class="text-muted">Today's MASTER Transmission</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-primary w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div id="cardContainer2" class="col-xl-3 col-sm-6 col-12" >
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<i class="fe fe-document"></i>
										<div class="dash-count">
											<asp:Label ID="lbl1Message" runat="server"></asp:Label>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Today's EDN Transmission</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-success w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div id="cardContainer3" class="col-xl-3 col-sm-6 col-12">
						<div class="card">
							<div class="card-body">
								<div class="dash-widget-header">
									<i class="fe fe-document"></i>
									<div class="dash-count">
										<asp:Label ID="lbl3Message" runat="server"></asp:Label>
									</div>
								</div>
								<div class="dash-widget-info">
							
									<h6 class="text-muted">Today's AQIS Transmission</h6>
									<div class="progress progress-sm">
										<div class="progress-bar bg-success w-50"></div>
									</div>
								</div>
							</div>
						</div>
		             </div>
						<div id="cardContainer4" class="col-xl-3 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<i class="fe fe-document"></i>
										<div class="dash-count">
											<asp:Label ID="lbl2Message" runat="server"></asp:Label>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Today's PRA Transmission</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-dark w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>
						
					</div>
					
									 
                     
				</div>			
			</div>
	<script>
        document.addEventListener("DOMContentLoaded", function () {
            var cardContainer2 = document.getElementById("cardContainer1");
            if (cardContainer2) {
                cardContainer2.addEventListener("click", function () {
                    window.location.href = 'DocumentList.aspx?context=MASTER';
                });
            }
        });

        document.addEventListener("DOMContentLoaded", function () {
            var cardContainer = document.getElementById("cardContainer2");
            if (cardContainer) {
                cardContainer.addEventListener("click", function () {
                    window.location.href = 'DocumentList.aspx?context=EDN';
                });
            }
		});
        document.addEventListener("DOMContentLoaded", function () {
            var cardContainer = document.getElementById("cardContainer3");
            if (cardContainer) {
                cardContainer.addEventListener("click", function () {
                    window.location.href = 'DocumentList.aspx?context=AQIS';
                });
            }
		});
        document.addEventListener("DOMContentLoaded", function () {
            var cardContainer = document.getElementById("cardContainer4");
            if (cardContainer) {
                cardContainer.addEventListener("click", function () {
                    window.location.href = 'DocumentList.aspx?context=PRA';
                });
            }
        });
    </script>
</asp:Content>
