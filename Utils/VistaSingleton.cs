using System;
using System.Collections.Generic;
using Avalonia.Controls;

namespace DIAEFACLIENT.Utils;
//Controlaremos que solo tengamos 1 isntanciacion de las Vistas,la principal consideró que es independiente
public class VistaSingleton
{
    // Lista para almacenar las vistas activas
    private static Dictionary<Type, Window> vistasActivas = new Dictionary<Type, Window>();

    private VistaSingleton() {}

    // Método para obtener la instancia de la vista (reutiliza o crea una nueva)
    //Nos vasamos en SUBTIPOS
    //restricción que debe heredar,lenguaje potente,new() obliga constructor sin parámetros
    public static T GetInstancia<T>() where T : Window, new()
    {
        // Verificar si la vista ya está en la lista de vistas activas
        if (vistasActivas.ContainsKey(typeof(T)))
        {
            return (T)vistasActivas[typeof(T)];
        }
        else
        {
            // Si no está, crear una nueva instancia y agregarla a la lista
            T vista = new T();
            vistasActivas.Add(typeof(T), vista);
            return vista;
        }
    }
    public static void CerrarInstancia<T>() where T : Window
    {
        Console.WriteLine("Me llaman a cerrarInstancia");
        // Verificar si la vista está en la lista de vistas activas
        if (vistasActivas.ContainsKey(typeof(T)))
        {
            // Obtener la vista y cerrar la ventana
            var vista = (T)vistasActivas[typeof(T)];
            vista.Close();  // Cierra la ventana

            // Eliminar la vista de la lista de vistas activas
            vistasActivas.Remove(typeof(T));
        }
    }

    // Método para cerrar todas las vistas activas
    public static void CerrarVistas()
    {
        Console.WriteLine("hola me llaman singleton");
        foreach (var vista in vistasActivas.Values)
        {
            Console.WriteLine("CERRANDO VISTA SINGLETON");
            vista.Close();
        }
        vistasActivas.Clear();
    }
}