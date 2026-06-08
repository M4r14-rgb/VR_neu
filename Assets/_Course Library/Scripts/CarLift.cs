using UnityEngine;

public class CarLift : MonoBehaviour
{
    public Transform jackPoint;

    public void LiftOnce()
    {
        // Leicht anheben
        transform.position += new Vector3(0f, 0.0015f, 0f);

        // Um den Wagenheberpunkt kippen
        transform.RotateAround(
            jackPoint.position,
            transform.forward,
            -0.15f
        );
    }
}