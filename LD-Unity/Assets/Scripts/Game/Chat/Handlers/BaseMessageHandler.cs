using Chrio.World;

public class BaseMessageHandler : IMessageHandler
{
    protected string callsign;
    protected string command;

    public virtual string HandleMessage(Game_State.State state, string message)
    {
        try 
        {
            callsign = message.Split(' ')[0]; // Get the first word of the command, which should always be a callsign
            command = message.Split(' ')[1]; 
        } catch 
        {
            callsign = string.Empty;
            command = string.Empty; 
        }

        return string.Empty;
    }
}
