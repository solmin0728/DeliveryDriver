using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject marker;

    void Start()
    {
        if (marker != null) marker.SetActive(true); // 손님이 생성될 때 표시 켬
        //void HideMarker() { if (marker != null) marker.SetActive(false); }
    }
}
