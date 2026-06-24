using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TwoHandWheelGrab : MonoBehaviour
{
    private XRGrabInteractable grab;

    private IXRSelectInteractor firstHand;
    private IXRSelectInteractor secondHand;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        grab.selectEntered.RemoveListener(OnGrab);
        grab.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (firstHand == null)
        {
            firstHand = args.interactorObject;
        }
        else if (secondHand == null && args.interactorObject != firstHand)
        {
            secondHand = args.interactorObject;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (args.interactorObject == firstHand)
        {
            firstHand = secondHand;
            secondHand = null;
        }
        else if (args.interactorObject == secondHand)
        {
            secondHand = null;
        }
    }

    void LateUpdate()
    {
        if (firstHand == null || secondHand == null)
            return;

        Transform h1 = firstHand.GetAttachTransform(grab);
        Transform h2 = secondHand.GetAttachTransform(grab);

        Vector3 midpoint = (h1.position + h2.position) / 2f;

        Transform cam = Camera.main.transform;

        Vector3 right = cam.right;
        Vector3 forward = cam.forward;

        right.y = 0f;
        forward.y = 0f;

        right.Normalize();
        forward.Normalize();

        Vector3 offset =
            right * 1.2f +
            Vector3.up * 0.3f +
            forward * 2.0f;

        transform.position = midpoint + offset;

        transform.rotation = h1.rotation * Quaternion.Euler(0f, 270f, 0f);
    }
}