using Control_Escolar_Consola.Entidades;
using controlescolar.View;
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

namespace controlescolar;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        Empleado empleado = new Empleado();
        PanelEmpleado ventana = new PanelEmpleado(empleado);
        this.Close();
        ventana.Show();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        User = UserText.Text;
        Password = PasswordText.Password;
        SesionTable.SesionLogin(User, Password, this);
    }

    string User="";
    string Password="";
}