using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace controlescolar;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        Console.WriteLine("¿Quieres abrir el entorno de pruebas [Y/N]?");
        string? option = Console.ReadLine();
        Type? t = Type.GetType("Test");
        if (option == "Y")
        {
            //this.Close();
            if (t != null)
            {
                Activator.CreateInstance(t);
            }
            else
            {
                Console.WriteLine("No se encontró la clase \"Test\"");
            }
        }
        else
        {
            InitializeComponent();
        }
    }

    private void BtnAlumno_Click(object sender, RoutedEventArgs e)
    {
        Login ventanaLogin = new Login();
        ventanaLogin.Show();
        this.Hide();
    }

    private void BtnAdmon_Click(object sender, RoutedEventArgs e)
    {
        LoginAdmon ventanaLoginAdmon = new LoginAdmon();
        ventanaLoginAdmon.Show();
        this.Hide();

    }
    private void BtnDocente_Click(object sender, RoutedEventArgs e)
    {
        LoginProf ventanaLoginProf = new LoginProf();
        ventanaLoginProf.Show();
        this.Hide();
    }
}