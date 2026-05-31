using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Renderer targetRenderer;
    public Material normalMaterial;
    public Material glowMaterial;

    public void SetNormalMaterial() {
        targetRenderer.material= normalMaterial;
    }

    public void SetGlowMaterial() {
        targetRenderer.material= glowMaterial;
    }
}
