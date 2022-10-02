using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using TMPro;

public class Message : SharksBehaviour
{
    private TextMeshProUGUI _text;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetContent(string Content, bool Player)
    {
        _text.text = Content;

        if (!Player) return;

        _text.horizontalAlignment = HorizontalAlignmentOptions.Right;
        _text.color = Color.red;
    }
}
