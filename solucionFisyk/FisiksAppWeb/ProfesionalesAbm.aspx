<%@ Page Title="" Language="C#" MasterPageFile="~/MPF.Master" AutoEventWireup="true" CodeBehind="ProfesionalesAbm.aspx.cs" Inherits="FisiksAppWeb.ProfesionalesAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            var txtFiltro = '#' + '<%=txtBuscar.ClientID %>';
            var grillaJedis = '#' + '<%=gvPro.ClientID %>';
            $(txtFiltro).quicksearch(grillaJedis + ' tbody tr');
        });
    </script>

    <script type="text/javascript">
        function cambioTxt() {
            var largoTxt = document.getElementById('<%=txtBuscar.ClientID %>').value.length;
            if (largoTxt == 0) {
                //alert("vacio!" + largoTxt);
                document.getElementById('divPanelListProfesional').setAttribute('style', 'display:none');
            }
            if (largoTxt > 0) {
                //alert("Algo!" + largoTxt);
                document.getElementById('divPanelListProfesional').setAttribute('style', 'visibility:visible');
                document.getElementById('divPanelPantalla').setAttribute('style', 'display:none');
            }
        }

        function editarProfesional() {
            document.getElementById('<%=txtBuscar.ClientID %>').value = "";
        }

        function ocultarFormProfesional() {
            document.getElementById('divPanelPantalla').setAttribute('style', 'display:none');
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#containerPantalla').bootstrapValidator({
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    <%=txtNombre.UniqueID%>: {
                        container: '#mensajeNombre',
                        validators: {
                            notEmpty: {
                                message: 'Ingrese el Nombre'
                            }//,
                            //regexp: {
                            //    regexp: /^[a-z\s]+$/i,
                            //    message: 'Solo se puede ingresar letras'
                            //},
                            //stringLength: {
                            //    max: 30,
                            //    message: 'El nombre no puede tener mas de 30 caracteres'
                            //}
                        }
                    },
                    <%=txtDocumento.UniqueID%>: {
                        container: '#mensajeDocumento',
                        validators: {
                            notEmpty: {
                                message: 'Ingrese el Documento'
                            }//,
                            //digits:{
                            //    message: 'No se permiten letras'
                            //},
                            //stringLength: {
                            //    max: 8,
                            //    min: 7,
                            //    message: 'El nombre no puede tener mas de 30 caracteres'
                            //}
                        }
                    },
                    //^(09|1[0-7]{1}):[0-5]{1}[0-9]{1}$   -----> valida HH:mm por ej hora cierre: 15:30
                    <%=txtTel.UniqueID%>: {
                        container: '#mensajeTelefono',
                        validators: {
                            notEmpty: {
                                message: 'Ingrese un teléfono'
                            },
                            //digits: {
                            //    message: 'Teléfono incorrecto'
                            //},
                            regexp: {
                                regexp: /^((\(?\d{3}\)?[-. ]?\d{4})|(\(?\d{4}\)?[-. ]?\d{3})|(\(?\d{5}\)?[-. ]?\d{2}))[-. ]?\d{4}$/,
                                message: 'Telefóno incorrecto, ej: 03514252627'
                            }//esto deberia ir.. obtener phone.js!!!! lo mismo que date.js
                            //,phone: {
                            //country: 'US',
                            // message: 'Please enter a valid US phone number'
                            //}
                        }
                    },
                    <%=txtFecNac.UniqueID%>: {
                        container: '#mensajeFecha',
                        validators: {
                            //date: {//falta date.js --lo puedo bajar o usar una regex
                            //    message: 'Fecha Incorrecta, ej: 01/07/1975',
                            //    format: 'YYYY/DD/MM' 
                            //},
                            regexp: {
                                regexp:  /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/,
                                message: 'Fecha Incorrecta, ej: 01/07/1975'
                            }
                        }
                    },
                    <%=txtApellido.UniqueID%>: {
                        container: '#mensajeApellido',
                        validators: {
                            notEmpty: {
                                message: 'Complete el apellido'
                            }//,
                            //stringLength: {
                            //    max: 30,
                            //    message: 'El apellido no puede tener mas de 30 caracteres'
                            //},
                            //regexp: {
                            //    regexp: /^[a-z\s]+$/i,
                            //    message: 'Solo se puede ingresar letras'
                            //}
                        }
                    },
                    <%=txtMail.UniqueID%>:{
                        container: '#mensajeMail',
                        validators: {
                            emailAddress: {
                                message: 'Email Incorrecto'
                            }
                        }
                    }
                }
            });
        });
    </script>

    <script type="text/javascript"> 
        function soloLetras(e){ 
            key = e.keyCode || e.which; 
            tecla = String.fromCharCode(key).toLowerCase(); 
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz"; // letras permitidas 
            especiales = [46,10,13]; // carácteres especiales como espacio, borrar y enter 

            tecla_especial = false 
            for(var i in especiales){ 
                if(key == especiales[i]){ 
                    tecla_especial = true; 
                    break; 
                } 
            } 

            if(letras.indexOf(tecla)==-1 && !tecla_especial){ 
                return false; 
            } 
        } 
    </script>

    <script type="text/javascript"> 
        function validarNum(e)
        {
            var keynum = window.event ? window.event.keyCode : e.which;
            if ((keynum == 8))
                return true;
 
            return /\d/.test(String.fromCharCode(keynum));
        }
    </script>
    <%--<style>
        .well {
            background: rgba(0, 0, 255, 0.9);
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPantalla">

        <h5><font color="blue"><b>Kinesiólogo</b></font></h5>
        <div class="form-group">
            <input type="text" class="form-control" id="txtBuscar" name="txtBuscar" runat="server" onkeyup="cambioTxt()" placeholder="Búscar Profesional..." />
        </div>

        <div id="divPanelPantalla">
            <asp:Panel ID="PanelPantalla" runat="server">
                <asp:Panel ID="panelColap" runat="server">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Datos Pesonales</a>
                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                <div class="panel-body">

                                    <div class="bloque">
                                        <div class="row">
                                            <div class="A">
                                                <div class="form-group">
                                                    <div class="col-md-3">

                                                        <label class="col-md-3 control-label" size="small">Documento</label>
                                                        <input runat="server" type="text" id="txtDocumento" maxlength="8" onkeypress="return validarNum(event);" name="txtDocumento" class="form-control" placeholder="Documento Paciente..." />
                                                        <span class="help-block" id="mensajeDocumento" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="B">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Nombre</label>
                                                        <input id="txtNombre" runat="server" type="text" maxlength="20" onkeypress="return soloLetras(event)" class="form-control" placeholder="Nombre Paciente..." />
                                                        <span class="help-block" id="mensajeNombre" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="C">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Apellido</label>
                                                        <input id="txtApellido" runat="server" type="text" class="form-control" maxlength="20" onkeypress="return soloLetras(event)" placeholder="Apellido Paciente..." />
                                                        <span class="help-block" id="mensajeApellido" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="D">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <%-- estado activo --%>
                                                        <asp:Label ID="lblEstado" runat="server" Text="" Font-Bold="True">Estado Activo</asp:Label>
                                                        <%--<label>Estado Activo</label>--%>
                                                        <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                                                        <br />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="bloque">
                                        <div class="row">
                                            <div class="A">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Fecha</label>
                                                        <input id="txtFecNac" runat="server" type="text" class="form-control" placeholder="Fecha Nacimiento..." />
                                                        <span class="help-block" id="mensajeFecha" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="B">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Télefono</label>
                                                        <input id="txtTel" type="text" runat="server" onkeypress="return validarNum(event);" maxlength="11" class="form-control" placeholder="Teléfono Paciente..." />
                                                        <span class="help-block" id="mensajeTelefono" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="C">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Email</label>
                                                        <input id="txtMail" type="email" runat="server" maxlength="25" class="form-control" placeholder="Email Paciente..." />
                                                        <span class="help-block" id="mensajeMail" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="D">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Dirección</label>
                                                        <input id="txtDire" runat="server" class="form-control" placeholder="Dirección Paciente..." />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <br />
                                    <div class="bloque">
                                        <div class="row">
                                            <div class="A">
                                                <div class="col-md-3">
                                                    <div class="col-md-6">
                                                        <label>Sexo</label>
                                                        <div class="radio">
                                                            <label>
                                                                <input type="radio" runat="server" name="opciones" id="rbM" value="masculino" checked="True" />Masculino</label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label style="visibility: hidden">invisible</label>
                                                        <div class="radio">
                                                            <label>
                                                                <input type="radio" runat="server" name="opciones" id="rbF" value="femenino" />Femenino</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:Label ID="lblProId" runat="server" Text="" ForeColor="Red" Font-Bold="True" Visible="False"></asp:Label>
                                    <asp:Label ID="lblPsnId" runat="server" Text="" ForeColor="Red" Font-Bold="True" Visible="False"></asp:Label>

                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">Matrículas - Agenda Laboral </a>
                                </h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="well well-sm">
                                                <label>MATRÍCULAS</label>
                                                <asp:Label ID="lblMsjMatricula" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                <!-- ##########################################  UPDATE PANEL (Matriculas) ########################################## -->
                                                <asp:UpdatePanel ID="upModalMatricula" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnMatAgregar" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="gvMat" EventName="RowDeleting" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <div class="bloque">
                                                            <div class="row">
                                                                <div class="A">
                                                                    <div class="form-group">
                                                                        <div class="col-md-6">
                                                                            <label>Tipo de Matrículas</label>
                                                                            <asp:DropDownList ID="ddlMat" runat="server" class="form-control"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="B">
                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label class="col-md- control-label">Número</label>
                                                                            <input type="text" id="txtNro" runat="server" onkeypress="return validarNum(event);" class="form-control" placeholder="Matrícula..." />
                                                                            <span class="help-block" id="mensajeNro" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="C">
                                                                    <div class="form-group">
                                                                        <div class="col-md-2">
                                                                            <label style="visibility: hidden">invisible</label>
                                                                            <asp:Button ID="btnMatAgregar" runat="server" class="btn btn-info btn-block" Text="+" OnClick="btnMatricula_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <hr />
                                                            <div class="row">
                                                                <asp:GridView ID="gvMat" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                                                                    AutoGenerateColumns="False"
                                                                    OnRowDeleting="MatriculaEliminarFilaGrilla"
                                                                    Width="95%" HorizontalAlign="Center">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PMTID" Visible="false" />
                                                                        <asp:BoundField DataField="PMT_MTTID" Visible="false" />
                                                                        <asp:BoundField DataField="MTTDESCRIPCION" HeaderText="Descripción">
                                                                            <ItemStyle Width="50%" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PMTNRO" HeaderText="Número">
                                                                            <ItemStyle Width="30%" />
                                                                        </asp:BoundField>
                                                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Img/delete16x16.png" ShowDeleteButton="True" />
                                                                    </Columns>
                                                                    <RowStyle CssClass="cursor-pointer" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!-- ##########################################  UPDATE PANEL (Matriculas) ########################################## -->
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="well well-sm">
                                                <label>AGENDA LABORAL</label>
                                                <asp:Label ID="lblMsjAgenda" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                <!-- ##########################################  UPDATE PANEL (Agenda Laboral) ########################################## -->
                                                <asp:UpdatePanel ID="upModalPanelLaborl" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnAgeAgregar" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="gvAgenda" EventName="RowDeleting" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <div class="bloque">
                                                            <div class="row">
                                                                <div class="A">
                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Días Laborables</label>
                                                                            <asp:DropDownList ID="ddlDias" runat="server" class="form-control"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="B">
                                                                    <div class="form-group">
                                                                        <div class="col-md-3">
                                                                            <label>Hora Desde</label>
                                                                            <asp:DropDownList ID="ddlHoraDesde" runat="server" class="form-control"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="C">
                                                                    <div class="form-group">
                                                                        <div class="col-md-3">
                                                                            <label>Hora Hasta</label>
                                                                            <asp:DropDownList ID="ddlHoraHasta" runat="server" class="form-control"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="D">
                                                                    <div class="form-group">
                                                                        <div class="col-md-2">
                                                                            <label style="visibility: hidden">invisible</label>
                                                                            <asp:Button ID="btnAgeAgregar" runat="server" class="btn btn-info btn-block" Text="+" OnClick="btnAgeAgregar_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <hr />
                                                            <div class="row">
                                                                <asp:GridView ID="gvAgenda" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                                                                    OnRowDeleting="AgendaEliminarFilaGrilla"
                                                                    AutoGenerateColumns="False"
                                                                    Width="95%" HorizontalAlign="Center">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="AGEID" HeaderText="AGEID" Visible="False"></asp:BoundField>

                                                                        <asp:BoundField DataField="AGE_DIAID" HeaderText="AGE_DIAID" Visible="False"></asp:BoundField>

                                                                        <asp:BoundField DataField="DIADESCRIPCION" HeaderText="Día">
                                                                            <ItemStyle Width="40%" />
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="AGEHORADESDE" HeaderText="Hora Desde">
                                                                            <ItemStyle Width="30%" />
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="AGEHORAHASTA" HeaderText="Hora Hasta">
                                                                            <ItemStyle Width="30%" />
                                                                        </asp:BoundField>

                                                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Img/delete16x16.png" ShowDeleteButton="True" />
                                                                    </Columns>
                                                                    <RowStyle CssClass="cursor-pointer" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!-- ##########################################  UPDATE PANEL (Agenda Laboral) ########################################## -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingThree">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">Especialidades</a>
                                </h4>
                            </div>
                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                <div class="panel-body">
                                    <%--<div class="row">
                                        <div class="col-md-12">
                                            <label>Especialidades:</label>
                                        </div>
                                    </div>--%>
                                    <div class="well well-sm">
                                        <div class="row" style="size: auto">
                                            <!-- ####################  UPDATE PANEL (Especialidades) #################### -->
                                            <asp:UpdatePanel ID="UpdatePanelEspecialidades" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <!-- ####################  UPDATE PANEL (Especialidades) #################### -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </asp:Panel>
                <div class="panel-footer">
                    <div class="container">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModalMensaje"><b>Guardar</b></button>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <!--  Modal Mensajes Confirmacion------------------------------------------------------------------------------------------------------------->
        <div id="myModalMensaje" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <div class="modal-content">
                    <div class="modal-header" style="background-color: #dff0d8; border-bottom-color: #d6e9c6; color: #468847;">

                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><b>Profesional</b></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblMsj" runat="server" Text="Label" Font-Bold="True" class="form"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!--  Modal Mensajes ------------------------------------------------------------------------------------------------------------------------->

        <!--  Modal Mensajes Confirmacion------------------------------------------------------------------------------------------------------------->
        <div id="openModalMsjGrabado" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #dff0d8; border-bottom-color: #d6e9c6; color: #468847;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><b>Profesional</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-12" style="text-align: center; padding-top: 20px;">
                            <h3 id="msjTitulo" runat="server">El Paciente se registro de forma correcta!</h3>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <a id="idsal" runat="server" class="btn btn-success" href="PacientesABM.aspx?e=N.aspx">Aceptar</a>
                    </div>
                </div>
            </div>
        </div>
        <!--  Modal Mensajes ------------------------------------------------------------------------------------------------------------------------->

        <asp:Panel ID="PanelBusqueda" runat="server">
            <div class="form-inline">
                <div id="divPanelListProfesional" style="visibility: hidden">
                    <asp:Panel ID="panelListProfesional" runat="server">
                        <asp:GridView ID="gvPro" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                            AutoGenerateColumns="False"
                            EmptyDataText="No se encontraron registros."
                            OnSelectedIndexChanged="OnSelectedIndexChanged">
                            <Columns>

                                <asp:BoundField DataField="PSNNRODCTO" HeaderText="Documento">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PSNAPELLIDO" HeaderText="Apellido">
                                    <ItemStyle Width="25%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PSNNOMBRE" HeaderText="Nombres">
                                    <ItemStyle Width="35%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PSNTELEFONO" HeaderText="Teléfono">
                                    <ItemStyle Width="25%" />
                                </asp:BoundField>

                                <%-- <asp:BoundField DataField="ProID" HeaderText="ProId" Visible="false"></asp:BoundField>--%>

                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Img/edit_16x16.png" ShowSelectButton="True" />

                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />

                        </asp:GridView>
                    </asp:Panel>
                    <asp:Label ID="lbl" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>

                </div>
            </div>
        </asp:Panel>

    </div>



    <script type="text/javascript">
        function openModalMsjGrabado() {
            $('#openModalMsjGrabado').modal({ show: true });
        }
        function openModalMsjClose() {
            $('#myModalMensaje').modal({ hide: true });
        }
    </script>
</asp:Content>
