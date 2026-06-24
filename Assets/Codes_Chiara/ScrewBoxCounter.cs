using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ScrewBoxCounter : MonoBehaviour
{
    public int requiredScrews = 5;
    private int currentScrews = 0;

    public XRGrabInteractable tireGrabInteractable;

    private HashSet<ScrewFullRemove> countedScrews = new HashSet<ScrewFullRemove>();
    private bool tireActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        ScrewFullRemove screw = other.GetComponent<ScrewFullRemove>();

        if (screw == null) return;
        if (countedScrews.Contains(screw)) return;

        countedScrews.Add(screw);
        currentScrews++;

        Debug.Log("Schraube in Box: " + currentScrews + "/" + requiredScrews);

        if (currentScrews >= requiredScrews && !tireActivated)
        {
            tireActivated = true;

            Debug.Log("Alle Schrauben in der Box. Reifen ist jetzt greifbar.");

            if (tireGrabInteractable != null)
            {
                tireGrabInteractable.enabled = true;

                tireGrabInteractable.selectEntered.AddListener(OnTireGrabbed);
                tireGrabInteractable.selectExited.AddListener(OnTireReleased);
            }
        }
    }

    private void OnTireGrabbed(SelectEnterEventArgs args)
    {
        ActivateTirePhysics();

        TireHapticFeedback haptic = tireGrabInteractable.GetComponent<TireHapticFeedback>();

        if (haptic != null)
            haptic.PlayHaptic();
    }

    private void OnTireReleased(SelectExitEventArgs args)
    {
        ActivateTirePhysics();
    }

    private void ActivateTirePhysics()
    {
        Rigidbody rb = tireGrabInteractable.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}