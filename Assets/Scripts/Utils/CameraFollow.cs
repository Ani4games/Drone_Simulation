using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 6, -12);
    public float followSmooth = 0.18f;
    public float hitShakeIntensity = 0.3f;
    public float hitShakeTime = 0.15f;

    private float shakeTimer;

    private Vector3 velocity = Vector3.zero;
    public void TriggerHitShake()
    {
        shakeTimer = hitShakeTime;
    }

    void LateUpdate()
    {
        Vector3 shakeOffset = Vector3.zero;

        if (shakeTimer > 0)
        {
            shakeOffset = Random.insideUnitSphere * hitShakeIntensity;
            shakeTimer -= Time.deltaTime;
        }
        if (!target) return;

        Vector3 targetPos = target.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos + offset + shakeOffset,
            ref velocity,
            followSmooth
        );

        Vector3 lookPoint = target.position + Vector3.up * 1.5f;
        transform.LookAt(lookPoint);
    }
}
