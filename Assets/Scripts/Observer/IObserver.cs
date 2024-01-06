/// <summary>
/// Interface for observers. Classes that inherit from IObserver interface must implement the OnNotify method.
/// </summary>
public interface IObserver
{
    /// <summary>
    /// Called when a button press action occurs.
    /// </summary>
    /// <param name="action">The button press action.</param>
    public void OnNotify(ButtonPressAction action);
}