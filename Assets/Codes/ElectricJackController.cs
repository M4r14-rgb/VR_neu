using UnityEngine;
using System.Collections;

public class ElectricJackController : MonoBehaviour
{
    public Transform autoTransform;

    public GameObject wagenheberZugeklappt;
    public GameObject wagenheberAusgeklappt;

    public float liftHeight = 0.25f;
    public float duration = 2f;

    private bool hasLifted = false;

    public void LiftCar()
    {
        if (hasLifted) return;

        StartCoroutine(LiftRoutine());
    }

    private IEnumerator LiftRoutine()
    {
        hasLifted = true;

        if (wagenheberZugeklappt != null)
            wagenheberZugeklappt.SetActive(false);

        if (wagenheberAusgeklappt != null)
            wagenheberAusgeklappt.SetActive(true);

        Vector3 startPos = autoTransform.position;
        Vector3 targetPos = startPos + new Vector3(0, liftHeight, 0);

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            autoTransform.position =
                Vector3.Lerp(startPos, targetPos, elapsed / duration);

            yield return null;
        }

        autoTransform.position = targetPos;

        Debug.Log("Auto wurde angehoben.");
    }
}