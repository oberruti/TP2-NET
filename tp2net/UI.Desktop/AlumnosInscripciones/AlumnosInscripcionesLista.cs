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
    public partial class AlumnosInscripcionesLista : ApplicationForm
    {

        private Persona _PersonaActual;
        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

        public AlumnosInscripcionesLista(Persona per)
        {
            InitializeComponent();
            PersonaActual = per;
            this.dgvAlumnosInscripciones.AutoGenerateColumns = false;
            if (per.TipoPersona == TiposPersonas.Docente) {
                btnCargarDatos.Visible = true;
            }
        }
        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_LeftToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            AlumnoInscripcionLogic alu = new AlumnoInscripcionLogic();
            PersonaLogic per = new PersonaLogic();
            CursoLogic cur = new CursoLogic();
            List<AlumnoInscripcion> alumnosInscripciones = alu.GetAll();
            List<AlumnosInscripcionesConCursoYAlumno> alumnosInscripcionesCursosAlumnos = new List<AlumnosInscripcionesConCursoYAlumno>();
            foreach (AlumnoInscripcion item in alumnosInscripciones)
            {
                Persona p = per.GetOne(item.IdAlumno);
                Curso c = cur.GetOne(item.IdCurso);
                AlumnosInscripcionesConCursoYAlumno a = new AlumnosInscripcionesConCursoYAlumno();
                a.ID = item.ID;
                a.IdAlumno = item.IdAlumno;
                a.IdCurso = item.IdCurso;
                a.Nota = item.Nota;
                a.Condicion = item.Condicion;
                a.DescCurso = c.Descripcion;
                a.NombreAlumno = p.Nombre;
                a.ApellidoAlumno = p.Apellido;

                alumnosInscripcionesCursosAlumnos.Add(a);
            }
            this.dgvAlumnosInscripciones.DataSource = alumnosInscripcionesCursosAlumnos;
        }

        private void AlumnosInscripcionesLista_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnosInscripciones.SelectedRows.Count > 0)
            {
                int ID = ((AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion, PersonaActual);
                aid.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class AlumnosInscripcionesConCursoYAlumno : AlumnoInscripcion
    {
        private string _NombreAlumno;
        private string _ApellidoAlumno;
        private string _DescCurso;

        public string NombreAlumno { get => _NombreAlumno; set => _NombreAlumno = value; }
        public string DescCurso { get => _DescCurso; set => _DescCurso = value; }
        public string ApellidoAlumno { get => _ApellidoAlumno; set => _ApellidoAlumno = value; }
    }
}
