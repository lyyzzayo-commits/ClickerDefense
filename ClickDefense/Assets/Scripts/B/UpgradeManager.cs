using System.Collections.Generic;
using UnityEngine;

public sealed class UpgradeManager : MonoBehaviour
{
    //[SerializeField] private EconomyManager economy;
    //[SerializeField] private PlayerStats playerStats;
    [SerializeField] private List<UpgradeDef> catalog = new();

    private readonly Dictionary<string, UpgradeDef> byId = new();

    private void Awake()
    {
        //if (economy == null) economy = FindFirstObjectByType<EconomyManager>();
        //if (playerStats == null) playerStats = FindFirstObjectByType<PlayerStats>();

        byId.Clear();
        foreach (var def in catalog)
        {
            if (def == null || string.IsNullOrWhiteSpace(def.id)) continue;
            byId[def.id] = def;
        }
    }

    private void OnEnable()
    {
        GameSignals.UpgradeRequested += OnUpgradeRequested;
    }

    private void OnDisable()
    {
        GameSignals.UpgradeRequested -= OnUpgradeRequested;
    }

    private void OnUpgradeRequested(string upgradeId)
    {
        //if (economy == null || playerStats == null) return;
        if (!byId.TryGetValue(upgradeId, out var def)) return;

        //if (!economy.TrySpend(def.cost)) return;

        //playerStats.AddAttack(def.addAttack);

        // 돈/공격력 바뀌었으니 UI 갱신 신호(필요 시)
        GameSignals.RaiseUpgradeComplete();
    }

    public IReadOnlyList<UpgradeDef> GetCatalog() => catalog;
}
