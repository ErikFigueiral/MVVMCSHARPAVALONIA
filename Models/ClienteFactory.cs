using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DIAEFACLIENT.Models;

public class ClienteFactory
{
    public Dictionary<string, string> CrearDiccionarioBase()
    {
        return new Dictionary<string, string>
        {
            { "Dni", "" },
            { "Nombre", "" },
            { "Direccion", "" },
            { "Codigo", "" }
        };
    }

    public ObservableCollection<string> CrearListaErroresBase()
    {
        return new ObservableCollection<string>
        {
            "", // Error para el DNI
            "", // Error para el Nombre
            "", // Error para la Dirección
            ""  // Error para el Código
        };
    }

    public Cliente CrearCliente(Dictionary<string, string> atributos)
    {
        var camposRequeridos = new[] { "Dni", "Nombre", "Direccion", "Codigo" };

        foreach (var campo in camposRequeridos)
        {
            if (!atributos.ContainsKey(campo) || string.IsNullOrWhiteSpace(atributos[campo]))
            {
                throw new ArgumentException($"Falta el campo requerido: {campo}");
            }
        }

        return new Cliente
        {
            Dni = atributos["Dni"],
            Nombre = atributos["Nombre"],
            Direccion = atributos["Direccion"],
            Codigo = atributos["Codigo"]
        };
    }
}
