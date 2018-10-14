using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        OrderDTO GetDataUsingDataContract(int orderId);
    }

    [DataContract]
    public class OrderDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public int[] OrderItems { get; set; }
    }
}