using UnityEngine;

public class FlowmapSimulationSystem : MonoBehaviour
{
    [Header("Flowmap Simulation Settings")]
    [SerializeField] private Material flowmapSimulationMat;
    [SerializeField] private RenderTexture flowA, flowB;
    [SerializeField] private float radius = 0.1f, hardness = 1.0f;

    [Header("Simulation Bounds (World Space)")]
    [SerializeField] private Vector3 simulationCenter = Vector3.zero;
    [SerializeField] private Vector3 simulationSize = new Vector3(10f, 1f, 10f);

    private Transform trackedElement;
    private Material instanceMat;
    private bool swap;
    private Vector3 lastPosition;

    private void Awake()
    {
        trackedElement = GameObject.FindGameObjectWithTag("Player").transform;
        instanceMat = new Material(flowmapSimulationMat);

        // Clear both buffers
        Graphics.Blit(Texture2D.blackTexture, flowA);
        Graphics.Blit(Texture2D.blackTexture, flowB);

        if (trackedElement != null) { lastPosition = trackedElement.position; }
    }

    private void Update()
    {
        if (trackedElement == null || instanceMat == null || flowA == null || flowB == null) { return; }

        RenderTexture source = swap ? flowA : flowB;
        RenderTexture target = swap ? flowB : flowA;

        Vector3 pos = trackedElement.position;
        Vector3 vel = (pos - lastPosition) / Mathf.Max(Time.deltaTime, 1e-6f);

        instanceMat.SetTexture("_PreviousFrame", source);
        instanceMat.SetVector("_Position", pos);
        instanceMat.SetVector("_Velocity", vel);
        instanceMat.SetVector("_SimulationCenter", simulationCenter);
        instanceMat.SetVector("_SimulationSize", simulationSize);
        instanceMat.SetFloat("_PlayerRadius", radius);
        instanceMat.SetFloat("_PlayerHardness", hardness);

        Graphics.Blit(source, target, instanceMat);
        Shader.SetGlobalTexture("_Flowmap", target);

        swap = !swap;
        lastPosition = pos;
    }
}