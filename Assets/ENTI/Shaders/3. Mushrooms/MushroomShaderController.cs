using UnityEngine;

public class MushroomController : MonoBehaviour
{
    private static readonly int PlayerPosID = Shader.PropertyToID("_PlayerPosition");
    private static readonly int RadiusID = Shader.PropertyToID("_AffectRadius");
    private static readonly int IntensityID = Shader.PropertyToID("_AffectIntensity");
    private static readonly int ContrastID = Shader.PropertyToID("_AffectContrast");

    [Header("References"), SerializeField] private Transform player;

    [Header("Config"), SerializeField, Range(0, 3)]
    private float affectRadius = 3f;

    [SerializeField, Range(0, 1f)] private float affectIntensity = 1f;
    [SerializeField, Range(0.1f, 5f)] private float affectContrast = 1f;

    private void Update()
    {
        Shader.SetGlobalVector(PlayerPosID, player.position);
        Shader.SetGlobalFloat(RadiusID, affectRadius);
        Shader.SetGlobalFloat(IntensityID, affectIntensity);
        Shader.SetGlobalFloat(ContrastID, affectContrast);
    }
}