namespace DIAEFACLIENT.Utils;
using System.Collections.Generic;
using DIAEFACLIENT.Models;
using System.Xml.Linq;

public class ClienteAdapter : IAdaptadorXML<Cliente>
{
    // Convierte la lista de clientes a un XElement (Árbol XML)
        
    public XElement ToXml(List<Cliente> clientes)
    {
        var clientesElement = new XElement("Clientes");

        foreach (var cliente in clientes)
        {
            var clienteElement = new XElement("Cliente",
                new XElement("Nombre", cliente.Nombre),
                new XElement("Dni", cliente.Dni),
                new XElement("Codigo", cliente.Codigo),
                new XElement("Direccion", cliente.Direccion)
            );
            clientesElement.Add(clienteElement);
        }

        return clientesElement;
    }

    // Convierte un XElement a una lista de clientes
    public List<Cliente> FromXml(XElement xml)
    {
        var clientes = new List<Cliente>();

        foreach (var clienteElement in xml.Elements("Cliente"))
        {
            var cliente = new Cliente
            {
                Nombre = (string)clienteElement.Element("Nombre"),
                Dni = (string)clienteElement.Element("Dni"),
                Codigo = (string)clienteElement.Element("Codigo"),
                Direccion = (string)clienteElement.Element("Direccion")
            };

            clientes.Add(cliente);
        }

        return clientes;
    }
}

