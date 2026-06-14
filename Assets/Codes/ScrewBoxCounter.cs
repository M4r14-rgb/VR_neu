using UnityEngine;
using System.Collections.Generic;

public class ScrewBoxCounter : MonoBehaviour
{
    public int requiredScrews = 5;
    private int currentScrews = 0;

    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable tireGrabInteractable;

    private HashSet<ScrewFullRemove> countedScrews = new HashSet<ScrewFullRemove>();

    private void OnTriggerEnter(Collider other)
    {
        ScrewFullRemove screw = other.GetComponent<ScrewFullRemove>();

        if (screw == null) return;

        if (countedScrews.Contains(screw)) return;

        countedScrews.Add(screw);
        currentScrews++;

        Debug.Log("Schraube in Box: " + currentScrews + "/" + requiredScrews);

        if (currentScrews >= requiredScrews)
        {
            Debug.Log("Alle Schrauben in der Box. Reifen ist jetzt greifbar.");

            if (tireGrabInteractable != null)
                tireGrabInteractable.enabled = true;
        }
    }
}