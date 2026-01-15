using System;

public static class GameSignals
{
    // UI / Input → Gameplay
    public static event Action Clicked;
    public static void RaiseClicked() => Clicked?.Invoke();

    //Upgrade
    public static event Action<string> UpgradeRequested; // upgradeId
    public static void RaiseUpgradeRequested(string upgradeId) => UpgradeRequested?.Invoke(upgradeId);

        public static event Action UpgradeComplete;
        public static void RaiseUpgradeComplete() => UpgradeComplete?.Invoke();

}