using UnityEngine;

public class MultiMaterialSwitcher : MonoBehaviour
{
    public Renderer[] targetRenderers;
    public Material glowMaterial;

    private Material[][] normalMaterials;

    private void Awake()
    {
        normalMaterials = new Material[targetRenderers.Length][];

        for (int i = 0; i < targetRenderers.Length; i++)
        {
            normalMaterials[i] = targetRenderers[i].materials;
        }
    }

    public void SetGlowMaterial()
    {
        for (int i = 0; i < targetRenderers.Length; i++)
        {
            Material[] glowMaterials = new Material[targetRenderers[i].materials.Length];

            for (int j = 0; j < glowMaterials.Length; j++)
            {
                glowMaterials[j] = glowMaterial;
            }

            targetRenderers[i].materials = glowMaterials;
        }
    }

    public void SetNormalMaterial()
    {
        for (int i = 0; i < targetRenderers.Length; i++)
        {
            targetRenderers[i].materials = normalMaterials[i];
        }
    }
}