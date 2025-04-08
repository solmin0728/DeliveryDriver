using UnityEngine;

public class Driver : MonoBehaviour
{
    //리셋 했을때 초기 값
    public string driverName;
    [SerializeField] float turnSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.02f;
    [SerializeField] float slowSpeedRatio = 0.5f;
    [SerializeField] float boostSpeedRatio = 1.5f;
    [SerializeField] float destoryDelay = 0.3f;

    float slowSpeed;
    float boostSpeed;

    private void Start()
    {
        slowSpeed = moveSpeed * slowSpeedRatio;
        boostSpeed = moveSpeed * boostSpeedRatio;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boost!");
            Destroy(other.gameObject, destoryDelay);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
        Debug.Log("아야!");
    }

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //Debug.Log(turnAmount);

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //Debug.Log(moveAmount);

        transform.Rotate(0, 0, -turnAmount); //방향 설정
        transform.Translate(0, moveAmount, 0);
    }
}

