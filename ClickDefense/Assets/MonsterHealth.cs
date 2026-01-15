using System;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHP = 10;
    [SerializeField] private int currentHP = 10;

    public event Action<MonsterHealth, Vector3> Died;



    //몬스터 죽고 체력 업할 때 쓸 함수
    public void Initialize(int newMaxHP)
    {
        maxHP = Mathf.Max(1, newMaxHP);
        currentHP = maxHP;

        Debug.Log($"[MonsterHealth] Initialized HP = {maxHP}");
    }

    public void TakeDamage(int dmg)
    {
        if (dmg <= 0) return;
        if (currentHP <= 0) return;

        currentHP -= dmg;

        Debug.Log($"[MonsterHealth] Took Damage: {dmg}, HP = {currentHP}/{maxHP}");

        if (currentHP <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log($"[MonsterHealth] DIED at position {transform.position}");

        Died?.Invoke(this, transform.position);

        Destroy(gameObject);
    }
}