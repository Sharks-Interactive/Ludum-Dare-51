using Chrio.World;

public class FuelHandler : BaseMessageHandler
{
    public override string HandleMessage(Game_State.State state, string message)
    {
        base.HandleMessage(state, message);

        if (!message.Contains("fuel")) return string.Empty;

        return $"{CallsignHandler.PlaneForCallsign(state, callsign.ToUpper()).FuelRemaining} Litres left, {callsign.ToUpper()}";
    }
}
