using UnityEngine;

[CreateAssetMenu(menuName = "Clicker/UpgradeDef")]
public sealed class UpgradeDef : ScriptableObject
{
    public string id;          // 고유키
    public string displayName; // 표시용
    public int cost = 10;      // 고정 가격
    public int addAttack = 1;  // 고정 증가량
}
