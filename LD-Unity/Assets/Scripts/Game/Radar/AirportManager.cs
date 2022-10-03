using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AirportManager : SharksBehaviour
{
    public GameObject[] Airports = new GameObject[6];
    public Dictionary<string, GameObject> AirportsMap = new ();
    public bool[] Occupied = new bool[6];

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _gameState.Game.Airport = this;

        // Unity doesn't serialise dictionaries by default (so stupid) so this is the only way I can think of rn
        // Sure I could do a setup with two lists or something or rq write my own dictionary drawer but.. crunch time!!!
        AirportsMap.Add("YQX", Airports[0]);
        AirportsMap.Add("BVK", Airports[1]);
        AirportsMap.Add("SRD", Airports[2]);
        AirportsMap.Add("INM", Airports[3]);
        AirportsMap.Add("PAP", Airports[4]);
        AirportsMap.Add("DOK", Airports[5]);
    }

    public bool IsOccupied(string Callsign) => Occupied[AirportsMap.Keys.ToList().IndexOf(Callsign)];
    public bool IsOccupied(int Index) => Occupied[Index];
}
