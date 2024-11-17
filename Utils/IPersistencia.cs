namespace DIAEFACLIENT.Utils;
using System.Collections.Generic;
public interface IPersistencia<T>
{
    void Save(List<T> items); // Guarda la lista
    List<T> Load(); // Carga la lista
}



