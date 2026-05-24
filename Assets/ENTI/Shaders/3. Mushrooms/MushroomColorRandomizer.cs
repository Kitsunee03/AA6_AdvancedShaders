using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MushroomColorRandomizer : MonoBehaviour
{
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private void Start()
    {
        MaterialPropertyBlock mpb = new();
        Renderer rend = GetComponent<Renderer>();

        // Leer el bloque existente (importante para no sobreescribir otros valores)
        rend.GetPropertyBlock(mpb);
        mpb.SetColor(ColorID, Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.7f, 1f));
        rend.SetPropertyBlock(mpb);
    }
}