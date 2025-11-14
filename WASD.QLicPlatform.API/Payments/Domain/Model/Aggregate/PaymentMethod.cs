namespace WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;

public class PaymentMethod
{
    public int Id { get; private set; } = default!;
    public string Type { get; private set; } = default!;
    public string Details { get; private set; } = default!;
    public bool IsDefault { get; private set; }

    public PaymentMethod(int id, string type, string details, bool isDefault)
    {
        Id = id;
        Type = type;
        Details = details;
        IsDefault = isDefault;
    }

    public void Update(string type, string details, bool isDefault)
    {
        Type = type;
        Details = details;
        IsDefault = isDefault;
    }

    public void SetDefault(bool isDefault) => IsDefault = isDefault;
}