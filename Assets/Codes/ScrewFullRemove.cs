using UnityEngine;
using System.Collections;

public class ScrewFullRemove : MonoBehaviour
{
    private bool isFullyRemoved = false;

    public Vector3 removeMove = new Vector3(-0.01f, 0, 0);
    public float removeDuration = 0.5f;
    public float rotationSpeed = 0f;

    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public Rigidbody rb;
    public MaterialSwitcher materialSwitcher;

    public void RemoveScrewFully()
    {
        if (isFullyRemoved) return;

        StartCoroutine(RemoveRoutine());
    }

    private IEnumerator RemoveRoutine()
    {
        isFullyRemoved = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + removeMove;

        float elapsed = 0f;

        while (elapsed < removeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / removeDuration;

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        transform.position = targetPosition;

       
        if (materialSwitcher != null)
            materialSwitcher.SetNormalMaterial();
     
        if (grabInteractable != null)
            grabInteractable.enabled = true;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        Debug.Log("Schraube komplett herausgedreht und fällt runter: " + gameObject.name);
    }
}
