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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace controlescolar
{
    /// <summary>
    /// Lógica de interacción para InicioE.xaml
    /// </summary>
    public partial class InicioE : Page
    {
        public InicioE()
        {
            InitializeComponent();
            Console.WriteLine(Nombre);
            HandOfGod.SetTags(PanelOne, BolsaGlobal.AlumnoLogueado, "-");
            HandOfGod.SetTags(PanelTwo, BolsaGlobal.AlumnoLogueado, "-");
        }
    }
}
