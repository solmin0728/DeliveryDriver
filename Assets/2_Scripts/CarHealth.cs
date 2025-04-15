using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts; // 하트 이미지들
    public TextMeshProUGUI gameStatusText; // ← 요게 방금 만든 GameStatusText랑 연결할 부분
    private int deliveriesMade = 0;

    public float invincibleTime = 5f; // 몇 초간 무적?
    private float invincibleTimer = 0f; // 무적 타이머
    private bool isInvincible = false;

    public GameObject restartButton;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    // 충돌 시 호출되는 함수
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard") && !isInvincible) // 가드레일과 충돌했을 때
        {
            TakeDamage(1); // 1만큼 체력 감소
            invincibleTimer = Time.time + invincibleTime; // 무적 타이머 시작
            isInvincible = true; // 무적 상태로 설정
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            // 배달 처리
            Object.FindFirstObjectByType<CarHealth>().MakeDelivery();
        }
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return; // 무적 중이면 데미지 무시

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

        restartButton.SetActive(true); // 버튼 보이게 하기
        Time.timeScale = 0f; // 게임 정지
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

        restartButton.SetActive(true); // 버튼 보이게 하기
        Time.timeScale = 0f; // 게임 정지
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 게임 재개
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (isInvincible && Time.time >= invincibleTimer)
        {
            isInvincible = false; // 무적 상태 끝
        }
    }
}
