using System;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;

public partial class Payment
{
    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Status { get; private set; }
    public string MethodId { get; private set; }

    public Payment(int id, decimal amount, DateTime date, string status, string methodId)
    {
        Id = id;
        Amount = amount;
        Date = date;
        Status = status;
        MethodId = methodId;
    }

    public Payment(CreatePaymentCommand cmd)
    {
        Id = cmd.Id;
        Amount = cmd.Amount;
        Date = cmd.Date;
        Status = cmd.Status;
        MethodId = cmd.MethodId;
    }

    public void Apply(UpdatePaymentCommand cmd)
    {
        Amount = cmd.Amount;
        Date = cmd.Date;
        Status = cmd.Status;
        MethodId = cmd.MethodId;
    }
}
