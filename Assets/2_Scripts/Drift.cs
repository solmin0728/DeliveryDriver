using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] float accleration = 20f;     //전진/후진 가속도
    [SerializeField] float steering = 3f;         //조향 속도
    [SerializeField] float maxSpeed = 10f;        //최대 속도 제한
    [SerializeField] float driftFactor = 0.95f;   //낮을수록 더 미끄러짐

    [SerializeField] ParticleSystem smokeLeft;
    [SerializeField] ParticleSystem smokeRight;

    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;

    [SerializeField] float slowAcclerationRatio = 0.5f;
    [SerializeField] float boostAcclerationRatio = 1.5f;

    Rigidbody2D rb;

    AudioSource audioSource;

    float defaultAccleration;
    float slowAccleration;
    float boostAccleration;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = rb.GetComponent<AudioSource>();

        defaultAccleration = accleration;
        slowAccleration = accleration * slowAcclerationRatio;
        boostAccleration = accleration * boostAcclerationRatio;
    }

    void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * accleration);
        }

        //float turnAmount = Input.GetAxis("Horizontal") * steering * speed * Time.fixedDeltaTime;
        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

        //Drift
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * driftFactor;
    }

    private void Update()
    {
        float sidewayVelocity = Vector2.Dot(rb.linearVelocity, transform.right);
        bool isDrifting = rb.linearVelocity.magnitude > 2f && Mathf.Abs(sidewayVelocity) > 2.2f;
        if (isDrifting)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            accleration = boostAccleration;
            Debug.Log("속도가 증가합니다");

            Invoke(nameof(ResetAccleration), 5f);
            //Destroy(other.gameObject, destoryDelay);
        }
    }

    void ResetAccleration()
    {
        accleration = defaultAccleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        accleration = slowAccleration;
        Debug.Log("가드레일과 충돌했습니다!");
        Debug.Log("속도가 감소합니다");

    }
}
