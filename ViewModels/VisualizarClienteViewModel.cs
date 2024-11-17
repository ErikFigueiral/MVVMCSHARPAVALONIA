using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using DIAEFACLIENT.Models;
using DIAEFACLIENT.Utils;
using DIAEFACLIENT.Views;

namespace DIAEFACLIENT.ViewModels;

public class VisualizarClienteViewModel :  ViewModelBase
{
    public ObservableCollection<Cliente> Clientes { get; }
    public IRelayCommand EliminarClienteCommand { get; }
    public IRelayCommand CerrarVentanaCommand { get; }

    public VisualizarClienteViewModel()
    {
        // Inicializamos la lista de clientes con la lista de clientes del GestorClienteSingleton
        Clientes = GestorClienteSingleton.GetInstancia()._listaCliente;
        EliminarClienteCommand = new RelayCommand<Cliente>(EliminarCliente);
        CerrarVentanaCommand = new RelayCommand(CerrarVentana);
    }

    private void EliminarCliente(Cliente cliente)
    {
        Console.WriteLine("Elimianmos cliente");
        // Eliminar el cliente de la lista
        if (cliente != null)
        {
            Clientes.Remove(cliente);
            foreach (var c in Clientes)
            {
                Console.WriteLine("DESPUES ELIMINAR"+c);
            }
            OnPropertyChanged(nameof(Clientes));
        }

        if (GestorClienteSingleton.GetInstancia()._listaCliente.Count == 0)
        {
            CerrarVentana();
        }

    }

    private void CerrarVentana()
    {
        // Método para cerrar la ventana
        VistaSingleton.CerrarInstancia<VisualizarClienteWindow>();
        //Messenger.GetInstance.Send(new CloseWindowMessage());
    }
}