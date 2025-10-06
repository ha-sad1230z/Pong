using UnityEngine;
public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public string inputAxis;
    private void Update()
    {
        float move = Input.GetAxisRaw(inputAxis);
        transform.Translate(Vector2.up * move * moveSpeed * Time.deltaTime);
        float clampedY = Mathf.Clamp(transform.position.y, -3.5f, 3.5f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}