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
        //var messenger = Messenger.GetInstance;
        DataContext = new AnadirClienteViewModel();
        
        //messenger.Register<CloseWindowMessage>(message => Close());
    }
    //Tenemos suerte de que se llama a Onclosed
    protected override void OnClosed(EventArgs e)
    {
        var messenger = Messenger.GetInstance;
        Console.WriteLine("CerrandoView añadir");
        VistaSingleton.CerrarInstancia<AnadirClienteWindow>();
        //messenger.Unregister<CloseWindowMessage>(message => Close());  // Desregistrarse
        base.OnClosed(e);
    }
    private void TextBox_LostFocus(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is AnadirClienteViewModel viewModel && sender is TextBox textBox)
        {
            // Usamos el nombre del TextBox como el identificador del campo
            string nombreCampo = textBox.Name switch
            {
                "TitularDNI" => "Dni",
                "TitularNombre" => "Nombre",
                "TitularDireccion" => "Direccion",
                "TitularCodigo" => "Codigo",
                _ => null
            };
            Console.WriteLine("focus vale"+nombreCampo);

            if (nombreCampo != null)
            {
                // Invocamos el comando para validar el campo
                viewModel.ValidarCampoCommand.Execute(nombreCampo);
            }
        }
    }
}