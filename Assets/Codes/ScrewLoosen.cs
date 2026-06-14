using UnityEngine;

public class ScrewLoosen : MonoBehaviour
{
    private bool isLoosened = false;

    public Vector3 loosenMove = new Vector3(-0.006f, 0, 0);

    public MaterialSwitcher materialSwitcher;

    public void LoosenScrew()
    {
        if (isLoosened) return;

        transform.position += loosenMove;

        isLoosened = true;

        if (materialSwitcher != null)
            materialSwitcher.SetNormalMaterial();

        Debug.Log("Schraube kommt raus: " + gameObject.name);
    }
}