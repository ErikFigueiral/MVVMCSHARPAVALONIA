using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using DIAEFACLIENT.Models;
using DIAEFACLIENT.Utils;
using DIAEFACLIENT.Views;

namespace DIAEFACLIENT.ViewModels;


public class AnadirClienteViewModel : ViewModelBase
{
    // Propiedades vinculadas a la vista
    private readonly ClienteFactory _clienteFactory;

    public Dictionary<string, string> AtributosCliente { get; }
    public ObservableCollection<string> ListaErroresCliente { get; }
    
    public IRelayCommand<string> ValidarCampoCommand { get; }
    // Comando para guardar el cliente
    public IRelayCommand AltaClienteCommand { get; }
    
    public AnadirClienteViewModel()
    {
        _clienteFactory = new ClienteFactory();

        // Inicializar los diccionarios desde la factoría
        AtributosCliente = _clienteFactory.CrearDiccionarioBase();
        ListaErroresCliente = _clienteFactory.CrearListaErroresBase();

        // Comandos
        AltaClienteCommand = new RelayCommand(AltaCliente, PuedeAltaCliente);
        ValidarCampoCommand = new RelayCommand<string>(ValidarCampo);
    }
    private void AltaCliente()
    {
        var cliente = _clienteFactory.CrearCliente(AtributosCliente);
        GestorClienteSingleton.GetInstancia().AnadirCliente(cliente);
        VistaSingleton.CerrarInstancia<AnadirClienteWindow>();
        //Messenger.GetInstance.Send(new CloseWindowMessage()); SingletonVista se cargo al messenger
    }
    
    private bool PuedeAltaCliente()
    {
        // Verifica que no haya errores y que todos los campos estén completos
        return ListaErroresCliente.All(string.IsNullOrWhiteSpace) &&
               AtributosCliente.Values.All(value => !string.IsNullOrWhiteSpace(value));
    }

    private void ActualizarEstadoBoton()
    {
        ((RelayCommand)AltaClienteCommand).NotifyCanExecuteChanged();
    }
    
    private void ValidarCampo(string nombreCampo)
    {
        if (!AtributosCliente.ContainsKey(nombreCampo)) return;

        // Realizamos validación llamando a los métodos estáticos de Cliente
        var valor = AtributosCliente[nombreCampo];
        string? error = nombreCampo switch
        {
            "Dni" => Cliente.ValidarDni(valor),
            "Nombre" => Cliente.ValidarNombre(valor),
            "Direccion" => Cliente.ValidarDireccion(valor),
            "Codigo" => Cliente.ValidarCodigo(valor),
            _ => null
        };
    
        // Determinamos el índice correspondiente del error en la lista
        int errorIndex = nombreCampo switch
        {
            "Dni" => 0,
            "Nombre" => 1,
            "Direccion" => 2,
            "Codigo" => 3,
            _ => -1
        };

        // Solo actualizamos si el índice es válido
        if (errorIndex >= 0)
        {
            ListaErroresCliente[errorIndex] = error;
        }

        // Actualizamos el estado del botón
        ActualizarEstadoBoton();
    }

}