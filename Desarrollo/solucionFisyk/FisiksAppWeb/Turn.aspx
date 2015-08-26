<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turn.aspx.cs" Inherits="FisiksAppWeb.Turn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title>Fisiks</title>
    <!-- Bootstrap core CSS -->
    <%--<link href="Libs/css/bootstrap.min.css" rel="stylesheet" />--%>
    <!-- Bootstrap theme -->
    <%--<link href="Libs/css/bootstrap-theme.min.css" rel="stylesheet" />--%><link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="LibsCalendar/css/cupertino/jquery-ui-1.10.3.min.css" rel="stylesheet" type="text/css" />
    <link href="LibsCalendar/css/cupertino/newStyle.css" rel="stylesheet" type="text/css" />
    <link href="LibsCalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="LibsCalendar/css/jquery.qtip-2.2.0.css" rel="stylesheet" type="text/css" />


    <%--<script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>--%>
    <!-- Bootstrap 3.3.4 -->
    <%--<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <!-- Font Awesome Icons -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <%--<link href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" rel="stylesheet" type="text/css" />--%>
    <!-- Theme style -->
    <link href="dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/DateTimePicker/bootstrap-datetimepicker.css" rel="stylesheet" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins 
         folder instead of downloading all of them to reduce the load. -->
    <link href="dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />

