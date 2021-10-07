<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeManagementSystem.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="HeaderContent" runat="server">

    <h1>Employee Management System Pakistan Center
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">Dashboard</li>
    </ol>


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form runat="server"></form>
    <div class="row">

        <!-- Home -->
        <div class="col-lg-3 col-xs-6" runat="server">
            <div class="small-box bg-aqua">
                <div class="inner">
                        <a class="link" style="text-decoration: none; color: white;" href="/Default.aspx">     <h2>HOME</h2> </a>
                    <h4>&nbsp; </h4>
                    <div class="icon">
                        <a class="link" href="/Default.aspx">
                            <i style="color: white;" class="ion ion-home"></i>
                        </a>
                    </div>
                </div>

                <a href="Default.aspx" class="small-box-footer" style="font-size: 16px;">Visit &nbsp; <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

        <!-- Manage Machines -->
        <div class="col-lg-3 col-xs-6" runat="server" id="divMachines">
            <!-- small box -->
            <div class="small-box bg-purple">

                <div class="inner">
                    <a class="link" href="/MachinesConfig.aspx" style="text-decoration: none; color: white;">
                        <h2>Manage
                            <br />
                            Employees</h2>
                    </a>
                    <div class="icon">
                        <a class="link" href="/MachinesConfig.aspx">
                            <i style="color: white;" class="ion ion-android-desktop"></i>
                        </a>
                    </div>
                </div>
                <a href="/MachinesConfig.aspx" class="small-box-footer" style="font-size: 16px;">Visit <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

        <!-- CMS App Config -->
        <div class="col-lg-3 col-xs-6" runat="server" id="DivAppConfig">
            <!-- small box -->
            <div class="small-box bg-orange-active">
                <div class="inner">
                    <a class="link" style="text-decoration: none; color: white;" href="/AppConfig.aspx">
                        <h2> App
                            <br />
                            Config</h2>
                    </a>

                    <div class="icon">
                        <a class="link" href="/AppConfig.aspx">
                            <i style="color: white;" class="ion ion-settings"></i></a>
                    </div>
                </div>

                <a  href="/AppConfig.aspx" class="small-box-footer" style="font-size: 16px;">Visit &nbsp; <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

        <!-- Reports -->
        <div class="col-lg-3 col-xs-6" runat="server">
            <!-- small box -->
            <div class="small-box bg-green-gradient">
                <div class="inner">
                   <a class="link" style="text-decoration: none; color: white;" href="/Reports.aspx"> 
                       <h2>Reports</h2> </a>
                        <h4>&nbsp;</h4>                 
                    <div class="icon">
                        <a class="link" href="/Reports.aspx">
                            <i style="color: white;" class="ion ion-stats-bars"></i></a>
                    </div>

                </div>
                <a href="/Reports.aspx" class="small-box-footer" style="font-size: 16px;">Visit <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

    </div>
    <div class="row">

        <!-- Manage Users  -->
        <%-- <div class="col-lg-3 col-xs-6" runat="server" id="divUsers">
          <!-- small box -->
             <div class="small-box bg-maroon">
            <div class="inner">
            <h2>Manage <br />  User</h2> 
             
            <div class="icon">
               <a href="/ManageUsers.aspx" >
              <i style="color:white;" class="ion ion-person"></i></a>
            </div>
            
            </div>
            <a href="/ManageUsers.aspx" class="small-box-footer" style="font-size:16px;">Visit <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>--%>
        <!-- System Configuration  -->
        <div class="col-lg-3 col-xs-6" runat="server" id="divSysConfig">
          <!-- small box -->
             <div class="small-box bg-maroon">
            <div class="inner">
            <h2>System <br /> Config</h2> 
             
            <div class="icon">
               <a href="/SystemConfig.aspx" >
              <i style="color:white;" class="ion ion-android-options"></i></a>
            </div>
            
            </div>
            <a href="/SystemConfig.aspx" class="small-box-footer" style="font-size:16px;">Visit <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
    </div>
</asp:Content>
