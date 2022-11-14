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
    public partial class ReportesPlanesDesktop : ApplicationForm
    {
        private PlanLogic planes = new PlanLogic();
        private List<Plan> listaPlanes = new List<Plan>();

        public ReportesPlanesDesktop()
        {
            InitializeComponent();
        }

        private void ReportesPlanesDesktop_Load(object sender, EventArgs e)
        {
            ListarCb();
        }

        public void Listardgv()
        {
            
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
        }

        public void ListarCb()
        {
            listaPlanes = planes.GetAll();
            this.cbReportesPlanes.ComboBox.DataSource = listaPlanes;
            this.cbReportesPlanes.ComboBox.DisplayMember = "descripcion";
            /*foreach (var plan in listaPlanes)
            {
                //cbReportesPlanes.Items.
                var itemToAdd = plan.Descripcion;
                this.cbReportesPlanes.Items.Add(plan);
                /*if (!this.cbReportesPlanes.Items.Contains(itemToAdd))
                {
                    this.cbReportesPlanes.Items.Add(itemToAdd); 
                } */
            //}
        }

        private void cbReportesPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listardgv();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarEstilos() 
        {
            
            for (int numCol = 0; numCol < dgvReportePlanes.Columns.Count; numCol++)
            {
                switch (dgvReportePlanes.Columns[numCol].Name)
                {
                    case "HSSemanales":
                        dgvReportePlanes.Columns[numCol].HeaderText = "Horas Semanales";
                        dgvReportePlanes.Columns[numCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvReportePlanes.Columns[numCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        continue;
                    case "HSTotales":
                        dgvReportePlanes.Columns[numCol].HeaderText = "Horas Totales";
                        dgvReportePlanes.Columns[numCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvReportePlanes.Columns[numCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        continue;


                }


            }
        }

        private void ocultarColumns()
        {
            for (int numCol = 0; numCol < dgvReportePlanes.Columns.Count; numCol++)
            {
                switch (dgvReportePlanes.Columns[numCol].Name)
                {
                    case "IDPlan":
                        dgvReportePlanes.Columns[numCol].Visible = false;
                        continue;
                    case "ID":
                        dgvReportePlanes.Columns[numCol].Visible = false;
                        continue;
                    case "State":
                        dgvReportePlanes.Columns[numCol].Visible = false;
                        continue;

                }


            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvReportePlanes.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Reportes-Planes.pdf";
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

                            PdfPTable pdfTable = new PdfPTable(dgvReportePlanes.Columns.Count - 3);
                            pdfTable.DefaultCell.Padding = 2;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            

                            foreach (DataGridViewColumn col in dgvReportePlanes.Columns)
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

                            foreach (DataGridViewRow viewRow in dgvReportePlanes.Rows)
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
                                document.AddAuthor("Acedemia");
                                document.AddTitle("Reporte de Planes");

                                iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                                document.Add(new Paragraph("Plan Año: " + ((Plan)cbReportesPlanes.SelectedItem).Descripcion));
                                document.Add(Chunk.NEWLINE);
                                document.Add(new Paragraph("Materias: "));
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
