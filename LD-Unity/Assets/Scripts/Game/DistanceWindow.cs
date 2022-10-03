using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using TMPro;

public class DistanceWindow : SharksBehaviour
{
    public TMP_InputField[] DistanceOutputs = new TMP_InputField[6];

    private TMP_InputField _input;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _input = transform.Find("Input CS").GetComponent<TMP_InputField>();
        _input.onEndEdit.AddListener(HandleLookup);
    }

    public void HandleLookup(string Callsign)
    {
        if (!CallsignHandler.CallsignIsValid(GlobalState, Callsign.ToUpper()))
        {
            UpdateAll("N/A");
            return;
        }

        GameObject _plane = CallsignHandler.PlaneForCallsign(GlobalState, Callsign.ToUpper()).gameObject;
        if (_plane == null) return;

        for (int i = 0; i < DistanceOutputs.Length; i++)
            DistanceOutputs[i].text =
                $"{Vector2.Distance(_plane.transform.position, GlobalState.Game.Airport.Airports[i].transform.position):F2} km's";
    }

    public void UpdateAll(string Text) { for (int i = 0; i < DistanceOutputs.Length; i++) DistanceOutputs[i].text = Text; }
}
