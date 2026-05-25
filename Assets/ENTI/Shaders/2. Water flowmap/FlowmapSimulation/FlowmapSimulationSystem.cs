using UnityEngine;

public class FlowmapSimulationSystem : MonoBehaviour
{
    private static readonly int PreviousFrameID = Shader.PropertyToID("_PreviousFrame");
    private static readonly int PositionID = Shader.PropertyToID("_Position");
    private static readonly int PlayerRadiusID = Shader.PropertyToID("_PlayerRadius");
    private static readonly int PlayerHardnessID = Shader.PropertyToID("_PlayerHardness");
    private static readonly int Flowmap = Shader.PropertyToID("_Flowmap");
    [SerializeField] private Material flowmapSimulationMat;

    [SerializeField] private RenderTexture flowA, flowB;

    [SerializeField] private float radius = 0.1f, hardness = 1.0f;

    private bool swap;
    private Transform player;
    private Camera mainCamera;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RenderTexture source = swap ? flowA : flowB;
        RenderTexture target = swap ? flowB : flowA;

        // Player to UV
        Vector3 viewport = mainCamera.WorldToViewportPoint(player.position);

        // parameters
        flowmapSimulationMat.SetTexture(PreviousFrameID, source);
        flowmapSimulationMat.SetVector(PositionID, new Vector4(viewport.x, viewport.y, 0, 0));
        flowmapSimulationMat.SetFloat(PlayerRadiusID, radius);
        flowmapSimulationMat.SetFloat(PlayerHardnessID, hardness);

        // fullscreen pass
        Graphics.Blit(source, target, flowmapSimulationMat);

        // global texture
        Shader.SetGlobalTexture(Flowmap, target);

        swap = !swap;
    }
}