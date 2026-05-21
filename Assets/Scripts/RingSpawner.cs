using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject ringPrefab;
    public float spawnInterval = 2.3f;
    public float spawnX = 9f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if( timer >= spawnInterval )
        {
            SpawnRing();
            timer = 0f;
        }
    }

    void SpawnRing()
    {
        Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);
        GameObject ring = Instantiate( ringPrefab, spawnPos, Quaternion.identity );

        Ring ringScript = ring.GetComponent<Ring>();
        ringScript.speed = GameManager.Instance.ringSpeed;
        ringScript.requiredAngle = GetRandomAngle();

    }

    float GetRandomAngle()
    {
        float[] angles = { 0f, 90f, 180f, 270f };
        return angles[Random.Range(0, angles.Length)];
    }
}
