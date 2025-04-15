using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] float accleration = 20f;     //����/���� ���ӵ�
    [SerializeField] float steering = 3f;         //���� �ӵ�
    [SerializeField] float maxSpeed = 10f;        //�ִ� �ӵ� ����
    [SerializeField] float driftFactor = 0.95f;   //�������� �� �̲�����

    [SerializeField] ParticleSystem smokeLeft;
    [SerializeField] ParticleSystem smokeRight;

    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;

    [SerializeField] float slowAcclerationRatio = 0.5f;
    [SerializeField] float boostAcclerationRatio = 1.5f;

    [SerializeField] float destroyDelay = 1f;

    Rigidbody2D rb;

    [SerializeField] AudioSource driftAudioSource;

    float defaultAccleration;
    float slowAccleration;
    float boostAccleration;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
            if (!driftAudioSource.isPlaying) driftAudioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }
        else
        {
            if (driftAudioSource.isPlaying) driftAudioSource.Stop();
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
            Debug.Log("�ӵ��� �����մϴ�");

            Invoke(nameof(ResetAccleration), 5f);
            Destroy(other.gameObject, destroyDelay);
        }
    }

    void ResetAccleration()
    {
        accleration = defaultAccleration;
        Debug.Log("�ӵ��� ������� ���ƿԽ��ϴ�");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        accleration = slowAccleration;
        Debug.LogWarning("���巹�ϰ� �浹�߽��ϴ�! �ӵ��� 5�ʵ��� �����մϴ�");

        Invoke(nameof(ResetAccleration), 5f);
    }
}
