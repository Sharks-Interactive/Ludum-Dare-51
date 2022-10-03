using Chrio.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandHandler : BaseMessageHandler
{
    private List<string> _airportCallsigns = new List<string>()
    {
        "inm",
        "bvk",
        "yqx",
        "dok",
        "srd",
        "pap"
    };

    private string _airport;

    public override string HandleMessage(Game_State.State state, string message)
    {
        base.HandleMessage(state, message);

        foreach (string item in _airportCallsigns) if (message.Contains(item)) _airport = item;

        if (!message.Contains("land")) return string.Empty;

        CallsignHandler.PlaneForCallsign(state, callsign.ToUpper()).gameObject.GetComponent<AirplaneBehaviour>().Land(_airport.ToUpper());
        return $"Cleared to land {_airport.ToUpper()}, {callsign.ToUpper()}";
    }
}
