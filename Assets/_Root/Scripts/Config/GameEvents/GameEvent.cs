using System;
using UnityEngine;
[CreateAssetMenu(fileName = "GameEvent", menuName = "Game/GameEvent")]
public class GameEvent : ScriptableObject
{
    [TextArea(2, 10)] public string DeveloperDescription = "";

    event Action _listeners;

    public void Subscribe(Action callback)
    {
        //if(_listeners != null)
        _listeners += callback;
    }

    public void Unsubscribe(Action callback)
    {
        if (_listeners != null)
            _listeners -= callback;
    }

    public void Raise()
    {
        _listeners?.Invoke();
    }

    void OnDisable()
    {
        // clear all references
        _listeners = null;
    }
}