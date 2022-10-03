using UnityEngine;

public static class ChatManager
{
    public static void CreateMessage(string Content, bool Player, Transform Parent)
    {
        GameObject _object = Object.Instantiate(Resources.Load<GameObject>("Objects/Message"), Parent);

        Message _msg = _object.GetComponent<Message>();
        _msg.OnLoad(null, () => { });
        _msg.SetContent(Content, Player);
    }
}