</head>
<body class="skin-blue sidebar-mini" runat="server">

    <form id="form1" runat="server">



        <!-- Site wrapper -->
        <div class="wrapper">

            <header class="main-header">
                <!-- Logo -->
                <a href="../index2.html" class="logo">
                    <!-- mini logo for sidebar mini 50x50 pixels -->
                    <span class="logo-mini"><b>FSK</b></span>
                    <!-- logo for regular state and mobile devices -->
                    <span class="logo-lg"><b>FISIKS</b></span>
                </a>
                <!-- Header Navbar: style can be found in header.less -->
                <nav class="navbar navbar-static-top" role="navigation">
                    <!-- Sidebar toggle button-->
                    <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <div class="navbar-custom-menu">
                        <ul class="nav navbar-nav">

                            <!-- User Account: style can be found in dropdown.less -->
                            <li class="dropdown user user-menu">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <img src="../dist/img/alf.jpg" class="user-image" alt="User Image" />
                                    <span class="hidden-xs">ALF</span>
                                </a>
                                <ul class="dropdown-menu">
                                    <!-- User image -->
                                    <li class="user-header">
                                        <img src="../dist/img/alf.jpg" class="img-circle" alt="User Image" />
                                        <p>
                                            Mario Bross - Web Developer
                     
                                            <small>Member since Nov. 2012</small>
                                        </p>
                                    </li>
                                    <!-- Menu Body -->
                                    <li class="user-body">
                                        <div class="col-xs-4 text-center">
                                            <a href="#">Followers</a>
                                        </div>
                                        <div class="col-xs-4 text-center">
                                            <a href="#">Sales</a>
                                        </div>
                                        <div class="col-xs-4 text-center">
                                            <a href="#">Friends</a>
                                        </div>
                                    </li>
                                    <!-- Menu Footer-->
                                    <li class="user-footer">
                                        <div class="pull-left">
                                            <a href="#" class="btn btn-default btn-flat">Profile</a>
                                        </div>
                                        <div class="pull-right">
                                            <a href="#" class="btn btn-default btn-flat">Sign out</a>
                                        </div>
                                    </li>
                                </ul>
                            </li>
                            <%--  <!-- Control Sidebar Toggle Button -->
                            <li>
                                <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                            </li>--%>
                        </ul>
                    </div>
                </nav>
            </header>

            <!-- =============================================== -->

            <!-- Left side column. contains the sidebar -->
            <aside class="main-sidebar">
                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">

                    <!-- sidebar menu: : style can be found in sidebar.less -->
                    <ul class="sidebar-menu">
                        <%--<li class="header">MAIN NAVIGATION</li>--%>
                        <li class="treeview">
                            <a href="Home.aspx">
                                <i class="fa fa-home"></i><span>Home</span>
                            </a>
                        </li>
                        <li class="treeview">
                            <a href="Turn.aspx">
                                <i class="fa fa-calendar"></i><span>Turnos</span>
                            </a>
                        </li>
                        <li class="treeview">
                            <a href="Home.aspx">
                                <i class="fa fa-user"></i>
                                <span>Pacientes</span> <i class="fa fa-angle-left pull-right"></i>
                                <%-- <span class="label label-primary pull-right">4</span>--%>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="PacientesAbm.aspx?e=B"><i class="fa fa-circle-o"></i>Buscar </a></li>
                                <li><a href="PacientesAbm.aspx?e=N"><i class="fa fa-circle-o"></i>Registrar</a></li>

                            </ul>
                        </li>
                        <li>
                            <a href="Home.aspx">
                                <i class="fa fa-user-md"></i>
                                <span>Kinesiólogos</span> <i class="fa fa-angle-left pull-right"></i>
                                <%-- <span class="label label-primary pull-right">4</span>--%>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="ProfesionalesAbm.aspx?e=B"><i class="fa fa-circle-o"></i>Buscar </a></li>
                                <li><a href="ProfesionalesAbm.aspx?e=N"><i class="fa fa-circle-o"></i>Registrar</a></li>

                            </ul>
                        </li>

                    </ul>
                </section>
                <!-- /.sidebar -->
            </aside>

            <!-- =============================================== -->

            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                </section>
                <!-- Main content -->
                <section class="content">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                    </asp:ScriptManager>

                    <div class="row">
                        <div class="col-md-3">
                            <!-- ============================================================================================== -->
                            <!-- ============================================================================================== -->
                            <!-- ============================================================================================== -->
                            <asp:Panel ID="panelColap" runat="server">
                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                    <div class="panel panel-success">
                                        <div class="panel-heading" role="tab" id="headingOne">
                                            <h4 class="panel-title">
                                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne"
                                                    aria-expanded="false" aria-controls="collapseTwo"><b>KINESIOLOGOS</b></a>
                                            </h4>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <input type="checkbox" name="pasa" value="tv">TODOS
                                                </div>
                                                <div class="row">
                                                    <input type="checkbox" name="pasa" value="tv">Rollon Juan
                                                </div>
                                                <div class="row">
                                                    <input type="checkbox" name="pasa" value="tv">Gutierrez Maria
                                                </div>
                                                <div class="row">
                                                    <input type="checkbox" name="pasa" value="tv">Samparo Marcos Aldo
                                                </div>
                                                <div class="row">
                                                    <input type="checkbox" name="pasa" value="tv">Alvarez Pitty
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-success">
                                        <div class="panel-heading" role="tab" id="headingTwo">
                                            <h4 class="panel-title">
                                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"
                                                    aria-expanded="false" aria-controls="collapseTwo"><b>PACIENTES</b></a>
                                            </h4>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                            <div class="panel-body">
                                                <div class="row">Guimenez F.</div>
                                                <div class="row">Perez E.</div>
                                                <div class="row">Sosa J.</div>
                                                <div class="row">Campo S.</div>
                                                <div class="row">Rodriguez A.</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>




                            <!-- ============================================================================================== -->
                            <!-- ============================================================================================== -->
                            <!-- ============================================================================================== -->
                            <div class="box box-solid">
                                <div class="box-header with-border">
                                    <h4 class="box-title">Draggable Events</h4>
                                </div>
                                <div class="box-body">
                                    <!-- the events -->
                                    <div id='external-events'>
                                        <div class='external-event bg-green'>Dr. Alvarez</div>
                                        <div class='external-event bg-yellow'>Dr. Gomez</div>
                                        <div class='external-event bg-aqua'>Dr.coco</div>
                                        <div class="checkbox">
                                            <label for='drop-remove'>
                                                <input type='checkbox' id='drop-remove' />
                                                remove after drop
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box box-solid">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Create Event</h3>
                                </div>
                                <div class="box-body">
                                    <div class="btn-group" style="width: 100%; margin-bottom: 10px;">
                                        <!--<button type="button" id="color-chooser-btn" class="btn btn-info btn-block dropdown-toggle" data-toggle="dropdown">Color <span class="caret"></span></button>-->
                                        <ul class="fc-color-picker" id="color-chooser">
                                            <li><a class="text-aqua" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-blue" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-light-blue" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-teal" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-yellow" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-orange" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-green" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-red" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-red" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-purple" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-fuchsia" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-muted" href="#"><i class="fa fa-square"></i></a></li>
                                            <li><a class="text-navy" href="#"><i class="fa fa-square"></i></a></li>
                                        </ul>
                                    </div>
                                    <!-- /btn-group -->
                                    <div class="input-group">
                                        <input id="new-event" type="text" class="form-control" placeholder="Event Title">
                                        <div class="input-group-btn">
                                            <button id="add-new-event" type="button" class="btn btn-primary btn-flat">Add</button>
                                        </div>
                                        <!-- /btn-group -->
                                    </div>
                                    <!-- /input-group -->
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="box box-primary">
                                <div class="box-body no-padding">
                                    <div id="calendar"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                     <div id="updatedialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px; display: none;"
                title="Actualizar o eliminar turno">
                <table cellpadding="0" class="style1">
                    <tr>
                        <td width="60%" valign="center" nowrap="" bgcolor="#654b24" align="center" colspan="3">
                            <font size="3" color="#ffffff" face="Arial">Paciente</font>
                        </td>
                    </tr>
                </table>
                <br />
                <table cellpadding="0" class="style1">
                    <tr style="display: none">
                        <td class="alignRight">Name:</td>
                        <td class="alignLeft">
                            <input id="eventName" type="text" /><br />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="alignRight">Description:</td>
                        <td class="alignLeft">
                            <textarea id="eventDesc" cols="30" rows="3"></textarea></td>
                    </tr>
                    <tr>
                        <td class="alignRight">DNI:</td>
                        <td class="alignLeft">
                            <input id="txtDoc" type="text" size="50" /><br />
                        </td>

                    </tr>
                    <tr style="display: none">
                        <td class="alignRight">Id:</td>
                        <td class="alignLeft">
                            <input id="eventPaeId" type="text" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Nombre:</td>
                        <td class="alignLeft">
                            <input id="txtNombre" type="text" size="50" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Apellido:</td>
                        <td class="alignLeft">
                            <input id="txtApellido" type="text" size="50" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Teléfono:</td>
                        <td class="alignLeft">
                            <input id="txtTel" type="text" size="50" /><br />
                        </td>
                    </tr>
                    <tr>

                        <td class="alignRight">Obra social:</td>
                        <td class="alignLeft">
                            <select id="eventOS" onchange="cargarCoseguroUpdate(this.value)">
                                <option></option>
                            </select>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Kinesiólogo:</td>
                        <td class="alignLeft">
                            <select id="eventKine">
                                <option value="1">Volvo</option>
                                <option value="2">Saab</option>
                            </select>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Inicio:</td>
                        <td class="alignLeft">
                            <span id="eventStart"></span></td>
                    </tr>
                    <tr>
                        <td class="alignRight">Fin: </td>
                        <td class="alignLeft">
                            <span id="eventEnd"></span>
                            <input type="hidden" id="eventId" /></td>
                    </tr>
                </table>

                <table cellpadding="0" class="style1">
                    <tr>
                        <td width="60%" valign="center" nowrap="" bgcolor="#654b24" align="center" colspan="3">
                            <font size="3" color="#ffffff" face="Arial">Cobro</font>
                        </td>
                    </tr>
                </table>
                <br />
                <table cellpadding="0">
                    <tr>
                        <td class="alignRight">Monto</td>
                        <td class="alignLeft">
                            <input id="eventMonto" type="text" size="10" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Coseguro</td>
                        <td class="alignLeft">
                            <input id="eventCoseguro" type="text" size="10" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Total</td>
                        <td class="alignLeft">
                            <input id="eventTotal" type="text" size="10" /><br />
                        </td>
                    </tr>



                </table>
            </div>

            <div runat="server" id="addDialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px;" title="Agregar turno">
                <table cellpadding="0" class="style1">
                    <tr>
                        <td width="60%" valign="center" nowrap="" bgcolor="#654b24" align="center" colspan="3">
                            <font size="3" color="#ffffff" face="Arial">Paciente</font>
                        </td>
                    </tr>
                </table>
                <br />
                <table cellpadding="0" class="style1" runat="server">
                    <tr style="display: none">
                        <td class="alignRight">Name:</td>
                        <td class="alignLeft">
                            <input id="addEventName" type="text" size="50" /><br />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="alignRight">Description:</td>
                        <td class="alignLeft">
                            <textarea id="addEventDesc" cols="30" rows="3"></textarea></td>
                    </tr>
                    <tr>
                        <td class="alignRight">DNI:</td>
                        <td class="alignLeft">
                            <input id="addTxtDoc" runat="server" type="text" class="form-control" placeholder="Ingrese documento..." />
                        </td>
                        <td class="alignRight">

                            <input id="buscarPaciente" class="btn btn-primary" type="button" value="Buscar" />



                        </td>
                    </tr>

                    <tr style="display: none">
                        <td class="alignRight">Id:</td>
                        <td class="alignLeft">
                            <input type="text" class="form-control" id="addEventPaciente" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Nombre:</td>
                        <td class="alignLeft">
                            <input id="addTxtNombre" runat="server" type="text" class="form-control" placeholder="Nombre Paciente..." />
                        </td>
                    </tr>
                    <tr>

                        <td class="alignRight">Apellido:</td>
                        <td class="alignLeft">
                            <input id="addTxtApellido" runat="server" type="text" class="form-control" placeholder="Apellido Paciente..." />

                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Teléfono:</td>
                        <td class="alignLeft">
                            <input runat="server" class="form-control" id="addTxtTel" placeholder="Teléfono Paciente..." />

                        </td>
                    </tr>
                    <tr>

                        <td class="alignRight">Obra social:</td>
                        <td class="alignLeft">
                            <select id="addEventOS" onchange="cargarCoseguro(this.value)">
                                <option></option>
                            </select>
                            <br />
                        </td>
                    </tr>


                    <tr>
                        <td class="alignRight">Kinesiólogo:</td>
                        <td class="alignLeft">
                            <input runat="server" class="form-control" id="addEventKine" placeholder="kine..." />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Inicio:</td>
                        <td class="alignLeft">
                            <span id="addEventStartDate"></span></td>
                    </tr>
                    <tr>

                        <td class="alignRight">Fin:</td>
                        <td class="alignLeft">
                            <span id="addEventEndDate"></span></td>
                    </tr>
                </table>
                <br />
                <table cellpadding="0" class="style1">
                    <tr>
                        <td width="60%" valign="center" nowrap="" bgcolor="#654b24" align="center" colspan="3">
                            <font size="3" color="#ffffff" face="Arial">Cobro</font>
                        </td>
                    </tr>
                </table>
                <br />
                <table cellpadding="0">
                    <tr>
                        <td class="alignRight">Monto</td>
                        <td class="alignLeft">
                            <input type="text" class="form-control" id="addEventMonto" runat="server" placeholder="Ingrese el Monto..." />

                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Coseguro</td>
                        <td class="alignLeft">
                            <input type="text" class="form-control" id="addEventCoseguro" runat="server" placeholder="..." />

                        </td>
                    </tr>
                    <tr>

                        <td class="alignRight">Total</td>
                        <td class="alignLeft">
                            <input type="text" class="form-control" id="addEventTotal" runat="server" placeholder="..." />
                        </td>
                    </tr>



                </table>

            </div>

                    <div runat="server" id="jsonDiv"></div>
                    <input type="hidden" id="hdClient" runat="server" />
                </section>
            </div>

            <!-- /.content-wrapper -->

            <footer class="main-footer">
                ///////////////////////////////////////////////////////
            </footer>

            <!-- Control Sidebar -->
            <aside class="control-sidebar control-sidebar-dark">
                <!-- Create the tabs -->
                <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
                    <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>

                    <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
                </ul>
            </aside>
            <!-- /.control-sidebar -->
            <!-- Add the sidebar's background. This div must be placed
           immediately after the control sidebar -->
            <div class='control-sidebar-bg'></div>
        </div>
        <!-- ./wrapper -->

    </form>


    <!-- jQuery 2.1.4 -->
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- SlimScroll -->
    <script src="plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <!-- FastClick -->
    <script src="plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="dist/js/app.min.js" type="text/javascript"></script>
    <!--QuickSearch-->
    <script src="plugins/quickSearch/jquery.quicksearch.js"></script>
    <!--Moments-->
    <script src="plugins/DateTimePicker/moment.min.js"></script>

    <script src="plugins/bootstrapValidator/bootstrapValidator.min.js"></script>
    <link href="plugins/bootstrapValidator/bootstrapValidator.min.css" rel="stylesheet" />

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster-->
    <script src="LibsCalendar/jquery/moment-2.8.1.min.js" type="text/javascript"></script>
    <%--<script src="LibsCalendar/jquery/jquery-2.1.1.js" type="text/javascript"></script>--%>
    <script src="LibsCalendar/jquery/jquery-ui-1.11.1.js" type="text/javascript"></script>
    <script src="LibsCalendar/jquery/jquery.qtip-2.2.0.js" type="text/javascript"></script>
    <script src="LibsCalendar/fullcalendar/fullcalendar-2.0.3.js" type="text/javascript"></script>
    <script src="LibsCalendar/fullcalendar/es.js" type="text/javascript"></script>
    <script src="LibsCalendar/scripts/scriptCalendario.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#buscarPaciente").click(function () {

            var doc = $("#txtDoc").val();
            //alert(doc);
            PageMethods.BuscarPacienteDoc(doc, cargarPaciente);
        });
    </script>
    <%--  <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js" type="text/javascript"></script>--%>
    <%-- <script src="plugins/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>--%>--%>
    <!-- Page specific script -->
    <script type="text/javascript">
        $(function () {

            /* initialize the external events
             -----------------------------------------------------------------*/
            function ini_events(ele) {
                ele.each(function () {

                    // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
                    // it doesn't need to have a start or end
                    var eventObject = {
                        title: $.trim($(this).text()) // use the element's text as the event title
                    };

                    // store the Event Object in the DOM element so we can get to it later
                    $(this).data('eventObject', eventObject);

                    // make the event draggable using jQuery UI
                    $(this).draggable({
                        zIndex: 1070,
                        revert: true, // will cause the event to go back to its
                        revertDuration: 0  //  original position after the drag
                    });

                });
            }
            ini_events($('#external-events div.external-event'));

            /* ADDING EVENTS */
            var currColor = "#3c8dbc"; //Red by default
            //Color chooser button
            var colorChooser = $("#color-chooser-btn");
            $("#color-chooser > li > a").click(function (e) {
                e.preventDefault();
                //Save color
                currColor = $(this).css("color");
                //Add color effect to button
                $('#add-new-event').css({ "background-color": currColor, "border-color": currColor });
            });
            $("#add-new-event").click(function (e) {
                e.preventDefault();
                //Get value and make sure it is not null
                var val = $("#new-event").val();
                if (val.length == 0) {
                    return;
                }

                //Create events
                var event = $("<div />");
                event.css({ "background-color": currColor, "border-color": currColor, "color": "#fff" }).addClass("external-event");
                event.html(val);
                $('#external-events').prepend(event);

                //Add draggable funtionality
                ini_events(event);

                //Remove event from text input
                $("#new-event").val("");
            });
        });
    </script>
</body>
</html>
