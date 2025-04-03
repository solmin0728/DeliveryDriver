using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destoryDelay = 0.3f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(0.35f, 0.65f, 1, 1);
    bool hasChicken = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Debug.Log("치킨 픽업");
            hasChicken = true;
            Destroy(collision.gameObject, destoryDelay);
            spriteRenderer.color = hasChickenColor;
        }

        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("배달 완료");
            hasChicken = false;
            spriteRenderer.color = noChickenColor;
        }

    }
}