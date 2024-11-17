namespace DIAEFACLIENT.Utils;
using System.Collections.Generic;
using System.Xml.Linq;
public interface IAdaptadorXML<T>
{
    XElement ToXml(List<T> items); // Convierte la lista a un árbol XML (XElement)
    List<T> FromXml(XElement xml); // Convierte un árbol XML en una lista de objetos
}

