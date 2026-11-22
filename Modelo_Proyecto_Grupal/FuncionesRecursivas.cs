using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modelo_Proyecto_Grupal
{
    public class FuncionesRecursivas
    {
        // --- 9.1 Funciones recursivas ---

        public long Factorial(int numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("El factorial no está definido para números negativos.");
            }

            if (numero == 0 || numero == 1)
            {
                return 1;
            }

            return numero * Factorial(numero - 1);
        }

        public double Potencia(double baseNum, int exponente)
        {
            if (exponente == 0)
            {
                return 1;
            }

            if (exponente < 0)
            {
                return 1.0 / Potencia(baseNum, -exponente);
            }

            return baseNum * Potencia(baseNum, exponente - 1);
        }

        public int Sumatoria(int numero)
        {
            if (numero <= 0)
            {
                return 0;
            }

            return numero + Sumatoria(numero - 1);
        }

        // --- 9.2 Aplicación (recorridos, búsquedas y conteos) ---

        public void RecorrerCanastaRecursivo(List<Producto> canasta, int indice = 0)
        {
            if (canasta == null || indice >= canasta.Count)
            {
                return;
            }

            Producto item = canasta[indice];
            Console.WriteLine($"  [{indice + 1}] {item.Codigo} - {item.Nombre} | Cant: {item.Cantidad} | Subtotal: S/ {item.Subtotal:F2}");

            RecorrerCanastaRecursivo(canasta, indice + 1);
        }

        public Producto BuscarProductoRecursivo(List<Producto> canasta, string codigo, int indice = 0)
        {
            if (canasta == null || indice >= canasta.Count)
            {
                return null;
            }

            if (canasta[indice].Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                return canasta[indice];
            }

            return BuscarProductoRecursivo(canasta, codigo, indice + 1);
        }

        public int ContarUnidadesRecursivo(List<Producto> canasta, int indice = 0)
        {
            if (canasta == null || indice >= canasta.Count)
            {
                return 0;
            }

            return canasta[indice].Cantidad + ContarUnidadesRecursivo(canasta, indice + 1);
        }

        // --- Métodos de prueba para consola ---

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

        public void EjecutarDemo91()
        {
            int subOpcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n================ FUNCIONES RECURSIVAS ================");
                Console.ResetColor();
                Console.WriteLine("1. Factorial");
                Console.WriteLine("2. Potencia");
                Console.WriteLine("3. Sumatoria");
                Console.WriteLine("4. Salir");
                Console.Write("Elija qué función probar: ");

                if (!int.TryParse(Console.ReadLine(), out subOpcion))
                {
                    MostrarMensajeInvalidoYResetear();
                    subOpcion = -1;
                    continue;
                }

                switch (subOpcion)
                {
                    case 1:
                        Console.Write("Ingrese un entero para Factorial (ej. 5): ");
                        if (int.TryParse(Console.ReadLine(), out int nFact) && nFact >= 0)
                        {
                            Console.WriteLine($"-> Factorial({nFact}) = {Factorial(nFact)}");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida para factorial.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese la base para Potencia (ej. 2): ");
                        bool baseOk = double.TryParse(Console.ReadLine(), out double baseNum);
                        Console.Write("Ingrese el exponente entero para Potencia (ej. 4): ");
                        bool expOk = int.TryParse(Console.ReadLine(), out int expNum);
                        if (baseOk && expOk)
                        {
                            Console.WriteLine($"-> Potencia({baseNum}, {expNum}) = {Potencia(baseNum, expNum)}");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida para potencia.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese un entero positivo para Sumatoria 1..N (ej. 5): ");
                        if (int.TryParse(Console.ReadLine(), out int nSum) && nSum >= 0)
                        {
                            Console.WriteLine($"-> Sumatoria({nSum}) = {Sumatoria(nSum)}");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida para sumatoria.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del submenú...");
                        break;

                    default:
                        MostrarMensajeInvalidoYResetear();
                        break;
                }
            } while (subOpcion != 4);
        }

        public void EjecutarDemo92(List<Producto> canasta)
        {
            int subOpcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n================ APLICACIÓN RECURSIVA ================");
                Console.ResetColor();

                if (canasta == null || canasta.Count == 0)
                {
                    Console.WriteLine("La canasta está vacía. Agrega productos primero (opción 1).");
                    return;
                }

                Console.WriteLine("1. Recorrido recursivo");
                Console.WriteLine("2. Búsqueda recursiva");
                Console.WriteLine("3. Conteo recursivo");
                Console.WriteLine("4. Salir");
                Console.Write("Elija qué operación probar: ");

                if (!int.TryParse(Console.ReadLine(), out subOpcion))
                {
                    MostrarMensajeInvalidoYResetear();
                    subOpcion = -1;
                    continue;
                }

                switch (subOpcion)
                {
                    case 1:
                        Console.WriteLine("-> Recorrido recursivo de la canasta:");
                        RecorrerCanastaRecursivo(canasta);
                        break;

                    case 2:
                        Console.Write("Ingrese código de producto para búsqueda recursiva (ej. 101): ");
                        string codigoBuscado = Console.ReadLine()?.Trim() ?? "";
                        Producto encontrado = BuscarProductoRecursivo(canasta, codigoBuscado);

                        if (encontrado != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"-> Encontrado: {encontrado.Nombre} | Cant: {encontrado.Cantidad} | Subtotal: S/ {encontrado.Subtotal:F2}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("-> Producto no encontrado en la canasta.");
                        }
                        break;

                    case 3:
                        int totalUnidades = ContarUnidadesRecursivo(canasta);
                        Console.WriteLine($"-> Conteo recursivo de unidades en canasta: {totalUnidades}");
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del submenú...");
                        break;

                    default:
                        MostrarMensajeInvalidoYResetear();
                        break;
                }
            } while (subOpcion != 4);
        }
    }
}