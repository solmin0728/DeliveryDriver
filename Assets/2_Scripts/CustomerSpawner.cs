using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject ManPrefab;     // ���� �մ� ������
    public GameObject WomanPrefab;   // ���� �մ� ������
    public Transform[] spawnPoints;   // �մ��� ��Ÿ�� ��ġ��

    public GameObject currentCustomer;       // ���� ���� �ִ� �մ�

    void Start()
    {
        SpawnCustomer();  // ���� �����ϸ� �� �� ����
    }
    public void SpawnCustomer()
    {
        // ���� �մ��� ������ ����
        if (currentCustomer != null)
        {
            Destroy(currentCustomer);
        }

        // ���� ��ġ ����
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPos = spawnPoints[randomSpawnIndex];
        // ���� �մ� ���� (0�̸� ����, 1�̸� ����)
        int randomType = Random.Range(0, 2);
        GameObject chosenPrefab = (randomType == 0) ? ManPrefab : WomanPrefab;
        // �մ� ����
        currentCustomer = Instantiate(chosenPrefab, spawnPos.position, Quaternion.identity);
        Debug.Log("���ο� �մ��� ��Ÿ�����ϴ�");
    }
}
