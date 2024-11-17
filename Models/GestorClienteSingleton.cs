using System;
using System.Runtime.CompilerServices;
using DIAEFACLIENT.Utils;

namespace DIAEFACLIENT.Models;

using System.Collections.Generic;


using System.Collections.ObjectModel;

public class GestorClienteSingleton
{
    private Action<IPersistencia<Cliente>, List<Cliente>> saveAction = (persistencia, lista) =>
    {
        persistencia.Save(lista);
    };
    
    private  IPersistencia<Cliente> _persistencia=new ConvertidorXML<Cliente>("Clientes.xml",new ClienteAdapter());
    
    private static GestorClienteSingleton instancia = new GestorClienteSingleton();
    public ObservableCollection<Cliente> _listaCliente { get; private set; }
    //Proxy Pattern
    public ReadOnlyObservableCollection<Cliente> ListaCliente
    {
        get=>new ReadOnlyObservableCollection<Cliente>(_listaCliente);
    }
    
    private GestorClienteSingleton()
    {
        _listaCliente = new ObservableCollection<Cliente>(_persistencia.Load());
        _listaCliente.CollectionChanged += (sender, args) =>
        {
            EventAggregator.Instance.Publish(new ListaClientesCambiadaMessage());
            saveAction?.Invoke(_persistencia,new List<Cliente>(_listaCliente));
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