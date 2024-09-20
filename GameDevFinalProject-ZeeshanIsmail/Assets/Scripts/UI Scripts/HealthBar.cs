using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbarSprite;
    public float reducespeed;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    public void UpdateHealthBar(float MaxHealth, float CurrentHealth)
    {
        healthbarSprite.fillAmount = CurrentHealth / MaxHealth;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
