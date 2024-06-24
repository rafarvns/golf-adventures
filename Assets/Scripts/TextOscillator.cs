using UnityEngine;
using TMPro;

public class OutlineOscillator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float minThickness = 0.000f;
    public float maxThickness = 0.0079f;
    public float oscillationSpeed = 1.0f;

    private Material textMaterial;

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
        textMaterial = textMeshPro.fontMaterial;
    }

    void Update()
    {
        float thickness = Mathf.Lerp(minThickness, maxThickness, (Mathf.Sin(Time.time * oscillationSpeed) + 1) / 2);
        textMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, thickness);
    }
}
