public class Spinner : Chrio.SharksBehaviour { void Update() => transform.Rotate(new UnityEngine.Vector3(0, 0, 36 * UnityEngine.Time.deltaTime * GlobalState.Game.Speed)); }
