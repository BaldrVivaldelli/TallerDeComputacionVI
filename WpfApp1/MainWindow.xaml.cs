using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Login {
                Usuario = new Ingreso { Etiqueta = "Usuario" },
                Clave = new Ingreso { Etiqueta = "Clave" },
            };
            
        }
    }
    public class Login : INotifyPropertyChanged
    {
        private Ingreso _usuario;

        public ButtonCommand IngresarCommand { get; set; }
        public Ingreso Usuario
        {
            get => _usuario;
            set { _usuario = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Usuario"));

                }
            }
        }
        public Ingreso Clave { get; set; }
        public Login()
        {
            IngresarCommand = new ButtonCommand(Ingresar, IsValid);
        }
        public void Ingresar()
        {
            Console.WriteLine(Usuario.Valor);
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Usuario.Valor) && !string.IsNullOrEmpty(Clave.Valor);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Ingreso : INotifyPropertyChanged
    {
        private string _etiqueta;
        private string _valor;

        public string Etiqueta { get => _etiqueta;
            set {
                _etiqueta = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Etiqueta"));

                }
            }

        }
        public string Valor
        {
            get => _valor;
            set
            {
                _valor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Valor"));

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
