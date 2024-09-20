using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playermaxHealth=10;
    private float playercurrentHealth;
    public int EnemyDamage = 1;
    public int Healing = 5;
    public HealthBar healthbar;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        playercurrentHealth = playermaxHealth;
        healthbar.UpdateHealthBar(playermaxHealth, playercurrentHealth);
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tr.position.y == -10)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("RestartMenu");
        }
        if (playercurrentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("RestartMenu");
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            TakeDamage(EnemyDamage);            
        }
        if (collision.gameObject.CompareTag("HealthOrb"))
        {
            Heal(Healing);
            Destroy(collision.gameObject);
        }
    }
    
    void TakeDamage(int amount)
    {
        playercurrentHealth -= amount;
        healthbar.UpdateHealthBar(playermaxHealth, playercurrentHealth);
    }
    void Heal(int amount)
    {
        playercurrentHealth += amount;
        healthbar.UpdateHealthBar(playermaxHealth, playercurrentHealth);
        Mathf.Min(playercurrentHealth, playermaxHealth);
    }
}
