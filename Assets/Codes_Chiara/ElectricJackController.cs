using UnityEngine;

public class ElectricJackController : MonoBehaviour
{
    public Transform autoTransform;

    public GameObject wagenheberZugeklappt;
    public GameObject wagenheberAusgeklappt;

    private bool hasLifted = false;

    public void LiftCar()
    {
        if (hasLifted)
            return;

        hasLifted = true;

        // Position des ausgeklappten Wagenhebers übernehmen
        if (wagenheberZugeklappt != null && wagenheberAusgeklappt != null)
        {
            wagenheberAusgeklappt.transform.position =
                wagenheberZugeklappt.transform.position;

            wagenheberAusgeklappt.transform.rotation =
                wagenheberZugeklappt.transform.rotation;
        }

        // Wagenheber wechseln
        if (wagenheberZugeklappt != null)
            wagenheberZugeklappt.SetActive(false);

        if (wagenheberAusgeklappt != null)
            wagenheberAusgeklappt.SetActive(true);

        // Auto leicht kippen
        autoTransform.Rotate(0f, 0f, -5f);

        // Auto leicht anheben
        autoTransform.position += new Vector3(0f, 0.08f, 0f);

        Debug.Log("Auto wurde angehoben.");
    }
}