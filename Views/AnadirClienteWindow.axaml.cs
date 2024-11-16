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
        var messenger = Messenger.GetInstance;
        DataContext = new AnadirClienteViewModel();
        
        messenger.Register<CloseWindowMessage>(message => Close());
    }
    //Tenemos suerte de que se llama a Onclosed
    protected override void OnClosed(EventArgs e)
    {
        var messenger = Messenger.GetInstance;
        Console.WriteLine("Me cierro");
        messenger.Unregister<CloseWindowMessage>(message => Close());  // Desregistrarse
        base.OnClosed(e);
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