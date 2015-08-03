using System.Collections.Generic;
using System;
using Microsoft.AspNet.Mvc;
using Host.Models;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Charge> Get()
        {
            /*return new Recargo[]{
                new Recargo { Id = 1, POS = "caja alameda", TipoRecargo = "Descuento", ruta = new Ruta {Id = 1, 
                    Origen="ALA",Destino="SFR",precioBase = new PrecioBase{Id=1,Monto=1000.2,FechaVigencia = DateTime.Today, 
                    DatosCambio="aaaa"}}, periodo = new Periodo{Id = 1, InicioVigencia = DateTime.Today, FinVigencia = DateTime.Today, 
                    Periodicidad = "anual", Descripcion = "semana santa"}, Restricciones = "aaaa", MedioPago = "bbbbb", 
                    Valor = 1.2, Prioridad = 5}
            };*/
            return null;
        }
    }
}