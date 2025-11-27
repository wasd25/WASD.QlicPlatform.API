using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.CommandServices;

public class PaymentMethodCommandService(IPaymentMethodRepository paymentMethodRepository, IUnitOfWork unitOfWork) 
    : IPaymentMethodCommandService
{
    public async Task<PaymentMethod?> Handle(CreatePaymentMethodCommand command)
    {
        // If this is set as default, unset all other default payment methods
        if (command.IsDefault)
        {
            var currentDefault = await paymentMethodRepository.FindDefaultAsync();
            if (currentDefault != null)
            {
                currentDefault.IsDefault = false;
                paymentMethodRepository.Update(currentDefault);
            }
        }
        
        var paymentMethod = new PaymentMethod
        {
            Type = command.Type,
            Details = command.Details,
            IsDefault = command.IsDefault
        };
        
        await paymentMethodRepository.AddAsync(paymentMethod);
        await unitOfWork.CompleteAsync();
        
        return paymentMethod;
    }

    public async Task<bool> Handle(DeletePaymentMethodCommand command)
    {
        var paymentMethod = await paymentMethodRepository.FindByIdAsync(command.Id);
        
        if (paymentMethod == null)
            return false;
        
        paymentMethodRepository.Remove(paymentMethod);
        await unitOfWork.CompleteAsync();
        
        return true;
    }
}

