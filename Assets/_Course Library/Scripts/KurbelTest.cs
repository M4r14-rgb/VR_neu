using UnityEngine;

public class KurbelTest : MonoBehaviour
{
    public CarLift carLift;

    public void KurbelGedrueckt()
    {
        carLift.LiftOnce();
    }
}