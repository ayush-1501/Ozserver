<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sidebar.ascx.cs" Inherits="Ozserver.WebUserControl1" %>

<!-- Sidebar -->
<div class="sidebar" id="sidebar">
    <div class="sidebar-inner slimscroll">
        <div id="sidebar-menu" class="sidebar-menu">
            <ul>
                <li class="menu-title"><span>Dashboard</span></li>
                <li class="active">
                    <a href="index.html"><i class="fe fe-home"></i><span>Dashboard</span></a>
                </li>
                <% if (EDN) { %>
                      <li class="submenu">
                        <a href="#" class="icon-link">
                            <img src="images/transLC.bmp" alt="Your Image Alt Text" />
                            <span id="ednLink">EDN Transmission</span>
                            <span class="menu-arrow"></span>
                        </a>
                        <ul style="display: none;">
                            <li><a href="WebForm7.aspx?context=EDN">Today's Transmission</a></li>
                            <li><a href="advancedsearch.aspx?context=EDN">Advanced Search</a></li>
                        </ul>
                    </li>
                <script>

                    var praLink = document.getElementById("ednLink");

                    praLink.addEventListener("click", function () {

                        window.location.href = "AQISDocumentData.aspx?context=EDN";
                    });
                </script>
                <% } %>
                <% if (AQIS) { %>
                <li class="submenu">
                    <a href="#" class="icon-link">
                        <img src="images/transLC.bmp" alt="Your Image Alt Text" />
                        <span id="aqisLink">AQIS Transmission</span>
                        <span class="menu-arrow"></span>
                    </a>
                    <ul style="display: none;">
                        <li><a href="WebForm7.aspx?context=AQIS">Today's Transmission</a></li>
                        <li><a href="advancedsearch.aspx?context=AQIS">Advanced Search</a></li>
                    </ul>
                </li>
                 <script>

                     var praLink = document.getElementById("aqisLink");

                     praLink.addEventListener("click", function () {

                         window.location.href = "AQISDocumentData.aspx?context=AQIS";
                     });
                 </script>
                <% } %>
                <% if (PRA) { %>
                    <li class="submenu">
                        <a href="#" class="icon-link">
                            <img src="images/transLC.bmp" alt="Your Image Alt Text" />
                            <span id="praLink">PRA Transmission</span>
                            <span class="menu-arrow"></span>
                        </a>
                        <ul style="display: none;">
                            <li><a href="WebForm7.aspx?context=PRA">Today's Transmission</a></li>
                            <li><a href="advancedsearch.aspx?context=PRA">Advanced Search</a></li>
                        </ul>
                    </li>

                    <script>
   
                        var praLink = document.getElementById("praLink");
   
                        praLink.addEventListener("click", function() {
     
                            window.location.href = "AQISDocumentData.aspx?context=PRA";
                        });
                    </script>
                <% } %>
                  
                <li><a href="profile.html"><i class="fa fa-user" aria-hidden="true"></i><span>Profile</span></a></li>
                <li><a href="logout.aspx"><i class="fa fa-sign-out" aria-hidden="true"></i><span>Logout</span></a></li>
            </ul>
        </div>
    </div>
</div>


<!-- /Sidebar -->
