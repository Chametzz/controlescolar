using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Control_Escolar_Consola.Entidades;

namespace controlescolar
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void ButtonLog_Click(object sender, RoutedEventArgs e)
        {
            var data = HandOfGod.ExecuteSubmit(sender);
            if (!int.TryParse($"{data["user"]}", out int user)) return;
            var alumno = DB.modelAlumno.ReadFirst($"Id_Alumno = {user}");
            Console.WriteLine($"{alumno?["CURP"]} == {data["pass"]} | {alumno?["CURP"] == data["pass"]}");
            if (alumno != null && alumno["CURP"]?.ToString() == data["pass"]?.ToString())
            {
                BolsaGlobal._bolsaGlobal = alumno;
                EstudiantePantalla ventanaEstudiante = new EstudiantePantalla();
                ventanaEstudiante.Show();
                this.Close();
            }
        }
        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }
    }
}
