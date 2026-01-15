using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class UpgradeRequestor : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text costText;

    private UpgradeDef def;

    public void Bind(UpgradeDef upgradeDef, bool canBuy)
    {
        def = upgradeDef;

        if (titleText != null)
            titleText.text = $"{def.displayName}  (+{def.addAttack} ATK)";

        if (costText != null)
            costText.text = $"Cost: {def.cost:n0}";

        if (button != null)
            button.interactable = canBuy;
    }

    private void Awake()
    {
        if (button == null) button = GetComponent<Button>();
        if (button != null) button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (def == null) return;
        GameSignals.RaiseUpgradeRequested(def.id);
    }
}
