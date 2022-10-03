using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using TMPro;

public class ScoreKeeper : SharksBehaviour
{
    private TextMeshProUGUI _scoreReadout;
    private UnityEngine.Vector2 _score;
    public UnityEngine.Vector2 Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreRefresh();
        }
    }
    private UnityEngine.GameObject _endScreen;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _gameState.Game.Score = this;
        _score = new UnityEngine.Vector2();

        _scoreReadout = GetComponent<TextMeshProUGUI>();
        _endScreen = UnityEngine.GameObject.Find("EndScreen");
        _endScreen.SetActive(false);
    }

    public void ScoreRefresh()
    {
        _scoreReadout.text = $"PLANES:\n  LANDED: {_score.x}\n  LOST: {_score.y}";

        if (_score.x + _score.y == 23)
        {
            _endScreen.SetActive(true);
            UnityEngine.Time.timeScale = 0.001f;
        }
    }

    public void LandPlane() => Score = new UnityEngine.Vector2(Score.x + 1, Score.y);

    public void LostPlane() => Score = new UnityEngine.Vector2(Score.x, Score.y + 1);
}
