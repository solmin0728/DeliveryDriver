using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public AudioClip crashSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource가 없습니다!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 감지됨! " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Guard"))
        {
            Debug.Log("가드레일 충돌! 소리 재생 시도");
            if (crashSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(crashSound);
            }
            else
            {
                Debug.LogWarning("사운드나 오디오소스가 비어 있습니다!");
            }
        }
    }
}



/*public class Accident : MonoBehaviour
{
    public AudioClip crashSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {
            Debug.Log("가드레일과 충돌!");
            if (crashSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(crashSound);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {
            Debug.Log("가드레일과 충돌!");  // 이 로그가 콘솔에 뜨는지 확인
            if (crashSound != null && audioSource != null)
            {
                Debug.Log("사운드 재생 시도");
                audioSource.PlayOneShot(crashSound);
            }
            else
            {
                Debug.Log("오디오소스나 사운드 누락");
            }
        }
    }*/