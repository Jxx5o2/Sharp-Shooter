using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int StartingHealth = 3;
    int currenthealth;

    void Awake()
    {
        currenthealth = StartingHealth;
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;

        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
