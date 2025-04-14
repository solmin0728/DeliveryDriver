using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
    public class Benchmark01_UGUI : MonoBehaviour
    {
        public int BenchmarkType = 0;

        public Canvas canvas;
        public TMP_FontAsset TMProFont;
        public Font TextMeshFont;  // 여전히 UI Text font는 필요할 수 있지만 TextMeshPro는 TMP_FontAsset 사용!

        private TextMeshProUGUI m_textMeshPro;  // TextMeshProUGUI로 수정
        // private TextContainer m_textContainer;
        // private Text m_textMesh;  // 이 부분을 사용하지 않음

        private const string label01 = "The <#0050FF>count is: </color>";
        private const string label02 = "The <color=#0050FF>count is: </color>";

        private Material m_material01;
        private Material m_material02;

        IEnumerator Start()
        {
            if (BenchmarkType == 0) // TextMesh Pro Component
            {
                m_textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();  // TextMeshProUGUI 컴포넌트 추가

                if (TMProFont != null)
                    m_textMeshPro.font = TMProFont;

                m_textMeshPro.fontSize = 48;
                m_textMeshPro.alignment = TextAlignmentOptions.Center;
                m_textMeshPro.extraPadding = true;

                m_material01 = m_textMeshPro.font.material;
                m_material02 = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - BEVEL");

            }
            else if (BenchmarkType == 1) // TextMeshPro로 변경
            {
                m_textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();  // TextMeshProUGUI로 변경

                if (TMProFont != null)
                {
                    m_textMeshPro.font = TMProFont;  // 텍스트에 Font 설정
                }

                m_textMeshPro.fontSize = 48;
                m_textMeshPro.alignment = TextAlignmentOptions.Center;
            }

            // 1000000까지 반복하면서 텍스트 변경
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
