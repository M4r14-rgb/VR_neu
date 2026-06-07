using UnityEngine;

public class ScrewLoosen : MonoBehaviour
{
    private bool isLoosened = false;

    public Vector3 loosenMove = new Vector3(0, 0, 0.05f);

    public void LoosenScrew()
    {
        if (isLoosened) return;

        transform.position += loosenMove;

        isLoosened = true;

        Debug.Log("Schraube kommt raus: " + gameObject.name);
    }
}