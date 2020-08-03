using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class MatriculaBLL
    {
        public static void Create(Matricula a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Materia mt = db.Materias.Find(a.idmateria);
                        Config(a, mt);
                        db.Matriculas.Add(a);
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

        private static void Config(Matricula a, Materia mt)
        {
            a.fecha = DateTime.Now;
            a.estado = "1"; //Creada
            if (a.tipo.Equals("P"))
            {
                a.costo = 0;
            }
            else if (a.tipo.Equals("S"))
            {
                a.costo = (decimal)(12.25 * mt.creditos);
            }
            else
            {
                a.costo = (decimal)(24.50 * mt.creditos);
            }            
        }

        public static Matricula Get(int? id)
        {
            Entities db = new Entities();
            return db.Matriculas.Find(id);
        }

        public static void Update(Matricula Matricula)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Materia mt = db.Materias.Find(Matricula.idmateria);
                        Config(Matricula, mt);
                        db.Matriculas.Attach(Matricula);
                        db.Entry(Matricula).State = System.Data.Entity.EntityState.Modified;
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
                        Matricula Matricula = db.Matriculas.Find(id);
                        db.Entry(Matricula).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Matricula> List()
        {
            Entities db = new Entities();
            return db.Matriculas.ToList();
        }

        public static List<Matricula> List(int id)
        {
            Entities db = new Entities();
            return db.Matriculas.Where(x => x.Alumno.idalumno == id).ToList();
        }









    }
}
