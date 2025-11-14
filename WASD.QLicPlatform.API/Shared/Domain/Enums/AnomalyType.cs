// WASD.QLicPlatform.API/Shared/Domain/Enums/AnomalyType.cs
namespace WASD.QLicPlatform.API.Shared.Domain.Enums
{
    public enum AnomalyType
    {
        LeakDetected = 1,
        HighTemperature = 2,
        UnusualConsumption = 3,
        LowReservoirLevel = 4,
        SensorOffline = 5,
        HighPressure = 6,
        Custom = 99
    }
}