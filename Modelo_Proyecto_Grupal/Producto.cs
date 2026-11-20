using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Proyecto_Grupal
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public bool RequiereEdad18 { get; set; }

        public double Subtotal => PrecioUnitario * Cantidad;

        public Producto(string codigo, string nombre, double precioUnitario, int cantidad, bool requiereEdad18)
        {
            Codigo = codigo;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            RequiereEdad18 = requiereEdad18;
        }
    }
}