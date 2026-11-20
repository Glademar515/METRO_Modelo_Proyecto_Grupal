using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Proyecto_Grupal
{
    public class GestorCanasta
    {
        private readonly List<Producto> _catalogo = new List<Producto>
        {
            new Producto("101", "Agua San Mateo 600ml", 2.50, 1, false),
            new Producto("102", "Leche Gloria Azul 400g", 4.80, 1, false),
            new Producto("103", "Cerveza Cusqueña 330ml", 7.50, 1, true)
        };

        private readonly List<Producto> _canasta = new List<Producto>();

        public List<Producto> Canasta => _canasta;

        public void LimpiarCanasta()
        {
            _canasta.Clear();
        }

        public void MostrarCatalogoTienda()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n================== CATÁLOGO DE PRODUCTOS METRO ==================");
            Console.WriteLine($"{"CÓDIGO",-8} | {"PRODUCTO",-26} | {"PRECIO (S/)",-12} | {"RESTRICCIÓN"}");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (Producto item in _catalogo)
            {
                string restriccionTexto = item.RequiereEdad18 ? "Sí (+18)" : "Ninguna";
                Console.WriteLine($"{item.Codigo,-8} | {item.Nombre,-26} | S/ {item.PrecioUnitario,-9:F2} | {restriccionTexto}");
            }
            Console.WriteLine("=================================================================");
            Console.ResetColor();
        }

        private Producto BuscarEnCatalogo(string codigoBuscado)
        {
            return _catalogo.Find(p => p.Codigo.Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase));
        }

        private int BuscarIndiceEnCanasta(string codigoBuscado)
        {
            return _canasta.FindIndex(p => p.Codigo.Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase));
        }

        public void RegistrarProductoEscaneado(ValidadorSeguridad validador)
        {
            MostrarCatalogoTienda();
            Console.Write("\n[ESCANER] Ingrese o escriba el código de barras del producto: ");
            string codigoEscaneado = Console.ReadLine()?.Trim() ?? "";

            Producto itemCatalogo = BuscarEnCatalogo(codigoEscaneado);
            if (itemCatalogo == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Código de barras no encontrado en el sistema de Metro.");
                Console.ResetColor();
                return;
            }

            Console.Write($"Producto detectado: {itemCatalogo.Nombre} (S/ {itemCatalogo.PrecioUnitario:F2})\nIngrese la cantidad a llevar: ");
            if (!int.TryParse(Console.ReadLine(), out int cant) || !validador.ValidarCantidad(cant))
            {
                Console.WriteLine("Error: Cantidad no válida.");
                return;
            }

            if (validador.ValidarRestriccionEdad(itemCatalogo.RequiereEdad18))
            {
                int posExistente = BuscarIndiceEnCanasta(codigoEscaneado);
                if (posExistente != -1)
                {
                    _canasta[posExistente].Cantidad += cant;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-> El producto ya estaba en la canasta. Se actualizó la cantidad.");
                    Console.ResetColor();
                }
                else
                {
                    _canasta.Add(new Producto(
                        itemCatalogo.Codigo,
                        itemCatalogo.Nombre,
                        itemCatalogo.PrecioUnitario,
                        cant,
                        itemCatalogo.RequiereEdad18
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
            string codBuscado = Console.ReadLine()?.Trim() ?? "";

            int pos = BuscarIndiceEnCanasta(codBuscado);
            if (pos != -1)
            {
                Producto p = _canasta[pos];
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
            string codMod = Console.ReadLine()?.Trim() ?? "";

            int pos = BuscarIndiceEnCanasta(codMod);
            if (pos != -1)
            {
                Producto p = _canasta[pos];
                Console.WriteLine($"Producto: {p.Nombre} | Cantidad actual: {p.Cantidad}");
                Console.Write("Ingrese la nueva cantidad: ");

                if (int.TryParse(Console.ReadLine(), out int nuevaCant) && validador.ValidarCantidad(nuevaCant))
                {
                    p.Cantidad = nuevaCant;
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
            string codElim = Console.ReadLine()?.Trim() ?? "";

            int pos = BuscarIndiceEnCanasta(codElim);
            if (pos != -1)
            {
                _canasta.RemoveAt(pos);
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
            if (_canasta.Count == 0)
            {
                Console.WriteLine("\n[Canasta vacía]");
                return;
            }

            double acumulado = 0;
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine($"{"CÓDIGO",-10} | {"PRODUCTO",-26} | {"PRECIO",-10} | {"CANT.",-6} | {"SUBTOTAL"}");
            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Producto p in _canasta)
            {
                Console.WriteLine($"{p.Codigo,-10} | {p.Nombre,-26} | S/ {p.PrecioUnitario,-7:F2} | {p.Cantidad,-6} | S/ {p.Subtotal:F2}");
                acumulado += p.Subtotal;
            }

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"TOTAL ACUMULADO PARCIAL: S/ {acumulado:F2}");
        }

        public void OrdenarBurbujaPorPrecio()
        {
            if (_canasta.Count < 2)
            {
                Console.WriteLine("Faltan productos para ordenar.");
                return;
            }

            for (int i = 0; i < _canasta.Count - 1; i++)
            {
                for (int j = 0; j < _canasta.Count - i - 1; j++)
                {
                    if (_canasta[j].PrecioUnitario > _canasta[j + 1].PrecioUnitario)
                    {
                        Producto aux = _canasta[j];
                        _canasta[j] = _canasta[j + 1];
                        _canasta[j + 1] = aux;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-> Canasta ordenada por PRECIO UNITARIO (Burbuja).");
            Console.ResetColor();
        }

        public void OrdenarSeleccionPorSubtotal()
        {
            if (_canasta.Count < 2)
            {
                Console.WriteLine("Faltan productos para ordenar.");
                return;
            }

            for (int i = 0; i < _canasta.Count - 1; i++)
            {
                int indiceMayor = i;
                for (int j = i + 1; j < _canasta.Count; j++)
                {
                    if (_canasta[j].Subtotal > _canasta[indiceMayor].Subtotal)
                    {
                        indiceMayor = j;
                    }
                }

                if (indiceMayor != i)
                {
                    Producto aux = _canasta[i];
                    _canasta[i] = _canasta[indiceMayor];
                    _canasta[indiceMayor] = aux;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-> Canasta ordenada por SUBTOTAL (Selección).");
            Console.ResetColor();
        }
    }
}