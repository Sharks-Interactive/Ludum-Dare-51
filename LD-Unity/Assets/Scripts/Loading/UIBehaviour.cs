using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base behaviour for UI elements that caches relevant object references
/// </summary>
public class UIBehaviour : SharksBehaviour
{
    protected Canvas canvas;
    protected EventSystem eventSystem;
    protected RectTransform rectTransform;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        eventSystem = FindObjectOfType<EventSystem>();
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }
}
