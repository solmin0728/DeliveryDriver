using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject ManPrefab;     // 남자 손님 프리팹
    public GameObject WomanPrefab;   // 여자 손님 프리팹
    public Transform[] spawnPoints;   // 손님이 나타날 위치들

    public GameObject currentCustomer;       // 지금 씬에 있는 손님

    void Start()
    {
        SpawnCustomer();  // 게임 시작하면 한 명 등장
    }
    public void SpawnCustomer()
    {
        // 기존 손님이 있으면 삭제
        if (currentCustomer != null)
        {
            Destroy(currentCustomer);
        }

        // 랜덤 위치 고르기
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPos = spawnPoints[randomSpawnIndex];
        // 랜덤 손님 고르기 (0이면 남자, 1이면 여자)
        int randomType = Random.Range(0, 2);
        GameObject chosenPrefab = (randomType == 0) ? ManPrefab : WomanPrefab;
        // 손님 생성
        currentCustomer = Instantiate(chosenPrefab, spawnPos.position, Quaternion.identity);
        Debug.Log("새로운 손님이 나타났습니다");
    }
}
