using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts; // ��Ʈ �̹�����
    public TextMeshProUGUI gameStatusText; // �� ��� ��� ���� GameStatusText�� ������ �κ�
    private int deliveriesMade = 0;

    public float invincibleTime = 5f; // �� �ʰ� ����?
    private float invincibleTimer = 0f; // ���� Ÿ�̸�
    private bool isInvincible = false;

    public GameObject restartButton;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    // �浹 �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard") && !isInvincible) // ���巹�ϰ� �浹���� ��
        {
            TakeDamage(1); // 1��ŭ ü�� ����
            invincibleTimer = Time.time + invincibleTime; // ���� Ÿ�̸� ����
            isInvincible = true; // ���� ���·� ����
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            // ��� ó��
            Object.FindFirstObjectByType<CarHealth>().MakeDelivery();
        }
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return; // ���� ���̸� ������ ����

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }

    void GameOver()
    {
        if (gameStatusText != null)
            gameStatusText.text = "Game Over";
        gameStatusText.color = Color.red;

        restartButton.SetActive(true); // ��ư ���̰� �ϱ�
        Time.timeScale = 0f; // ���� ����
    }

    public void MakeDelivery()
    {
        deliveriesMade++;
        if (deliveriesMade >= 4)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        if (gameStatusText != null)
            gameStatusText.text = "Game Clear!";
        gameStatusText.color = Color.yellow;

        restartButton.SetActive(true); // ��ư ���̰� �ϱ�
        Time.timeScale = 0f; // ���� ����
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // ���� �簳
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (isInvincible && Time.time >= invincibleTimer)
        {
            isInvincible = false; // ���� ���� ��
        }
    }
}
