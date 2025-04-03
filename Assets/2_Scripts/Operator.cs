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
            Debug.Log("건강해요");
        }
        else if (health > 30)
        {
            Debug.Log("약간 지쳤어요");
        }
        else if (health > 0)
        {
            Debug.Log("위험해요");
        }
        else
        {
            Debug.Log("사망");
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
                Debug.Log("우수 합격");
            }
            else
            {
                Debug.Log("일반 합격");
            }
        }
        else
        {
            Debug.Log("불합격");
        }
    }

    private void ex3()
    {
        int level = 5;
        bool isItem = true;
        bool isBattle = true;

        if (level >= 5 && isItem && isBattle)
        {
            Debug.Log("아이템 사용 가능");
        }
        else
        {
            Debug.Log("아이템 사용 불가");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
