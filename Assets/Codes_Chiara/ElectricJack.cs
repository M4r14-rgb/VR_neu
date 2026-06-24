using UnityEngine;

public class ElectricJack : MonoBehaviour
{
    public Transform autoTransform;
    public GameObject wagenheberZugeklappt;
    public GameObject wagenheberAusgeklappt;

    private bool wurdeAngehoben = false;

    public bool darfHochfahren = true;
    public bool darfRunterfahren = false;

    public void EnableLiftOnly()
    {
        darfHochfahren = true;
        darfRunterfahren = false;
        Debug.Log("Wagenheber: Hochfahren erlaubt");
    }

    public void EnableLowerOnly()
    {
        darfHochfahren = false;
        darfRunterfahren = true;
        Debug.Log("Wagenheber: Runterfahren erlaubt");
    }

    public void LiftCar()
    {
        if (!darfHochfahren)
            return;

        if (wurdeAngehoben)
            return;

        wurdeAngehoben = true;

        if (wagenheberZugeklappt != null)
            wagenheberZugeklappt.SetActive(false);

        if (wagenheberAusgeklappt != null)
            wagenheberAusgeklappt.SetActive(true);

        if (autoTransform != null)
        {
            autoTransform.Rotate(0f, 0f, -5f);
            autoTransform.position += new Vector3(0f, 0.008f, 0f);
        }

        Debug.Log("LiftCar wurde ausgelöst");
    }

    public void LowerCar()
    {
        if (!darfRunterfahren)
            return;

        if (!wurdeAngehoben)
            return;

        wurdeAngehoben = false;

        if (wagenheberAusgeklappt != null)
            wagenheberAusgeklappt.SetActive(false);

        if (wagenheberZugeklappt != null)
            wagenheberZugeklappt.SetActive(true);

        if (autoTransform != null)
        {
            autoTransform.Rotate(0f, 0f, 5f);
            autoTransform.position += new Vector3(0f, -0.008f, 0f);
        }

        Debug.Log("LowerCar wurde ausgelöst");
    }
}