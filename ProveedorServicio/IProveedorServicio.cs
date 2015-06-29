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
        List<ProveedorDTO> BuscarProveedor();

        [OperationContract]
        bool IncluirProveedor(Proveedor aProveedor);

        [OperationContract]
        bool ModifcarProveedor(Proveedor aProveedor);

        [OperationContract]
        bool EliminarProveedor(Proveedor aProveedor);
        #endregion


        #region Producto
        [OperationContract]
        List<ProductoDTO> BuscarProducto();

        [OperationContract]
        bool IncluirProducto(Producto aProducto);

        [OperationContract]
        bool ModifcarProducto(Producto aProducto);

        [OperationContract]
        bool EliminarProducto(Producto aProducto);
        #endregion

        #region Categoria

        [OperationContract]
        List<CategoriaDTO> BuscarCategoria();

        [OperationContract]
        bool IncluirCategoria(Categoria aCategoria);

        [OperationContract]
        bool ModifcarCategoria(Categoria aCategoria);

        [OperationContract]
        bool EliminarCategoria(Categoria aCategoria);
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
