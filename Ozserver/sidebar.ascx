<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sidebar.ascx.cs" Inherits="Ozserver.WebUserControl1" %>

<!-- Sidebar -->
<div class="sidebar" id="sidebar">
    <div class="sidebar-inner slimscroll">
        <div id="sidebar-menu" class="sidebar-menu">
            <ul>
                <li class="menu-title"><span>Dashboard</span></li>
                <li class="active">
                    <a href="Dashboard.aspx"><i class="fe fe-home"></i><span>Dashboard</span></a>
                  </li>
                         <% if (MASTER) { %>
                           <li class="submenu">
                                 <a href="#" class="icon-link">
                                         <i class="fe fe-document"></i>
                                        <span id="masterLink">ORGANISATION</span>
                                        <span class="menu-arrow"></span>
                                    </a>
                                  <ul style="display: none;">
                                      <li><a href="DocumentList.aspx?context=ORGANISATION">List</a></li>
                                      <li><a href="Organization.aspx">New/Update</a></li>
                                  </ul>
                              </li>
  
                          <% } %>
                       <% if (MASTER) { %>
                           <li class="submenu">
                                 <a href="#" class="icon-link">
                                         <i class="fe fe-document"></i>
                                        <span id="masterLink">USER</span>
                                        <span class="menu-arrow"></span>
                                    </a>
                                  <ul style="display: none;">
                                    <li><a href="DocumentList.aspx?context=USER">List</a></li>
                                    <li><a href="User.aspx">New/Update</a></li>
                                  </ul>
                              </li>
  
                          <% } %>
                  
              
                  <% if (MASTER) { %>
                   <li class="submenu">
                         <a href="#" class="icon-link">
                                 <i class="fe fe-document"></i>
                                <span id="masterLink">MASTER Document</span>
                                <span class="menu-arrow"></span>
                            </a>
                          <ul style="display: none;">
                              <li><a href="DocumentList.aspx?context=MASTER">Today's Transmission</a></li>
                              <li><a href="advancedsearch.aspx?context=MASTER">Advanced Search</a></li>
                          </ul>
                      </li>
                
                  <% } %>
                <% if (EDN) { %>
                      <li class="submenu">
                        <a  href="#" class="icon-link">
                            <i class="fe fe-document"></i>
                            <span id="ednLink">EDN Transmission</span>
                            <span class="menu-arrow"></span>
                        </a>
                        <ul style="display: none;">
                            <li><a href="DocumentList.aspx?context=EDN">Today's Transmission</a></li>
                            <li><a href="advancedsearch.aspx?context=EDN">Advanced Search</a></li>
                        </ul>
                    </li>
              
                <% } %>
                <% if (AQIS) { %>
                <li class="submenu">
                    <a  href="#" class="icon-link">
                       <i class="fe fe-document"></i>
                        <span id="aqisLink">AQIS Transmission</span>
                        <span class="menu-arrow"></span>
                    </a>
                    <ul style="display: none;">
                        <li><a href="DocumentList.aspx?context=AQIS">Today's Transmission</a></li>
                        <li><a href="advancedsearch.aspx?context=AQIS">Advanced Search</a></li>
                    </ul>
                </li>
                
                <% } %>
                <% if (PRA) { %>
                    <li class="submenu">
                        <a  href="#" class="icon-link">
                             <i class="fe fe-document"></i>
                            <span id="praLink">PRA Transmission</span>
                            <span class="menu-arrow"></span>
                        </a>
                        <ul style="display: none;">
                            <li><a href="DocumentList.aspx?context=PRA">Today's Transmission</a></li>
                            <li><a href="advancedsearch.aspx?context=PRA">Advanced Search</a></li>
                        </ul>
                    </li>

                  
                <% } %>
                  
                <li><a href="Profile.aspx"><i class="fa fa-user" aria-hidden="true"></i><span>Profile</span></a></li>
                <li><a href="logout.aspx"><i class="fa fa-sign-out" aria-hidden="true"></i><span>Logout</span></a></li>
            </ul>
        </div>
    </div>
</div>


<!-- /Sidebar -->
