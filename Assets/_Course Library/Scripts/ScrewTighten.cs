using UnityEngine;

public class ScrewTighten : MonoBehaviour
{
    private bool isTightened = false;
    private bool finalTightenAllowed = false;
    private bool finalTightened = false;

    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public Rigidbody rb;

    public MaterialSwitcher materialSwitcher;

    public void ScrewInserted()
    {
        if (materialSwitcher != null)
            materialSwitcher.SetGlowMaterial();

        Debug.Log("Schraube eingesetzt und leuchtet: " + gameObject.name);
    }

    public void TightenScrew()
    {
        if (finalTightenAllowed && !finalTightened)
        {
            finalTightened = true;

            if (materialSwitcher != null)
                materialSwitcher.SetNormalMaterial();

            Debug.Log("Schraube final festgezogen: " + gameObject.name);
            return;
        }

        if (isTightened) return;

        transform.localPosition += new Vector3(0.009f, 0, 0);

        isTightened = true;

        if (materialSwitcher != null)
            materialSwitcher.SetNormalMaterial();

        if (grabInteractable != null)
            grabInteractable.enabled = false;

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Debug.Log("Schraube festgezogen: " + gameObject.name);
    }

    public void EnableFinalTighten()
    {
        finalTightenAllowed = true;
        finalTightened = false;

        if (materialSwitcher != null)
            materialSwitcher.SetGlowMaterial();

        Debug.Log("Finales Festziehen aktiviert: " + gameObject.name);
    }
}