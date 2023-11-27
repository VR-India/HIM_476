using System.Collections.Generic;
using UnityEngine;

public abstract class subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver> ();

    //adds observers to the list of observers
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    //removes observers to the list of observers
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    //notifies observers in the list when an event occurs
    protected void NotifyObserver(ButtonPressAction action)
    {
        _observers.ForEach((_observer) => {_observer.OnNotify(action); } );
    }
}
