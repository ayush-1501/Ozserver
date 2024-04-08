<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteOzserver.Master" CodeBehind="DocumentList.aspx.cs" Inherits="Example.WebForm7" EnableEventValidation="false"%>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                      <div class="col-sm-12">
                          
                          <% if (IsTransmissionFrom("EDN")) { %>
                                   <h3 class="page-title">List of EDN Transmissions</h3>
                              <% } %>
                            <% if (IsTransmissionFrom("PRA")) { %>
                                   <h3 class="page-title">List of PRA Transmissions</h3>
                             <% } %> 
                            <% if (IsTransmissionFrom("AQIS")) { %>
                                    <h3 class="page-title">List of AQIS Transmissions</h3>
                             <% } %>
                          <ul class="breadcrumb">
                              <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                               <% if (IsTransmissionFrom("EDN")) { %>
                                      <li class="breadcrumb-item active">EDN Document</li>
                                 <% } %>
                               <% if (IsTransmissionFrom("PRA")) { %>
                                       <li class="breadcrumb-item active">PRA Document</li>
                                <% } %> 
                               <% if (IsTransmissionFrom("AQIS")) { %>
                                        <li class="breadcrumb-item active">AQIS Document</li>
                                <% } %>
                          </ul>
                      </div>
                    <div class="col-sm-12">
                        <h6 class='></h6>
                    </div>
                </div>
            </div>

            <asp:ScriptManager ID="MainScriptManager" runat="server" />
            <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:Repeater ID="rptResult" runat="server">
                            <HeaderTemplate>
                               <table class="table">
                                   <tr style="background-color: #d3d3d3;">
                                        <th>ID</th>
                                              <% if (Role == "Admin") { %>
                                                <th>Office Id</th>
                                            <% } %>
                                          <% if (IsTransmissionFrom("EDN")) { %>
                                                 <th>Sender Ref</th>
                                            <% } %>
                                          <% if (IsTransmissionFrom("PRA")) { %>
                                                  <th>1-Stop Ref</th>
                                                 
                                           <% } %> 
                                          <% if (IsTransmissionFrom("AQIS")) { %>
                                                    <th>AQIS Id</th>
                                           <% } %>
                                        <th>Version</th>
                                        <th>Send Date/Time</th>
                                        <% if (IsTransmissionFrom("EDN")) { %>
                                               <th>EDN</th>
                                          <% } %>
                                        <% if (IsTransmissionFrom("PRA")) { %>
                                                <th>Shipper Ref</th>
                                         <% } %> 
                                        <% if (IsTransmissionFrom("AQIS")) { %>
                                                  <th>Permit No</th>
                                                  <th>RFP No</th>
                                         <% } %>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Id") %></td>
                                       <% if (Role == "Admin") { %>
                                              <td><%# Eval("OfficeId") %></td>
                                        <% } %>
                                     <% if (IsTransmissionFrom("EDN")) { %>
                                             <td><%# Eval("senderRef") %></td>
                                       <% } %>
                                     <% if (IsTransmissionFrom("PRA")) { %>
                                             
                                             <td><%# Eval("shippersRef") %></td>
                                            
                                      <% } %> 
                                     <% if (IsTransmissionFrom("AQIS")) { %>
                                               <td><%# Eval("aqisId") %></td>
                                             
                                      <% } %>
                                    <td><%# Eval("Version") %></td>
                                    <td><%# Eval("SDateTime", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                       <% if (IsTransmissionFrom("EDN")) { %>
                                              <td><%# Eval("EDN") %></td>
                                        <% } %>
                                      <% if (IsTransmissionFrom("PRA")) { %>
                                              <td><%# Eval("oneStopRef") %></td>
                                            
                                       <% } %> 
                                      <% if (IsTransmissionFrom("AQIS")) { %>
                                                <td><%# Eval("permitNo") %></td>
                                                 <td><%# Eval("rfpNo") %></td>
                                       <% } %>
                                    <td><%# Eval("Status") %></td>

                                   <td>
                                    <a href="search.aspx">
                                          <i class="fa fa-info" style="color: #1b5a90;"></i> 
                                    </a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                   <div>
                        <table class="table table-bordered">
                            <tr>
                                <td class="text-center">
                                    <asp:LinkButton ID="lbFirst" runat="server" OnClick="lbFirst_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">First</asp:LinkButton>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="lbPrevious" runat="server" OnClick="lbPrevious_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">Previous</asp:LinkButton>
                                </td>
                                <td class="text-center" style="display: flex; justify-content: center;">
                                    <asp:DataList ID="rptPaging" runat="server"
                                        OnItemCommand="rptPaging_ItemCommand"
                                        OnItemDataBound="rptPaging_ItemDataBound" 
                                        RepeatDirection="Horizontal">
                                       <ItemTemplate>
                                            <asp:LinkButton ID="lbPaging" runat="server"
                                                CommandArgument='<%# Eval("PageIndex") %>' 
                                                CommandName="newPage"
                                                Text='<%# Eval("PageText") %>' Width="40px"
                                                CssClass="btn"
                                                style='<%# Convert.ToInt32(Eval("PageIndex")) == CurrentPage ? "background-color: #00d0f1; color: white;" : "background-color: #1b5a90; color: white;" %>'
                                                onmouseover="changeColor(this, '#00d0f1')" 
                                            onmouseout='<%# GenerateMouseOutScript(Convert.ToInt32(Eval("PageIndex"))) %>'>
   

                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">Next</asp:LinkButton>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="lbLast" runat="server" OnClick="lbLast_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">Last</asp:LinkButton>
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <script>
                        // Function to change button color
                        function changeColor(element, color) {
                            element.style.backgroundColor = color;
                        }

                        // Add event listener for click event to handle button clicks
                        document.addEventListener('click', function (event) {
                            if (event.target.classList.contains('btn')) {
                                changeColor(event.target, '#00d0f1');
                            }
                        });
                    </script>

                </ContentTemplate>
            </asp:UpdatePanel>
             <div class="card">
             <div class="card-header">
                 <h4 class="card-title">View Messages</h4>
             </div>
             <div class="card-body" style="display: flex; justify-content: space-between;">
                 <button type="button" class="btn btn-rounded btn-outline-primary" style="padding: 10px 100px;">View EDI from EDNDOCS</button>
                 <button type="button" class="btn btn-rounded btn-outline-success" style="padding: 10px 100px;">View EDI to EDNDOCS</button>
                 <button type="button" class="btn btn-rounded btn-outline-dark" style="padding: 10px 100px;">View EDI from ICS</button>
             </div>
         </div>
        </div>
    </div>
</asp:Content>



 