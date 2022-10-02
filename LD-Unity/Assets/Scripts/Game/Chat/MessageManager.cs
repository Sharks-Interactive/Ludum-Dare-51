using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using System.Linq;

public class MessageManager : SharksBehaviour
{
    private Transform _chatContent;
    private List<IMessageHandler> MessageHandlers = new();

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _chatContent = GameObject.Find("Chat-Content").transform;
        GameObject.Find("Chat-Text").GetComponent<TMP_InputField>().onValueChanged.AddListener(OnMessage);

        // Get everything with the message handler interface
        IEnumerable<Type> results = from type in AppDomain.CurrentDomain.GetAssemblies()
                      .SelectMany(s => s.GetTypes())
                                    where typeof(IMessageHandler).IsAssignableFrom(type)
                                    select type;

        foreach (Type result in results)
            if (result.Name != "IMessageHandler" && result.Name != "BaseMessageHandler") MessageHandlers.Add(Activator.CreateInstance(result) as IMessageHandler);
    }

    public void OnMessage(string Message)
    {
        ChatManager.CreateMessage(Message, true, _chatContent);

        // Loop through subsystems and find one to handle it and respond
    }

    public void Respond(string Message) => ChatManager.CreateMessage(Message, false, _chatContent);
}
