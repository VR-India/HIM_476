using UnityEngine;
using BNG;

public class Haptics : MonoBehaviour
{
    public static Haptics instance;

    // Input bridge for handling controller input.
    public InputBridge input;

    public float VibrateFrequency = 0.3f;
    public float VibrateAmplitude = 0.1f;
    public float VibrateDuration = 0.1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    /// <summary>
    /// Calls haptic feedback for the right controller with default parameters.
    /// </summary>
    public void callHaptics()
    {
        doHaptics(ControllerHand.Right, VibrateFrequency, VibrateAmplitude, VibrateDuration);
    }

    /// <summary>
    /// Executes haptic feedback for a specified controller.
    /// </summary>
    /// <param name="touchingHand">The controller hand to provide haptic feedback.</param>
    /// <param name="frequency">The vibration frequency.</param>
    /// <param name="amplitude">The vibration amplitude.</param>
    /// <param name="duration">The vibration duration.</param>
    public void doHaptics(ControllerHand touchingHand, float frequency, float amplitude, float duration)
    {
        if (input)
        {
            input.VibrateController(frequency, amplitude, duration, touchingHand);
            Debug.Log("Vibrating");
        }
    }
}
