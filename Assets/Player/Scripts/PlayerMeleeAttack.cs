using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] public float duration;
    private float timer;

    void Start()
    {
       
    }
    private void OnEnable()
    {
        timer = duration;
    }
    private void Update()
    {
        if (gameObject.activeSelf && duration > 0)
        {
            duration -= Time.deltaTime;
        }
        if (duration <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
