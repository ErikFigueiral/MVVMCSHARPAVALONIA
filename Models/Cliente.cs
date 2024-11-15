namespace DIAEFACLIENT.Models;


using System.Linq;

public class Cliente
{
    private string _dni;

    public required string Dni
    {
        get { return _dni; }
        init
        {
            if (value.Length == '9' && value.Take(value.Length - 1).All(char.IsDigit) && char.IsLetter(value[8]))
            {
                _dni = value;
            }
        }
    }

    public required string Nombre { get; init; }
    public required string Direccion { get; init; }
    public required string Codigo { get; init; }

    public override string ToString()
    {
        return $"Nombre:{Nombre} Dni:{Dni} Direccion:{Direccion} Codigo:{Codigo}";
    }
}
