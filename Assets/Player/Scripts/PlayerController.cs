using UnityEngine;

public class PlayerController : MonoBehaviour {
    #region variables
    [Space]
    [Header("General Attack Items:")]
    [SerializeField] public Rigidbody2D attackFollow;
    [SerializeField] public Transform attackPoint;

    [Space]
    [Header("Melee Attack:")]
    [SerializeField] public GameObject playerMeleeAttack;

    [Space]
    [Header("Fireball Stats:")]
    [SerializeField] public GameObject playerFireball;
    [SerializeField] public float fireballLength;
    public float fireballTimer;
    [SerializeField] public float fireballSpeed = 10f;

    [Space]
    [Header("Ground Slam:")]
    [SerializeField] public GameObject playerSlam;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Camera cam;
    public Unlocks unlocks;
    public Animator animator;

    [Space]
    [Header("Player Stats:")]
    [SerializeField] private float playerSpeed;
    public int health = 100;

    private Vector2 movement;
    private Vector2 mousePos;
    #endregion
    // Update is called once per frame
    private void Update() {

        #region General

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        #endregion General

        #region Movement

        if (!playerSlam.activeSelf) {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }
        else {
            movement.x = 0;
            movement.y = 0;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        #endregion Movement

        #region Melee Attack

        if (Input.GetButtonDown("Fire1") && !playerMeleeAttack.activeSelf) {
            playerMeleeAttack.SetActive(true);
            animator.SetBool("Slash", true);
        }

        #endregion Melee Attack

        #region Ability 1 / Fireball

        if ((bool)unlocks.unlocks[0] && GameObject.Find("Fireball(Clone)") == null && Input.GetButtonDown("Fire2")) {
            GameObject fireball = Instantiate(playerFireball, attackPoint.position, attackPoint.rotation);
            Rigidbody2D fireballRB = fireball.GetComponent<Rigidbody2D>();
            fireballRB.AddForce(attackPoint.right * fireballSpeed, ForceMode2D.Impulse);
            fireballTimer = fireballLength;
        }

        #endregion Ability 1 / Fireball

        #region Ground Slam

        if ((bool)unlocks.unlocks[1] && !playerSlam.activeSelf && Input.GetButtonDown("Fire3")) {
            playerSlam.SetActive(true);
        }

        #endregion Ground Slam
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        if (movement.x < 0) { transform.localScale = new Vector3(-1, 1, 1); } 
        else { transform.localScale = Vector3.one; }

        attackFollow.position = rb.position;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        attackFollow.rotation = angle;
    }

    #region Taking Damage

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Debug.Log("Dead");
        }
    }

    #endregion Taking Damage
}