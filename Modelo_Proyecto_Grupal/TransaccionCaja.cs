using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Proyecto_Grupal
{
    public class TransaccionCaja
    {
        public int NumeroTicket { get; set; }
        public double OperacionGravada { get; set; }
        public double Descuento { get; set; }
        public double Igv { get; set; }
        public double TotalPagado { get; set; }

        public TransaccionCaja(int numeroTicket, double operacionGravada, double descuento, double igv, double totalPagado)
        {
            NumeroTicket = numeroTicket;
            OperacionGravada = operacionGravada;
            Descuento = descuento;
            Igv = igv;
            TotalPagado = totalPagado;
        }
    }
}
