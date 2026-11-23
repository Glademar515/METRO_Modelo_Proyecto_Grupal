using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Proyecto_Grupal
{
    public class ControladorPagos
    {
        private const double TASA_IGV = 0.18;
        private readonly List<TransaccionCaja> _transacciones = new List<TransaccionCaja>();

        public void ProcesarPagoYComprobante(GestorCanasta gestorCanasta, ValidadorSeguridad validador)
        {
            List<Producto> canasta = gestorCanasta.Canasta;

            if (canasta.Count == 0)
            {
                Console.WriteLine("\nLa canasta está vacía. No hay nada que pagar.");
                return;
            }

            double totalBruto = 0;
            foreach (Producto p in canasta)
            {
                totalBruto += p.Subtotal;
            }

            double descuento = (totalBruto > 150.0) ? totalBruto * 0.05 : 0.0;
            double totalPagar = totalBruto - descuento;
            double opGravada = totalPagar / (1.0 + TASA_IGV);
            double igv = totalPagar - opGravada;
            int puntosBonus = (int)(totalPagar / 10);

            Console.Write("\nSeleccione tipo de comprobante (1: Boleta con DNI / 2: Factura con RUC): ");
            int.TryParse(Console.ReadLine(), out int tipoComp);

            Console.Write("Ingrese número de documento: ");
            string docCliente = Console.ReadLine()?.Trim() ?? "";

            if (!validador.ValidarDocumento(docCliente, tipoComp))
            {
                Console.WriteLine("Aviso: Documento no estándar para el tipo de comprobante.");
            }

            Console.Write("Ingrese últimos 4 dígitos de su tarjeta: ");
            string numTarjeta = Console.ReadLine()?.Trim() ?? "";

            int numeroTicket = _transacciones.Count + 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("        SUPERMERCADOS METRO - CENCOSUD PERÚ          ");
            Console.WriteLine("          COMPROBANTE DE PAGO ELECTRÓNICO            ");
            Console.WriteLine("=====================================================");
            Console.ResetColor();
            Console.WriteLine($"Tipo Comprobante  : {(tipoComp == 2 ? "FACTURA" : "BOLETA")}");
            Console.WriteLine($"Documento Cliente : {docCliente}");
            Console.WriteLine($"Medio de Pago     : Tarjeta ****{numTarjeta}");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Operación Gravada : S/ {opGravada:F2}");
            Console.WriteLine($"Descuento (5%)    : S/ {descuento:F2}");
            Console.WriteLine($"IGV (18%)         : S/ {igv:F2}");
            Console.WriteLine($"IMPORTE TOTAL     : S/ {totalPagar:F2}");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Puntos Bonus      : {puntosBonus} pts.");
            Console.WriteLine($"Estado            : APROBADO - HASH #MTR2026T{numeroTicket}");
            Console.WriteLine("=====================================================");

            _transacciones.Add(new TransaccionCaja(numeroTicket, opGravada, descuento, igv, totalPagar));
            gestorCanasta.LimpiarCanasta();
        }

        public void MostrarMatrizAuditoriaPagos()
        {
            if (_transacciones.Count == 0)
            {
                Console.WriteLine("\nNo hay transacciones registradas en este turno.");
                return;
            }

            Console.WriteLine("\n=====================================================================");
            Console.WriteLine("   LISTA DINÁMICA DE AUDITORÍA DE PAGOS (CAJA METRO)               ");
            Console.WriteLine("=====================================================================");
            Console.WriteLine($"{"TICKET",-10} | {"OP. GRAVADA",-14} | {"DESCUENTO",-12} | {"IGV (18%)",-12} | {"TOTAL PAGADO"}");
            Console.WriteLine("---------------------------------------------------------------------");

            double totalCaja = 0;
            foreach (TransaccionCaja t in _transacciones)
            {
                Console.WriteLine($"Ticket #{t.NumeroTicket,-3} | S/ {t.OperacionGravada,-11:F2} | S/ {t.Descuento,-9:F2} | S/ {t.Igv,-9:F2} | S/ {t.TotalPagado:F2}");
                totalCaja += t.TotalPagado;
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"RECAUDACIÓN TOTAL EN CAJA: S/ {totalCaja:F2}");
        }
        public const double TasaIgv = 0.18;
        public IReadOnlyList<TransaccionCaja> Transacciones => _transacciones.AsReadOnly();

        public void RegistrarTransaccion(TransaccionCaja transaccion)
        {
            if (transaccion != null)
            {
                _transacciones.Add(transaccion);
            }
        }
    }
}