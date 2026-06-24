using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TireLockController : MonoBehaviour
{
    public XRGrabInteractable tireGrab;
    public Rigidbody tireRigidbody;

    public void LockTire()
    {
        if (tireGrab != null)
            tireGrab.enabled = false;

        if (tireRigidbody != null)
        {
            tireRigidbody.isKinematic = true;
            tireRigidbody.useGravity = false;
        }

        Debug.Log("Reifen wurde gesperrt");
    }
}