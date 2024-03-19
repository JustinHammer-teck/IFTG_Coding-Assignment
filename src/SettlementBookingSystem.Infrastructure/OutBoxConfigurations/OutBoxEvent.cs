namespace SettlementBookingSystem.Infrastructure.OutBoxConfigurations
{
    public record OutBoxEvent(string Id, string Payload, string Type);

}