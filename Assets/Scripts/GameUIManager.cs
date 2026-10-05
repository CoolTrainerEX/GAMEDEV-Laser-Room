using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class GameUIManager : MonoBehaviour
{
    [SerializeField] private UISettings settings;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerStats playerStats;

    private PanelRenderer panelRenderer;
    private VisualElement healthElement;
    private int uiVersion = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelRenderer = GetComponent<PanelRenderer>();

        panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    void OnDestroy()
    {
        panelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthElement != null) healthElement.style.width = Length.Percent(Mathf.MoveTowards(healthElement.style.width.value.value, playerStats.Health / playerSettings.maxHealth * 100, settings.transitionSpeed * Time.deltaTime));
    }

    private void OnUIReload(PanelRenderer renderer, VisualElement rootElement, int version)
    {
        if (uiVersion == version) return;

        uiVersion = version;
        healthElement = rootElement.Q<VisualElement>("Health");
    }
}
