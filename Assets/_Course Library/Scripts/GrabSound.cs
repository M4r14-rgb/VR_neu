using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabSound : MonoBehaviour
{
    public AudioSource audioSource;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    private void OnGrab(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}