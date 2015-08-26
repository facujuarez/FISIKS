<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turn.aspx.cs" Inherits="FisiksAppWeb.Turn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Fisiks</title>
    <!-- Bootstrap core CSS -->
    <link href="Libs/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <link href="Libs/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="LibsCalendar/css/cupertino/jquery-ui-1.10.3.min.css" rel="stylesheet" type="text/css" />
    <link href="LibsCalendar/css/cupertino/newStyle.css" rel="stylesheet" type="text/css" />
    <link href="LibsCalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="LibsCalendar/css/jquery.qtip-2.2.0.css" rel="stylesheet" type="text/css" />

    <style type='text/css'>
        body {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
        }

        #calendar {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
            }

            .ui-timepicker-div dl dd {
                margin: -25px 0 10px 65px;
            }

        .style1 {
            width: 100%;
        }

        /* table fields alignment*/
        .alignRight {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }

        .alignLeft {
            text-align: left;
            padding-bottom: 10px;
        }
    </style>
</head>
<body runat="server">
    <form id="form1" runat="server">
        <div class="panel-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>


            <div id="calendar"></div>


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
                            <select id="eventOS">
                                <option value="1">Apross</option>
                                <option value="2">Swiss Medical</option>
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
                            <input runat="server" class="form-control" id="addEventOS" placeholder="Obra social..." />
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
            <div runat="server" id="jsonDiv" />
            <input type="hidden" id="hdClient" runat="server" />
        </div>
    </form>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster-->
    <script src="Libs/js/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="Libs/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="Libs/js/jquery.quicksearch.js" type="text/javascript"></script>
    <script src="LibsCalendar/jquery/moment-2.8.1.min.js" type="text/javascript"></script>
    <script src="LibsCalendar/jquery/jquery-2.1.1.js" type="text/javascript"></script>
    <script src="LibsCalendar/jquery/jquery-ui-1.11.1.js" type="text/javascript"></script>
    <script src="LibsCalendar/jquery/jquery.qtip-2.2.0.js" type="text/javascript"></script>
    <script src="LibsCalendar/fullcalendar/fullcalendar-2.0.3.js" type="text/javascript"></script>
    <script src="LibsCalendar/fullcalendar/es.js" type="text/javascript"></script>
    <script src="LibsCalendar/scripts/scriptCalendario2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#buscarPaciente").click(function () {

            var doc = $("#addTxtDoc").val();
            //alert(doc);
            PageMethods.buscarPac(doc, cargarPaciente);



        });



    </script>

</body>
</html>
