namespace DIAEFACLIENT.Models;

using System.Xml.Linq;
using System;
using System.Collections.Generic;
public class ClienteXML
{
    public required List<Cliente> ListaClientes { get; init; }

    private XElement ToXml()
    {
        var toret = new XElement("Clientes");
        foreach (var c in this.ListaClientes)
        {
            var v = new XElement("cliente");
            v.Add(new XElement("nombre", c.Nombre));
            v.Add(new XElement("dni",c.Dni));
            v.Add(new XElement("direccion",c.Direccion));
            v.Add(new XElement("codigo",c.Codigo));
            toret.Add(v);
        }
        return toret;
    }
    public void Save(string nf)
    {
        XElement raiz=ToXml();
        raiz.Save(nf);
    }
    public  List<Cliente> Load(string nf)
    {
        return FromXML(XElement.Load(nf));
    }

    private List<Cliente> FromXML(XElement xet)
    {
        var toret = new List<Cliente>();
        foreach (var e in xet.Elements())
        {
            var c= new Cliente
            {
                Nombre = (string)e.Element("nombre"),
                Dni = (string)e.Element("dni"),
                Codigo = (string)e.Element("codigo"),
                Direccion = (string)e.Element("direccion")
            };
            toret.Add(c);
        }

        return toret;
    }
  
}