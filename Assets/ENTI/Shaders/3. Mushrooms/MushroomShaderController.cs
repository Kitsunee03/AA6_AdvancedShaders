using UnityEngine;

public class MushroomShaderController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField, Range(0, 2)] public float affectRadius = 1.18f;
    [SerializeField, Range(0, 2)] public float affectIntensity = 0.5f;

    static readonly int ID_Pos = Shader.PropertyToID("_PlayerPosition");
    static readonly int ID_Radius = Shader.PropertyToID("_AffectRadius");
    static readonly int ID_Intensity = Shader.PropertyToID("_AffectIntensity");

    private void Update()
    {
        Shader.SetGlobalVector(ID_Pos, player.position);
        Shader.SetGlobalFloat(ID_Radius, affectRadius);
        Shader.SetGlobalFloat(ID_Intensity, affectIntensity);
    }
}