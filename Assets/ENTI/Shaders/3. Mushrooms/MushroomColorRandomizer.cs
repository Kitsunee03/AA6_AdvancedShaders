using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MushroomColorRandomizer : MonoBehaviour
{
    static readonly int ID_Color = Shader.PropertyToID("_Color");

    private void Start()
    {
        var mpb = new MaterialPropertyBlock();
        GetComponent<Renderer>().GetPropertyBlock(mpb);
        mpb.SetColor(ID_Color, Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f));
        GetComponent<Renderer>().SetPropertyBlock(mpb);
    }
}