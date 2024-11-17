using System.Collections.Generic;
using System.Xml.Linq;
namespace DIAEFACLIENT.Utils;


public class ConvertidorXML<T> : IPersistencia<T>
{
    private string _fileName;
    private IAdaptadorXML<T> _adaptadorXML;

    // Recibe el adaptador y el nombre del archivo
    public ConvertidorXML(string fileName, IAdaptadorXML<T> adaptadorXML)
    {
        _fileName = fileName;
        _adaptadorXML = adaptadorXML;
    }

    // Guarda la lista en XML
    public void Save(List<T> items)
    {
        XElement xml = _adaptadorXML.ToXml(items);
        xml.Save(_fileName); // Guardamos el XML en el archivo
    }

    // Carga la lista desde XML
    public List<T> Load()
    {
        XElement xml = XElement.Load(_fileName); // Carga el archivo XML
        return _adaptadorXML.FromXml(xml); // Convertimos el XML en una lista de objetos
    }
}





