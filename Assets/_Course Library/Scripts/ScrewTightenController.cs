using UnityEngine;
using UnityEngine.XR;

public class ScrewTightenController : MonoBehaviour
{
    public XRNode controllerHand = XRNode.RightHand;

    public AudioSource audioSource;
    public TireLockController tireLockController;
    private int tightenedCount = 0;

    private ScrewTighten currentScrew;
    private bool wasTriggerPressed = false;

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerHand);

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && !wasTriggerPressed)
            {
                TryTightenCurrentScrew();
            }

            wasTriggerPressed = isPressed;
        }
    }

    public void TryTightenCurrentScrew()
    {
        if (currentScrew == null)
        {
            Debug.Log("Keine Schraube zum Festziehen in Reichweite");
            return;
        }

        if (audioSource != null && audioSource.clip != null)
            audioSource.PlayOneShot(audioSource.clip);

        currentScrew.TightenScrew();

        tightenedCount++;

        Debug.Log("Neue Schrauben fest: " + tightenedCount);

        if (tightenedCount >= 1 && tireLockController != null)
        {
            tireLockController.LockTire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ScrewTighten screw = other.GetComponent<ScrewTighten>();

        if (screw != null)
        {
            currentScrew = screw;
            Debug.Log("Schraube zum Festziehen bereit: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ScrewTighten screw = other.GetComponent<ScrewTighten>();

        if (screw != null && screw == currentScrew)
        {
            currentScrew = null;
        }
    }
}