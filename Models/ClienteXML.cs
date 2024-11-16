namespace DIAEFACLIENT.Models;

using System.Xml.Linq;
using System;
using System.Collections.Generic;
public abstract class ClienteXML
{

    private static XElement ToXml(List<Cliente> listaClientes)
    {
        var toret = new XElement("Clientes");
        foreach (var c in listaClientes)
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
    public static void Save(string nf,List<Cliente> listaClientes)
    {
        XElement raiz=ToXml(listaClientes);
        raiz.Save(nf);
    }
    public static  List<Cliente> Load(string nf)
    {
        try
        {
            return FromXML(XElement.Load(nf));
        }
        catch (Exception e)
        {
            return new List<Cliente>();
        }
    }

    private static List<Cliente> FromXML(XElement xet)
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