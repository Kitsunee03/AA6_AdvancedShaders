using UnityEngine;

public class SimulationTEST : MonoBehaviour
{
    public Transform minSimulation, maxSimulation;

    public Transform trackedElement;
    
    public Material material;
    public RenderTexture renderTexture;

    [Header("WATCH ONLY")]
    public Material instanceMaterial;

    private void Awake()
    {
        instanceMaterial = new Material(material);
        instanceMaterial.SetVector("_MinPosSimulation", minSimulation.position);
        instanceMaterial.SetVector("_MaxPosSimulation", maxSimulation.position);
    }

    private void Update()
    {
        instanceMaterial.SetVector("_ElementPosition", trackedElement.position);
        Graphics.Blit(null, renderTexture, instanceMaterial);
    }
}