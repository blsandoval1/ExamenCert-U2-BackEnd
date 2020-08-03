using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class AreaBLL
    {
        public static List<Area> List()
        {
            Entities db = new Entities();
            return db.Areas.ToList();
        }
    }
}
