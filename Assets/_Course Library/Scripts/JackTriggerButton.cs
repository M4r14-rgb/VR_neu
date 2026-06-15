using UnityEngine;
using UnityEngine.XR;

public class JackTriggerButton : MonoBehaviour
{
    public ElectricJackController electricJackController;

    private bool isHovering = false;
    private bool wasPressed = false;

    private void Update()
    {
        if (!isHovering)
            return;

        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && !wasPressed)
            {
                if (electricJackController != null)
                    electricJackController.LiftCar();
            }

            wasPressed = isPressed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Hand") || other.name.Contains("Controller"))
        {
            isHovering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Hand") || other.name.Contains("Controller"))
        {
            isHovering = false;
        }
    }
}