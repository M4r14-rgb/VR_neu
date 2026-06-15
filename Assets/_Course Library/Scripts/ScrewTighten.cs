using UnityEngine;

public class ScrewTighten : MonoBehaviour
{
    private bool isTightened = false;

    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public Rigidbody rb;

    public void TightenScrew()
    {
        if (isTightened) return;

        // Schraube leicht nach innen bewegen
        transform.localPosition += new Vector3(0.009f, 0, 0);

        isTightened = true;

        if (grabInteractable != null)
            grabInteractable.enabled = false;

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Debug.Log("Schraube festgezogen: " + gameObject.name);
    }
}