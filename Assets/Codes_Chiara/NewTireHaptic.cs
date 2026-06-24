using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class NewTireHaptic : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    public float intensity = 1f;
    public float duration = 0.5f;

    private void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        SendHaptic(XRNode.LeftHand);
        SendHaptic(XRNode.RightHand);
    }

    private void SendHaptic(XRNode hand)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(hand);

        if (device.isValid)
            device.SendHapticImpulse(0, intensity, duration);
    }
}