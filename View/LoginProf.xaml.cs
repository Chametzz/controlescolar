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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace controlescolar
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class LoginProf : Window
    {
        public LoginProf()
        {
            InitializeComponent();
        }
        private void ButtonLogprof_Click(object sender, RoutedEventArgs e)
        {
            /*var data = HandOfGod.ExecuteSubmit(sender);
            if (!int.TryParse($"{data["user"]}", out int user)) return;
            var docente = DB.modelDocentes.ReadFirst($"Id_Empleado = {user}");
            if (docente == null) return;
            var empleado = DB.modelEmpleado.ReadFirst($"Id = {user}");
            Console.WriteLine($"{empleado?["CURP"]} == {data["pass"]} | {empleado?["CURP"] == data["pass"]}");
            if (empleado != null && empleado["CURP"]?.ToString() == data["pass"]?.ToString())
            {
                PantallaDocentes ventanaEmpleados = new PantallaDocentes();
                ventanaEmpleados.Show();
                this.Close();
            }*/
        }
        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }
    }
}
