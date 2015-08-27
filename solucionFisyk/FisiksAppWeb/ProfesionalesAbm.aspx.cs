using System;
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
    public partial class ProfesionalesAbm : Page
    {
        private static CheckBox[] arregloCheckBoxs;
        private static List<ProfesionalEspecialidadesDto> listaEspecialidades;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //-----------------------------------------------------------
                txtBuscar.Visible = false;
                ddlEstado.Visible = false;
                lblEstado.Visible = false;
                //-----------------------------------------------------------
                //B(busqueda) - N(nuevo)
                var varEstado = Request.QueryString["e"];
                lblMsj.Text = " Confirmar los datos del nuevo Kinesiólogo ?";
                if (varEstado == "B")
                {
                    txtBuscar.Visible = true;

                    ddlEstado.Visible = true;
                    lblEstado.Visible = true;

                    PanelBusqueda.Visible = true;
                    PanelPantalla.Visible = false;

                    var script = "ocultarFormPaciente();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarFormProfesional", script, true);

                    btnConfirmar.Visible = false;

                    lblMsj.Text = " Confirmar la edición del Kinesiólogo ?";
                }
                //-----------------------------------------------------------
                listaEspecialidades = new List<ProfesionalEspecialidadesDto>();
                CargarGrilla();
                CargarDatosIniciales();
                AgendaIniFila();
                MatriculaIniFila();
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
                    PlaceHolder1.Controls.Add(new LiteralControl("<div class='col-md-4'>"));
                    PlaceHolder1.Controls.Add(ckBoxs);
                    PlaceHolder1.Controls.Add(new LiteralControl("</div>"));

                    var trigger = new AsyncPostBackTrigger();
                    trigger.ControlID = ckBoxs.ID;
                    trigger.EventName = "CheckedChanged";
                    UpdatePanelEspecialidades.Triggers.Add(trigger);
                }
            }
        }

        private void ObtenerDatosPantalla(ProfesionalDto profesional)
        {
            #region  Persona -----------------------------------------

            string aux;
            profesional.PsnNroDcto = txtDocumento.Value;
            if (!string.IsNullOrEmpty(txtNombre.Value)) { aux = txtNombre.Value; profesional.PsnNombre = aux.ToUpper(); }
            if (!string.IsNullOrEmpty(txtApellido.Value)) { aux = txtApellido.Value; profesional.PsnApellido = aux.ToUpper(); }
            profesional.PsnFechaNac = txtFecNac.Value;
            profesional.PsnTelefono = txtTel.Value;
            if (!string.IsNullOrEmpty(txtDire.Value)) { aux = txtDire.Value; profesional.PsnDomicilio = aux.ToUpper(); }
            if (!string.IsNullOrEmpty(txtMail.Value)) { aux = txtMail.Value; profesional.PsnEmail = aux.ToUpper(); }
            if (rbM.Checked) { profesional.PsnSexo = "M"; } else if (rbF.Checked) { profesional.PsnSexo = "F"; }
            profesional.ProActivo = "S";

            #endregion

            #region Matriculas --------------------------------------
            if (ViewState["DadaTableMat"] != null)
            {
                var dtMat = (DataTable)ViewState["DadaTableMat"];
                var listaMatricula = new List<ProfesionalMatriculaDto>();
                foreach (DataRow dtRow in dtMat.Rows)
                {
                    var matricula = new ProfesionalMatriculaDto();
                    if (!DBNull.Value.Equals(dtRow[0]))
                    {
                        matricula.PmtId = Convert.ToInt32(dtRow[0].ToString());
                    }
                    matricula.PmtMttId = Convert.ToInt32(dtRow[1].ToString());
                    if (!DBNull.Value.Equals(dtRow["PMTNRO"]))
                    {
                        matricula.PmtNro = dtRow["PMTNRO"].ToString();
                    }
                    listaMatricula.Add(matricula);
                }
                profesional.ProListMatriculas = listaMatricula;
            }
            #endregion

            #region Especialidades ----------------------------------

            profesional.ProListEspecialidades = listaEspecialidades;

            #endregion

            #region Agenda ------------------------------------------
            if (ViewState["DataTableAge"] != null)
            {
                var dtAge = (DataTable)ViewState["DataTableAge"];
                var listaAgenda = new List<AgendaDto>();
                foreach (DataRow dtRow in dtAge.Rows)
                {
                    var agenda = new AgendaDto();
                    if (!DBNull.Value.Equals(dtRow[0])) { agenda.AgeId = Convert.ToInt32(dtRow[0].ToString()); }
                    agenda.AgeDiaId = Convert.ToInt32(dtRow[1].ToString());
                    // Descripcion del tipo de dia = dtRow[2].ToString()
                    agenda.AgeHoraDesde = dtRow[3].ToString();
                    agenda.AgeHoraHasta = dtRow[4].ToString();
                    listaAgenda.Add(agenda);
                }
                profesional.ProListAgenda = listaAgenda;
            }
            #endregion

            var varEstado = Request.QueryString["e"];
            if (varEstado == "B")
            {
                if (lblProId != null) profesional.ProId = Convert.ToInt32(lblProId.Text);
                if (lblPsnId != null) profesional.PsnId = Convert.ToInt32(lblPsnId.Text);

                var opcionSeleccionada = ddlEstado.SelectedItem.ToString();
                if (opcionSeleccionada == "NO")
                    profesional.ProActivo = "N";
                else
                    profesional.ProActivo = "S";
            }
        }

        private void CargarDatosPantalla(ProfesionalDto profesional)
        {
            #region  Persona ----------------------------------------

            lblPsnId.Text = profesional.PsnId.ToString();

            txtDocumento.Value = profesional.PsnNroDcto;
            txtNombre.Value = profesional.PsnNombre;
            txtApellido.Value = profesional.PsnApellido;
            txtFecNac.Value = profesional.PsnFechaNac;
            txtTel.Value = profesional.PsnTelefono;
            txtDire.Value = profesional.PsnDomicilio;
            txtMail.Value = profesional.PsnEmail;
            switch (profesional.PsnSexo)
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

            #region  Profesional ------------------------------------

            lblProId.Text = profesional.ProId.ToString();

            #endregion

            #region Especialidad ---------------------------

            for (var i = 0; i < arregloCheckBoxs.Count(); i++)
            {
                arregloCheckBoxs[i].Checked = false;
            }

            var listaespecialPeorfesional = ManagerEspecialidades.ListEspecialidadProfesional(profesional.ProId);
            for (var i = 0; i < arregloCheckBoxs.Count(); i++)
            {
                foreach (var le in listaespecialPeorfesional)
                {
                    var varEsp = arregloCheckBoxs[i].ID;
                    varEsp = varEsp.Substring(varEsp.Length - 2, 2);

                    if (Convert.ToInt32(varEsp) == le.EspId)
                    {
                        arregloCheckBoxs[i].Checked = true;

                        var especial = new ProfesionalEspecialidadesDto();
                        especial.PepEpcId = Convert.ToInt32(varEsp);
                        listaEspecialidades.Add(especial);
                    }
                }
            }

            #endregion

            #region Matricula --------------------------------------
            try
            {
                MatriculaIniFila();
                var dtMat = (DataTable)ViewState["DadaTableMat"];
                var listaMat = ManagerProfesionalMatriculas.ListProfesionalMatricula(profesional.ProId);
                var dtCurrentTable = (DataTable)ViewState["DadaTableMat"];
                foreach (var lm in listaMat)
                {
                    DataRow drCurrentRow;
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["PMT_MTTID"] = lm.PmtMttId;
                    drCurrentRow["MTTDESCRIPCION"] = lm.MttDescripcion;
                    if (!string.IsNullOrEmpty(lm.PmtNro))
                    {
                        drCurrentRow["PMTNRO"] = lm.PmtNro;
                    }
                    else
                    {
                        drCurrentRow["PMTNRO"] = "0";
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["DadaTableMat"] = dtCurrentTable;
                }
                gvMat.DataSource = dtMat;
                gvMat.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Matrícula','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
            #endregion

            #region Agenda -----------------------------------------
            try
            {
                AgendaIniFila();
                var dtAge = (DataTable)ViewState["DataTableAge"];
                var listaAge = ManagerAgendas.ListAgendaProfesional(profesional.ProId);
                var dtCurrentTable = (DataTable)ViewState["DataTableAge"];
                foreach (var la in listaAge)
                {
                    DataRow drCurrentRow;
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow[1] = la.AgeDiaId;
                    drCurrentRow[2] = la.DiaDescripcion;
                    drCurrentRow[3] = la.AgeHoraDesde;
                    drCurrentRow[4] = la.AgeHoraHasta;

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["DataTableAge"] = dtCurrentTable;
                }
                gvAgenda.DataSource = dtAge;
                gvAgenda.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Agenda','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
            #endregion
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var script = "editarProfesional();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "editarProfesional", script, true);
            var varPro = gvPro.SelectedRow.Cells[0].Text;
            if (!string.IsNullOrEmpty(varPro))
            {
                var pro = new ProfesionalDto();
                pro = ManagerProfesional.ExisteProfesional(varPro);
                if (pro != null)
                {
                    lbl.Text = "Existe";
                    CargarDatosPantalla(pro);
                    PanelPantalla.Visible = true;
                    btnConfirmar.Visible = true;
                }
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var opcionSeleccionada = ddlEstado.SelectedItem.ToString();
            if (opcionSeleccionada == "NO")
            {
                BloquearCampos();
                ViewState["Bloquear"] = "Si";
                lblMsj.Text = "Desea Confirmar Bloquear al profesional ?";
            }
            else
            {
                DesbloquearCampos();
                ViewState["Bloquear"] = "No";
                lblMsj.Text = "Desea Confirmar la edición de los datos del paciente ?";
            }
        }

        #region ----------- Cargar Datos Iniciales -------------

        private void CargarGrilla()
        {
            try
            {
                gvPro.DataSource = ManagerProfesional.ListProfesional();
                gvPro.DataBind();
                if (gvPro.Rows.Count > 0)
                {
                    gvPro.UseAccessibleHeader = true;
                    gvPro.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Grilla Kinesiologo','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        private void CargarDatosIniciales()
        {
            //________________________________________________________________________________________________________
            //  Cargar Dias Laborales
            var dias = PublicData.ArrayDiasLaborales();
            ddlDias.DataSource = dias;
            ddlDias.DataBind();
            //  Cargar  Lista de Horas - Hora Desde
            ddlHoraDesde.DataSource = PublicData.ArrayListaDeHoras();
            ddlHoraDesde.DataBind();
            //  Cargar  Lista de Horas - Hora hasta
            ddlHoraHasta.DataSource = PublicData.ArrayListaDeHoras();
            ddlHoraHasta.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Tipo de Matriculas
            try
            {
                ddlMat.DataSource = ManagerMatriculaTipo.ListMatriculaTipo();
                ddlMat.DataValueField = "mttId";
                ddlMat.DataTextField = "mttDescripcion";
                ddlMat.DataBind();
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar Tipos de Matriculas.','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
            //________________________________________________________________________________________________________
            //  Cargar Check Especialidades profesionales
            ddlEstado.Items.Add("SI");
            ddlEstado.Items.Add("NO");

            //________________________________________________________________________________________________________
            //  Cargar Check Especialidades
            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            try
            {
                var listEsp = ManagerEspecialidades.ListEspecialidades();
                arregloCheckBoxs = new CheckBox[listEsp.Count];
                var nroPos = 0;
                foreach (var espcial in listEsp)
                {
                    var ckBoxs = new CheckBox();
                    var espid = espcial.EspId.ToString();
                    if (espid.Length == 1)
                    {
                        espid = "0" + espid;
                    }
                    ckBoxs.ID = "ckEsp" + espid.ToString();
                    ckBoxs.Text = " " + espcial.EspDescripcion.ToString();
                    ckBoxs.AutoPostBack = true;
                    ckBoxs.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                    arregloCheckBoxs[nroPos] = ckBoxs;
                    Form.Controls.Add(ckBoxs);

                    PlaceHolder1.Controls.Add(new LiteralControl("<div class='col-md-4'>"));
                    PlaceHolder1.Controls.Add(ckBoxs);
                    PlaceHolder1.Controls.Add(new LiteralControl("</div>"));

                    var trigger = new AsyncPostBackTrigger();
                    trigger.ControlID = ckBoxs.ID;
                    trigger.EventName = "CheckedChanged";
                    UpdatePanelEspecialidades.Triggers.Add(trigger);

                    nroPos++;
                }
            }
            catch (Exception e)
            {
                var script = "showAlert('Error al cargar las Especialidades','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            chk.ID = ((CheckBox)sender).ClientID;
            var especial = new ProfesionalEspecialidadesDto();
            var varEsp = chk.ID;
            varEsp = varEsp.Substring(varEsp.Length - 2, 2);
            especial.PepEpcId = Convert.ToInt32(varEsp);
            if (chk.Checked)
            {
                var flag = new int();
                flag = 0;
                if (listaEspecialidades == null)
                {
                    listaEspecialidades.Add(especial);
                }
                else
                {
                    foreach (ProfesionalEspecialidadesDto especialidad in listaEspecialidades)
                    {
                        if (especialidad.PepEpcId == especial.PepEpcId)
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        listaEspecialidades.Add(especial);
                    }
                }
            }
            else
            {
                foreach (ProfesionalEspecialidadesDto especialidad in listaEspecialidades)
                {
                    if (especialidad.PepEpcId == especial.PepEpcId)
                    {
                        listaEspecialidades.Remove(especial);
                        break;
                    }
                }
            }
        }

        #endregion

        #region ----------- Manejo de Agenda Laboral -----------

        private void AgendaIniFila()
        {
            ViewState["DataTableAge"] = null;//Agenda
            var dtAgenda = new DataTable();
            dtAgenda.Columns.Add(new DataColumn("AGEID", typeof(int)));
            dtAgenda.Columns.Add(new DataColumn("AGE_DIAID", typeof(string)));
            dtAgenda.Columns.Add(new DataColumn("DIADESCRIPCION", typeof(string)));
            dtAgenda.Columns.Add(new DataColumn("AGEHORADESDE", typeof(string)));
            dtAgenda.Columns.Add(new DataColumn("AGEHORAHASTA", typeof(string)));
            dtAgenda.Columns.Add(new DataColumn("AGE_PROID", typeof(string)));

            ViewState["DataTableAge"] = dtAgenda;

            gvAgenda.DataSource = dtAgenda;
            gvAgenda.DataBind();
        }

        protected void btnAgeAgregar_Click(object sender, EventArgs e)
        {
            lblMsjAgenda.Visible = false;
            lblMsjAgenda.Text = null;
            if (ddlDias.SelectedIndex != 0)
            {
                if (ddlHoraDesde.SelectedIndex != 0)
                {
                    if (ddlHoraHasta.SelectedIndex != 0)
                    {
                        AgendaAgregarFilaGrilla();
                    }
                }
            }
        }

        private void AgendaAgregarFilaGrilla()
        {
            if (ViewState["DataTableAge"] != null)
            {
                lblMsjAgenda.Text = null;
                lblMsjAgenda.Visible = false;
                var dtCurrentTable = (DataTable)ViewState["DataTableAge"];
                //recorro la tabla para saber si se agrego otro dia igual
                var controlExiste = false;

                #region Controles
                if (ddlHoraDesde.SelectedIndex == 0 || ddlHoraHasta.SelectedIndex == 0)
                {
                    lblMsjAgenda.Visible = true;
                    lblMsjAgenda.Text = "Verifique, debe selecionar un horario.";
                    controlExiste = true;
                }
                if (ddlHoraDesde.SelectedIndex != 0 && ddlHoraHasta.SelectedIndex != 0)
                {
                    DateTime h1 = Convert.ToDateTime(ddlHoraDesde.SelectedItem.Value);
                    DateTime h2 = Convert.ToDateTime(ddlHoraHasta.SelectedItem.Value);

                    TimeSpan span = h2.Subtract(h1);
                    Int32 diff = Convert.ToInt32(span.TotalMinutes);
                    if (diff <= 0)
                    {
                        lblMsjAgenda.Visible = true;
                        lblMsjAgenda.Text = "Verifique, la hora Desde es mayor o igual a la hora hasta.";
                        controlExiste = true;
                    }
                }
                if (ddlDias.SelectedIndex == 0)
                {
                    lblMsjAgenda.Visible = true;
                    lblMsjAgenda.Text = "Seleccione un Día para la Agenda Laboral.";
                    controlExiste = true;
                }

                if (ddlDias.SelectedIndex == 0 && ddlHoraDesde.SelectedIndex == 0 && ddlHoraHasta.SelectedIndex == 0)
                {
                    lblMsjAgenda.Visible = true;
                    lblMsjAgenda.Text = "Verifique, se debe selecionar un día y horario para la Agenda Laboral.";
                    controlExiste = true;
                }

                if (ddlDias.SelectedIndex == 0 && ddlHoraDesde.SelectedIndex != 0 && ddlHoraHasta.SelectedIndex != 0)
                {
                    lblMsjAgenda.Visible = true;
                    lblMsjAgenda.Text = "Verifique, se debe selecionar un día para la Agenda Laboral.";
                    controlExiste = true;
                }
                else if (ddlDias.SelectedIndex == 0 && ddlHoraDesde.SelectedIndex != 0 && ddlHoraHasta.SelectedIndex != 0)
                {
                    lblMsjAgenda.Visible = true;
                    lblMsjAgenda.Text = "Verifique, se debe selecionar un día para la Agenda Laboral.";
                    controlExiste = true;
                }
                else if (ddlDias.SelectedIndex != 0 && (ddlHoraDesde.SelectedIndex == 0 || ddlHoraHasta.SelectedIndex == 0))
                {
                    lblMsjAgenda.Visible = true;
                    lblMsjAgenda.Text = "Verifique, se debe selecionar un horario para la Agenda Laboral.";
                    controlExiste = true;
                }
                #endregion

                if (ddlDias.SelectedValue == "TODOS")
                {
                    var arrayDias = PublicData.ArrayDiasLaborales();
                    int indexDia = 0;
                    foreach (var varDia in arrayDias)
                    {
                        if (varDia.ToString() != "TODOS" && varDia.ToString() != "Elegir...")
                        {
                            foreach (DataRow fila in dtCurrentTable.Rows)
                            {
                                if (Convert.ToInt32(fila["AGE_DIAID"].ToString()) == indexDia)// mismo dias
                                {
                                    DateTime horaDesdeTime = Convert.ToDateTime(fila["AGEHORADESDE"].ToString());
                                    DateTime horaHastaTime = Convert.ToDateTime(fila["AGEHORAHASTA"].ToString());

                                    DateTime horaDesdeSelecTime = Convert.ToDateTime(ddlHoraDesde.SelectedItem.Value);
                                    DateTime horaHastaSelecTime = Convert.ToDateTime(ddlHoraHasta.SelectedItem.Value);

                                    if (horaHastaSelecTime > horaDesdeTime && horaDesdeSelecTime < horaHastaTime)
                                    {
                                        lblMsjAgenda.Visible = true;
                                        lblMsjAgenda.Text = "Se tiene uan superpocision de horarios.";
                                        controlExiste = true;
                                    }
                                }
                            }
                        }
                        indexDia++;
                    }
                }
                else
                {
                    foreach (DataRow fila in dtCurrentTable.Rows)
                    {
                        if (Convert.ToInt32(fila["AGE_DIAID"].ToString()) == ddlDias.SelectedIndex)// mismo dias
                        {
                            DateTime horaDesdeTime = Convert.ToDateTime(fila["AGEHORADESDE"].ToString());
                            DateTime horaHastaTime = Convert.ToDateTime(fila["AGEHORAHASTA"].ToString());

                            DateTime horaDesdeSelecTime = Convert.ToDateTime(ddlHoraDesde.SelectedItem.Value);
                            DateTime horaHastaSelecTime = Convert.ToDateTime(ddlHoraHasta.SelectedItem.Value);

                            if (horaHastaSelecTime > horaDesdeTime && horaDesdeSelecTime < horaHastaTime)
                            {
                                lblMsjAgenda.Visible = true;
                                lblMsjAgenda.Text = "Se tiene uan superpoSiCión de horarios.";
                                controlExiste = true;
                            }
                        }
                    }
                }

                if (controlExiste == false)
                {
                    //-------------------------------------------------------------------------------------------
                    if (ddlDias.SelectedValue == "TODOS")
                    {
                        var arrayDias = PublicData.ArrayDiasLaborales();
                        int indexDia = 0;
                        foreach (var varDia in arrayDias)
                        {
                            if (varDia.ToString() != "TODOS" && varDia.ToString() != "Elegir...")
                            {
                                DataRow drCurrentRow;
                                drCurrentRow = dtCurrentTable.NewRow();

                                drCurrentRow["AGE_DIAID"] = indexDia;
                                drCurrentRow["DIADESCRIPCION"] = varDia.ToString();

                                drCurrentRow["AGEHORADESDE"] = ddlHoraDesde.SelectedItem.Value;
                                drCurrentRow["AGEHORAHASTA"] = ddlHoraHasta.SelectedItem.Value;

                                dtCurrentTable.Rows.Add(drCurrentRow);
                                ViewState["DataTableAge"] = dtCurrentTable;

                                DataTable ordenDataTable = ViewState["DataTableAge"] as DataTable;
                                DataView dv = ordenDataTable.DefaultView;
                                dv.Sort = "AGE_DIAID, AGEHORADESDE, AGEHORAHASTA";
                                ordenDataTable = dv.ToTable();

                                ViewState["DataTableAge"] = ordenDataTable;
                            }
                            indexDia++;
                        }
                        lblMsjAgenda.Visible = false;
                        lblMsjAgenda.Text = null;
                    }
                    //-------------------------------------------------------------------------------------------
                    else
                    {
                        DataRow drCurrentRow;
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["AGE_DIAID"] = ddlDias.SelectedIndex;
                        drCurrentRow["DIADESCRIPCION"] = ddlDias.SelectedItem.Value;

                        drCurrentRow["AGEHORADESDE"] = ddlHoraDesde.SelectedItem.Value;
                        drCurrentRow["AGEHORAHASTA"] = ddlHoraHasta.SelectedItem.Value;

                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["DataTableAge"] = dtCurrentTable;

                        DataTable ordenDataTable = ViewState["DataTableAge"] as DataTable;
                        DataView dv = ordenDataTable.DefaultView;
                        dv.Sort = "AGE_DIAID, AGEHORADESDE, AGEHORAHASTA";
                        ordenDataTable = dv.ToTable();

                        ViewState["DataTableAge"] = ordenDataTable;

                        lblMsjAgenda.Visible = false;
                        lblMsjAgenda.Text = null;
                    }
                }
                ddlDias.SelectedIndex = 0;
                ddlHoraDesde.SelectedIndex = 0;
                ddlHoraHasta.SelectedIndex = 0;

                gvAgenda.DataSource = dtCurrentTable;
                gvAgenda.DataBind();
            }
        }

        protected void AgendaEliminarFilaGrilla(object sender, GridViewDeleteEventArgs e)
        {
            lblMsjAgenda.Text = null;
            lblMsjAgenda.Visible = false;

            var index = Convert.ToInt32(e.RowIndex);
            var dt = ViewState["DataTableAge"] as DataTable;
            if (dt != null && dt.Rows.Count > 1)
            {
                dt.Rows[index].Delete();
                ViewState["DataTableAge"] = dt;
                AgendaBindGrid();
            }
            else
            {
                AgendaIniFila();
            }
        }

        private void AgendaBindGrid()
        {
            gvAgenda.DataSource = ViewState["DataTableAge"] as DataTable;
            gvAgenda.DataBind();
            gvAgenda.UseAccessibleHeader = true;
            gvAgenda.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion

        #region ----------- Manejo de Matrículas ---------------

        private void MatriculaIniFila()
        {
            try
            {
                ViewState["DadaTableMat"] = null;//Matricula
                var dtMat = new DataTable();
                dtMat.Columns.Add(new DataColumn("PMTID", typeof(int)));
                dtMat.Columns.Add(new DataColumn("PMT_MTTID", typeof(int)));
                dtMat.Columns.Add(new DataColumn("MTTDESCRIPCION", typeof(string)));
                dtMat.Columns.Add(new DataColumn("PMTNRO", typeof(string)));

                ViewState["DadaTableMat"] = dtMat;

                gvMat.DataSource = dtMat;
                gvMat.DataBind();
            }
            catch (Exception)
            {
                var script = "showAlert('Error al cargar Matrículas','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        protected void btnMatricula_Click(object sender, EventArgs e)
        {
            var controlExiste = false;
            string msj = "";
            if (ddlMat.SelectedIndex == 0 || string.IsNullOrEmpty(txtNro.Value))
            {
                msj = msj + " Falta seleccionar un tipo de matrícula y/o cargar su número.";
                controlExiste = true;
            }
            if (!controlExiste)
            {
                MatriculaAgregarFilaGrilla();
            }
            else
            {
                var script = "showAlert(" + msj + ",'3');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        private void MatriculaAgregarFilaGrilla()
        {
            try
            {
                if (ViewState["DadaTableMat"] != null)
                {
                    var dtCurrentTable = (DataTable)ViewState["DadaTableMat"];
                    var controlExiste = false;
                    foreach (DataRow fila in dtCurrentTable.Rows)
                    {
                        if (fila["PMT_MTTID"].ToString() == ddlMat.SelectedValue)
                        {
                            var script = "showAlert('Advertencia!',' Igrese otro tipo de matrícula.','3');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                            controlExiste = true;
                            break;
                        }
                    }
                    if (controlExiste == false)
                    {
                        DataRow drCurrentRow;
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["PMT_MTTID"] = ddlMat.SelectedItem.Value;
                        drCurrentRow["MTTDESCRIPCION"] = ddlMat.SelectedItem.Text;
                        if (!string.IsNullOrEmpty(txtNro.Value))
                        {
                            drCurrentRow["PMTNRO"] = txtNro.Value;
                        }
                        else
                        {
                            drCurrentRow["PMTNRO"] = "0";
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["DadaTableMat"] = dtCurrentTable;

                        DataTable ordenDataTable = ViewState["DadaTableMat"] as DataTable;
                        DataView dv = ordenDataTable.DefaultView;
                        dv.Sort = "PMT_MTTID";
                        ordenDataTable = dv.ToTable();

                        ViewState["DadaTableMat"] = ordenDataTable;

                        ddlMat.SelectedIndex = 0;
                        txtNro.Value = null;
                    }
                    gvMat.DataSource = dtCurrentTable;
                    gvMat.DataBind();
                }
            }
            catch (Exception)
            {
                var script = "showAlert('Error al Agregar Matrículas a Lista.','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        protected void MatriculaEliminarFilaGrilla(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(e.RowIndex);
                var dt = ViewState["DadaTableMat"] as DataTable;
                if (dt.Rows.Count > 1)
                {
                    dt.Rows[index].Delete();
                    ViewState["DadaTableMat"] = dt;
                    MatriculaBindGrid();
                }
                else
                {
                    MatriculaIniFila();
                }
            }
            catch (Exception ex)
            {
                var script = "showAlert('Error al Eliminar Matrículas de Grilla.','2');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
            }
        }

        private void MatriculaBindGrid()
        {
            gvMat.DataSource = ViewState["DadaTableMat"] as DataTable;
            gvMat.DataBind();
            gvMat.UseAccessibleHeader = true;
            gvMat.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion

        private void Limpiar()
        {
            lblProId.Text = null;
            lblPsnId.Text = null;

            txtDocumento.Value = null;
            txtNombre.Value = null;
            txtApellido.Value = null;
            txtFecNac.Value = null;
            txtTel.Value = null;
            txtDire.Value = null;
            txtMail.Value = null;
            rbM.Checked = true;

            AgendaIniFila();
            MatriculaIniFila();

            ddlMat.SelectedIndex = 0;
            txtNro.Value = null;
            ddlDias.SelectedIndex = 0;
            ddlHoraDesde.SelectedIndex = 0;
            ddlHoraHasta.SelectedIndex = 0;

            ddlEstado.SelectedIndex = 0;

            listaEspecialidades.Clear();

            for (var i = 0; i < arregloCheckBoxs.Count(); i++)
            {
                arregloCheckBoxs[i].Checked = false;
            }

            CargarGrilla();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string error = null; string msj = null; int errorNro = 0;
                var profesional = new ProfesionalDto();
                ObtenerDatosPantalla(profesional);
                var varEstado = Request.QueryString["e"];
                if (varEstado == "N")
                {
                    ManagerProfesional.GrabarProfesionalInsert(ref profesional, ref error, ref errorNro);
                    msj = "Kinesiólogo Guardado.";
                }
                else if (varEstado == "B")
                {
                    ManagerProfesional.GrabarProfesionalUpdate(ref profesional, ref error, ref errorNro);
                    msj = "Kinesiólogo Actualizado.";
                }
                if (error == null)
                {
                    var script = "showAlert('" + msj + "','1');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                    Limpiar();
                    var script2 = "ocultarFormProfesional();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarFormPaciente", script2, true);
                }
                else
                {
                    if (errorNro == -2)
                    {
                        var script = "showAlert('" + error + "','3');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                    }
                    if (errorNro == -1)
                    {
                        var script = "showAlert('" + error + "','2');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showAlert", script, true);
                    }
                }
            }
        }



        private void BloquearCampos()
        {
            txtApellido.Disabled = true;
            txtDire.Disabled = true;
            txtFecNac.Disabled = true;
            txtNombre.Disabled = true;
            txtTel.Disabled = true;
            rbF.Disabled = true;
            rbM.Disabled = true;
        }

        private void DesbloquearCampos()
        {
            txtApellido.Disabled = false;
            txtDire.Disabled = false;
            txtFecNac.Disabled = false;
            txtNombre.Disabled = false;
            txtTel.Disabled = false;
            rbF.Disabled = false;
            rbM.Disabled = false;
        }
    }
}