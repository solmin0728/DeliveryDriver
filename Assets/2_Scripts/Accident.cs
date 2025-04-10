using UnityEngine;

public class Accident : MonoBehaviour
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
}