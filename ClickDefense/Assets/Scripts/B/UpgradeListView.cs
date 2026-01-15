using System.Collections.Generic;
using UnityEngine;

public sealed class UpgradeListView : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    //[SerializeField] private EconomyManager economy;

    [SerializeField] private RectTransform content;
    [SerializeField] private UpgradeRequestor itemPrefab;

    private readonly List<UpgradeRequestor> items = new();
    private IReadOnlyList<UpgradeDef> defs;

    private void Awake()
    {
        if (upgradeManager == null) upgradeManager = FindFirstObjectByType<UpgradeManager>();
        //if (economy == null) economy = FindFirstObjectByType<EconomyManager>();
    }

    private void Start()
    {
        defs = upgradeManager.GetCatalog();
        Build();
        Refresh();
    }

    private void OnEnable()
    {
        // 돈이 바뀌면 구매 가능 여부만 갱신
        //if (economy != null) economy.Changed += Refresh;

        // 업그레이드 구매 후 UI 갱신(선택)
        GameSignals.UpgradeComplete += Refresh;
    }

    private void OnDisable()
    {
        //if (economy != null) economy.Changed -= Refresh;
        GameSignals.UpgradeComplete -= Refresh;
    }

    private void Build()
    {
        foreach (Transform child in content) Destroy(child.gameObject);
        items.Clear();

        foreach (var def in defs)
        {
            var item = Instantiate(itemPrefab, content);
            items.Add(item);
        }
    }

    private void Refresh()
    {
        //if (defs == null || economy == null) return;

        for (int i = 0; i < items.Count; i++)
        {
            var def = defs[i];
            //bool canBuy = economy.CanAfford(def.cost);
            //items[i].Bind(def, canBuy);
        }
    }
}
