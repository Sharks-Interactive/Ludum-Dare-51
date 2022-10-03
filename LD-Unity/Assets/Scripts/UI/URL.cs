using UnityEngine;

public class URL : MonoBehaviour
{
    public string Website;

    public void OpenURL() => Application.OpenURL(Website);

    public void OpenURL(string Url) => Application.OpenURL(Url);

    public void Quit() => Application.Quit();
}