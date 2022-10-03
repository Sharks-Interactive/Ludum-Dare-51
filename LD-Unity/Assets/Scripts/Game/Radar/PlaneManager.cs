using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using SharkUtils;
using UnityEngine;
using static Chrio.World.Game_State;

public class PlaneManager : SharksBehaviour
{
    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        GeneratePlanes();
    }

    public void GeneratePlanes()
    {
        for (int i = 0; i < 15; i++)
        {
            (System.Guid, string) _identity = CallsignHandler.RegisterNewCallsign(GlobalState);

            GlobalState.Game.Planes.Add(
                _identity.Item1,
                CreatePlane(_identity.Item2)
            );
        }
    }

    public AirPlane CreatePlane(string callsign)
    {
        GameObject Plane = Instantiate(
            Resources.Load<GameObject>("Objects/Plane"), 
            ExtraFunctions.RandomPointInsideDonut(transform.position, 370, 60),
            Quaternion.identity,
            transform
        );

        AirplaneBehaviour _behaviour = Plane.GetComponent<AirplaneBehaviour>();
        _behaviour.Plane = new AirPlane()
        {
            gameObject = Plane,
            Callsign = callsign,
            FlightLevel = Random.Range(10, 40),
            Speed = Random.Range(165, 220),
            FuelRemaining = Random.Range(590, 1230)
        };

        _behaviour.OnLoad(GlobalState, () => { });

        return _behaviour.Plane;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, 370);
    }
#endif
}
