using UnityEngine;

public class Operater : MonoBehaviour
{
    private void Start()
    {
        ex1();
        ex2();
        ex3();

    }

    private static void ex1()
    {
        int health = 40;

        if (health > 70)
        {
            Debug.Log("�ǰ��ؿ�");
        }
        else if (health > 30)
        {
            Debug.Log("�ణ ���ƾ��");
        }
        else if (health > 0)
        {
            Debug.Log("�����ؿ�");
        }
        else
        {
            Debug.Log("���");
        }
    }

    private void ex2()
    {
        int mathScore = 100;
        int englishScore = 100;

        if (mathScore >= 60 && englishScore >= 60)
        {
            if (mathScore + englishScore / 2 >= 90)
            {
                Debug.Log("��� �հ�");
            }
            else
            {
                Debug.Log("�Ϲ� �հ�");
            }
        }
        else
        {
            Debug.Log("���հ�");
        }
    }

    private void ex3()
    {
        int level = 5;
        bool isItem = true;
        bool isBattle = true;

        if (level >= 5 && isItem && isBattle)
        {
            Debug.Log("������ ��� ����");
        }
        else
        {
            Debug.Log("������ ��� �Ұ�");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
