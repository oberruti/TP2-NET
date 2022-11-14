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
        public List<Comision> Comisiones { get => comisiones; set => comisiones = value; }

        private Persona _PersonaActual;

        private List<Comision> comisiones;

        public AlumnoInscripcionDesktop(Persona pers)
        {
            PersonaActual = pers;
            InitializeComponent();
            InicializarComboBox();
            this.Modo = ModoForm.Alta;

            if (pers.TipoPersona == TiposPersonas.Alumno) { lblCondicion.Visible = false; lblNota.Visible = false; cmbCondiciones.Visible = false; txtNota.Visible = false; this.lblAlumno2.Text = PersonaActual.Apellido + ", " + PersonaActual.Nombre; }

        }
        public AlumnoInscripcionDesktop(int ID, ModoForm modo, Persona p)
        {
            InitializeComponent();
            InicializarComboBox();
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            AluInscripcionActual = ail.GetOne(ID);
            PersonaActual = p;
            this.Modo = modo;
            Persona per = new PersonaLogic().GetOne(AluInscripcionActual.IdAlumno);
            this.lblAlumno2.Text = per.Apellido + ", " + per.Nombre;
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.cmbIDCurso.Enabled = false;
            this.cmbMaterias.Enabled = false;
            this.cmbCondiciones.Enabled = true;
            this.txtNota.Enabled = true;
            this.cmbCondiciones.Text = "";
            this.txtNota.Text = "";


            this.btnAceptar.Text = "Guardar cambios";
        }

        public override void GuardarCambios()
        {
            AlumnoInscripcion al = MapearADatos();

            if (!(ValidaAlumnoEnVariosCursos(CursoActual)) || PersonaActual.TipoPersona == TiposPersonas.Docente)
            {
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                if (ValidaCupo(CursoActual)) { ail.Save(al); }
                else { MessageBox.Show("ERROR: Curso sin cupo"); }
            }
            else
            {
                MessageBox.Show("ERROR: Este alumno ya se encuentra inscripto en este curso");
            }
        }

        private void InicializarComboBox()
        {
            string[] condicionesLista = new string[] { "Cursando" ,"Regular", "Aprobado", "Libre" };
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
            if (cursosAMostrar.Count > 0)
            {
                List<Curso> curs = cursosAMostrar;
                List<Materia> mats = new List<Materia>();
                List<Materia> matsSinRep = new List<Materia>();
                List<int> ids = new List<int>();
                MateriaLogic ml = new MateriaLogic();
                foreach (Curso item in curs)
                {
                    mats.Add(ml.GetOne(item.IDMateria));
                }
                foreach (Materia mat in mats)
                {
                    if (!ids.Contains(mat.ID))
                    {
                        ids.Add(mat.ID);
                        matsSinRep.Add(mat);
                    }
                }
                cmbCondiciones.DataSource = condicionesLista;
                cmbMaterias.DisplayMember = "descripcion";
                cmbMaterias.DataSource = matsSinRep;
                return;
            }
            this.Notificar("Atención", "No hay cursos con cupo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();

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
                alu.Condicion = cmbCondiciones.SelectedItem.ToString();
                alu.State = BusinessEntity.States.Modified;
            }
            return alu;
        }

        private Curso GetCurso()
        {
            return new CursoLogic().GetOne(((Comision)this.cmbIDCurso.SelectedValue).ID, ((Materia)this.cmbMaterias.SelectedValue).ID); ;
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
                if (item.IdCurso == cActual.ID && item.IdAlumno == PersonaActual.ID)
                {
                    x = true;
                    break;
                }
            }
            return x;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbMaterias_SelectedValueChanged(object sender, EventArgs e)
        {
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
            if (cursosAMostrar.Count > 0)
            {
                List<Curso> curs = cursosAMostrar;
                List<Comision> coms = new List<Comision>();
                List<Comision> comsSinRep = new List<Comision>();
                List<int> ids = new List<int>();
                ComisionLogic cl = new ComisionLogic();
                foreach (Curso item in curs)
                {
                    Materia mat = (Materia)cmbMaterias.SelectedItem;
                    if (item.IDMateria == mat.ID) { coms.Add(cl.GetOne(item.IDComision)); }

                }
                foreach (Comision com in coms)
                {
                    if (!ids.Contains(com.ID))
                    {
                        ids.Add(com.ID);
                        comsSinRep.Add(com);
                    }
                }
                cmbIDCurso.DisplayMember = "desc_comision";
                cmbIDCurso.DataSource = comsSinRep;
                return;
            }
            this.Notificar("Atención", "No hay cursos con cupo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();


        }

        private bool ValidaCupo(Curso cur)
        {
            List<AlumnoInscripcion> alumsInsc = new AlumnoInscripcionLogic().GetInscripcionesByCursoId(cur.ID);
            if (alumsInsc.Count() < cur.Cupo)
            {
                return true;
            }
            return false;
        }
    }
}

