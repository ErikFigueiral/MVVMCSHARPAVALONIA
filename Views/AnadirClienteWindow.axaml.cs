using System;
using Avalonia.Controls;
using DIAEFACLIENT.ViewModels;

namespace DIAEFACLIENT.Views;

public partial class AnadirClienteWindow : Window
{
    public AnadirClienteWindow()
    {
        InitializeComponent();
        DataContext = new AnadirClienteViewModel();
    }
    private void TextBox_LostFocus(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var viewModel = (AnadirClienteViewModel)DataContext;
        // Comprobamos qué campo ha perdido el foco
        var textBox = sender as TextBox;
        if (textBox != null)
        {
            if (textBox.Name == "TitularDNI")
            {
                viewModel.ValidarDniOnLostFocus();
            }
            else if (textBox.Name == "TitularNombre")
            {
                viewModel.ValidarNombreOnLostFocus();
            }
            else if (textBox.Name == "TitularDireccion")
            {
                viewModel.ValidarDireccionOnLostFocus();
            }
            else if (textBox.Name == "TitularCodigo")
            {
                viewModel.ValidarCodigoOnLostFocus();
            }
        }
    }
}