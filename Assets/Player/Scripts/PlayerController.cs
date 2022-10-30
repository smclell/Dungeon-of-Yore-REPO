using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] public GameObject playerMeleeAttack;
    [SerializeField] public Rigidbody2D attackFollow;
    [SerializeField] public Transform attackPoint;

    [SerializeField] public GameObject playerFireball;
    [SerializeField] public float fireballLength;
    public float fireballTimer;
    [SerializeField] public float fireballSpeed = 10f;

    public Rigidbody2D rb;
    public Camera cam;
    public Unlocks unlocks;

    public int health = 100;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        #region General

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        #endregion

        #region Movement

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        #endregion

        #region Melee Attack

        if (Input.GetButtonDown("Fire1") && !playerMeleeAttack.activeSelf)
        {
            playerMeleeAttack.SetActive(true);
        }
        #endregion

        #region Ability 1 / Fireball

        if ((bool)unlocks.unlocks[0] && fireballTimer <= 0 && Input.GetButtonDown("Fire2"))
        {
            GameObject fireball = Instantiate(playerFireball, attackPoint.position, attackPoint.rotation);
            Rigidbody2D fireballRB = fireball.GetComponent<Rigidbody2D>();
            fireballRB.AddForce(attackPoint.right * fireballSpeed, ForceMode2D.Impulse);
            fireballTimer = fireballLength;
        }

        #endregion

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        attackFollow.position = rb.position;

        if (!playerMeleeAttack.activeSelf)
        {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            attackFollow.rotation = angle;
        }

        if ((bool)unlocks.unlocks[0])
        {
            fireballTimer -= Time.fixedDeltaTime;
        }
    }

    #region Taking Damage

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Dead");
        }
    }

    #endregion
}
