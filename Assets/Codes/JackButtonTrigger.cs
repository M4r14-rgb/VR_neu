using UnityEngine;

public class JackButtonTrigger : MonoBehaviour
{
    public ElectricJackController electricJackController;
    private bool wasPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (wasPressed) return;

        if (other.CompareTag("Player") || other.name.Contains("Hand") || other.name.Contains("Controller"))
        {
            wasPressed = true;

            if (electricJackController != null)
                electricJackController.LiftCar();

            Debug.Log("Wagenheber-Knopf wurde ausgelöst.");
        }
    }
}