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
    [SerializeField] public float slamLength;
    public float slamTimer;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;

    public Camera cam;
    public Unlocks unlocks;
    public Animator animator;
    public HealthBar healthbar;
    public Sprite deadSprite;

    [Space]
    [Header("Player Stats:")]
    [SerializeField] private float playerSpeed;

    public int health;
    public int maxHealth = 100;

    private Vector2 movement;
    private Vector2 mousePos;
    private bool dead;

    public bool animated = false;

    #endregion variables

    private void Start() {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        dead = false;
    }

    // Update is called once per frame
    private void Update() {

        #region General

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        #endregion General

        #region Movement

        if (!(playerSlam.activeSelf || dead)) {
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
            animator.SetTrigger("Slash");
            animated = true;
        }

        #endregion Melee Attack

        #region Ability 1 / Fireball

        if ((bool)unlocks.unlocks[0] && fireballTimer <= 0 && Input.GetButtonDown("Fire2")) {
            animator.SetTrigger("Fireball");
            animated = true;
            fireballTimer = fireballLength;
        }
        if (fireballTimer > 0) {
            fireballTimer -= Time.deltaTime;
        }

        #endregion Ability 1 / Fireball

        #region Ground Slam

        if ((bool)unlocks.unlocks[1] && slamTimer <= 0 && Input.GetButtonDown("Fire3")) {
            animator.SetTrigger("Slam");
            animated = true;
            slamTimer = slamLength;
        }
        if (slamTimer > 0) {
            slamTimer -= Time.deltaTime;
        }

        #endregion Ground Slam
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        attackFollow.position = rb.position;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        attackFollow.rotation = angle;

        #region Look Direction

        if (animated) {
            if (lookDir.x >= 0) {
                transform.localScale = Vector3.one;
            }
            else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (movement.x < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        else { transform.localScale = Vector3.one; }

        #endregion Look Direction

        
    }

    #region Taking Damage

    public void TakeDamage(int damage) {
        health -= damage;
        animator.SetTrigger("Hit");
        healthbar.SetHealth(health);

        if (health <= 0) {
            animator.SetTrigger("Death");
            dead = true;
        }
    }

    #endregion Taking Damage

    #region Death

    public void Death() {
        animator.enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = deadSprite;
    }

    #endregion Death

    #region Spawn Slam

    public void SpawnSlam() {
        playerSlam.SetActive(true);
    }

    #endregion Spawn Slam

    #region Spawn Fireball

    public void SpawnFireball() {
        GameObject fireball = Instantiate(playerFireball, attackPoint.position, attackPoint.rotation);
        Rigidbody2D fireballRB = fireball.GetComponent<Rigidbody2D>();
        fireballRB.AddForce(attackPoint.right * fireballSpeed, ForceMode2D.Impulse);
        fireballTimer = fireballLength;
    }

    #endregion Spawn Fireball

    #region End Of Animation
    public void EndOfAnimation() {
        animated = false;
    }
    #endregion
}