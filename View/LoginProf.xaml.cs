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
            var data = HandOfGod.ExecuteSubmit(sender);
            var admon = DB.ReadFirst<Empleado>("Id = @user AND Contrasena = @password AND Puesto = 'Docente'", ("@user", data["user"]), ("@password", data["pass"]));
            if (admon != null)
            {
                PantallaDocentes pdoc = new PantallaDocentes();
                pdoc.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show($"Usuario y contraseña no encontrado.\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }
    }
}
