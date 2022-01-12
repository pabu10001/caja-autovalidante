using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Componentes.MisControles
{
    /// <summary>
    /// Lógica de interacción para Validacion.xaml
    /// </summary>
    public partial class Validacion : UserControl
    {
        public String tipoValidacion { get; set; }
        
        public Validacion()
        {
            InitializeComponent();
        }

        private void textbox_input_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox input = (TextBox)sender;
            validate(tipoValidacion, input.Text);
        }

        private void validate(String tipo, String campo)
        {
            switch (tipo)
            {
                case "dni":
                    if (Regex.Match(campo, @"^((([A-Za-z])\d{8})|(\d{8}([A-Za-z])))$").Success)
                    {
                        label_errores.Content = "";
                    }
                    else
                    {
                        label_errores.Content = "Formato de dni incorrecto";
                    }
                    break;

                case "tlf":
                    if (Regex.Match(campo, @"^([0-9])\d{8}$").Success)
                    {
                        label_errores.Content = "";
                    }
                    else
                    {
                        label_errores.Content = "Formato de telefono incorrecto";
                    }
                        break;
                case "cp":
                    if (Regex.Match(campo, @"^([0-9]\d{4})$").Success)
                    {
                        label_errores.Content = "";
                    }
                    else
                    {
                        label_errores.Content = "Formato de codigo postal incorrecto";
                    }
                    break;

                default:
                    label_errores.Content = "Atributo no valido";
                    break;
            }
        }
    }
}
