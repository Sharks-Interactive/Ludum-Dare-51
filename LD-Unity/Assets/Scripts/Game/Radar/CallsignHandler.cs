using System;

/// <summary>
/// Handles callsigns for airplanes
/// </summary>
public static class CallsignHandler
{
    public static Guid RegisterNewCallsign(Chrio.World.Game_State.State GlobalState)
    {
        // Generate new pair
        string _callsign = GenerateCallsign();
        Guid _guid = Guid.NewGuid();

        if (GlobalState.Game.Callsigns.ContainsKey(_callsign)) _callsign = GenerateCallsign(); // One level of redundancy

        // Register it in state
        GlobalState.Game.Callsigns.Add(_callsign, _guid);

        return _guid; // For registering a plane to this callsign
    }

    public static string GenerateCallsign() =>
            $"{Convert.ToChar(UnityEngine.Random.Range(65, 91))}" +
            $"{Convert.ToChar(UnityEngine.Random.Range(65, 91))}" +
            $"{UnityEngine.Random.Range(10000, 99999)}";
}
