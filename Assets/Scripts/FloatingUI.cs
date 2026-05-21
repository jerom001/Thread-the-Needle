using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    public float floatAmount = 10f;
    public float speed = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 pos = startPos;
        pos.y += Mathf.Sin(Time.time * speed) * floatAmount;

        transform.localPosition = pos;
    }
}