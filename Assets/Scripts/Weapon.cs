using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] int damageAmount = 1;
    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Shoot";

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleflash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);

            // if (enemyHealth)
            // {
            //     enemyHealth.TakeDamage(damageAmount);  => enemyHealth?.TakeDamage(damageAmount);랑 동일한 로직
            // }

            starterAssetsInputs.ShootInput(false);
        }

        
    }
}
