using System;
using static Chrio.World.Game_State;

/// <summary>
/// Handles callsigns for airplanes
/// </summary>
public static class CallsignHandler
{
    public static AirPlane PlaneForCallsign(State GlobalState, string Callsign) => PlaneForId(GlobalState, GlobalState.Game.Callsigns[Callsign]);
    public static AirPlane PlaneForId(State GlobalState, Guid Id) => GlobalState.Game.Planes[Id];

    public static bool CallsignIsValid(Chrio.World.Game_State.State GlobalState, string Callsign)
    {
        Callsign = Callsign.ToUpper();

        if (!GlobalState.Game.Callsigns.TryGetValue(Callsign, out var id)) return false;

        if (!GlobalState.Game.Planes.TryGetValue(id, out var plane)) return false;

        return true;
    }

    public static (Guid, string) RegisterNewCallsign(Chrio.World.Game_State.State GlobalState)
    {
        // Generate new pair
        string _callsign = GenerateCallsign();
        Guid _guid = Guid.NewGuid();

        if (GlobalState.Game.Callsigns.ContainsKey(_callsign)) _callsign = GenerateCallsign(); // One level of redundancy

        // Register it in state
        GlobalState.Game.Callsigns.Add(_callsign, _guid);

        return (_guid, _callsign); // For registering a plane to this callsign
    }

    public static string GenerateCallsign() =>
            $"{Convert.ToChar(UnityEngine.Random.Range(65, 91))}" +
            $"{Convert.ToChar(UnityEngine.Random.Range(65, 91))}" +
            $"{UnityEngine.Random.Range(10000, 99999)}";
}
