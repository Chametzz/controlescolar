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
            var alumno = DB.ReadFirst<Alumno>("Id = @user AND Contrasena = @password", ("@user", data["user"]), ("@password", data["pass"]));
            if (alumno != null)
            {
                BolsaGlobal.AlumnoLogueado = alumno;
                new EstudiantePantalla().Show();
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
