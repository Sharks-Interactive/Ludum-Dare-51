using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using System.Collections.Generic;
using TMPro;

public class AirportsWindow : SharksBehaviour
{
    private List<TMP_InputField> _airports = new ();
    private int _timer;

    private TextMeshProUGUI _refreshText;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _refreshText = transform.Find("Refresh Text").GetComponent<TextMeshProUGUI>();

        // transform.Find("Airports") for every child in the loop is a bad idea but I'm way to crunch time/lasy rn to break it out into it's own var
        // yeah writing this probably took longer but what can I say, priorities
        for (int i = 0; i < transform.Find("Airports").childCount; i++) _airports.Add(transform.Find("Airports").GetChild(i).GetComponentInChildren<TMP_InputField>());
        InvokeRepeating("Refresh", 0, 1);
    }

    public void Refresh()
    {
        if (_timer < 1)
        {
            for (int i = 0; i < _airports.Count; i++)
                _airports[i].text = GlobalState.Game.Airport.IsOccupied(i) ? "Occupied" : $"Vacancy";

            _timer = 5;
            _refreshText.text = $"Refreshing in {_timer} seconds...";
        }
        else
        {
            _timer--;
            _refreshText.text = $"Refreshing in {_timer} seconds...";
        }
    }
}
