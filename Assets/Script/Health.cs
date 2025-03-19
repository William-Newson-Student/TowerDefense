using UnityEngine;

namespace TowerDefense
{
    
    public class Health : MonoBehaviour
    {

        public int healthAmount = 3;

        public void TakeDamage(int damageAmount)
        {
            healthAmount -= damageAmount;
            if (healthAmount <= 0)
            {
                Debug.Log("Game Over");
            }
        }

        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health targetHealth = target.GetComponent<Health>();

            if (targetHealth)
            {
                targetHealth.TakeDamage(damageAmount);
            }
        }
    }
}