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
        private AlumnoInscripcion _aluInscripcionActual;

        private Curso _CursoActual;

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
        public AlumnoInscripcion AluInscripcionActual { get => _aluInscripcionActual; set => _aluInscripcionActual = value; }
        public Curso CursoActual { get => _CursoActual; set => _CursoActual = value; }

        private Persona _PersonaActual;

        public AlumnoInscripcionDesktop(Persona pers)
        {
            PersonaActual = pers;
            InitializeComponent();
            InicializarComboBox();
            this.Modo = ModoForm.Alta;
            this.lblAlumno.Text = PersonaActual.Apellido + ", " + PersonaActual.Nombre;
        }
        public AlumnoInscripcionDesktop(int ID, ModoForm modo, Persona p)
        {
            InitializeComponent();
            InicializarComboBox();
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            AluInscripcionActual = ail.GetOne(ID);
            PersonaActual = p;
            this.Modo = modo;
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.lblAlumno.Text = PersonaActual.Apellido + ", " + PersonaActual.Nombre;
            this.cmbIDCurso.Enabled = false;
            this.txtCondicion.Enabled = true;
            this.txtNota.Enabled = true;
            this.txtCondicion.Text = "";
            this.txtNota.Text = "";


            this.btnAceptar.Text = "Guardar cambios";
        }

        public override void GuardarCambios()
        {
            AlumnoInscripcion al = MapearADatos();

            if (!(ValidaAlumnoEnVariosCursos(CursoActual)) || PersonaActual.TipoPersona == TiposPersonas.Docente)
            {
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                ail.Save(al);
            }
            else
            {
                MessageBox.Show("ERROR: Este alumno ya se encuentra inscripto en este curso");
            }
        }

        private void InicializarComboBox()
        {
            cmbIDCurso.DisplayMember = "descripcion";
            List<Curso> cursos = new CursoLogic().GetAllCursosConCupos();
            List<Curso> cursosAMostrar = new List<Curso>();
            foreach (Curso curso in cursos)
            {
                List<AlumnoInscripcion> inscripciones = new AlumnoInscripcionLogic().GetInscripcionesByCursoId(curso.ID);
                if (inscripciones.Count < curso.Cupo)
                {
                    cursosAMostrar.Add(curso);
                }
            }
            cmbIDCurso.DataSource = cursosAMostrar;
        }

        public virtual AlumnoInscripcion MapearADatos()
        {
            CursoActual = GetCurso();

            AlumnoInscripcion alu = new AlumnoInscripcion();
            if (PersonaActual.TipoPersona == TiposPersonas.Alumno)
            { 
                alu.IdAlumno = PersonaActual.ID;
                alu.IdCurso = CursoActual.ID;
                alu.Nota = 0;
                alu.Condicion = " ";
                alu.State = BusinessEntity.States.New;
            }
            else
            {
                alu.ID = AluInscripcionActual.ID;
                alu.IdAlumno = AluInscripcionActual.IdAlumno;
                alu.IdCurso = AluInscripcionActual.IdCurso;
                alu.Nota = Int32.Parse(txtNota.Text);
                alu.Condicion = txtCondicion.Text;
                alu.State = BusinessEntity.States.Modified;
            }
            return alu;
        }

        private Curso GetCurso()
        {
            return new CursoLogic().GetOne(((Curso)this.cmbIDCurso.SelectedValue).ID); ;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        public override bool Validar()
        {
            if (
                (this.cmbIDCurso == null)
                )
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool ValidaAlumnoEnVariosCursos(Curso cActual)
        {
            bool x = false;
            List<AlumnoInscripcion> alums = new AlumnoInscripcionLogic().GetAll();
            foreach (AlumnoInscripcion item in alums)
            {
                if (item.IdCurso == cActual.ID)
                {
                    x = true;
                    break;
                }
            }
            return x;
        }

    }
}

