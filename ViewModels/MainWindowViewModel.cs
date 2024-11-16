using DIAEFACLIENT.Utils;

namespace DIAEFACLIENT.ViewModels;
using System;
using Avalonia;
using DIAEFACLIENT.Models;
using DIAEFACLIENT.Views;


using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public IRelayCommand AñadirClienteCommand { get; }
    public IRelayCommand VisualizarClienteCommand { get; }

    public MainWindowViewModel()
    {
        AñadirClienteCommand = new RelayCommand(AñadirCliente);
        VisualizarClienteCommand = new RelayCommand(VisualizarCliente,PoderVisualizarCliente);
    }

    private void AñadirCliente()
    {
        Console.WriteLine("Añadiendo cliente!");
        var messenger = Messenger.GetInstance;
        if (!PoderVisualizarCliente())
        {
            messenger.Register<AddClient>(message =>
                ((RelayCommand)VisualizarClienteCommand).NotifyCanExecuteChanged());
        }
        AbrirVentanaAñadirCliente();
    }

    private void VisualizarCliente()
    {
        Console.WriteLine("Visualizo cliente!");
        AbrirVentanaVisualizarCliente();
    }
    //De esta manera  si hay clientes habilitamos el Command o no
    private bool PoderVisualizarCliente()
    {
        Console.WriteLine("Compruebo de nuevo");
        var messenger = Messenger.GetInstance;
        messenger.Unregister<AddClient>(message => ((RelayCommand)VisualizarClienteCommand).NotifyCanExecuteChanged());
        return GestorClienteSingleton.GetInstancia()._listaCliente.Count != 0;
    }
    private void AbrirVentanaAñadirCliente()
    {
        var ventana = new AnadirClienteWindow();
        ventana.Show(); // Abre la ventana de forma modal
    }

    private void AbrirVentanaVisualizarCliente()
    {
        var ventana = new VisualizarClienteWindow();
        ventana.Show();
    }
}
