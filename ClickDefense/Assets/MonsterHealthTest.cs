using UnityEngine;

public sealed class MonsterHealthTest : MonoBehaviour
{
    [SerializeField] private MonsterHealth health;

    private void Awake()
    {
        if (health == null)
            health = GetComponent<MonsterHealth>();

        health.Died += OnDied;

        health.Initialize(10);
    }

    private void Update()
    {
        health.TakeDamage(3);
    }

    private void OnDied(MonsterHealth h, Vector3 pos)
    {
        Debug.Log($"[TEST] Monster died callback received at {pos}");
    }
}
