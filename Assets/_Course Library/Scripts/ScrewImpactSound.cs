using UnityEngine;

public class ScrewImpactSound : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField]
    private float impactThreshold = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource == null || audioSource.clip == null)
            return;

        if (collision.relativeVelocity.magnitude > impactThreshold)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}