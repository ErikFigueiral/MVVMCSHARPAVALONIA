using System;
using System.Collections.Generic;

namespace DIAEFACLIENT.Models;


using System.Linq;

public class Cliente
{
    private string _dni;

    public string Dni
    {
        get => _dni;
        init
        {
            var error = ValidarDni(value);
            if (error != null)
                throw new ArgumentException(error);
            _dni = value;
        }
    }

    public string Nombre { get; init; }
    public string Direccion { get; init; }
    public string Codigo { get; init; }

    // Métodos de validación
    public static string? ValidarDni(string dni)
    {
        dni = dni.Trim();
        if (dni.Length != 9 || !dni.Take(8).All(char.IsDigit) || !char.IsLetter(dni[8]))
            return "DNI incorrecto. Debe tener 8 dígitos seguidos de una letra.";
        return null;
    }

    public static string? ValidarNombre(string nombre)
    {
        return string.IsNullOrWhiteSpace(nombre) ? "El nombre no puede estar vacío." : null;
    }

    public static string? ValidarDireccion(string direccion)
    {
        return string.IsNullOrWhiteSpace(direccion) ? "La dirección no puede estar vacía." : null;
    }

    public static string? ValidarCodigo(string codigo)
    {
        return string.IsNullOrWhiteSpace(codigo) ? "El código no puede estar vacío." : null;
    }

    public override string ToString()
    {
        return $"Nombre:{Nombre} Dni:{Dni} Direccion:{Direccion} Codigo:{Codigo}";
    }
}
