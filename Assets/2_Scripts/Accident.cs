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
            Debug.LogWarning("AudioSource�� �����ϴ�!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹 ������! " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Guard"))
        {
            Debug.Log("���巹�� �浹! �Ҹ� ��� �õ�");
            if (crashSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(crashSound);
            }
            else
            {
                Debug.LogWarning("���峪 ������ҽ��� ��� �ֽ��ϴ�!");
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
            Debug.Log("���巹�ϰ� �浹!");
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
            Debug.Log("���巹�ϰ� �浹!");  // �� �αװ� �ֿܼ� �ߴ��� Ȯ��
            if (crashSound != null && audioSource != null)
            {
                Debug.Log("���� ��� �õ�");
                audioSource.PlayOneShot(crashSound);
            }
            else
            {
                Debug.Log("������ҽ��� ���� ����");
            }
        }
    }*/