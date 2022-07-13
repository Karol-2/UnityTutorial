using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage //dziedziczy damage po enemydamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

#pragma warning disable CS0108 // Sk³adowa ukrywa dziedziczon¹ sk³adow¹; brak s³owa kluczowego new
    private void OnTriggerEnter2D(Collider2D collision)
#pragma warning restore CS0108 // Sk³adowa ukrywa dziedziczon¹ sk³adow¹; brak s³owa kluczowego new
    {
        base.OnTriggerEnter2D(collision);//execute logic from parent script first
        gameObject.SetActive(false);// jak udezy jakikolwiek objects, znika
    }
}
