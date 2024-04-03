﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteOzserver.Master" CodeBehind="SearchResult.aspx.cs" Inherits="Ozserver.WebForm1" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
   <div class="page-wrapper">
     <div class="content container-fluid">
         <div class="page-header">
             <div class="row">
                   <div class="col-sm-12">
                       <h3 class="page-title">Search Result</h3>
                       
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
                            <tr style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #f2f2f2;" : "background-color: #ffffff;" %>'>
                                <th>ID</th>
                                <th>Version</th>
                                <th>SDate</th>
                                <th>Status</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Id") %></td>
                            <td><%# Eval("Version") %></td>
                            <td><%# Convert.ToDateTime(Eval("RequestDate")).ToString("MM/dd/yyyy") %></td>
                            <td><%# Eval("Status") %></td>
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
                                 <asp:LinkButton ID="lbFirst" runat="server" OnClick="lbFirst_Click" CssClass="btn btn-primary">First</asp:LinkButton>
                             </td>
                             <td class="text-center">
                                 <asp:LinkButton ID="lbPrevious" runat="server" OnClick="lbPrevious_Click" CssClass="btn btn-primary">Previous</asp:LinkButton>
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
                                             CssClass="btn btn-primary">
                                         </asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:DataList>
                             </td>

                             <td class="text-center">
                                 <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click" CssClass="btn btn-primary">Next</asp:LinkButton>
                             </td>
                             <td class="text-center">
                                 <asp:LinkButton ID="lbLast" runat="server" OnClick="lbLast_Click" CssClass="btn btn-primary">Last</asp:LinkButton>
                             </td>
                             <td class="text-center">
                                 <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>
                     </table>
                 </div>
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