using Microsoft.EntityFrameworkCore;

namespace WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class PaymentsModelBuilderExtensions
{
    public static void ApplyPaymentsConfiguration(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PaymentConfiguration());
        builder.ApplyConfiguration(new PaymentMethodConfiguration());
        builder.ApplyConfiguration(new BillingSettingConfiguration());
    }
}

