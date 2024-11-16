using System;
using DIAEFACLIENT.Utils;

namespace DIAEFACLIENT.Models;

using System.Collections.Generic;


using System.Collections.ObjectModel;

public class GestorClienteSingleton
{
    private static Action<List<Cliente>> saveAction = lista =>
    {
        ClienteXML.Save("Clientes.xml", lista);
    };
    private static GestorClienteSingleton instancia = new GestorClienteSingleton(ClienteXML.Load("Clientes.xml"),saveAction);
    public ObservableCollection<Cliente> _listaCliente { get; private set; }
    //Proxy Pattern
    public ReadOnlyObservableCollection<Cliente> ListaCliente
    {
        get=>new ReadOnlyObservableCollection<Cliente>(_listaCliente);
    }
    public event Action ListaClienteCambiada;
    private GestorClienteSingleton(List<Cliente> initialList, Action<List<Cliente>> onSaveCallback)
    {
        _listaCliente = new ObservableCollection<Cliente>(initialList);
        _listaCliente.CollectionChanged += (sender, args) =>
        {
            EventAggregator.Instance.Publish(new ListaClientesCambiadaMessage());
            onSaveCallback?.Invoke(new List<Cliente>(_listaCliente));
        };
    }

    public static GestorClienteSingleton  GetInstancia()
    {
        return instancia;
    }
    

    public void AnadirCliente(Cliente cliente)
    {
        _listaCliente.Add(cliente);
    }

    public void BorrarCliente(Cliente cliente)
    {
        _listaCliente.Remove(cliente);
    }
}

//Mensajes
public class ListaClientesCambiadaMessage
{
    // Puedes agregar más detalles si lo necesitas
}