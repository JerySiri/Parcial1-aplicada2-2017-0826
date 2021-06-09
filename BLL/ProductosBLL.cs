using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial1_aplicada2_2017_0826.Models;
using Parcial1_aplicada2_2017_0826.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Parcial1_aplicada2_2017_0826.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            if (!Existe(producto.ProductoId))
            {
                return Insertar(producto);
            }
            else
            {
                return Modificar(producto);
            }

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esteExiste = false;

            try
            {
                esteExiste = contexto.Productos.Any(p => p.ProductoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return esteExiste;

        }

        private static bool Insertar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Add(producto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }

        public static Productos Buscar(int id)
        {
            Productos producto;
            Contexto contexto = new Contexto();

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return producto;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var producto = contexto.Productos.Find();

                if (producto != null)
                {
                    contexto.Productos.Remove(producto);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }
        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.Productos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
