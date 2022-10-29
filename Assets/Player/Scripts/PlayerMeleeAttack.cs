using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] public float duration;

    public int damage = 40;
    private float timer;

    private void OnEnable()
    {
        timer = duration;
    }
    private void Update()
    {
        if (gameObject.activeSelf && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
