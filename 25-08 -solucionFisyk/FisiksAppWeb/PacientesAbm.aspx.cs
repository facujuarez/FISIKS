﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FisiksAppWeb.Clases;
using FisiksAppWeb.Entities;
using FisykBLL;

namespace FisiksAppWeb
{
    public partial class PacientesAbm : Page
    {
        private static CheckBox[] arregloCheckBoxs;
        private static List<PacienteAntecedentesDto> listaAntMed;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //-----------------------------------------------------------
                //lblHC.Disabled = true;
                txtDocumento.Disabled = false;
                txtBuscar.Visible = false;
                //-----------------------------------------------------------
                //B(busqueda) - N(nuevo)
                var varEstado = Request.QueryString["e"];
                lblMsj.Text = "Desea Confirmar los datos para guardar del nuevo paciente ?";

                if (varEstado == "B")
                {
                    txtBuscar.Visible = true;

                    var script = "ocultarFormPaciente();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarFormPaciente", script, true);

                    btnConfirmar.Visible = false;

                    txtDocumento.Disabled = true;

                    lblMsj.Text = "Desea Confirmar la edición de los datos del paciente ?";
                }
                //-----------------------------------------------------------
                listaAntMed = new List<PacienteAntecedentesDto>();
                CargarGrilla();
                CargarDatosIniciales();
                ObraSocialIniFila();
            }
            else
            {
                var num = arregloCheckBoxs.Count();
                for (var i = 0; i < num; i++)
                {
                    var ckBoxs = new CheckBox();
                    ckBoxs.ID = arregloCheckBoxs[i].ID;
                    ckBoxs.Text = arregloCheckBoxs[i].Text;
                    ckBoxs.Checked = arregloCheckBoxs[i].Checked;
                    ckBoxs.AutoPostBack = true;
                    ckBoxs.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                    arregloCheckBoxs[i] = ckBoxs;
                    Form.Controls.Add(ckBoxs);
                    PlaceHolder1.Controls.Add(new LiteralControl("<div class='col-md-3'>"));
                    PlaceHolder1.Controls.Add(ckBoxs);
                    PlaceHolder1.Controls.Add(new LiteralControl("</div>"));

                    var trigger = new AsyncPostBackTrigger();
                    trigger.ControlID = ckBoxs.ID;
                    trigger.EventName = "CheckedChanged";
                    UpdatePanelAntecedentes.Triggers.Add(trigger);
                }
            }
        }

        private void ObtenerDatosPantalla(PacienteDto paciente)
        {
            #region  Persona ----------------------------------------

            paciente.PsnNroDcto = txtDocumento.Value;
            paciente.PsnNombre = txtNombre.Value;
            paciente.PsnApellido = txtApellido.Value;
            paciente.PsnFechaNac = txtFecNac.Value;
            paciente.PsnTelefono = txtTel.Value;
            paciente.PsnDomicilio = txtDire.Value;
            paciente.PsnEmail = txtMail.Value;
            if (rbM.Checked)
            {
                paciente.PsnSexo = "M";
            }
            else if (rbF.Checked)
            {
                paciente.PsnSexo = "F";
            }

            #endregion

            #region  Paciente ---------------------------------------

            var varPeso = ddlPeso.SelectedValue;
            varPeso = varPeso.Replace("Kg", "");
            paciente.PaePeso = ddlPeso.SelectedIndex != 0 ? Convert.ToInt16(varPeso) : 0;
            var varAltura = ddlAltura.SelectedValue;
            varAltura = varAltura.Replace("cm", "");
            paciente.PaeAltura = ddlAltura.SelectedIndex != 0 ? Convert.ToInt16(varAltura) : 0;

            paciente.PaeTensionMax = ddlMax.SelectedIndex != 0 ? Convert.ToInt16(ddlMax.SelectedValue) : 0;
            paciente.PaeTensionMin = ddlMin.SelectedIndex != 0 ? Convert.ToInt16(ddlMin.SelectedValue) : 0;


                //paciente.PaeActFisica = "S";
                //if (!string.IsNullOrEmpty(txtAct.Value))
                //{
                //    paciente.PaePeriodicidad = Convert.ToInt16(txtAct.Value);
                //}
         
           

            paciente.PaeOcuId = ddlOcu.SelectedIndex != 0 ? Convert.ToInt16(ddlOcu.SelectedValue) : 0;

            #endregion

            #region Obra Social ------------------------------------

            var dtOs = (DataTable)ViewState["DadaTableOS"];
            var listaObraSoc = new List<PacienteOsDto>();
            foreach (DataRow dtRow in dtOs.Rows)
            {
                var obrasSoc = new PacienteOsDto();
                obrasSoc.OspOsoId = Convert.ToInt32(dtRow[0].ToString());
                if (!string.IsNullOrEmpty(dtRow["OSPNROSOCIO"].ToString()))
                {
                    obrasSoc.OspNroSocio = Convert.ToInt64(dtRow["OSPNROSOCIO"].ToString());
                }
                listaObraSoc.Add(obrasSoc);
            }
            paciente.PaeListObraSocial = listaObraSoc;

            #endregion

            #region Antecedentes Medicos ---------------------------

            //var listaAntMed = new List<PacienteAntecedentesDto>();
            //foreach (Control c in PlaceHolder1.Controls)
            //{
            //    if (c.GetType() == typeof(CheckBox))
            //    {
            //        using (CheckBox chk = (CheckBox)c)
            //        {
            //            if (chk.Checked) { 
            //            var anteMed = new PacienteAntecedentesDto();
            //            var varAteMed = chk.ID;
            //            varAteMed = varAteMed.Replace("ContentPlaceHolder1_ckAntMed", "");
            //            anteMed.ApaAmeId = Convert.ToInt32(varAteMed);
            //            listaAntMed.Add(anteMed);
            //            }
            //        }
            //    }
            //}
            paciente.PaeListAntecedentes = listaAntMed;

            #endregion

            var varEstado = Request.QueryString["e"];
            if (varEstado == "B")
            {
                if (lblPaeId != null) paciente.PaeId = Convert.ToInt32(lblPaeId.Text);
                if (lblPsnId != null) paciente.PsnId = Convert.ToInt32(lblPsnId.Text);
            }
        }

        private void CargarDatosPantalla(PacienteDto paciente)
        {
            #region  Persona ----------------------------------------

            lblPsnId.Text = paciente.PsnId.ToString();

            txtDocumento.Value = paciente.PsnNroDcto;
            txtNombre.Value = paciente.PsnNombre;
            txtApellido.Value = paciente.PsnApellido;
            txtFecNac.Value = paciente.PsnFechaNac.ToString();
            txtTel.Value = paciente.PsnTelefono;
            txtDire.Value = paciente.PsnDomicilio;
            txtMail.Value = paciente.PsnEmail;
            switch (paciente.PsnSexo)
            {
                case "M":
                    rbM.Checked = true;
                    rbF.Checked = false;
                    break;
                case "F":
                    rbM.Checked = false;
                    rbF.Checked = true;
                    break;
            }

            #endregion

            #region  Paciente ---------------------------------------

            lblPaeId.Text = paciente.PaeId.ToString();

            if (paciente.PaePeso == 0)
            {
                ddlPeso.SelectedIndex = 0;
            }
            else
            {
                ddlPeso.SelectedValue = paciente.PaePeso + " Kg";
            }
            if (paciente.PaeAltura == 0)
            {
                ddlAltura.SelectedIndex = 0;
            }
            else
            {
                ddlAltura.SelectedValue = paciente.PaeAltura + " cm";
            }
            if (paciente.PaeTensionMax == 0)
            {
                ddlMax.SelectedIndex = 0;
            }
            else
            {
                ddlMax.SelectedValue = paciente.PaeTensionMax.ToString();
            }
            if (paciente.PaeTensionMin == 0)
            {
                ddlMin.SelectedIndex = 0;
            }
            else
            {
                ddlMin.SelectedValue = paciente.PaeTensionMin.ToString();
            }

            //if (paciente.PaeActFisica == "S")
            //{
            //    cbAct.Checked = true;
            //    txtAct.Value = paciente.PaePeriodicidad.ToString();
            //}
            //else if (paciente.PaeActFisica == "N")
            //{
            //    cbAct.Checked = false;
            //    txtAct.Value = null;
            //}

            if (paciente.PaeOcuId == 0)
            {
                ddlPeso.SelectedIndex = 0;
            }
            else
            {
                ddlOcu.SelectedValue = Convert.ToString(paciente.PaeOcuId);
            }


            #endregion

            #region Obra Social ------------------------------------
            try
            {
                ObraSocialIniFila();

                var dtOs = (DataTable)ViewState["DadaTableOS"];

                var listaObraSoc = ManagerObraSociales.ListObraSocialesPaciente(paciente.PaeId);
                var dtCurrentTable = (DataTable)ViewState["DadaTableOS"];
                foreach (var los in listaObraSoc)
                {
                    DataRow drCurrentRow = null;
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["OSOID"] = los.OspId;
                    drCurrentRow["OSODESCRIPCION"] = los.OsoDescripcion;
                    drCurrentRow["OSPNROSOCIO"] = los.OspNroSocio;

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["DadaTableOS"] = dtCurrentTable;
                }

                gvOsocial.DataSource = dtCurrentTable;
                gvOsocial.DataBind();

                ddlOS.DataSource = dtCurrentTable;
                ddlOS.DataValueField = "OSOID";
                ddlOS.DataTextField = "OSODESCRIPCION";
                ddlOS.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Obras Sociales','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
            #endregion

            #region Antecedentes Medicos ---------------------------

            for (var i = 0; i < arregloCheckBoxs.Count(); i++)
            {
                arregloCheckBoxs[i].Checked = false;
            }

            var listaAteMedPacientes = ManagerAntecedentesMedicos.ListAntecedenteMedicoPaciente(paciente.PaeId);
            for (var i = 0; i < arregloCheckBoxs.Count(); i++)
            {
                foreach (var lam in listaAteMedPacientes)
                {
                    var varAteMed = arregloCheckBoxs[i].ID;
                    varAteMed = varAteMed.Substring(varAteMed.Length - 2, 2);

                    if (Convert.ToInt32(varAteMed) == lam.AmeId)
                    {
                        arregloCheckBoxs[i].Checked = true;

                        var anteMed = new PacienteAntecedentesDto();
                        //varAteMed = varAteMed.Replace("ContentPlaceHolder1_ckAntMed", "");
                        //varAteMed = varAteMed.Substring(varAteMed.Length - 2, 2);
                        //varAteMed = varAteMed.Replace("ContentPlaceHolder1_", "");
                        anteMed.ApaAmeId = Convert.ToInt32(varAteMed);
                        listaAntMed.Add(anteMed);
                    }
                }
            }

            #endregion
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var script = "editarPaciente();";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "editarPaciente", script, true);

            var varPac = gvPac.SelectedRow.Cells[0].Text;

            if (!string.IsNullOrEmpty(varPac))
            {
                var pac = new PacienteDto();
                pac = ManagerPacientes.ExistePaciente(varPac);
                if (pac != null)
                {
                    lbl.Text = "Existe";
                    CargarDatosPantalla(pac);
                    PanelPantalla.Visible = true;
                    btnConfirmar.Visible = true;
                }
            }
        }

        #region Cargar Datos Iniciales

        private void CargarDatosIniciales()
        {
            //________________________________________________________________________________________________________
            //  Cargar Altura
            var altura = PublicData.ArrayAltura();
            ddlAltura.DataSource = altura;
            ddlAltura.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Peso
            var peso = PublicData.ArrayPeso();
            ddlPeso.DataSource = peso;
            ddlPeso.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Maxima
            var max = PublicData.ArrayMaxMin();
            ddlMax.DataSource = max;
            ddlMax.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Minima
            var min = PublicData.ArrayMaxMin();
            ddlMin.DataSource = min;
            ddlMin.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Ocupaciones
            try
            {
                ddlOcu.DataSource = ManagerOcupaciones.ListOcupaciones();
                ddlOcu.DataValueField = "ocuId";
                ddlOcu.DataTextField = "ocuDescripcion";
                ddlOcu.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Ocupaciones','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }


            //________________________________________________________________________________________________________
            //  Cargar Obra Sociales
            try
            {
                ddlOS.DataSource = ManagerObraSociales.ListObraSociales();
                ddlOS.DataValueField = "osoId";
                ddlOS.DataTextField = "osoDescripcion";
                ddlOS.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Obras Sociales','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }

            //________________________________________________________________________________________________________
            //  Cargar Check Antecedentes Medicos
            try
            {
                CargaAntecedentesMedicos();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Antecedentes Médicos','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        private void CargaAntecedentesMedicos()
        {
            var listAntMed = ManagerAntecedentesMedicos.ListAntecedenteMedico();
            arregloCheckBoxs = new CheckBox[listAntMed.Count];
            var nroPos = 0;
            foreach (var antemed in listAntMed)
            {
                var ckBoxs = new CheckBox();
                var ameid = antemed.AmeId.ToString();
                if (ameid.Length == 1){
                    ameid = "0" + ameid;
                }
                ckBoxs.ID = "ckAntMed" +ameid.ToString();
                ckBoxs.Text = " " + antemed.AmeDescripcion.ToString();
                ckBoxs.AutoPostBack = true;
                ckBoxs.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                arregloCheckBoxs[nroPos] = ckBoxs;
                Form.Controls.Add(ckBoxs);
                PlaceHolder1.Controls.Add(new LiteralControl("<div class='col-md-3'>"));
                PlaceHolder1.Controls.Add(ckBoxs);
                PlaceHolder1.Controls.Add(new LiteralControl("</div>"));

                var trigger = new AsyncPostBackTrigger();
                trigger.ControlID = ckBoxs.ID;
                trigger.EventName = "CheckedChanged";
                UpdatePanelAntecedentes.Triggers.Add(trigger);

                nroPos++;
            }
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //write the client id of the control that triggered the event
            //Response.Write(((CheckBox) sender).ClientID);
            var chk = (CheckBox)sender;
            chk.ID = ((CheckBox)sender).ClientID;
            //var i = 0;
            //foreach (var ck in arregloCheckBoxs)
            //{
            //    if (ckPant.Text == ck.Text)
            //    {
            //        arregloCheckBoxs[i].Checked = true;
            //    }
            //    i++;
            //}

            //foreach (Control c in PlaceHolder1.Controls)
            //{
            //    if (c.GetType() == typeof(CheckBox))
            //    {
            //        using (CheckBox chk = (CheckBox)c)
            //        {
            var anteMed = new PacienteAntecedentesDto();
            var varAteMed = chk.ID;
            varAteMed = varAteMed.Substring(varAteMed.Length - 2, 2);
            //varAteMed = varAteMed.Replace("ContentPlaceHolder1_ckAntMed", "");
            //varAteMed = varAteMed.Replace("ContentPlaceHolder1_", "");
            anteMed.ApaAmeId = Convert.ToInt32(varAteMed);
            if (chk.Checked)
            {
                var flag = new int();
                flag = 0;


                if (listaAntMed == null)
                {
                    listaAntMed.Add(anteMed);
                }
                else
                {
                    foreach (PacienteAntecedentesDto antecedente in listaAntMed)
                    {
                        if (antecedente.ApaAmeId == anteMed.ApaAmeId)
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        listaAntMed.Add(anteMed);
                    }
                }
                //var cont = listaAntMed.Count;
            }
            else
            {
                foreach (PacienteAntecedentesDto antecedente in listaAntMed)
                {
                    if (antecedente.ApaAmeId == anteMed.ApaAmeId)
                    {
                        listaAntMed.Remove(antecedente);
                        break;
                    }
                }
            }
            //        }
            //    }
            //}
        }

        private void CargarGrilla()
        {
            try
            {
                gvPac.DataSource = ManagerPacientes.ListPaciente();
                gvPac.DataBind();

                gvPac.UseAccessibleHeader = true;
                gvPac.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception e)
            {
                //estaria bueno guardar los errores
                //algo asi como erroresLog(id, decripcion, pantalla/metodo, fecha/hora)
                var script = "showAlert('Error al cargar Grilla Paciente','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);

            }
            finally
            { //lineas de codigo que se deben ejecutar siempre
                //prueba  -> Anda el sowAlert a nivel masterpage, es accesible desde cualquier pantalla!!!
                //var script = "showAlert('Carga Exitosa Grilla Paciente','1');";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        #endregion

        #region Manejo de Obra Sociales

        private void ObraSocialIniFila()
        {
            try
            {
                ViewState["DadaTableOS"] = null;
                //Obra Social
                var dtObraSoc = new DataTable();
                dtObraSoc.Columns.Add(new DataColumn("OSOID", typeof(int)));
                dtObraSoc.Columns.Add(new DataColumn("OSODESCRIPCION", typeof(string)));
                dtObraSoc.Columns.Add(new DataColumn("OSPNROSOCIO", typeof(string)));

                ViewState["DadaTableOS"] = dtObraSoc;

                gvOsocial.DataSource = dtObraSoc;
                gvOsocial.DataBind();

                ddlOS.DataSource = dtObraSoc;
                ddlOS.DataBind();

                ddlOS.DataSource = dtObraSoc;
                ddlOS.DataValueField = "OSOID";
                ddlOS.DataTextField = "OSODESCRIPCION";
                ddlOS.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Obras Sociales','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        protected void btnObraSocial_Click(object sender, EventArgs e)
        {
            if (ddlOS.SelectedIndex != 0)
            {
                ObraSocialAgregarFilaGrilla();
            }
        }

        private void ObraSocialAgregarFilaGrilla()
        {
            try
            {
                if (ViewState["DadaTableOS"] != null)
                {
                    //lblMsjObrasocial.Text = null;
                    //lblMsjObrasocial.Visible = false;
                    var dtCurrentTable = (DataTable)ViewState["DadaTableOS"];
                    //recorro la tabla para saber si se agrego otra OS igual
                    var controlExiste = false;
                    foreach (DataRow fila in dtCurrentTable.Rows)
                    {
                        if (fila["OSOID"].ToString() == ddlOS.SelectedValue)
                        {
                            //lblMsjObrasocial.Visible = true;
                            //lblMsjObrasocial.Text =
                                //"Verifique los datos,  ya existe una Obra Social con distintos Número de Socio.";

                            if (fila["OSOID"].ToString() == ddlOS.SelectedValue &&
                                fila["OSPNROSOCIO"].ToString() == txtNrotarj.Value)
                            {
                                controlExiste = true;
                                //lblMsjObrasocial.Text =
                                    //"Verifique los datos, ya existe una Obra Social con el mismo Número de Socio.";
                                break;
                            }
                        }
                    }
                    if (ddlOS.SelectedIndex == 0)
                    {
                        //lblMsjObrasocial.Visible = true;
                        //lblMsjObrasocial.Text =
                                    //"Seleccione una Obra social de la lista.";
                        controlExiste = true;
                    }
                    if (controlExiste == false)
                    {
                        DataRow drCurrentRow = null;
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["OSOID"] = ddlOS.SelectedItem.Value;
                        drCurrentRow["OSODESCRIPCION"] = ddlOS.SelectedItem.Text;
                        if (!string.IsNullOrEmpty(txtNrotarj.Value))
                        {
                            drCurrentRow["OSPNROSOCIO"] = txtNrotarj.Value;
                        }
                        else
                        {
                            drCurrentRow["OSPNROSOCIO"] = "0";
                        }

                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["DadaTableOS"] = dtCurrentTable;

                        ddlOS.SelectedIndex = 0;
                        txtNrotarj.Value = null;
                    }

                    gvOsocial.DataSource = dtCurrentTable;
                    gvOsocial.DataBind();

                    ddlOS.DataSource = dtCurrentTable;
                    ddlOS.DataValueField = "OSOID";
                    ddlOS.DataTextField = "OSODESCRIPCION";
                    ddlOS.DataBind();
                }
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al Agregar Obra Social a Lista','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        protected void ObraSocialEliminarFilaGrilla(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //lblMsjObrasocial.Text = null;
                //lblMsjObrasocial.Visible = false;

                var index = Convert.ToInt32(e.RowIndex);
                var dt = ViewState["DadaTableOS"] as DataTable;
                if (dt.Rows.Count > 1)
                {
                    dt.Rows[index].Delete();
                    ViewState["DadaTableOS"] = dt;
                    ObraSocialBindGrid();
                }
                else
                {
                    ObraSocialIniFila();
                }
            }
            catch (Exception ex)
            {
                var script = "showAlert('Error al Eliminar Obra Social de Grilla','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        protected void ObraSocial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (gvOsocial.Rows.Count > 0)
            {
                ddlOS.SelectedValue = gvOsocial.Rows[e.NewSelectedIndex].Cells[0].Text;
                txtNrotarj.Value = gvOsocial.Rows[e.NewSelectedIndex].Cells[2].Text;
            }
        }

        protected void ObraSocialBindGrid()
        {
            gvOsocial.DataSource = ViewState["DadaTableOS"] as DataTable;
            gvOsocial.DataBind();
            gvOsocial.UseAccessibleHeader = true;
            gvOsocial.HeaderRow.TableSection = TableRowSection.TableHeader;

            ddlOS.DataSource = ViewState["DadaTableOS"] as DataTable;
            ddlOS.DataValueField = "OSOID";
            ddlOS.DataTextField = "OSODESCRIPCION";
            ddlOS.DataBind();
        }

        #endregion

        private void Limpiar()
        {
            lblPaeId.Text = null;
            lblPsnId.Text = null;

            txtDocumento.Value = null;
            txtNombre.Value = null;
            txtApellido.Value = null;
            //lblHC.Value = null;
            txtFecNac.Value = null;
            txtTel.Value = null;
            txtDire.Value = null;
            txtMail.Value = null;
            listaAntMed.Clear();

            rbM.Checked = true;

            ObraSocialIniFila();
            ddlOcu.SelectedIndex = 0;

            ddlAltura.SelectedIndex = 0;
            ddlPeso.SelectedIndex = 0;
            ddlMax.SelectedIndex = 0;
            ddlMin.SelectedIndex = 0;

            for (var i = 0; i < arregloCheckBoxs.Count(); i++)
            {
                arregloCheckBoxs[i].Checked = false;
            }

            txtAct.Value = null;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var personaPaciente = new PacienteDto();
                ObtenerDatosPantalla(personaPaciente);
                var varEstado = Request.QueryString["e"];
                if (varEstado == "N")
                {
                    String error = null;
                    ManagerPacientes.GrabarPacienteInsert(ref personaPaciente, ref error);
                    if (error == null)
                    {
                        var script = "showAlert('Paciente Guardado','1');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                        Limpiar();
                    }
                    else
                    {
                        var script = "showAlert('Error al grabar','2');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                    }
                }

                else if (varEstado == "B")
                {
                    string error = null;
                    ManagerPacientes.GrabarPacienteUpdate(ref personaPaciente);//, ref error);
                    if (error == null)
                    {
                        var script = "showAlert('Paciente Actualizado','1');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                        Limpiar();
                        var script2 = "ocultarFormPaciente();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarFormPaciente", script2, true);
                    }
                }
            }
            else
            {
                var script = "showAlert('Campos Incorrectos','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }
    }
}


