namespace VisitorDemo
{
    public class NetWorthVisitor : IVisitor
    {
        public int Total { get; private set; }
        
        public void Visit(RealEstate realEstate)
        {
            Total += realEstate.EstimatedValue;
        }

        public void Visit(BankAccount bankAccount)
        {
            Total += bankAccount.Amount;
        }

        public void Visit(Loan loan)
        {
            Total -= loan.Owed;
        }
    }
}