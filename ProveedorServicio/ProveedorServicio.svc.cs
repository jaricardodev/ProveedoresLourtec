using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProveedorServicio.Modelos;

namespace ProveedorServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProveedorServicio: IProveedorServicio
    {


        public List<ProveedorDTO> BuscarProveedor()
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    return contexto.Proveedors.ToList().Select(aObj=>new ProveedorDTO(aObj)).ToList();
                }
            }
            catch (Exception e)
            {
                return new List<ProveedorDTO>();
                
            }
           
        }

        public bool IncluirProveedor(Proveedor aProveedor)
        {
            using (var contexto = new ProveedoresEntities())
            {
                try
                {
                    int _NuevoId;
                    if (contexto.Proveedors.Any())
                    {
                         _NuevoId = contexto.Proveedors.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aProveedor.Id = _NuevoId;

                    contexto.Proveedors.Add(aProveedor);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return true;
        }

        public bool ModifcarProveedor(Proveedor aProveedor)
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    contexto.Entry(aProveedor).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool EliminarProveedor(Proveedor aProveedor)
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    contexto.Entry(aProveedor).State = EntityState.Deleted;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ProductoDTO> BuscarProducto()
        {
            using (var contexto = new ProveedoresEntities())
            {
                return contexto.Productoes.ToList().Select(aObj => new ProductoDTO(aObj)).ToList(); 
            }
        }

        public bool IncluirProducto(Producto aProducto)
        {
            using (var contexto = new ProveedoresEntities())
            {
                try
                {

                    int _NuevoId;
                    if (contexto.Proveedors.Any())
                    {
                        _NuevoId = contexto.Productoes.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                  

                    aProducto.Id = _NuevoId;

                    contexto.Productoes.Add(aProducto);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return true;
        }

        public bool ModifcarProducto(Producto aProducto)
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    contexto.Entry(aProducto).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarProducto(Producto aProducto)
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    contexto.Entry(aProducto).State = EntityState.Deleted;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CategoriaDTO> BuscarCategoria()
        {
            using (var contexto = new ProveedoresEntities())
            {
                return contexto.Categorias.ToList().Select(aObj => new CategoriaDTO(aObj)).ToList(); 
            }
        }

        public bool IncluirCategoria(Categoria aCategoria)
        {
            using (var contexto = new ProveedoresEntities())
            {
                try
                {
                    int _NuevoId;
                    if (contexto.Proveedors.Any())
                    {
                        _NuevoId = contexto.Productoes.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aCategoria.Id = _NuevoId;

                    contexto.Categorias.Add(aCategoria);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return true;
        }

        public bool ModifcarCategoria(Categoria aCategoria)
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    contexto.Entry(aCategoria).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarCategoria(Categoria aCategoria)
        {
            try
            {
                using (var contexto = new ProveedoresEntities())
                {
                    contexto.Entry(aCategoria).State = EntityState.Deleted;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

       public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
    }
}
