using System;

namespace ApprovalCommon
{
    public interface IExpenseReport
    {
        decimal Total { get; }
    }

    public interface IExpenseApprover
    {
        ApprovalResponse ApproveExpense(IExpenseReport expenseReport);
    }

    public enum ApprovalResponse
    {
        Denied,
        Approved,
        BeyondApprovalLimit,
    }
}
