// COMO ADICIONAR ESSE SCRIPT:
// 1 - ARRASTE ELE PARA O OBJETO QUE IRA SOFRER A AÇÃP
// 2 - ABRA O OBJETO QUE IRA SOFRER A AÇÃO E ARRASTE ELE PROPRIO PARA O CAMPO Txt Vitoria



using UnityEngine;
using TMPro;
using System.Collections;

public class VictoryText : MonoBehaviour
{
    public TextMeshProUGUI txtVitoria;
    public float animationDuration = 0.5f;
    public float bounceAmount = 10f; 

    void Start()
    {       
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        TMP_TextInfo textInfo = txtVitoria.textInfo;
        txtVitoria.ForceMeshUpdate();

        Vector3[][] originalVertices = new Vector3[textInfo.meshInfo.Length][];
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            originalVertices[i] = textInfo.meshInfo[i].vertices;
        }

        while (true)
        {
            txtVitoria.ForceMeshUpdate();
            textInfo = txtVitoria.textInfo;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible)
                    continue;

                int materialIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;

                Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                Vector3 offset = new Vector3(0, Mathf.Sin(Time.time * animationDuration + i) * bounceAmount, 0);
                vertices[vertexIndex + 0] += offset;
                vertices[vertexIndex + 1] += offset;
                vertices[vertexIndex + 2] += offset;
                vertices[vertexIndex + 3] += offset;
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                txtVitoria.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }

            yield return null;
        }
    }
}
