using UnityEngine;
using UnityEngine.XR;

public class JackLowerTriggerButton : MonoBehaviour
{
    public ElectricJack electricJack;

    private bool isHovering = false;
    private bool wasPressed = false;

    private void Update()
    {
        if (!isHovering) return;

        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && !wasPressed)
            {
                Debug.Log("Runter-Knopf gedrückt");

                if (electricJack != null)
                    electricJack.LowerCar();
            }

            wasPressed = isPressed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name != "Knopf_unten")
            return;

        isHovering = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name != "Knopf_unten")
            return;

        isHovering = false;
        wasPressed = false;
    }
}