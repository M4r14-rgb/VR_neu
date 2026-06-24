using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScrewSocketGlow : MonoBehaviour
{
    public void OnScrewInserted(SelectEnterEventArgs args)
    {
        ScrewTighten screw = args.interactableObject.transform.GetComponent<ScrewTighten>();

        if (screw != null)
            screw.ScrewInserted();
    }
}