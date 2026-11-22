using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//MAIN DEL SISTEMA
namespace Modelo_Proyecto_Grupal
{
    internal class Program
    {
        private static void MostrarMensajeInvalidoYResetear()
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
                Console.WriteLine("6. Ordenar canasta");
                Console.WriteLine("7. Procesar pago y emitir comprobante");
                Console.WriteLine("8. Ver reporte de auditoría");
                Console.WriteLine("9. Probar funciones recursivas");
                Console.WriteLine("10. Probar aplicación recursiva");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    MostrarMensajeInvalidoYResetear();
                    opcion = -1;
                    continue;
                }

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
                        gestorCanasta.MenuOrdenarCanasta();
                        break;
                    case 7:
                        controladorPagos.ProcesarPagoYComprobante(gestorCanasta, validador);
                        break;
                    case 8:
                        controladorPagos.MostrarMatrizAuditoriaPagos();
                        break;
                    case 9:
                        funcionesRecursivas.EjecutarDemo91();
                        break;
                    case 10:
                        funcionesRecursivas.EjecutarDemo92(gestorCanasta.Canasta);
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        MostrarMensajeInvalidoYResetear();
                        break;
                }
            } while (opcion != 0);
        }
    }
}