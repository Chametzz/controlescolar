using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace controlescolar
{
    public partial class PageCalificaciones : Page
    {
        public PageCalificaciones()
        {
            InitializeComponent();
        }

        private void DescargarBoleta_Click(object sender, RoutedEventArgs e)
        {
            string periodo = ((ComboBoxItem)PeriodoCombo.SelectedItem)?.Content.ToString();

            if (periodo == "Seleccione periodo")
            {
                MessageBox.Show("Por favor, selecciona un período válido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string fileName = $"Boleta_{SanitizarNombre(periodo)}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            string rutaImagen = Path.Combine(Directory.GetCurrentDirectory(), "Recursos", "LOGO-SEP.jpeg");//@"C:\Users\Kazan\OneDrive\Escritorio\Nueva carpeta\controlescolar\Recursos\LOGO-SEP.png";
            string rutaLogoControlEscolar = Path.Combine(Directory.GetCurrentDirectory(), "Recursos", "logoescolar.jpeg");//@"C:\Users\Kazan\OneDrive\Escritorio\Nueva carpeta\controlescolar\Recursos\logoescolar.png";
            if (!File.Exists(rutaImagen))
            {
                MessageBox.Show($"No se encontró la imagen en la ruta:\n{rutaImagen}", "Error de Imagen", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!File.Exists(rutaLogoControlEscolar))
            {
                MessageBox.Show($"No se encontró el logotipo de control escolar en la ruta:\n{rutaLogoControlEscolar}", "Error de Imagen", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    // Tamaño de página para posicionamiento
                    var pageSize = pdf.GetDefaultPageSize();

                    // Imagen SEP a la izquierda
                    ImageData dataSep = ImageDataFactory.Create(rutaImagen);
                    iText.Layout.Element.Image imagenSep = new iText.Layout.Element.Image(dataSep)
                        .ScaleToFit(200, 100)
                        .SetFixedPosition(50, pageSize.GetTop() - 100);

                    // Logo control escolar a la derecha
                    ImageData dataLogo = ImageDataFactory.Create(rutaLogoControlEscolar);
                    iText.Layout.Element.Image imagenLogo = new iText.Layout.Element.Image(dataLogo)
                        .ScaleToFit(150, 100)
                        .SetFixedPosition(pageSize.GetWidth() - 200, pageSize.GetTop() - 110);

                    // Añadir ambas imágenes al documento
                    document.Add(imagenSep);
                    document.Add(imagenLogo);

                    // Título
                    Paragraph titulo = new Paragraph("INSTITUTO MAIN() CHA")
                        .SetFontSize(18)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetWidth(UnitValue.CreatePercentValue(100))
                        .SetFontColor(ColorConstants.BLACK)
                        .SetPadding(10)
                        .SetMarginTop(80); // espacio después de las imágenes
                    document.Add(titulo);

                    // Línea decorativa
                    LineSeparator linea = new LineSeparator(new SolidLine());
                    linea.SetStrokeColor(new DeviceRgb(0x0d, 0x3b, 0x31))
                         .SetMarginTop(10)
                         .SetMarginBottom(10);
                    document.Add(linea);

                    // Texto alineado: Boleta izquierda, Período y Fecha a la derecha
                    string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");

                    Paragraph encabezado = new Paragraph()
                        .AddTabStops(new TabStop(pageSize.GetWidth() - 50, TabAlignment.RIGHT))
                        .Add("Boleta de calificaciones")
                        .Add(new Tab())
                        .Add($"Período: {periodo}    Fecha: {fechaActual}")
                        .SetFontSize(14)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetMarginBottom(20);

                    document.Add(encabezado);



                    // Datos del alumno
                    string nombreAlumno = "Juan Pérez";
                    string matricula = "A123456";
                    string carrera = "Ingeniería en Sistemas";

                    var datosAlumno = new Paragraph()
                        .Add($"Nombre del alumno: {nombreAlumno}\n")
                        .Add($"Matrícula: {matricula}\n")
                        .Add($"Carrera: {carrera}")
                        .SetFontSize(12)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetMarginBottom(10);

                    document.Add(datosAlumno);
                    // Tabla de calificaciones
                    var tablaCalificaciones = new Table(UnitValue.CreatePercentArray(new float[] { 1f, 4f, 2f }))
                        .UseAllAvailableWidth()
                        .SetMarginBottom(20);

                    // Encabezados
                    tablaCalificaciones.AddHeaderCell(new Cell().Add(new Paragraph("Clave")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                    tablaCalificaciones.AddHeaderCell(new Cell().Add(new Paragraph("Materia")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                    tablaCalificaciones.AddHeaderCell(new Cell().Add(new Paragraph("Calificación")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                    // Filas de ejemplo
                    tablaCalificaciones.AddCell("001");
                    tablaCalificaciones.AddCell("Matemáticas");
                    tablaCalificaciones.AddCell("9.0");

                    tablaCalificaciones.AddCell("002");
                    tablaCalificaciones.AddCell("Español");
                    tablaCalificaciones.AddCell("8.5");

                    tablaCalificaciones.AddCell("003");
                    tablaCalificaciones.AddCell("Historia");
                    tablaCalificaciones.AddCell("10.0");

                    document.Add(tablaCalificaciones);
                }

                MessageBox.Show($"Boleta guardada en: {filePath}", "Descarga Exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el PDF:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string SanitizarNombre(string texto)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                texto = texto.Replace(c, '_');
            }
            return texto.Replace(" ", "_");
        }
    }
}
