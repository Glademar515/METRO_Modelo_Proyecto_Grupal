using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MAIN DEL SISTEMA
namespace Modelo_Proyecto_Grupal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidadorSeguridad validador = new ValidadorSeguridad();
            GestorCanasta gestorCanasta = new GestorCanasta();
            ControladorPagos controladorPagos = new ControladorPagos();
            FuncionesRecursivas funcionesRecursivas = new FuncionesRecursivas();

            int opcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n==============================================================");
                Console.WriteLine("   SISTEMA DE CONTROL DE PAGOS Y AUTOCOBRO - METRO LIMA 2026  ");
                Console.WriteLine("==============================================================");
                Console.ResetColor();
                Console.WriteLine("1. Ver catálogo y registrar/escanear producto");
                Console.WriteLine("2. Buscar producto en la canasta");
                Console.WriteLine("3. Modificar cantidad de un producto");
                Console.WriteLine("4. Eliminar producto de la canasta");
                Console.WriteLine("5. Mostrar canasta actual");
                Console.WriteLine("6. Ordenar canasta por Precio Unitario (Burbuja)");
                Console.WriteLine("7. Ordenar canasta por Subtotal (Selección)");
                Console.WriteLine("8. Procesar pago y emitir comprobante");
                Console.WriteLine("9. Ver reporte de auditoría");
                Console.WriteLine("10. Probar funciones recursivas (9.1)");
                Console.WriteLine("11. Probar aplicación recursiva (9.2)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1:
                        gestorCanasta.RegistrarProductoEscaneado(validador);
                        break;
                    case 2:
                        gestorCanasta.BuscarProductoEnCanasta();
                        break;
                    case 3:
                        gestorCanasta.ModificarCantidad(validador);
                        break;
                    case 4:
                        gestorCanasta.EliminarProducto();
                        break;
                    case 5:
                        gestorCanasta.MostrarCanasta();
                        break;
                    case 6:
                        gestorCanasta.OrdenarBurbujaPorPrecio();
                        break;
                    case 7:
                        gestorCanasta.OrdenarSeleccionPorSubtotal();
                        break;
                    case 8:
                        controladorPagos.ProcesarPagoYComprobante(gestorCanasta, validador);
                        break;
                    case 9:
                        controladorPagos.MostrarMatrizAuditoriaPagos();
                        break;
                    case 10:
                        funcionesRecursivas.EjecutarDemo91();
                        break;
                    case 11:
                        funcionesRecursivas.EjecutarDemo92(gestorCanasta.Canasta);
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }
    }
}