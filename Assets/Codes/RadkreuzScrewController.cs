using UnityEngine;
using UnityEngine.XR;

public class RadkreuzScrewController : MonoBehaviour
{
    public XRNode controllerHand = XRNode.RightHand;

    public AudioSource audioSource;

    private ScrewLoosen currentScrew;
    private bool wasTriggerPressed = false;

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerHand);

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && !wasTriggerPressed)
            {
                TryLoosenCurrentScrew();
            }

            wasTriggerPressed = isPressed;
        }
    }

    public void TryLoosenCurrentScrew()
    {
        if (currentScrew == null)
        {
            Debug.Log("Keine Schraube in Reichweite");
            return;
        }

        if (audioSource != null)
            audioSource.Play();

        currentScrew.LoosenScrew();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScrewLoosen screw = other.GetComponent<ScrewLoosen>();

        if (screw != null)
        {
            currentScrew = screw;
            Debug.Log("Schraube bereit: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ScrewLoosen screw = other.GetComponent<ScrewLoosen>();

        if (screw != null && screw == currentScrew)
        {
            currentScrew = null;
            Debug.Log("Schraube verlassen");
        }
    }
}