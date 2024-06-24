using UnityEngine;
using TMPro;

public class TextOscillator : MonoBehaviour
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

        // Garantir que o componente TextMeshProUGUI está atribuído
        if (textMeshPro != null)
        {
            // Clone o material para evitar modificar o material compartilhado
            textMaterial = textMeshPro.fontMaterial;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
        }
    }

    void Update()
    {
        if (textMaterial == null)
        {
            return; // Sai da função Update se textMaterial for nulo
        }

        float thickness = Mathf.Lerp(minThickness, maxThickness, (Mathf.Sin(Time.time * oscillationSpeed) + 1) / 2);
        textMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, thickness);
    }
}
