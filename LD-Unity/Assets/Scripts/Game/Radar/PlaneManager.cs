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
        for (int i = 0; i < 50; i++)
            GlobalState.Game.Planes.Add(
                CallsignHandler.RegisterNewCallsign(GlobalState),
                CreatePlane()
            );
    }

    public AirPlane CreatePlane()
    {
        GameObject Plane = Instantiate(
            Resources.Load<GameObject>("Object/Plane"), 
            ExtraFunctions.RandomPointInsideCircle(transform.position, 500),
            Quaternion.identity,
            transform
        );

        return new AirPlane()
        {
            gameObject = Plane
        };
    }
}
