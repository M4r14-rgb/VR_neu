using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TireHapticFeedback : MonoBehaviour
{
    public float intensity = 0.8f;
    public float duration = 0.25f;

    public void PlayHaptic()
    {
        SendHaptic(XRNode.RightHand);
        SendHaptic(XRNode.LeftHand);
    }

    private void SendHaptic(XRNode hand)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(hand);

        if (device.isValid)
        {
            device.SendHapticImpulse(0, intensity, duration);
        }
    }
}