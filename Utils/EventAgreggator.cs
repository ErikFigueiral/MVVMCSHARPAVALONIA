using System;
using System.Collections.Generic;

namespace DIAEFACLIENT.Utils;
//Mediator
public class EventAggregator
{
    private static readonly EventAggregator _instance = new EventAggregator();
    public static EventAggregator Instance => _instance;

    private readonly Dictionary<Type, List<Action<object>>> _subscribers = new Dictionary<Type, List<Action<object>>>();

    public void Subscribe<T>(Action<T> callback)
    {
        var eventType = typeof(T);
        if (!_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType] = new List<Action<object>>();
        }
        _subscribers[eventType].Add(obj => callback((T)obj));
    }

    public void Publish<T>(T message)
    {
        var eventType = typeof(T);
        if (_subscribers.ContainsKey(eventType))
        {
            foreach (var subscriber in _subscribers[eventType])
            {
                subscriber(message);
            }
        }
    }
}