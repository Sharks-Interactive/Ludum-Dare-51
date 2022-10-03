using Chrio;
using Chrio.World;
using Chrio.World.Loading;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using System.Linq;
using SharkUtils;

public class MessageManager : SharksBehaviour
{
    private Transform _chatContent;
    private List<IMessageHandler> MessageHandlers = new();

    private TMP_InputField _chatInput;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        _chatContent = GameObject.Find("Chat-Content").transform;
        _chatInput = GameObject.Find("Chat-Text").GetComponent<TMP_InputField>();
        _chatInput.onEndEdit.AddListener(OnMessage);

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
        if (Message.Replace(" ", "") == string.Empty) return;

        ChatManager.CreateMessage(Message, true, _chatContent);
        _chatInput.text = "";

        Message = Message.Trim().ToLower();
        Message = ExtraFunctions.RemoveSpecialCharacters(Message);

        if (!CallsignHandler.CallsignIsValid(GlobalState, Message.Split(' ')[0].ToUpper()))
        {
            Respond("...");
            return;
        }

        string _resp = string.Empty;
        // Loop through subsystems and find one to handle it and respond
        foreach (IMessageHandler messageHandler in MessageHandlers)
        {
            _resp = messageHandler.HandleMessage(GlobalState, Message);
            if (_resp != string.Empty) break;
        }

        if (_resp == string.Empty) _resp = "Tower, say again?";
        Respond(_resp);
    }

    public void Respond(string Message) => ChatManager.CreateMessage(Message, false, _chatContent);
}
