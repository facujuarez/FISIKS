<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="PacientesAbm.aspx.cs" Inherits="FisiksAppWeb.PacientesAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>

    <script type="text/javascript">
        function filtrarGrilla(){
            var txtFiltro = '#' + '<%=txtBuscar.ClientID %>';
            var grillaJedis = '#' + '<%=gvPac.ClientID %>';
            $(txtFiltro).quicksearch(grillaJedis + ' tbody tr');}
    </script>

    <script type="text/javascript">
        function cambioTxt() {
            var largoTxt = document.getElementById('<%=txtBuscar.ClientID %>').value.length;
            if (largoTxt == 0) {
                document.getElementById('divPanelListPaciente').setAttribute('style', 'display:none');
            }
            if (largoTxt > 0) {
                filtrarGrilla();
                document.getElementById('divPanelListPaciente').setAttribute('style', 'visibility:visible');
                document.getElementById('divPanelPantalla').setAttribute('style', 'display:none');
            }
        }

        function sinCaracteres(e){
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz0123456789";
            especiales = "8-37-39-46";

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

        function editarPaciente() {
            document.getElementById('<%=txtBuscar.ClientID %>').value = "";
        }

        function ocultarFormPaciente() {
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
                    <%=txtNrotarj.UniqueID%>:{
                        container: '#mensajeNroTar',
                        validators: {
                            notEmpty: {
                                message: 'Complete el nro. tarjeta'
                            }
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

    <script type="text/javascript">
        $(function () {
            $('#<%=txtFecNac.ClientID%>').datetimepicker({ viewMode: 'years',
                format: 'DD/MM/YYYY',
                //maxDate: d,
                locale: 'es'});
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" id="containerPantalla">

        <h5><font color="#3c8dbc"><b>PACIENTES</b></font></h5>
        <div class="form-group">
            <input type="text" class="form-control" id="txtBuscar" name="txtBuscar" runat="server" onkeyup="cambioTxt()" placeholder="Búscar Pacientes..." />
        </div>

        <div id="divPanelPantalla">
            <asp:Panel ID="PanelPantalla" runat="server">
                <asp:Panel ID="panelColap" runat="server">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        <div class="row">
                                            <div class="col-md-10">
                                                Datos Pesonales
                                            </div>
                                            <div class="col-md-2">
                                                <button type="button" id="btnHc" runat="server" class="btn btn-sm btn-warning ">
                                                    HC  <span class="badge">
                                                        <asp:Label ID="lblPaeId" runat="server" Text="" Visible="true"></asp:Label>
                                                    </span>
                                                </button>
                                            </div>
                                        </div>
                                    </a>
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
                                                        <input runat="server" type="text" id="txtDocumento" maxlength="8" onkeypress="return validarNum(event);" name="txtDocumento" class="form-control" placeholder="Ingresar Documento..." />
                                                        <span class="help-block" id="mensajeDocumento" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="B">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Nombre</label>
                                                        <input id="txtNombre" runat="server" type="text" maxlength="32" onkeypress="return soloLetras(event)" class="form-control" placeholder="Ingresar Nombre..." />
                                                        <span class="help-block" id="mensajeNombre" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="C">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Apellido</label>
                                                        <input id="txtApellido" runat="server" type="text" class="form-control" maxlength="32" onkeypress="return soloLetras(event)" placeholder="Ingresar Apellido..." />
                                                        <span class="help-block" id="mensajeApellido" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="D">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Télefono</label>
                                                        <input id="txtTel" type="text" runat="server" onkeypress="return validarNum(event);" maxlength="16" class="form-control" placeholder="Ingresar Teléfono..." />
                                                        <span class="help-block" id="mensajeTelefono" />
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
                                                        <input id="txtFecNac" runat="server" type="text" maxlength="10" class="form-control" placeholder="Ingresar Fecha Nacimiento..." />
                                                        <%--data-inputmask="'alias': 'dd/mm/yyyy'" data-mask />--%>
                                                        <span class="help-block" id="mensajeFecha" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="B">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Email</label>
                                                        <input id="txtMail" type="email" runat="server" maxlength="40" class="form-control" placeholder="Ingresar Email..." />
                                                        <span class="help-block" id="mensajeMail" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="C">
                                                <div class="form-group">
                                                    <div class="col-md-3">
                                                        <label class="col-md-3 control-label">Domicilio</label>
                                                        <input id="txtDire" runat="server" class="form-control" maxlength="40" onkeypress="return sinCaracteres(event)" placeholder="Ingresar Domicilio.." />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="D">
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
                                    <hr />
                                    <div class="bloque">
                                        <div class="row">
                                            <div class="col-md-9">
                                                <div class="well">
                                                    <label>Obra Social</label>
                                                    <!-- ##########################################  UPDATE PANEL (Obrea Social) ########################################## -->
                                                    <asp:UpdatePanel ID="upModalSocial" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnOSAgregar" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="gvOsocial" EventName="RowDeleting" />
                                                        </Triggers>
                                                        <ContentTemplate>
                                                            <div class="bloque">
                                                                <div class="row">
                                                                    <div class="A">
                                                                        <div class="form-group">
                                                                            <div class="col-md-6">
                                                                                <label>Lista de Obras Sociales</label>
                                                                                <asp:DropDownList ID="ddlOS" runat="server" class="form-control"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="B">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <label class="col-md- control-label">Número de Tarjeta</label>
                                                                                <input type="text" id="txtNrotarj" runat="server" onkeypress="return validarNum(event);" class="form-control" placeholder="Número de Tarjeta..." />
                                                                                <span class="help-block" id="mensajeNroTar" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="C">
                                                                        <div class="form-group">
                                                                            <div class="col-md-2">
                                                                                <br />
                                                                                <asp:Button ID="btnOSAgregar" runat="server" class="btn btn-info btn-block" Text="+" OnClick="btnObraSocial_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <hr />
                                                                <div class="row">
                                                                    <asp:GridView ID="gvOsocial" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                                                                        AutoGenerateColumns="False"
                                                                        OnRowDeleting="ObraSocialEliminarFilaGrilla"
                                                                        OnSelectedIndexChanging="ObraSocial_SelectedIndexChanging">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="OSPID" Visible="false" />
                                                                            <asp:BoundField DataField="OSOID" Visible="False" />
                                                                            <asp:BoundField DataField="OSODESCRIPCION" HeaderText="Descripción">
                                                                                <ItemStyle Width="60%" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="OSPNROSOCIO" HeaderText="Número de Tarjeta">
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
                                                    <!-- ##########################################  UPDATE PANEL (Obrea Social) ########################################## -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <%-- <asp:Label ID="lblPaeId" runat="server" Text="" ForeColor="Red" Font-Bold="True" Visible="False"></asp:Label>--%>
                                    <asp:Label ID="lblPsnId" runat="server" Text="" ForeColor="Red" Font-Bold="True" Visible="False"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Antecedentes Médicos</a>
                                </h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                <div class="panel-body">

                                    <!-- Medidas --------------------------------------------------------------------------------->
                                    <div class="bloque">
                                        <div class="row">
                                            <div class="A">
                                                <div class="col-md-4">
                                                    <div class="col-md-12">
                                                        <label>Medidas</label>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Altura</label>
                                                        <asp:DropDownList ID="ddlAltura" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Peso</label>
                                                        <asp:DropDownList ID="ddlPeso" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="B">
                                                <div class="col-md-4">
                                                    <div class="col-md-12">
                                                        <label>Tensión Arterial</label>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Mínima</label>
                                                        <asp:DropDownList ID="ddlMin" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Máxima</label>
                                                        <asp:DropDownList ID="ddlMax" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="C">
                                                <div class="col-md-4">
                                                    <div class="col-md-12">
                                                        <label style="visibility: hidden">invisible</label>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Ocupaciones</label>
                                                        <asp:DropDownList ID="ddlOcu" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Realiza Actividad</label>
                                                        <asp:DropDownList ID="ddlAct" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <!-- Antecedentes --------------------------------------------------------------------------------->
                                    <div class="well well-sm">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label>Antecedentes:</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <!-- ####################  UPDATE PANEL (Antecedentes Medicos) #################### -->
                                            <asp:Panel ID="panelAntMed" runat="server">
                                            </asp:Panel>
                                            <asp:UpdatePanel ID="UpdatePanelAntecedentes" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnOSAgregar" EventName="Click" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <!-- ####################  UPDATE PANEL (Antecedentes Medicos) #################### -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="btn-toolbar pull-right">
                    <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModalMensaje"><b>Guardar</b></button>
                    <br />
                    <br />
                </div>
            </div>
        </div>



        <!--  Modal Mensajes Confirmacion----------------------------------------------------------------------------------------------------------------->
        <div id="myModalMensaje" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal Obras Sociales -->
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #dff0d8; border-bottom-color: #d6e9c6; color: #468847;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><b>PACIENTES</b></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblMsj" runat="server" Text="Label" Font-Bold="True" class="form"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="Button1" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!--  Modal Mensajes ------------------------------------------------------------------------------------------------------------------------->

        <!--  Modal Mensajes Confirmacion----------------------------------------------------------------------------------------------------------------->
        <div id="openModalMsjGrabado" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal Obras Sociales -->
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #dff0d8; border-bottom-color: #d6e9c6; color: #468847;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><b>Paciente</b></h4>
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
                <div id="divPanelListPaciente" style="display: none">
                    <asp:Panel ID="panelListPaciente" runat="server">
                        <asp:GridView ID="gvPac" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                            AutoGenerateColumns="False"
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

                                <asp:BoundField DataField="OSPID" HeaderText="OSPID" Visible="false"></asp:BoundField>

                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Img/edit_16x16.png" ShowSelectButton="True" />

                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />

                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </asp:Panel>


    </div>

    <%--    <div class="panel-footer">
        <div class="container">
            <br />
            ( NO preguntar y NO molestar por Boludeces ) Marca que indica que aca va el panel-footer ( NO preguntar y NO molestar por Boludeces )
        </div>
    </div>--%>


    <script type="text/javascript">
        function openModalMsjGrabado() {
            $('#openModalMsjGrabado').modal({ show: true });
        }
        function openModalMsjClose() {
            $('#myModalMensaje').modal({ hide: true });
        }
    </script>

</asp:Content>
