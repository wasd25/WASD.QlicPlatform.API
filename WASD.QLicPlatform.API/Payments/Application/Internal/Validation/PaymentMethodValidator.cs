using System.Linq;
using System.Text.RegularExpressions;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.Validation;

public static class PaymentMethodValidator
{
    private static readonly Regex DigitsOnly = new(@"^\d{12,19}$");

    public static string SanitizeCard(string input)
    {
        var digits = new string(input?.Where(char.IsDigit).ToArray() ?? []);
        return digits;
    }

    public static bool IsSupportedType(string? type)
        => !string.IsNullOrWhiteSpace(type) &&
           (string.Equals(type, "Visa", System.StringComparison.OrdinalIgnoreCase) ||
            string.Equals(type, "PayPal", System.StringComparison.OrdinalIgnoreCase));

    public static bool IsValidCard(string? digits)
        => !string.IsNullOrWhiteSpace(digits) && DigitsOnly.IsMatch(digits) && PassesLuhn(digits!);

    private static bool PassesLuhn(string digits)
    {
        int sum = 0; bool alternate = false;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            int n = digits[i] - '0';
            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }
            sum += n;
            alternate = !alternate;
        }
        return sum % 10 == 0;
    }
}