using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using TMPro;

public class FuelWindow : SharksBehaviour
{
    private TMP_InputField _fuelInput;
    private TMP_InputField _distOutput;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _fuelInput = transform.Find("Mask").transform.Find("Input KL").GetComponent<TMP_InputField>();
        _distOutput = transform.Find("Mask").transform.Find("Output KL").GetComponent<TMP_InputField>();

        _fuelInput.onValueChanged.AddListener(input => _distOutput.text = (float.Parse(input) * 0.418).ToString("F2") + "km's");
    }
}
