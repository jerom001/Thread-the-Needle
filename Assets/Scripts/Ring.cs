using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour
{
    public float speed = 3f;
    public float requiredAngle;
    public bool checkedAlready = false;
    public Transform arrow;

    private NeedleController needle;
    private Vector3 originalScale;
    private bool isFinishing = false;

    void Start()
    {
        needle = FindFirstObjectByType<NeedleController>();
        originalScale = transform.localScale;

        if (arrow != null)
            arrow.localRotation = Quaternion.Euler(0, 0, requiredAngle - 90f);

        StartCoroutine(SpawnPop());
    }

    void Update()
    {
        if (!isFinishing)
            transform.position += Vector3.left * speed * Time.deltaTime;

        if (!checkedAlready && transform.position.x <= 0f)
        {
            checkedAlready = true;
            CheckAngle();
        }

        if (transform.position.x < -10f)
            Destroy(gameObject);
    }

    void CheckAngle()
    {
        isFinishing = true;

        float difference = Mathf.Abs(Mathf.DeltaAngle(needle.currentAngle, requiredAngle));

        if (difference <= 25f)
        {
            GameManager.Instance.AddScore();
            GameManager.Instance.SpawnSuccessParticles(transform.position);
            StopAllCoroutines();
            StartCoroutine(PopAndDestroy());
        }
        else
        {
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnPop()
    {
        transform.localScale = originalScale * 0.6f;
        yield return new WaitForSeconds(0.06f);

        transform.localScale = originalScale * 1.08f;
        yield return new WaitForSeconds(0.05f);

        transform.localScale = originalScale;
    }

    IEnumerator PopAndDestroy()
    {
        transform.localScale = originalScale * 1.2f;
        yield return new WaitForSeconds(0.08f);

        transform.localScale = originalScale * 0.85f;
        yield return new WaitForSeconds(0.05f);

        Destroy(gameObject);
    }
}