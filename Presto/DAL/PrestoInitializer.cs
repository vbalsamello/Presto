using Presto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Presto.DAL
{
    public class PrestoInitializer : DropCreateDatabaseAlways<PrestoContext>
    {
        protected override void Seed(PrestoContext context)
        {
            //IList<Simulacion> objectS = new List<Simulacion>();
            //objectS.Add(new Simulacion() { Nombre = "Simulacion 1", Prestamo = 20000, Interes = 12.05, Meses = 300 });
            //context.Simulaciones.AddRange(objectS);
            //base.Seed(context);
        }
    }
}