using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Accident : MonoBehaviour
{
    /*public AudioClip crashSound;
    private AudioSource AccidentAudioSource;

    void Start()
    {
        AccidentAudioSource = GetComponent<AudioSource>();
        AccidentAudioSource.playOnAwake = false; // ���� �� �ڵ� ��� ����
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {
            if (crashSound != null)
            {
                AccidentAudioSource.PlayOneShot(crashSound);
            }
        }
    }*/
}
