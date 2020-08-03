using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class MateriaBLL
    {
        public static void Create(Materia a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Materias.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Materia Get(int? id)
        {
            Entities db = new Entities();
            return db.Materias.Find(id);
        }

        public static void Update(Materia Materia)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Materias.Attach(Materia);
                        db.Entry(Materia).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Materia Materia = db.Materias.Find(id);
                        db.Entry(Materia).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Materia> List()
        {
            Entities db = new Entities();            
            return db.Materias.ToList();            
        }

        public static List<Materia> ListToNames()
        {
            Entities db = new Entities();
            List<Materia> result = new List<Materia>();
            db.Materias.ToList().ForEach(x =>
                result.Add(
                    new Materia
                    {
                        nombre = x.nrc + "-" + x.nombre,
                        idmateria = x.idmateria
                    }));
            return result;
        }


    }
}
