<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteOzserver.Master" CodeBehind="DocumentList.aspx.cs" Inherits="Example.WebForm7" EnableEventValidation="false"%>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    
    <div class="page-wrapper">
        <div class="content container-fluid">
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                      <div class="col-sm-12">
                          
                          <% if (IsTransmissionFrom("EDN") || IsTransmissionFrom("EDNSEARCH") ) { %>
                                   <h3 class="page-title">List of EDN Transmissions</h3>
                              <% } %>
                            <% if (IsTransmissionFrom("PRA") || IsTransmissionFrom("PRASEARCH")) { %>
                                   <h3 class="page-title">List of PRA Transmissions</h3>
                             <% } %> 
                            <% if (IsTransmissionFrom("AQIS") || IsTransmissionFrom("AQISSEARCH")) { %>
                                    <h3 class="page-title">List of AQIS Transmissions</h3>
                             <% } %>
                              <% if (IsTransmissionFrom("MASTER") || IsTransmissionFrom("MASTERSEARCH")) { %>
                                     <h3 class="page-title">MASTER Document</h3>
                              <% } %>
                           <% if (IsTransmissionFrom("USER")) { %>
                              <h3 class="page-title">List of Users </h3>

                         <% } %>
                            <% if (IsTransmissionFrom("ORGANISATION")) { %>
                                 <h3 class="page-title">ORGANISATION LIST</h3>
                            <% } %>
                          <ul class="breadcrumb">
                              <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                               <% if (IsTransmissionFrom("EDN") || IsTransmissionFrom("EDNSEARCH")) { %>
                                      <li class="breadcrumb-item active">EDN Document</li>
                                 <% } %>
                               <% if (IsTransmissionFrom("PRA") || IsTransmissionFrom("PRASEARCH")) { %>
                                       <li class="breadcrumb-item active">PRA Document</li>
                                <% } %> 
                               <% if (IsTransmissionFrom("AQIS") || IsTransmissionFrom("AQISSEARCH")) { %>
                                        <li class="breadcrumb-item active">AQIS Document</li>
                                <% } %>
                                <% if (IsTransmissionFrom("MASTER") || IsTransmissionFrom("MASTERSEARCH")) { %>
                                         <li class="breadcrumb-item active">MASTER Document</li>
                                  <% } %>
                                <% if (IsTransmissionFrom("USER")) { %>
                                     <li class="breadcrumb-item active">USERS</li>
                                <% } %>
                                <% if (IsTransmissionFrom("ORGANISATION")) { %>
                                   <li class="breadcrumb-item active">ORGANISATION</li>
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
                                        <%  if (IsTransmissionFrom("MASTER") || IsTransmissionFrom("MASTERSEARCH")) { %>
                                               <th>ID</th>
                                                  <% if (Role == "Admin") { %>
                                                        <th>Office Id</th>
                                                   <% } %>
                                                 <th>Version</th>
                                                 <th>Invoice No</th>
                                                 <th>Invoice Date</th>
                                                 <th>Exporter</th>
                                                 <th>Invoice Value</th>
                                                 <th>Document Status</th>
                                                 <th>EDN</th>
                                                <th>View</th>
                                        <% } %>
                                           <% else if (IsTransmissionFrom("USER")){%>
                                                <th>Id</th>     
                                                <th>OrgId</th>  
                                                <th>UserId</th>     
                                                <th>Password</th>   
                                                <th>Update</th>
                                        <% }%>
                                          <% else if (IsTransmissionFrom("ORGANISATION")){%>
                                                <th>OfficeId</th>   
                                                <th>CompanyName</th>    
                                                <th>Email_Address</th>
                                                 <th>Update</th>
                                        <% }%>
                                       <% else{ %>
                                          <th>ID</th>
                                                  <% if (Role == "Admin") { %>
                                                    <th>Office Id</th>
                                                <% } %>
                                              <% if (IsTransmissionFrom("EDN") || IsTransmissionFrom("EDNSEARCH")) { %>
                                                     <th>Sender Ref</th>
                                                <% } %>
                                              <% if (IsTransmissionFrom("PRA") || IsTransmissionFrom("PRASEARCH") ) { %>
                                                      <th>1-Stop Ref</th>
         
                                               <% } %> 
                                              <% if (IsTransmissionFrom("AQIS") || IsTransmissionFrom("AQISSEARCH")) { %>
                                                        <th>AQIS Id</th>
                                               <% } %>
                                            <th>Version</th>
                                            <th>Send Date/Time</th>
                                            <% if (IsTransmissionFrom("EDN") || IsTransmissionFrom("EDNSEARCH")) { %>
                                                   <th>EDN</th>
                                              <% } %>
                                            <% if (IsTransmissionFrom("PRA") || IsTransmissionFrom("PRASEARCH")) { %>
                                                    <th>Shipper Ref</th>
                                             <% } %> 
                                            <% if (IsTransmissionFrom("AQIS") || IsTransmissionFrom("AQISSEARCH")) { %>
                                                      <th>Permit No</th>
                                                      <th>RFP No</th>
                                             <% } %>
                                             <th>Status</th>
                                              <th>View</th>
                                      <% } %>
                                      
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                       <%  if (IsTransmissionFrom("MASTER") || IsTransmissionFrom("MASTERSEARCH")) { %>
                                                <td><%# Eval("Id") %></td>
                                                <% if (Role == "Admin") { %>
                                                       <td><%# Eval("OfficeId") %></td>
                                                 <% } %>
                                                 <td><%# Eval("Version") %></td>
                                                 <td><%# Eval("InvoiceNo") %></td>
                                                 <td><%# Eval("InvoiceDate") %></td>
                                                 <td><%# Eval("Exporter") %></td>
                                                 <td><%# Eval("InvoiceValue") %><%# Eval("Currency") %></td>
                                                 <td><%# Eval("DocumentStatus") %></td>
                                                  <td><%# Eval("EDN") %></td>
                                                  <td>
                                                    <a href='<%# "search.aspx?id=" + Eval("Id") + "&source=" + GetTransmissionSource() %>'>
                                                        <i class="fa fa-eye" style="color: #1b5a90;" onmouseover="this.style.color='#00d0f1'" onmouseout="this.style.color='#1b5a90'"></i> 
                                                    </a>
                                                </td>
                                       <% } %>
                                           <% else if (IsTransmissionFrom("USER")){%>
                                                     <td><%# Eval("Id") %></td>
                                                    <td><%# Eval("OrgId") %></td>
                                                    <td><%# Eval("UserId") %></td>
                                                    <td><%# Eval("Password") %></td>
                                                     <td>
                                                        <a href='<%# "user.aspx?id=" + Eval("Id") + "&source=" + GetTransmissionSource() %>'>
                                                            <i class="fa fa-edit mr-1" style="color: #1b5a90;" onmouseover="this.style.color='#00d0f1'" onmouseout="this.style.color='#1b5a90'"></i> 
                                                        </a>
                                                    </td>

                                            <% }%>
                                              <% else if (IsTransmissionFrom("ORGANISATION")){%>
                                                     
                                                        <td><%# Eval("OfficeId") %></td>
                                                        <td><%# Eval("CompanyName") %></td>
                                                        <td><%# Eval("Email_Address") %></td>
                                                         <td>
                                                            <a href='<%# "organisation.aspx?id=" + Eval("Id") + "&source=" + GetTransmissionSource() %>'>
                                                                <i class="fa fa-edit mr-1" style="color: #1b5a90;" onmouseover="this.style.color='#00d0f1'" onmouseout="this.style.color='#1b5a90'"></i> 
                                                            </a>
                                                        </td>
                                              <% }%>
                                     <% else{ %>
                                    <td><%# Eval("Id") %></td>
                                       <% if (Role == "Admin") { %>
                                              <td><%# Eval("OfficeId") %></td>
                                        <% } %>
                                     <% if (IsTransmissionFrom("EDN") ||  IsTransmissionFrom("EDNSEARCH")) { %>
                                             <td><%# Eval("senderRef") %></td>
                                       <% } %>
                                     <% if (IsTransmissionFrom("PRA") || IsTransmissionFrom("PRASEARCH")) { %>
                                             
                                             <td><%# Eval("shippersRef") %></td>
                                            
                                      <% } %> 
                                     <% if (IsTransmissionFrom("AQIS") || IsTransmissionFrom("AQISSEARCH")) { %>
                                               <td><%# Eval("aqisId") %></td>
                                             
                                      <% } %>
                                    <td><%# Eval("Version") %></td>
                                    <td><%# Eval("SDateTime", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                       <% if (IsTransmissionFrom("EDN") || IsTransmissionFrom("EDNSEARCH")) { %>
                                              <td><%# Eval("EDN") %></td>
                                        <% } %>
                                      <% if (IsTransmissionFrom("PRA") || IsTransmissionFrom("PRASEARCH")) { %>
                                              <td><%# Eval("oneStopRef") %></td>
                                            
                                       <% } %> 
                                      <% if (IsTransmissionFrom("AQIS") || IsTransmissionFrom("AQISSEARCH")) { %>
                                                <td><%# Eval("permitNo") %></td>
                                                 <td><%# Eval("rfpNo") %></td>
                                       <% } %>
                                           <td><%# Eval("Status") %></td>
                                          <td>
                                            <a href='<%# "search.aspx?id=" + Eval("Id") + "&source=" + GetTransmissionSource() %>'>
                                                <i class="fa fa-eye" style="color: #1b5a90;" onmouseover="this.style.color='#00d0f1'" onmouseout="this.style.color='#1b5a90'"></i> 
                                            </a>
                                        </td>
                                  <% } %>
                                    

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
                                <td class="text-center align-middle">
                                    <asp:LinkButton ID="lbFirst" runat="server" OnClick="lbFirst_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">First</asp:LinkButton>
                                </td>
                                <td class="text-center align-middle">
                                    <asp:LinkButton ID="lbPrevious" runat="server" OnClick="lbPrevious_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">Previous</asp:LinkButton>
                                </td>
                                <td class="text-center align-middle" style="display: flex; justify-content: center;">
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
                                <td class="text-center align-middle">
                                    <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">Next</asp:LinkButton>
                                </td>
                                <td class="text-center align-middle">
                                    <asp:LinkButton ID="lbLast" runat="server" OnClick="lbLast_Click" CssClass="btn" style="background-color: #1b5a90; color: white;" onmouseover="changeColor(this, '#00d0f1')" onmouseout="changeColor(this, '#1b5a90')">Last</asp:LinkButton>
                                </td>
                                <td class="text-center align-middle">
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
                
             </div>
            
         </div>
        </div>
    </div>
</asp:Content>



 