namespace WASD.QLicPlatform.API.Payments.Application.Internal.Validation;

public static class BillingSettingsValidator
{
    public static bool IsValidCycle(string cycle) =>
        cycle is not null &&
        (string.Equals(cycle, "yearly", StringComparison.OrdinalIgnoreCase) ||
         string.Equals(cycle, "monthly", StringComparison.OrdinalIgnoreCase));

    public static bool IsValidDay(int day) => day >= 1 && day <= 31;

    public static string NormalizeCycle(string cycle) =>
        string.Equals(cycle, "monthly", StringComparison.OrdinalIgnoreCase) ? "monthly" : "yearly";
}