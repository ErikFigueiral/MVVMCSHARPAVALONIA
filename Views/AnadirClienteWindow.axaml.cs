using System;
using Avalonia.Controls;
using DIAEFACLIENT.Utils;
using DIAEFACLIENT.ViewModels;

namespace DIAEFACLIENT.Views;

public partial class AnadirClienteWindow : Window
{
    public AnadirClienteWindow()
    {
        InitializeComponent();
        //No queremos acoplamiento directa ViewModel-View
        var messenger = new Messenger();
        DataContext = new AnadirClienteViewModel(messenger);
        
        messenger.Register<CloseWindowMessage>(message => Close());
    }
    private void TextBox_LostFocus(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var viewModel = (AnadirClienteViewModel)DataContext;
        // Es un cast seguro,sino es vale NULL
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