using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class representing a subject that can be observed by implementing the Observer pattern.
/// </summary>
public abstract class Subject : MonoBehaviour
{
    /// <summary>
    /// List of observers subscribed to this subject.
    /// </summary>
    private List<IObserver> _observers = new List<IObserver>();

    /// <summary>
    /// Adds an observer to the list of observers.
    /// </summary>
    /// <param name="observer">The observer to be added.</param>
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    /// <summary>
    /// Removes an observer from the list of observers.
    /// </summary>
    /// <param name="observer">The observer to be removed.</param>
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /// <summary>
    /// Notifies all observers in the list when a specific action occurs.
    /// </summary>
    /// <param name="action">The action to notify observers about.</param>
    protected void NotifyObserver(ButtonPressAction action)
    {
        _observers.ForEach((_observer) => { _observer.OnNotify(action); });
    }
}
