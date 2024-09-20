using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemymaxHealth = 10;
    private float enemycurrentHealth;
    public int BulletDamage = 5;
    public HealthBar healthbar;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        enemycurrentHealth = enemymaxHealth;
        healthbar.UpdateHealthBar(enemymaxHealth, enemycurrentHealth);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y == -10)
        {
            Die();
        }

        if (enemycurrentHealth <= 0)
        {
            anim.SetBool("Death", true);
            Invoke("Die", 1);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(BulletDamage);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        enemycurrentHealth -= amount;
        healthbar.UpdateHealthBar(enemymaxHealth, enemycurrentHealth);
    }
}
