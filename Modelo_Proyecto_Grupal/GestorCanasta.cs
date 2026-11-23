using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modelo_Proyecto_Grupal
{
    public class GestorCanasta
    {
        private readonly List<Producto> PRIVcatalogo = new List<Producto>
        {
            new Producto("101", "Agua San Mateo 600ml", 2.50, 1, false),
            new Producto("102", "Leche Gloria Azul 400g", 4.80, 1, false),
            new Producto("103", "Cerveza Cusqueña 330ml", 7.50, 1, true)
        };

        private readonly List<Producto> PRIVcanasta = new List<Producto>();

        public List<Producto> Canasta => PRIVcanasta;

        public void LimpiarCanasta()
        {
            PRIVcanasta.Clear();
        }

        public void MostrarCatalogoTienda()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n================== CATÁLOGO DE PRODUCTOS METRO ==================");
            Console.WriteLine($"{"CÓDIGO",-8} | {"PRODUCTO",-26} | {"PRECIO (S/)",-12} | {"RESTRICCIÓN"}");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (Producto item in PRIVcatalogo)
            {
                string restriccion = item.RequiereEdad18 ? "Sí (+18)" : "Ninguna";
                Console.WriteLine($"{item.Codigo,-8} | {item.Nombre,-26} | S/ {item.PrecioUnitario,-9:F2} | {restriccion}");
            }
            Console.WriteLine("=================================================================");
            Console.ResetColor();
        }

        public IReadOnlyList<Producto> Catalogo => PRIVcatalogo.AsReadOnly();

        public Producto BuscarEnCatalogo(string codigo)
        {
            return PRIVcatalogo.Find(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        private int BuscarIndiceEnCanasta(string codigo)
        {
            return PRIVcanasta.FindIndex(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public void RegistrarProductoEscaneado(ValidadorSeguridad validador)
        {
            MostrarCatalogoTienda();
            Console.Write("\n[ESCANER] Ingrese o escriba el código de barras del producto: ");
            string codigo = Console.ReadLine()?.Trim() ?? "";

            Producto productoCatalogo = BuscarEnCatalogo(codigo);
            if (productoCatalogo == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Código de barras no encontrado en el sistema de Metro.");
                Console.ResetColor();
                return;
            }

            Console.Write($"Producto detectado: {productoCatalogo.Nombre} (S/ {productoCatalogo.PrecioUnitario:F2})\nIngrese la cantidad a llevar: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || !validador.ValidarCantidad(cantidad))
            {
                Console.WriteLine("Error: Cantidad no válida.");
                return;
            }

            if (validador.ValidarRestriccionEdad(productoCatalogo.RequiereEdad18))
            {
                int indice = BuscarIndiceEnCanasta(codigo);
                if (indice != -1)
                {
                    PRIVcanasta[indice].Cantidad += cantidad;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-> El producto ya estaba en la canasta. Se actualizó la cantidad.");
                    Console.ResetColor();
                }
                else
                {
                    PRIVcanasta.Add(new Producto(
                        productoCatalogo.Codigo,
                        productoCatalogo.Nombre,
                        productoCatalogo.PrecioUnitario,
                        cantidad,
                        productoCatalogo.RequiereEdad18
                    ));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-> Producto agregado exitosamente a la canasta.");
                    Console.ResetColor();
                }
            }
        }

        public void BuscarProductoEnCanasta()
        {
            Console.Write("\nIngrese el código de barras a buscar en su canasta: ");
            string codigo = Console.ReadLine()?.Trim() ?? "";

            int indice = BuscarIndiceEnCanasta(codigo);
            if (indice != -1)
            {
                Producto p = PRIVcanasta[indice];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[Encontrado] {p.Nombre} | Precio Unit: S/ {p.PrecioUnitario:F2} | Cant: {p.Cantidad} | Subtotal: S/ {p.Subtotal:F2}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("El producto no se encuentra en la canasta actual.");
            }
        }

        public void ModificarCantidad(ValidadorSeguridad validador)
        {
            Console.Write("\nIngrese el código de barras del producto a modificar: ");
            string codigo = Console.ReadLine()?.Trim() ?? "";

            int indice = BuscarIndiceEnCanasta(codigo);
            if (indice != -1)
            {
                Producto p = PRIVcanasta[indice];
                Console.WriteLine($"Producto: {p.Nombre} | Cantidad actual: {p.Cantidad}");
                Console.Write("Ingrese la nueva cantidad: ");

                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad) && validador.ValidarCantidad(nuevaCantidad))
                {
                    p.Cantidad = nuevaCantidad;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-> Cantidad actualizada con éxito.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Error: Cantidad no válida.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado en la canasta.");
            }
        }

        public void EliminarProducto()
        {
            Console.Write("\nIngrese el código de barras del producto a eliminar: ");
            string codigo = Console.ReadLine()?.Trim() ?? "";

            int indice = BuscarIndiceEnCanasta(codigo);
            if (indice != -1)
            {
                PRIVcanasta.RemoveAt(indice);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-> Producto eliminado de la canasta.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No se encontró el producto en la canasta.");
            }
        }

        public void MostrarCanasta()
        {
            if (PRIVcanasta.Count == 0)
            {
                Console.WriteLine("\n[Canasta vacía]");
                return;
            }

            double total = 0;
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine($"{"CÓDIGO",-10} | {"PRODUCTO",-26} | {"PRECIO",-10} | {"CANT.",-6} | {"SUBTOTAL"}");
            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Producto p in PRIVcanasta)
            {
                Console.WriteLine($"{p.Codigo,-10} | {p.Nombre,-26} | S/ {p.PrecioUnitario,-7:F2} | {p.Cantidad,-6} | S/ {p.Subtotal:F2}");
                total += p.Subtotal;
            }

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"TOTAL ACUMULADO PARCIAL: S/ {total:F2}");
        }

        private void MostrarMensajeInvalidoYResetear()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nOpción no válida");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(" .");
            }
            Console.ResetColor();
            Thread.Sleep(500);
            Console.Clear();
        }

        public void MenuOrdenarCanasta()
        {
            int opcionOrden;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n================ ORDENAR CANASTA ================");
                Console.ResetColor();
                Console.WriteLine("1. Por Precio Unitario (Burbuja)");
                Console.WriteLine("2. Por Subtotal (Selección)");
                Console.WriteLine("3. Volver");
                Console.Write("Elija método de ordenamiento: ");

                if (!int.TryParse(Console.ReadLine(), out opcionOrden))
                {
                    MostrarMensajeInvalidoYResetear();
                    opcionOrden = -1;
                    continue;
                }

                switch (opcionOrden)
                {
                    case 1:
                        OrdenarBurbujaPorPrecio();
                        break;
                    case 2:
                        OrdenarSeleccionPorSubtotal();
                        break;
                    case 3:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;
                    default:
                        MostrarMensajeInvalidoYResetear();
                        break;
                }
            } while (opcionOrden != 3);
        }

        public void OrdenarBurbujaPorPrecio()
        {
            if (PRIVcanasta.Count < 2)
            {
                Console.WriteLine("Faltan productos para ordenar.");
                return;
            }

            for (int i = 0; i < PRIVcanasta.Count - 1; i++)
            {
                for (int j = 0; j < PRIVcanasta.Count - i - 1; j++)
                {
                    if (PRIVcanasta[j].PrecioUnitario > PRIVcanasta[j + 1].PrecioUnitario)
                    {
                        Producto aux = PRIVcanasta[j];
                        PRIVcanasta[j] = PRIVcanasta[j + 1];
                        PRIVcanasta[j + 1] = aux;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-> Canasta ordenada por PRECIO UNITARIO (Burbuja).");
            Console.ResetColor();
        }

        public void OrdenarSeleccionPorSubtotal()
        {
            if (PRIVcanasta.Count < 2)
            {
                Console.WriteLine("Faltan productos para ordenar.");
                return;
            }

            for (int i = 0; i < PRIVcanasta.Count - 1; i++)
            {
                int mayor = i;
                for (int j = i + 1; j < PRIVcanasta.Count; j++)
                {
                    if (PRIVcanasta[j].Subtotal > PRIVcanasta[mayor].Subtotal)
                    {
                        mayor = j;
                    }
                }

                if (mayor != i)
                {
                    Producto aux = PRIVcanasta[i];
                    PRIVcanasta[i] = PRIVcanasta[mayor];
                    PRIVcanasta[mayor] = aux;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-> Canasta ordenada por SUBTOTAL (Selección).");
            Console.ResetColor();
        }
    }
}