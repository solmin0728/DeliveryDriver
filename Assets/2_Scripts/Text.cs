using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject marker;

    void Start()
    {
        if (marker != null) marker.SetActive(true); // �մ��� ������ �� ǥ�� ��
        //void HideMarker() { if (marker != null) marker.SetActive(false); }
    }
}
