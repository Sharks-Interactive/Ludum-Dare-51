using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicker : SharksBehaviour
{
    private AudioSource _src;
    public AudioClip Click;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _src = GetComponent<AudioSource>();
    }

    private void Update() { if (Mouse.current.leftButton.wasPressedThisFrame) _src.PlayOneShot(Click); }
}
