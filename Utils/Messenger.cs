using System;
using System.Collections.Generic;

namespace DIAEFACLIENT.Utils;
//Patron Messenger variante de Observer(ENVIÓ MENSAJE EXPLÍCITO más en arquitecturas MVMM)
public class Messenger
{
    private readonly Dictionary<Type, List<Action<object>>> _subscribers = new Dictionary<Type, List<Action<object>>>();

    // Método para enviar un mensaje
    public void Send<TMessage>(TMessage message)
    {
        var messageType = typeof(TMessage);
        if (_subscribers.ContainsKey(messageType))
        {
            foreach (var subscriber in _subscribers[messageType])
            {
                subscriber(message);
            }
        }
    }

    // Método para registrar un receptor para un tipo de mensaje
    public void Register<TMessage>(Action<TMessage> callback)
    {
        var messageType = typeof(TMessage);
        if (!_subscribers.ContainsKey(messageType))
        {
            _subscribers[messageType] = new List<Action<object>>();
        }

        _subscribers[messageType].Add(x => callback((TMessage)x));
    }

    // Método para desregistrar un receptor
    public void Unregister<TMessage>(Action<TMessage> callback)
    {
        var messageType = typeof(TMessage);
        if (_subscribers.ContainsKey(messageType))
        {
            _subscribers[messageType].Remove(x => callback((TMessage)x));
        }
    }
}

public class CloseWindowMessage { }