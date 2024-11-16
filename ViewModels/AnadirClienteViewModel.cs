using System;
using CommunityToolkit.Mvvm.Input;

namespace DIAEFACLIENT.ViewModels;


public class AnadirClienteViewModel : ViewModelBase
{
    private string _titularDNI="";
    public string TitularDNI 
    {
           get => _titularDNI;
           set => SetProperty(ref _titularDNI, value);
    }
    
    private string _titularNombre="";
    public string TitularNombre
    {
        get => _titularNombre;
        set => SetProperty(ref _titularNombre, value);
    }
    
    private string _titularDireccion="";
    public string TitularDireccion
    {
        get => _titularDireccion;
        set => SetProperty(ref _titularDireccion, value);
    }
    
    private string _titularCodigo="";
    public string TitularCodigo
    {
        get => _titularCodigo;
        set => SetProperty(ref _titularCodigo, value);
    }
    // Comando para guardar el cliente
    public IRelayCommand AltaClienteCommand { get; }
    
    public AnadirClienteViewModel()
    {
        AltaClienteCommand=new RelayCommand(AltaCliente);
    }

    private void AltaCliente()
    {
       Console.WriteLine("Estoy ejecutando"+TitularDNI);
    }
}