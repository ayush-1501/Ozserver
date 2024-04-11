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
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<a href="#" class="icon-link"><img src="images/transLC.bmp" alt="Your Image Alt Text"></a>
										<div class="dash-count">
											<h3>1168</h3>
										</div>
									</div>
									<div class="dash-widget-info">
										<h6 class="text-muted">EDN Transmission Today</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-primary w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<a href="#" class="icon-link"><img src="images/transLC.bmp" alt="Your Image Alt Text"></a>
										<div class="dash-count">
											<h3>487</h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">AQIS Transmission Today</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-success w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<a href="#" class="icon-link"><img src="images/transLC.bmp" alt="Your Image Alt Text"></a>
										<div class="dash-count">
											<h3>485</h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">PRA Transmission Today</h6>
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

</asp:Content>
