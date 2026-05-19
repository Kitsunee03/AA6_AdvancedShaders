using UnityEngine;

public class FlowmapSimulationSystem : MonoBehaviour
{
    [SerializeField] private Material flowmapSimulationMat;

    [SerializeField] private RenderTexture flowA, flowB;

    [SerializeField] private float radius = 0.1f, hardness = 1.0f;

    private bool swap;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        RenderTexture source = swap ? flowA : flowB;
        RenderTexture target = swap ? flowB : flowA;

        // Player to UV
        Vector3 viewport = Camera.main.WorldToViewportPoint(player.position);

        // parameteres
        flowmapSimulationMat.SetTexture("_PreviousFrame", source);
        flowmapSimulationMat.SetVector("_Position", new(viewport.x, viewport.y, 0, 0));
        flowmapSimulationMat.SetFloat("_PlayerRadius", radius);
        flowmapSimulationMat.SetFloat("_PlayerHardness", hardness);

        // fullscreen pass
        Graphics.Blit(source, target, flowmapSimulationMat);

        // global texture
        Shader.SetGlobalTexture("_Flowmap", target);

        swap = !swap;
    }
}