using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class GameUIManager : MonoBehaviour
{
    private TemplateContainer healthElement;
    private int uiVersion = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnUIReload);
    }

    // Update is called once per frame
    private void Update()
    { }

    private void OnUIReload(PanelRenderer renderer, VisualElement rootElement, int version)
    {
        if (uiVersion == version) return;

        uiVersion = version;
        healthElement = rootElement.Q<TemplateContainer>("Health");
    }
}
