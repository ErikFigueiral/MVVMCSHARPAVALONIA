using System;
using CommunityToolkit.Mvvm.Input;
using DIAEFACLIENT.Models;

namespace DIAEFACLIENT.ViewModels;


public class AnadirClienteViewModel : ViewModelBase
{
    private string _titularDNI="";

    public string TitularDNI
    {
        get => _titularDNI;
        set
        {
            SetProperty(ref _titularDNI, value);
            AltaClienteCommand.NotifyCanExecuteChanged();
        }
    }


    
    private string _titularNombre="";
    public string TitularNombre
    {
        get => _titularNombre;
        set{
            SetProperty(ref _titularNombre, value);
            AltaClienteCommand.NotifyCanExecuteChanged();
        }
    }
    
    private string _titularDireccion="";
    public string TitularDireccion
    {
        get => _titularDireccion;
        set{
            SetProperty(ref _titularDireccion, value);
            AltaClienteCommand.NotifyCanExecuteChanged();
        }
    }
    
    private string _titularCodigo="";
    public string TitularCodigo
    {
        get => _titularCodigo;
        set{
            SetProperty(ref _titularCodigo, value);
            AltaClienteCommand.NotifyCanExecuteChanged();
        }
    }
    // Comando para guardar el cliente
    public IRelayCommand AltaClienteCommand { get; }
    
    public AnadirClienteViewModel()
    {
        AltaClienteCommand=new RelayCommand(AltaCliente,ComprobarAltaCliente);
    }

    private void AltaCliente()
    {
        GestorClienteSingleton.GetInstancia().AnadirCliente(new Cliente
        {
            Codigo = TitularCodigo,
            Direccion = TitularDireccion,
            Dni = TitularDNI,
            Nombre = TitularNombre

        });
        Console.WriteLine("hola");
    }
    
    private bool ComprobarAltaCliente()
    {
        return !string.IsNullOrWhiteSpace(TitularDNI) &&
               !string.IsNullOrWhiteSpace(TitularDireccion) &&
               !string.IsNullOrWhiteSpace(TitularNombre) &&
               !string.IsNullOrWhiteSpace(TitularCodigo);
    }
}