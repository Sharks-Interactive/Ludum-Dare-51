using Chrio;

public class SpeedManager : SharksBehaviour
{
    public void SetSpeed(int Speed) => GlobalState.Game.Speed = Speed;
}
