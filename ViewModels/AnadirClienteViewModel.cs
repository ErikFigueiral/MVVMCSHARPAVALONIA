using System;
using CommunityToolkit.Mvvm.Input;
using DIAEFACLIENT.Models;
using DIAEFACLIENT.Utils;

namespace DIAEFACLIENT.ViewModels;


public class AnadirClienteViewModel : ViewModelBase
{
    // Propiedades vinculadas a la vista
    private string _titularDNI = "";
    public string TitularDNI
    {
        get => _titularDNI;
        //Observador-Observable (BIDIRECCIONAL)!!
        set => SetProperty(ref _titularDNI, value); // No validamos en el setter
    }

    private string _titularNombre = "";
    public string TitularNombre
    {
        get => _titularNombre;
        set => SetProperty(ref _titularNombre, value);
    }

    private string _titularDireccion = "";
    public string TitularDireccion
    {
        get => _titularDireccion;
        set => SetProperty(ref _titularDireccion, value);
    }

    private string _titularCodigo = "";
    public string TitularCodigo
    {
        get => _titularCodigo;
        set => SetProperty(ref _titularCodigo, value);
    }

    // Propiedades para almacenar los errores
    private string _dniError;
    public string DniError
    {
        get => _dniError;
        set => SetProperty(ref _dniError, value);
    }

    private string _nombreError;
    public string NombreError
    {
        get => _nombreError;
        set => SetProperty(ref _nombreError, value);
    }

    private string _direccionError;
    public string DireccionError
    {
        get => _direccionError;
        set => SetProperty(ref _direccionError, value);
    }

    private string _codigoError;
    public string CodigoError
    {
        get => _codigoError;
        set => SetProperty(ref _codigoError, value);
    }
    // Comando para guardar el cliente
    public IRelayCommand AltaClienteCommand { get; }
    public Messenger Messenger { get; init; }
    
    public AnadirClienteViewModel(Messenger messenger)
    {
        Messenger = messenger;
        AltaClienteCommand=new RelayCommand(AltaCliente,ComprobarAltaCliente);
    }

    private void AltaCliente()
    {
        //Al usar setters alomejor puedo comprobar hay errores probably
        GestorClienteSingleton.GetInstancia().AnadirCliente(new Cliente
        {
            Codigo = TitularCodigo,
            Direccion = TitularDireccion,
            Dni = TitularDNI,
            Nombre = TitularNombre

        });
        Messenger.Send(new CloseWindowMessage());
    }
    
    private bool ComprobarAltaCliente()
    {
        return string.IsNullOrWhiteSpace(Cliente.ValidarDni(TitularDNI)) &&
               string.IsNullOrWhiteSpace(Cliente.ValidarNombre(TitularNombre)) &&
               string.IsNullOrWhiteSpace(Cliente.ValidarDireccion(TitularDireccion)) &&
               string.IsNullOrWhiteSpace(Cliente.ValidarCodigo(TitularCodigo));
    }

    private void ActualizarEstadoBoton()
    {
        ((RelayCommand)AltaClienteCommand).NotifyCanExecuteChanged();
    }
    
    public void ValidarDniOnLostFocus()
    {
        
        DniError = Cliente.ValidarDni(TitularDNI);
        ActualizarEstadoBoton();
    }

    public void ValidarNombreOnLostFocus()
    {
        NombreError = Cliente.ValidarNombre(TitularNombre);
        ActualizarEstadoBoton();
    }

    public void ValidarDireccionOnLostFocus()
    {
        DireccionError = Cliente.ValidarDireccion(TitularDireccion);
        ActualizarEstadoBoton();
    }

    public void ValidarCodigoOnLostFocus()
    {
        CodigoError = Cliente.ValidarCodigo(TitularCodigo);
        ActualizarEstadoBoton();
    }
}