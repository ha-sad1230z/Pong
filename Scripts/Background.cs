using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    public Sprite[] backgrounds;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (backgrounds.Length > 0)
            sr.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        FitToCamera(sr);
    }

    void FitToCamera(SpriteRenderer sr)
    {
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
    }
}
