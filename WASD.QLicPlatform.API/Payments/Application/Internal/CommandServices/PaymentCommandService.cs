using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork) 
    : IPaymentCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payment
        {
            Amount = command.Amount,
            Date = command.Date,
            Status = command.Status,
            MethodId = command.MethodId
        };
        
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        
        return payment;
    }

    public async Task<Payment?> Handle(UpdatePaymentCommand command)
    {
        var payment = await paymentRepository.FindByIdAsync(command.Id);
        
        if (payment == null)
            return null;
        
        payment.Amount = command.Amount;
        payment.Date = command.Date;
        payment.Status = command.Status;
        payment.MethodId = command.MethodId;
        
        paymentRepository.Update(payment);
        await unitOfWork.CompleteAsync();
        
        return payment;
    }

    public async Task<bool> Handle(DeletePaymentCommand command)
    {
        var payment = await paymentRepository.FindByIdAsync(command.Id);
        
        if (payment == null)
            return false;
        
        paymentRepository.Remove(payment);
        await unitOfWork.CompleteAsync();
        
        return true;
    }
}