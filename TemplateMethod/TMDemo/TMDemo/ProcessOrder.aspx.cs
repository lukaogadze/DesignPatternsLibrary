using System;
using System.IO;
using System.Web.UI;

namespace TMDemo
{
    public partial class ProcessOrder : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Sending order UPS: <br />");
            var upsOrder = new UpsOrderShipment(); // code smell: referencing implementation directly with "new"
            upsOrder.ShippingAddress = "NimblePros, Hudson, OH 44236";
            upsOrder.Ship(Response.Output);
            Response.Write("<br />");

            Response.Write("Sending order FedEx: <br />");
            var fedExOrder = new FedExOrderShipment(); // code smell: referencing implementation directly with "new"
            fedExOrder.ShippingAddress = "NimblePros, Hudson, OH 44236";
            fedExOrder.Ship(Response.Output);
            Response.Write("<br />");

        }
    }

    public abstract class OrderShipment
    {
        public string ShippingAddress { get; set; }
        public string Label { get; set; }
        public void Ship(TextWriter writer)
        {
            VerifyShippingData();
            GetShippingLabelFromCarrier();
            PrintLabel(writer);
        }

        public virtual void VerifyShippingData()
        {
            if (String.IsNullOrEmpty(ShippingAddress))
            {
                throw new ApplicationException("Invalid address.");
            }
        }
        public abstract void GetShippingLabelFromCarrier();
        public virtual void PrintLabel(TextWriter writer)
        {
            writer.Write(Label);
        }
    }

    public class UpsOrderShipment : OrderShipment
    {
        public override void GetShippingLabelFromCarrier()
        {
            // Call UPS Web Service
            Label = String.Format("UPS:[{0}]", ShippingAddress);
        }
    }

    public class FedExOrderShipment : OrderShipment
    {
        public override void GetShippingLabelFromCarrier()
        {
            // Call FedEx Web Service
            Label = String.Format("FedEx:[{0}]", ShippingAddress);
        }
    }
}