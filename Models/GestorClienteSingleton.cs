namespace DIAEFACLIENT.Models;

using System.Collections.Generic;


using System.Collections.ObjectModel;

public class GestorClienteSingleton
{
    private static GestorClienteSingleton instancia = new GestorClienteSingleton();
    private   List<Cliente> listaCliente=new List<Cliente>();
    
    private GestorClienteSingleton()
    {
        
    }

    public static GestorClienteSingleton  GetInstancia()
    {
        return instancia;
    }
    
    public  ReadOnlyCollection<Cliente> ListaCliente => new ReadOnlyCollection<Cliente>(this.listaCliente);

    public void AnadirCliente(Cliente cliente)
    {
        listaCliente.Add(cliente);
    }

    public void BorrarCliente(Cliente cliente)
    {
        listaCliente.Remove(cliente);
    }
}