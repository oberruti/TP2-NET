using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class ReportesCursosDesktop : ApplicationForm
    {
        private MateriaLogic materia = new MateriaLogic();
        private List<Materia> listaMaterias = new List<Materia>();
        private ComisionLogic comision = new ComisionLogic();
        private List<Comision> listaComision = new List<Comision>();

        private Materia materiaActual = new Materia();

        public ReportesCursosDesktop()
        {
            InitializeComponent();
        }

        private void ReportesCursos_Load(object sender, EventArgs e)
        {
            ListarCb();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarCb()
        {
            listaMaterias = materia.GetAll();        
            this.cbAsignatura.ComboBox.DataSource = listaMaterias;
            this.cbAsignatura.ComboBox.DisplayMember = "descripcion";
        }

        public void Listardgv()
        {
            //this.dgvReportesCursos.Rows.Clear();
            this.dgvReportesCursos.Refresh();
            if (cbComision.SelectedItem != null && cbAsignatura.SelectedItem != null)
            { 
                if (cbComision.SelectedItem.ToString() != string.Empty && cbAsignatura.SelectedIndex.ToString() != string.Empty)
                {
                    /*Comision comision = listaComision.Where(lc => lc.Desc_comision.ToLower() == cbComision.SelectedItem.ToString().ToLower()).FirstOrDefault();
                    Materia materia = listaMaterias.Where(lm => lm.Descripcion.ToLower() == cbAsignatura.SelectedItem.ToString().ToLower()).FirstOrDefault();
                    var reporteCurso = new ReporteCursoLogic();
                    List<Persona> listaPersonas = new List<Persona>();
                    reporteCurso.GetReporteCurso(comision.ID, materia.ID).ForEach(reporte => listaPersonas.Add(reporte.persona));
                    */

                    this.dgvReportesCursos.DataSource = new CursoLogic().GetAllTabla(((Materia)this.cbAsignatura.SelectedItem).ID, ((Comision)this.cbComision.SelectedItem).ID);
                    this.ocultarColumns();
                }
            }
            /*
            MateriaLogic materia = new MateriaLogic();
            List<Materia> listaMaterias = materia.GetAll();
            List<Materia> listaMateriasAMostrar = new List<Materia>();
            foreach (Materia mat in listaMaterias)
            {
                if (mat.IDPlan == ((Plan)(this.cbReportesPlanes.ComboBox.SelectedItem)).ID)
                {
                    listaMateriasAMostrar.Add(mat);
                    this.ModificarEstilos();
                    this.ocultarColumns();
                }
            }
            this.dgvReportePlanes.DataSource = listaMateriasAMostrar;
            */
        }

        private void cbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            materiaActual = (Materia)this.cbAsignatura.ComboBox.SelectedItem;

            List<Curso> curs = new CursoLogic().GetAllCursosConCupos();
            List<Comision> comsAMostrar = new List<Comision>();
            ComisionLogic cl = new ComisionLogic();
            foreach (Curso item in curs)
            {
                Materia mat = (Materia)cbAsignatura.ComboBox.SelectedItem;
                if (item.IDMateria == mat.ID) { comsAMostrar.Add(cl.GetOne(item.IDComision)); }
            }
            cbComision.ComboBox.DisplayMember = "desc_comision";
            cbComision.ComboBox.DataSource = comsAMostrar;
            this.Listardgv();
        }

        private void cbComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Listardgv();
            
   
        }

        private void ocultarColumns() 
        {
            for (int numCol = 0; numCol < dgvReportesCursos.Columns.Count; numCol++)
            {
                switch (dgvReportesCursos.Columns[numCol].Name)
                {
                    case "Direccion":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "FechaNacimiento":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "IDPlan":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "Telefono":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "NombreUsuario":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "Clave":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "Habilitado":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "TipoPersona":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "ID":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;
                    case "State":
                        dgvReportesCursos.Columns[numCol].Visible = false;
                        continue;


                }


            }
        }

        private void cbAsignatura_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvReportesCursos.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Reportes-Cursos.pdf";
                bool errorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            errorMessage = true;
                            MessageBox.Show("No se puede escribir data en el disco" + ex.Message);
                        }
                    }
                    if (!errorMessage)
                    {
                        try
                        {

                            PdfPTable pdfTable = new PdfPTable(dgvReportesCursos.Columns.Count);
                            pdfTable.DefaultCell.Padding = 2;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;



                            foreach (DataGridViewColumn col in dgvReportesCursos.Columns)
                            {
                                if (col.Visible)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(col.HeaderText));

                                    if (col.HeaderText.ToLower() != "descripcion")
                                    {
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    }

                                    pdfTable.AddCell(pdfCell);
                                }

                            }

                            foreach (DataGridViewRow viewRow in dgvReportesCursos.Rows)
                            {
                                foreach (DataGridViewCell dgvCell in viewRow.Cells)
                                {
                                    if (dgvCell.Visible)
                                    {
                                        PdfPCell pdfCell = new PdfPCell(new Phrase(dgvCell.Value.ToString()));
                                        if (dgvCell.ColumnIndex != 0)
                                        {
                                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        }
                                        pdfTable.AddCell(pdfCell);
                                    }

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.AddAuthor("Academia");
                                document.AddTitle("Reporte de Cursos");

                                iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                                //document.Add(new Paragraph("Plan Año: " + ((Curso)dgvReportesCursos.SelectedItem).Descripcion));
                                //document.Add(Chunk.NEWLINE);
                                document.Add(new Paragraph("Cursos: "));
                                document.Add(Chunk.NEWLINE);
                                document.Add(pdfTable);
                                document.Close();
                                fileStream.Close();
                                pdfWriter.Close();

                            }
                            MessageBox.Show("La Data se exportó satisfactoriamente", "info");
                            
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Error al guardar");
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("no se encontró informacion de registro", "info");
            }
        }
    }
}

