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

namespace FigurasGeometricas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double escala;
        double origenX, origenY;

        public MainWindow()
        {
            InitializeComponent();
            this.SizeChanged += (s, e) => DibujarPlano();
            txtAltura.Visibility = Visibility.Hidden;
            txbAltura.Visibility = Visibility.Hidden;
            txtBase.Visibility = Visibility.Hidden;
            txbBase.Visibility = Visibility.Hidden;
            txtRadio.Visibility = Visibility.Visible;
            txbRadio.Visibility = Visibility.Visible;
        }

        private void DibujarPlano()
        {
            escala = sldEscala.Value;
            canvasPlano.Children.Clear();

            origenX = canvasPlano.ActualWidth / 2;
            origenY = canvasPlano.ActualHeight / 2;

            // Dibujar cuadrícula
            for (double x = 0; x < canvasPlano.ActualWidth; x += escala)
            {
                Line lineaVertical = new Line
                {
                    X1 = x,
                    Y1 = 0,
                    X2 = x,
                    Y2 = canvasPlano.ActualHeight,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                canvasPlano.Children.Add(lineaVertical);
            }

            for (double y = 0; y < canvasPlano.ActualHeight; y += escala)
            {
                Line lineaHorizontal = new Line
                {
                    X1 = 0,
                    Y1 = y,
                    X2 = canvasPlano.ActualWidth,
                    Y2 = y,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                canvasPlano.Children.Add(lineaHorizontal);
            }

            // Dibujar ejes
            Line ejeX = new Line
            {
                X1 = 0,
                Y1 = origenY,
                X2 = canvasPlano.ActualWidth,
                Y2 = origenY,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Line ejeY = new Line
            {
                X1 = origenX,
                Y1 = 0,
                X2 = origenX,
                Y2 = canvasPlano.ActualHeight,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            canvasPlano.Children.Add(ejeX);
            canvasPlano.Children.Add(ejeY);
        }

        private Point Convertir(double x, double y)
        {
            double pantallaX = origenX + (x * escala);
            double pantallaY = origenY - (y * escala);
            return new Point(pantallaX, pantallaY);
        }

        private void cmbFiguras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string figuraSeleccionada = ((ComboBoxItem)cmbFiguras.SelectedItem).Content.ToString();
            if (figuraSeleccionada == "Rectángulo")
            {
                txtRadio.Visibility = Visibility.Hidden;
                txbRadio.Visibility = Visibility.Hidden;
                txtAltura.Visibility = Visibility.Visible;
                txbAltura.Visibility = Visibility.Visible;
                txtBase.Visibility = Visibility.Visible;
                txbBase.Visibility = Visibility.Visible;
            }
            else if (figuraSeleccionada == "Triángulo")
            {
                txtRadio.Visibility = Visibility.Hidden;
                txbRadio.Visibility = Visibility.Hidden;
                txtAltura.Visibility = Visibility.Visible;
                txbAltura.Visibility = Visibility.Visible;
                txtBase.Visibility = Visibility.Visible;
                txbBase.Visibility = Visibility.Visible;
            }
        }

        private void BtnDibujar_Click(object sender, RoutedEventArgs e)
        {
            DibujarPlano();

            double x = double.Parse(txtX.Text);
            double y = double.Parse(txtY.Text);

            string figuraSeleccionada = ((ComboBoxItem)cmbFiguras.SelectedItem).Content.ToString();

            if (figuraSeleccionada == "Círculo")
            {
                double radio = double.Parse(txtRadio.Text);
                Circulo figura = new Circulo(x, y, radio);
                Ellipse circulo = new Ellipse
                {
                    Width = radio * 2 * escala,
                    Height = radio * 2 * escala,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2
                };
                Point centro = Convertir(x, y);
                Canvas.SetLeft(circulo, centro.X - radio * escala);
                Canvas.SetTop(circulo, centro.Y - radio * escala);
                canvasPlano.Children.Add(circulo);

                txtRespuesta.Text = $"Área: {figura.CalcularArea():F2}\n" +
                                     $"Perímetro: {figura.CalcularPerimetro():F2}\n" +
                                     $"Posición: ({figura.posicionX}, {figura.posicionY})";
            }
            else if (figuraSeleccionada == "Rectángulo")
            {
                double baseR = double.Parse(txtBase.Text);
                double altura = double.Parse(txtAltura.Text);
                Rectangulo figura = new Rectangulo(x,y,baseR,altura);
                Rectangle rect = new Rectangle
                {
                    Width = baseR * escala,
                    Height = altura * escala,
                    Stroke = Brushes.Blue,
                    StrokeThickness = 2
                };
                Point esquina = Convertir(x, y);
                Canvas.SetLeft(rect, esquina.X);
                Canvas.SetTop(rect, esquina.Y - altura * escala);
                canvasPlano.Children.Add(rect);

                txtRespuesta.Text = $"Área: {figura.CalcularArea():F2}\n" +
                                     $"Perímetro: {figura.CalcularPerimetro():F2}\n" +
                                     $"Posición: ({figura.posicionX}, {figura.posicionY})";
            }
            else if (figuraSeleccionada == "Triángulo")
            {
                double baseT = double.Parse(txtBase.Text);
                double altura = double.Parse(txtAltura.Text);

                Point p1 = Convertir(x, y);
                Point p2 = Convertir(x + baseT, y);
                Point p3 = Convertir(x + baseT / 2, y + altura);

                Triangulo figura = new Triangulo(x, y, baseT, altura);

                Polygon triangulo = new Polygon
                {
                    Stroke = Brushes.Green,
                    StrokeThickness = 2,
                    Fill = Brushes.LightGreen,
                    Points = new PointCollection { p1, p2, p3 }
                };
                canvasPlano.Children.Add(triangulo);

                txtRespuesta.Text = $"Área: {figura.CalcularArea():F2}\n" +
                                     $"Perímetro: {figura.CalcularPerimetro():F2}\n" +
                                     $"Posición: ({figura.posicionX}, {figura.posicionY})";
            }

            
        }
    }
}