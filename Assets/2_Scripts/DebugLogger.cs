using TMPro;
using UnityEngine;

public class DebugLogger : MonoBehaviour
{
    /*public TextMeshProUGUI debugText;
    private string logHistory = "";

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logHistory += logString + "\n";

        // 최근 10줄까지만 유지
        string[] lines = logHistory.Split('\n');
        if (lines.Length > 10)
        {
            logHistory = string.Join("\n", lines, lines.Length - 10, 10);
        }

        if (debugText != null)
        {
            debugText.text = logHistory;
        }
    }*/
}
