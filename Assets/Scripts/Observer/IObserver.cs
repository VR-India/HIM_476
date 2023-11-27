public interface IObserver
{
    //Classes that inherit from IObserver interface must implement the OnNotify method
    public void OnNotify(ButtonPressAction action);
}