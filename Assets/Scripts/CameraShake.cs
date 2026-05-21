using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private Vector3 originalPosition;

    void Awake()
    {
        Instance = this;
        originalPosition = transform.position;
    }

    public void Shake(float duration, float strength)
    {
        StartCoroutine(ShakeRoutine(duration, strength));
    }

    IEnumerator ShakeRoutine(float duration, float strength)
    {
        float timer = 0f;

        while (timer < duration)
        {
            transform.position = originalPosition + (Vector3)Random.insideUnitCircle * strength;
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}