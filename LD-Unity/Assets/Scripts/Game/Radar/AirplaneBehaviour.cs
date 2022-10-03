using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using TMPro;
using UnityEngine;
using static Chrio.World.Game_State;

public class AirplaneBehaviour : SharksBehaviour
{
    public AirPlane Plane;
    private TextMeshProUGUI _identifier;
    private GameObject _icon;
    private System.Guid _id;

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
    }

    public void Land(string AirportCallsign)
    {
        // Point towards
        Vector3 vectorToTarget = GlobalState.Game.Airport.AirportsMap[AirportCallsign.ToUpper()].transform.position - _icon.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        _icon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
