using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using ProveedorServicio.Modelos;
using ProveedorServicio.Utils;

namespace ProveedorServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProveedorServicio: IProveedorServicio
    {
        public RespuestaOperacionListado<ProveedorDTO> BuscarProveedor()
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    var _Datos = _Contexto.Proveedors.ToList().Select(aObj => new ProveedorDTO(aObj)).ToList();
                    return new RespuestaOperacionListado<ProveedorDTO>
                    {
                        DatosRespuesta = _Datos,
                        EsOperacionExitosa = true,
                    };
                }
            }
            catch (Exception _E)
            {
                return new RespuestaOperacionListado<ProveedorDTO>
                    {
                        EsOperacionExitosa = false,
                        Message = _E.ObtenerInnerException()
                    };

            }
        }

        public RespuestaOparacionSimple<Proveedor> IncluirProveedor(Proveedor aProveedor)
        {
            using (var _Contexto = new ProveedoresEntities())
            {
                try
                {
                    int _NuevoId;
                    if (_Contexto.Proveedors.Any())
                    {
                        _NuevoId = _Contexto.Proveedors.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aProveedor.Id = _NuevoId;

                    _Contexto.Proveedors.Add(aProveedor);
                    _Contexto.SaveChanges();

                    return new RespuestaOparacionSimple<Proveedor>
                    {
                        Dato = aProveedor,
                        EsOperacionExitosa = true,
                        TipoOperacion = "Incluir"
                    };
                }
                catch (DbEntityValidationException _Ex)
                {
                    var _ValidationMessage= _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                    _ValidationMessage = _ValidationMessage.Trim(';');

                    return new RespuestaOparacionSimple<Proveedor>
                    {
                        Dato = aProveedor,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _ValidationMessage
                    };
                }
                catch (Exception _E)
                {
                    return new RespuestaOparacionSimple<Proveedor>
                    {
                        Dato = aProveedor,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _E.ObtenerInnerException()
                    };
                }

            }
            
        }

        public RespuestaOparacionSimple<Proveedor> ModifcarProveedor(Proveedor aProveedor)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aProveedor).State = EntityState.Modified;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Proveedor>
                {
                    Dato = aProveedor,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Modificar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Proveedor>
                {
                    Dato = aProveedor,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Proveedor>
                {
                    Dato = aProveedor,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _E.ObtenerInnerException()
                };
            }


        }

        public RespuestaOparacionSimple<Proveedor> EliminarProveedor(Proveedor aProveedor)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aProveedor).State = EntityState.Deleted;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Proveedor>
                {
                    Dato = aProveedor,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Eliminar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Proveedor>
                {
                    Dato = aProveedor,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Proveedor>
                {
                    Dato = aProveedor,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _E.ObtenerInnerException()
                };
            }
        }

        public RespuestaOperacionListado<ProductoDTO> BuscarProducto()
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    var _Datos = _Contexto.Productoes.Include(aProd=>aProd.Categoria).ToList().Select(aObj => new ProductoDTO(aObj)).ToList();

                    return new RespuestaOperacionListado<ProductoDTO>
                    {
                        DatosRespuesta = _Datos,
                        EsOperacionExitosa = true,
                    };
                }
            }

            catch (Exception _E)
            {

                return new RespuestaOperacionListado<ProductoDTO>
                {
                    EsOperacionExitosa = true,
                    Message = _E.ObtenerInnerException()
                };
            }
            
        }

        public RespuestaOparacionSimple<Producto> IncluirProducto(Producto aProducto)
        {
            using (var _Contexto = new ProveedoresEntities())
            {
                try
                {

                    int _NuevoId;
                    if (_Contexto.Productoes.Any())
                    {
                        _NuevoId = _Contexto.Productoes.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aProducto.Id = _NuevoId;

                    _Contexto.Productoes.Add(aProducto);
                    _Contexto.SaveChanges();

                    return new RespuestaOparacionSimple<Producto>
                    {
                        Dato = aProducto,
                        EsOperacionExitosa = true,
                        TipoOperacion = "Incluir"
                        
                    };
                }
                catch (DbEntityValidationException _Ex)
                {
                    var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                    _ValidationMessage = _ValidationMessage.Trim(';');

                    return new RespuestaOparacionSimple<Producto>
                    {
                        Dato = aProducto,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _ValidationMessage
                    };
                }
                catch (Exception _E)
                {
                    return new RespuestaOparacionSimple<Producto>
                    {
                        Dato = aProducto,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _E.ObtenerInnerException()

                    };
                }

            }
            
        }

        public RespuestaOparacionSimple<Producto> ModifcarProducto(Producto aProducto)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aProducto).State = EntityState.Modified;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Producto>
                {
                    Dato = aProducto,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Modificar"

                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Producto>
                {
                    Dato = aProducto,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Producto>
                {
                    Dato = aProducto,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _E.ObtenerInnerException()
                    
                };
            }
        }

        public RespuestaOparacionSimple<Producto> EliminarProducto(Producto aProducto)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aProducto).State = EntityState.Deleted;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Producto>
                {
                    Dato = aProducto,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Eliminar"

                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Producto>
                {
                    Dato = aProducto,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Producto>
                {
                    Dato = aProducto,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _E.ObtenerInnerException()
                    
                };
            }
        }

        public RespuestaOperacionListado<CategoriaDTO> BuscarCategoria()
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    var _Datos = _Contexto.Categorias.ToList().Select(aObj => new CategoriaDTO(aObj)).ToList();
                    return new RespuestaOperacionListado<CategoriaDTO>
                    {
                        DatosRespuesta = _Datos,
                        EsOperacionExitosa = true
                    };
                }
            }
            catch (Exception _E)
            {

                return new RespuestaOperacionListado<CategoriaDTO>
                {
                    EsOperacionExitosa = true,
                    Message = _E.ObtenerInnerException()
                };
            }
            
        }

        public RespuestaOparacionSimple<Categoria> IncluirCategoria(Categoria aCategoria)
        {
            using (var _Contexto = new ProveedoresEntities())
            {
                try
                {
                    int _NuevoId;
                    if (_Contexto.Categorias.Any())
                    {
                        _NuevoId = _Contexto.Categorias.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aCategoria.Id = _NuevoId;

                    _Contexto.Categorias.Add(aCategoria);
                    _Contexto.SaveChanges();

                    return new RespuestaOparacionSimple<Categoria>
                    {
                        Dato = aCategoria,
                        EsOperacionExitosa = true,
                       TipoOperacion = "Incluir"
                    };
                }
                catch (DbEntityValidationException _Ex)
                {
                    var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                    _ValidationMessage = _ValidationMessage.Trim(';');

                    return new RespuestaOparacionSimple<Categoria>
                    {
                        Dato = aCategoria,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _ValidationMessage
                    };
                }
                catch (Exception _E)
                {
                    return new RespuestaOparacionSimple<Categoria>
                    {
                        Dato = aCategoria,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _E.ObtenerInnerException()

                    };
                }

            }
            
        }

        public RespuestaOparacionSimple<Categoria> ModifcarCategoria(Categoria aCategoria)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aCategoria).State = EntityState.Modified;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Categoria>
                {
                    Dato = aCategoria,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Modificar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Categoria>
                {
                    Dato = aCategoria,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Categoria>
                {
                    Dato = aCategoria,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _E.ObtenerInnerException()
                };
            }
        }

        public RespuestaOparacionSimple<Categoria> EliminarCategoria(Categoria aCategoria)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aCategoria).State = EntityState.Deleted;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Categoria>
                {
                    Dato = aCategoria,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Eliminar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Categoria>
                {
                    Dato = aCategoria,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Categoria>
                {
                    Dato = aCategoria,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _E.ObtenerInnerException()
                };
            }
        }

        public RespuestaOperacionListado<ClienteDTO> BuscarCliente()
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    var _Datos = _Contexto.Clientes.ToList().Select(aObj => new ClienteDTO(aObj)).ToList();
                    return new RespuestaOperacionListado<ClienteDTO>
                    {
                        DatosRespuesta = _Datos,
                        EsOperacionExitosa = true
                        
                    };
                }
            }
            catch (Exception _E)
            {

                return new RespuestaOperacionListado<ClienteDTO>
                {
                    EsOperacionExitosa = false,
                    Message = _E.ObtenerInnerException()

                };
            }
            
        }

        public RespuestaOparacionSimple<Cliente> IncluirCliente(Cliente aCliente)
        {
            using (var _Contexto = new ProveedoresEntities())
            {
                try
                {
                    int _NuevoId;
                    if (_Contexto.Clientes.Any())
                    {
                        _NuevoId = _Contexto.Clientes.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aCliente.Id = _NuevoId;
                    aCliente.FechaRegistro = DateTime.Now;

                    _Contexto.Clientes.Add(aCliente);
                    _Contexto.SaveChanges();

                    return new RespuestaOparacionSimple<Cliente>
                    {
                        Dato = aCliente,
                        EsOperacionExitosa = true,
                        TipoOperacion = "Incluir"
                    };

                }
                catch (DbEntityValidationException _Ex)
                {
                    var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                    _ValidationMessage = _ValidationMessage.Trim(';');

                    return new RespuestaOparacionSimple<Cliente>
                    {
                        Dato = aCliente,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _ValidationMessage
                    };
                }
                catch (Exception _E)
                {
                    return new RespuestaOparacionSimple<Cliente>
                    {
                        Dato = aCliente,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _E.ObtenerInnerException()
                    };
                }

            }
        
        }

        public RespuestaOparacionSimple<Cliente> ModifcarCliente(Cliente aCliente)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aCliente).State = EntityState.Modified;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Cliente>
                {
                    Dato = aCliente,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Modificar"

                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Cliente>
                {
                    Dato = aCliente,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Cliente>
                {
                    Dato = aCliente,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _E.ObtenerInnerException()
                    
                };
            }
        }

        public RespuestaOparacionSimple<Cliente> EliminarCliente(Cliente aCliente)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aCliente).State = EntityState.Deleted;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Cliente>
                {
                    Dato = aCliente,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Eliminar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Cliente>
                {
                    Dato = aCliente,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _ValidationMessage
                };
            }
            catch (Exception _E)
            {
                return new RespuestaOparacionSimple<Cliente>
                {
                    Dato = aCliente,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _E.ObtenerInnerException()
                };
            }
        }

        public RespuestaOperacionListado<MovimientoDTO> BuscarMovimiento()
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    var _Datos = _Contexto.Movimientoes.Include(aProd=>aProd.Producto).ToList().Select(aObj => new MovimientoDTO(aObj)).ToList();
                    return new RespuestaOperacionListado<MovimientoDTO>
                    {
                        DatosRespuesta = _Datos,
                        EsOperacionExitosa = true
                    };
                }
            }
            catch (Exception _E)
            {

                return new RespuestaOperacionListado<MovimientoDTO>
                {
                   EsOperacionExitosa = false,
                   Message = _E.ObtenerInnerException()
                };
            }
        }

        public RespuestaOparacionSimple<Movimiento> IncluirMovimiento(Movimiento aMovimiento)
        {
            using (var _Contexto = new ProveedoresEntities())
            {
                try
                {
                    int _NuevoId;
                    if (_Contexto.Movimientoes.Any())
                    {
                        _NuevoId = _Contexto.Movimientoes.Max(aPro => aPro.Id) + 1;
                    }
                    else
                    {
                        _NuevoId = 1;
                    }

                    aMovimiento.Id = _NuevoId;

                    var _ProductoAfectado = _Contexto.Productoes.Find(aMovimiento.ProductoId);
                    if (aMovimiento.TipoMovimiento == 0)
                    {
                        if (_ProductoAfectado.Existencia >= aMovimiento.Cantidad)
                        {
                            _ProductoAfectado.Existencia -=  aMovimiento.Cantidad;
                        }
                    }
                    else
                    {
                        _ProductoAfectado.Existencia += aMovimiento.Cantidad;
                    }

                    _Contexto.Entry(_ProductoAfectado).State = EntityState.Modified;
                    _Contexto.Movimientoes.Add(aMovimiento);

                    _Contexto.SaveChanges();

                    return new RespuestaOparacionSimple<Movimiento>
                    {
                        Dato = aMovimiento,
                        EsOperacionExitosa = true,
                        TipoOperacion = "Incluir"
                    };
                }
                catch (DbEntityValidationException _Ex)
                {
                    var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                    _ValidationMessage = _ValidationMessage.Trim(';');

                    return new RespuestaOparacionSimple<Movimiento>
                    {
                        Dato = aMovimiento,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _ValidationMessage
                    };
                }
                catch (Exception _E)
                {
                    return new RespuestaOparacionSimple<Movimiento>
                    {
                        Dato = aMovimiento,
                        EsOperacionExitosa = false,
                        TipoOperacion = "Incluir",
                        Message = _E.ObtenerInnerException()
                    };
                }

            }
          
        }

      /*  public RespuestaOparacionSimple<Movimiento> ModifcarMovimiento(Movimiento aMovimiento)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aMovimiento).State = EntityState.Modified;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Movimiento>
                {
                    Dato = aMovimiento,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Modificar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Movimiento>
                {
                    Dato = aMovimiento,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Movimiento>
                {
                    Dato = aMovimiento,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Modificar",
                    Message = _E.ObtenerInnerException()

                };
            }
        }

        public RespuestaOparacionSimple<Movimiento> EliminarMovimiento(Movimiento aMovimiento)
        {
            try
            {
                using (var _Contexto = new ProveedoresEntities())
                {
                    _Contexto.Entry(aMovimiento).State = EntityState.Deleted;
                    _Contexto.SaveChanges();
                }
                return new RespuestaOparacionSimple<Movimiento>
                {
                    Dato = aMovimiento,
                    EsOperacionExitosa = true,
                    TipoOperacion = "Eliminar"
                };
            }
            catch (DbEntityValidationException _Ex)
            {
                var _ValidationMessage = _Ex.EntityValidationErrors.ToList().SelectMany(aError => aError.ValidationErrors).Aggregate(string.Empty, (aCurrent, aDbValidationError) => aCurrent + (aDbValidationError.ErrorMessage + ";"));

                _ValidationMessage = _ValidationMessage.Trim(';');

                return new RespuestaOparacionSimple<Movimiento>
                {
                    Dato = aMovimiento,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _ValidationMessage
                };
            }
            catch(Exception _E)
            {
                return new RespuestaOparacionSimple<Movimiento>
                {
                    Dato = aMovimiento,
                    EsOperacionExitosa = false,
                    TipoOperacion = "Eliminar",
                    Message = _E.ObtenerInnerException()
                };
            }
        }*/

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
