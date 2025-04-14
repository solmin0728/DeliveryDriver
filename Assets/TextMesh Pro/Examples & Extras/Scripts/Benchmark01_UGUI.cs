using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
    public class Benchmark01_UGUI : MonoBehaviour
    {
        public int BenchmarkType = 0;

        public Canvas canvas;
        public TMP_FontAsset TMProFont;
        public Font TextMeshFont;  // ������ UI Text font�� �ʿ��� �� ������ TextMeshPro�� TMP_FontAsset ���!

        private TextMeshProUGUI m_textMeshPro;  // TextMeshProUGUI�� ����
        // private TextContainer m_textContainer;
        // private Text m_textMesh;  // �� �κ��� ������� ����

        private const string label01 = "The <#0050FF>count is: </color>";
        private const string label02 = "The <color=#0050FF>count is: </color>";

        private Material m_material01;
        private Material m_material02;

        IEnumerator Start()
        {
            if (BenchmarkType == 0) // TextMesh Pro Component
            {
                m_textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();  // TextMeshProUGUI ������Ʈ �߰�

                if (TMProFont != null)
                    m_textMeshPro.font = TMProFont;

                m_textMeshPro.fontSize = 48;
                m_textMeshPro.alignment = TextAlignmentOptions.Center;
                m_textMeshPro.extraPadding = true;

                m_material01 = m_textMeshPro.font.material;
                m_material02 = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - BEVEL");

            }
            else if (BenchmarkType == 1) // TextMeshPro�� ����
            {
                m_textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();  // TextMeshProUGUI�� ����

                if (TMProFont != null)
                {
                    m_textMeshPro.font = TMProFont;  // �ؽ�Ʈ�� Font ����
                }

                m_textMeshPro.fontSize = 48;
                m_textMeshPro.alignment = TextAlignmentOptions.Center;
            }

            // 1000000���� �ݺ��ϸ鼭 �ؽ�Ʈ ����
            for (int i = 0; i <= 1000000; i++)
            {
                if (BenchmarkType == 0)
                {
                    m_textMeshPro.text = label01 + (i % 1000);
                    if (i % 1000 == 999)
                        m_textMeshPro.fontSharedMaterial = m_textMeshPro.fontSharedMaterial == m_material01 ? m_material02 : m_material01;
                }
                yield return null;
            }

            yield return null;
        }
    }
}
