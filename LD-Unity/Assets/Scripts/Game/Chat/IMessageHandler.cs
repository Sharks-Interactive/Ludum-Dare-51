using Chrio.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMessageHandler
{
    string HandleMessage(Game_State.State state, string message);
}
