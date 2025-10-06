using UnityEngine;
public class Ball : MonoBehaviour
{
    public float initialSpeed = 6f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        transform.position = Vector2.zero;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = rb.velocity * 1.1f;
            GameManager.Instance.PlaySound(GameManager.Instance.hitPaddleClip);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.PlaySound(GameManager.Instance.hitWallClip);
        }
    }
}