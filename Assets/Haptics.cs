 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Windows;

public class Haptics : MonoBehaviour
{
    public static Haptics instance;
    
    public InputBridge input;

    public float VibrateFrequency = 0.3f;
    public float VibrateAmplitude = 0.1f;
    public float VibrateDuration = 0.1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void doHaptics(ControllerHand touchingHand, float frequency, float amplitude, float duration)
    {
        if (input)
        {
            input.VibrateController(frequency, amplitude, duration, touchingHand);
        }
    }

}
