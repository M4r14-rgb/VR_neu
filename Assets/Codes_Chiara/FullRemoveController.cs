using UnityEngine;
using UnityEngine.XR;

public class FullRemoveController : MonoBehaviour
{
    public bool removeModeActive = false;
    public XRNode controllerHand = XRNode.RightHand;

    private ScrewFullRemove currentScrew;
    private bool wasPressed = false;

    public void EnableRemoveMode()
    {
        removeModeActive = true;
        Debug.Log("Schrauben komplett entfernen ist jetzt aktiv.");
    }

    private void Update()
    {
        if (!removeModeActive) return;
        if (currentScrew == null) return;

        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerHand);

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && !wasPressed)
            {
                currentScrew.RemoveScrewFully();
            }

            wasPressed = isPressed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ScrewFullRemove screw = other.GetComponent<ScrewFullRemove>();

        if (screw != null)
        {
            currentScrew = screw;
            Debug.Log("Schraube zum Entfernen bereit: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ScrewFullRemove screw = other.GetComponent<ScrewFullRemove>();

        if (screw != null && screw == currentScrew)
        {
            currentScrew = null;
            Debug.Log("Schraube verlassen.");
        }
    }
}