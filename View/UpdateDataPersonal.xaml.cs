using System;
using System.Collections.Generic;
using System.Globalization;
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
using System;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using Control_Escolar_Consola.Entidades;
namespace controlescolar.View
{
    /// <summary>
    /// Lógica de interacción para UpdateDataPersonal.xaml
    /// </summary>
    /// 

    public partial class UpdateDataPersonal : Page
    {
        public UpdateDataPersonal(Empleado Obj)
        {
            InitializeComponent();
            NombreTtxBx.Text = Obj.Nombre;
            ApellidoPtnTxtBx.Text = Obj.Apellido;
            ApellidoMttxt.Text = Obj.Apellido;
            DiaTxt.Text = Obj.FechaNacimiento.Day.ToString();
            MesesCmbx.SelectedIndex = Obj.FechaNacimiento.Month - 1;
            añoTbx.Text = Obj.FechaNacimiento.Year.ToString();
            CurpTbx.Text = Obj.CURP;
            Telefono_PersonalTbx.Text = Obj.TelefonoPersonal;
            Telefono_ContactTbx.Text = Obj.TelefonoContacto;
            CorreoPersonal_TextBox.Text = Obj.CorreoPersonal;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class ScrollLimitConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double && values[1] is double)
            {
                return (double)values[0] == (double)values[1];
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomThumb : Thumb
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            // El Thumb ocupa todo el alto del Track, sin dejar espacios arriba o abajo
            return base.ArrangeOverride(finalSize);
        }
    }

    public class RippleEffectDecorator : ContentControl
    {
        static RippleEffectDecorator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RippleEffectDecorator), new FrameworkPropertyMetadata(typeof(RippleEffectDecorator)));
        }

        public Brush HighlightBackground
        {
            get { return (Brush)GetValue(HighlightBackgroundProperty); }
            set { SetValue(HighlightBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightBackgroundProperty =
            DependencyProperty.Register("HighlightBackground", typeof(Brush), typeof(RippleEffectDecorator), new PropertyMetadata(Brushes.White));

        Ellipse ellipse;
        Grid grid;
        Storyboard animation;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ellipse = GetTemplateChild("PART_ellipse") as Ellipse;
            grid = GetTemplateChild("PART_grid") as Grid;
            animation = grid.FindResource("PART_animation") as Storyboard;

            this.AddHandler(MouseDownEvent, new RoutedEventHandler((sender, e) =>
            {
                var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
                var mousePosition = (e as MouseButtonEventArgs).GetPosition(this);
                var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
                //set initial margin to mouse position
                ellipse.Margin = startMargin;
                //set the to value of the animation that animates the width to the target width
                (animation.Children[0] as DoubleAnimation).To = targetWidth;
                //set the to and from values of the animation that animates the distance relative to the container (grid)
                (animation.Children[1] as ThicknessAnimation).From = startMargin;
                (animation.Children[1] as ThicknessAnimation).To = new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0);
                ellipse.BeginStoryboard(animation);
            }), true);
        }
    }
}