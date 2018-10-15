using System;

namespace Web.Content
{
    public class Demo
    {
         
    }

    
    // Demo Code for Slides

    public class DelinquentInvoiceSpecification
    {
        private readonly DateTime _evaluationDate;

        public DelinquentInvoiceSpecification(DateTime evaluationDate)
        {
            _evaluationDate = evaluationDate;
        }

        public bool IsSatisfiedBy(Invoice invoice)
        {
            DateTime hardDeadline = invoice.DueDate
                .AddDays(invoice.Customer.GracePeriodDays);

            return _evaluationDate > hardDeadline;
        }
    }

    public class Invoice
    {
        public DateTime DueDate { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public double GracePeriodDays { get; set; }
    }

}