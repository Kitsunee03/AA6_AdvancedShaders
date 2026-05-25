using UnityEngine;

public class SnowController : MonoBehaviour
{
    [Header("Animation")] [SerializeField] private float speed = 0.25f;
    [SerializeField, Range(0f, 1f)] private float maxSnow = 1f;
    [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    private static readonly int SnowAmountID = Shader.PropertyToID("_SnowAmount");

    private void OnDisable() => Shader.SetGlobalFloat(SnowAmountID, 0f);

    private void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        float amount = curve.Evaluate(t) * maxSnow;
        Shader.SetGlobalFloat(SnowAmountID, amount);
    }
}