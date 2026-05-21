using UnityEngine;
using System.Collections;
public class NeedleController : MonoBehaviour
{
    public float currentAngle;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        Vector2 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        currentAngle = angle;
    }

    public IEnumerator FlashHit()
    {
        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.08f);

        spriteRenderer.color = originalColor;
    }
}
