using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProveedorServicio.Modelos;

namespace ProveedorServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProveedorServicio
    {
        #region Proveedor
        [OperationContract]
        RespuestaOperacionListado<ProveedorDTO> BuscarProveedor();
      

        [OperationContract]
        RespuestaOparacionSimple<Proveedor> IncluirProveedor(Proveedor aProveedor);

        [OperationContract]
        RespuestaOparacionSimple<Proveedor> ModifcarProveedor(Proveedor aProveedor);

        [OperationContract]
        RespuestaOparacionSimple<Proveedor> EliminarProveedor(Proveedor aProveedor);
        #endregion


        #region Producto
        [OperationContract]
        RespuestaOperacionListado<ProductoDTO> BuscarProducto();

        [OperationContract]
        RespuestaOparacionSimple<Producto> IncluirProducto(Producto aProducto);

        [OperationContract]
        RespuestaOparacionSimple<Producto> ModifcarProducto(Producto aProducto);

        [OperationContract]
        RespuestaOparacionSimple<Producto> EliminarProducto(Producto aProducto);
        #endregion

        #region Categoria

        [OperationContract]
        RespuestaOperacionListado<CategoriaDTO> BuscarCategoria();

        [OperationContract]
        RespuestaOparacionSimple<Categoria> IncluirCategoria(Categoria aCategoria);

        [OperationContract]
        RespuestaOparacionSimple<Categoria> ModifcarCategoria(Categoria aCategoria);

        [OperationContract]
        RespuestaOparacionSimple<Categoria> EliminarCategoria(Categoria aCategoria);
        #endregion

        #region Cliente

        [OperationContract]
        RespuestaOperacionListado<ClienteDTO> BuscarCliente();

        [OperationContract]
        RespuestaOparacionSimple<Cliente> IncluirCliente(Cliente aCliente);

        [OperationContract]
        RespuestaOparacionSimple<Cliente> ModifcarCliente(Cliente aCliente);

        [OperationContract]
        RespuestaOparacionSimple<Cliente> EliminarCliente(Cliente aCliente);
        #endregion

        #region Movimiento

        [OperationContract]
        RespuestaOperacionListado<MovimientoDTO> BuscarMovimiento();

        [OperationContract]
        RespuestaOparacionSimple<Movimiento> IncluirMovimiento(Movimiento aMovimiento);

       /* [OperationContract]
        RespuestaOparacionSimple<Movimiento> ModifcarMovimiento(Movimiento aMovimiento);

        [OperationContract]
        RespuestaOparacionSimple<Movimiento> EliminarMovimiento(Movimiento aMovimiento);*/
        #endregion


        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //// TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
