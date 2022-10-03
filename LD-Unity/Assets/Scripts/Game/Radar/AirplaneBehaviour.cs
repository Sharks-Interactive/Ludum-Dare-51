using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using TMPro;
using UnityEngine;
using static Chrio.World.Game_State;
using static UnityEngine.GraphicsBuffer;

public class AirplaneBehaviour : SharksBehaviour
{
    public AirPlane Plane;
    private TextMeshProUGUI _identifier;
    private GameObject _icon;
    private System.Guid _id;

    private Transform _airportTarget = null;
    private string _targetAirportICO = string.Empty;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _identifier = GetComponentInChildren<TextMeshProUGUI>();
        _identifier.text = $"{Plane.Callsign} \n 0{Plane.FlightLevel}  {Plane.Speed}";

        _icon = transform.Find("Icon").gameObject;
        _icon.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));

        _id = GlobalState.Game.Callsigns[Plane.Callsign.ToUpper()];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Update our position
        transform.Translate((Plane.Speed * 0.01f) * _icon.transform.up, Space.Self);
        GlobalState.Game.Planes[_id].FuelRemaining -= (int)(Plane.Speed * 0.01f * 2.39234449761f);

        // If we are too far from the center/headed away from the center turn us
        if (Vector2.Distance(_icon.transform.position, GlobalState.Game.Airport.AirportsMap["YQX"].transform.position) > 340)
            _icon.transform.up = GlobalState.Game.Airport.AirportsMap["YQX"].transform.position - _icon.transform.position; ;

        if (GlobalState.Game.Planes[_id].FuelRemaining < 10)
        {
            // We are out of fuel/dead
            GlobalState.Game.Score.LostPlane();
            Destroy(gameObject);
        }

        if (_airportTarget == null) return;

        // Check if we've landed
        if (Vector2.Distance(_icon.transform.position, _airportTarget.position) < 5)
        {
            GlobalState.Game.Airport.OccupyAirportFor(_targetAirportICO.ToUpper());
            GlobalState.Game.Score.LandPlane();
            Destroy(gameObject);
        }
    }

    public void Land(string AirportCallsign)
    {
        // Point towards
        _airportTarget = GlobalState.Game.Airport.AirportsMap[AirportCallsign.ToUpper()].transform;
        _icon.transform.up = _airportTarget.position - _icon.transform.position;

        _targetAirportICO = AirportCallsign.ToUpper();
    }
}
