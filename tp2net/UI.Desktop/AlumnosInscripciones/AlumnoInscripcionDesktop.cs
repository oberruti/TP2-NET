using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        /*private AlumnoInscripcion _aluInscripcionActual;
        public AlumnoInscripcion AluInscripcionActual { get => _aluInscripcionActual; set => _aluInscripcionActual = value; }

        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
            this.Modo = ModoForm.Baja;
            InicializarComboBox();
            this.AutoSize = false;
        }

        private void InicializarComboBox()
        {
            cmbIDAlumno.DisplayMember = "nombre";
            cmbIDAlumno.DataSource = new AlumnoLogic().GetAllAlumnos();
            cmbIDCurso.DisplayMember = "descripcion";
            cmbIDCurso.DataSource = new CursoLogic().GetAll();
        }

        public AlumnoInscripcionDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;

        }

        public AlumnoInscripcionDesktop(int ID, ModoForm modo)
            : this()
        {
            Modo = modo;
            Alu cl = new ComisionLogic();
            ComisionActual = cl.GetOne(ID);
            MapearDeDatos();
        }

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.AluInscripcionActual.ID.ToString();
            this.txtCondicion.Text = this.AluInscripcionActual.Condicion;
            this.txtNota.Text = this.AluInscripcionActual.Nota.ToString();
            //this.cmbAlumnos.SelectedIndex = new PersonaLogic().DameIndex(this.AluInscripcionActual.IDAlumno, Business.Entities.Personas.TiposPersonas.Alumno);
            //CargarCursos();
            //this.cmbCursos.SelectedIndex = new CursoLogic().DameIndex(this.AluInscripcionActual.IDCurso);
        }

        /*public virtual void GuardarCambios()
        {
            try
            {
                MapearADatos();
                if (AluInscripcionActual != null)
                {
                    new AlumnoInsLogic().Save(AluInscripcionActual);
                }
            }
            catch (ErrorEliminar ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void MapearADatos()
        {

            Business.Entities.Curso cursoActual = this.DevolverCurso();
            Business.Entities.Personas personaActual = this.DevolverPersona();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        if (new AlumnoInsLogic().HayCupo(((Business.Entities.Curso)this.cmbCursos.SelectedValue).ID))
                        {
                            AluInscripcionActual = new AlumnoInscripcion();
                            this.AluInscripcionActual.IDAlumno = personaActual.ID;
                            this.AluInscripcionActual.IDCurso = cursoActual.ID;
                            if (Login.UsuarioLogueado.Per.TipoPersona == Business.Entities.Personas.TiposPersonas.Alumno)
                            {
                                this.AluInscripcionActual.Condicion = "INSCRIPTO";
                                this.AluInscripcionActual.Nota = 0;
                            }
                            else
                            {
                                this.AluInscripcionActual.Condicion = this.txtCondicion.Text;
                                this.AluInscripcionActual.Nota = int.Parse(this.txtNota.Text);
                            }
                            this.AluInscripcionActual.State = BusinessEntity.States.New;
                            break;
                        }
                        else
                        {
                            AluInscripcionActual = null;
                            Notificar("Error", "Error a la hora de inscribirse. No hay cupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                case (ModoForm.Modificacion):
                    {
                        this.AluInscripcionActual.IDAlumno = personaActual.ID;
                        this.AluInscripcionActual.IDCurso = cursoActual.ID;
                        this.AluInscripcionActual.Condicion = this.txtCondicion.Text;
                        this.AluInscripcionActual.Nota = int.Parse(this.txtNota.Text);
                        this.AluInscripcionActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.AluInscripcionActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.AluInscripcionActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        private Business.Entities.Personas DevolverPersona()
        {
            return new PersonaLogic().GetOne(((Business.Entities.Personas)this.cmbAlumnos.SelectedValue).ID);
        }

        private Curso DevolverCurso()
        {
            return new CursoLogic().GetOne(((Business.Entities.Curso)this.cmbCursos.SelectedValue).ID);
        }

        public virtual bool Validar()
        {
            int nro;
            Boolean estado = true;
            if (!(this.Modo == ModoForm.Baja))
            {
                foreach (Control control in this.tableLayoutPanel1.Controls)
                {
                    if (!(control == txtID))
                    {
                        if (control is TextBox && control.Text == String.Empty)
                        {
                            estado = false;
                        }
                    }

                }
                if (estado == false)
                {
                    Notificar("Campos vacíos", "Existen campos sin completar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!(int.TryParse(this.txtNota.Text, out nro)))
                {
                    estado = false;
                    Notificar("Tipo incorrecto", "La nota debe ser un número entero.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!((0 <= int.Parse(this.txtNota.Text)) && (int.Parse(this.txtNota.Text) <= 10)))
                {
                    estado = false;
                    Notificar("Número de nota incorrecta", "La nota debe ser un numero entero positivo)(entre 0 y 10).", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return estado;
        }

        private bool EstaInscripto()
        {
            bool estado = new AlumnoInsLogic().AlumnoEstaInscripto(((Business.Entities.Personas)this.cmbAlumnos.SelectedValue).ID, ((Business.Entities.Curso)this.cmbCursos.SelectedValue).ID);
            if (estado)
            {
                Notificar("Inscripción doble", "El Alumno que desea inscribir ya se encuentra inscripto en este Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return estado;
        }

        private void CargarCursos()
        {
            cmbCursos.DisplayMember = "descripcion";
            if (Login.UsuarioLogueado.Per.TipoPersona == Business.Entities.Personas.TiposPersonas.Administrador && this.Modo != ModoForm.Baja && this.Modo != ModoForm.Modificacion)
            {
                cmbCursos.DataSource = new CursoLogic().GetAllXPlan(new PersonaLogic().DameIDPlanPersona(this.cmbAlumnos.SelectedIndex, Business.Entities.Personas.TiposPersonas.Alumno));
            }
            else if (this.AluInscripcionActual != null && this.Modo == ModoForm.Baja)
            {
                cmbCursos.DataSource = new CursoLogic().GetAll();
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                cmbCursos.DataSource = new CursoLogic().GetAll();
            }
            else
            {
                cmbCursos.DataSource = new CursoLogic().GetAllXPlan(Login.UsuarioLogueado.Per.IDPlan);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Login.UsuarioLogueado.Per.TipoPersona == Business.Entities.Personas.TiposPersonas.Alumno)
            {
                this.txtNota.Text = "0";
                this.txtCondicion.Text = "INSCRIPTO";
            }
            if (Validar()) //Valido campos vacios
            {
                if ((this.Modo != ModoForm.Alta) || !(EstaInscripto())) //Compruebo si ya se encuentra registrado
                {
                    GuardarCambios();
                    Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.Modo == ModoForm.Baja || this.Modo == ModoForm.Modificacion))
            {
                CargarCursos();
            }
        }
    }*/
    }
}
