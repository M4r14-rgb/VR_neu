using UnityEngine;

public class ElectricJack : MonoBehaviour
{
    public Transform autoTransform;

    private bool wurdeAngehoben = false;

    public void LiftCar()
    {
        if (wurdeAngehoben)
            return;

        wurdeAngehoben = true;

        // leicht kippen
        autoTransform.Rotate(0f, 0f, -5f);

        // zusätzlich anheben
        autoTransform.position += new Vector3(0f, 0.08f, 0f);
    }
}