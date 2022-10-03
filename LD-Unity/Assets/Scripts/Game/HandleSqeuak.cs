using System.Collections.Generic;
using UnityEngine;
using SharkUtils;
using Chrio.World;
using Chrio.World.Loading;

public class HandleSqeuak : Handle
{
    public List<AudioClip> Squeaks;
    private AudioSource _src;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _src = GetComponent<AudioSource>();
    }

    protected override void OnDragStart(Vector3 MousePosition)
    {
        base.OnDragStart(MousePosition);

        _src.PlayOneShot(ExtraFunctions.RandomFromList<AudioClip>(Squeaks));
    }
}
