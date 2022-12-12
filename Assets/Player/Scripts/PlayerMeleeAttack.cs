using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {
    public int damage = 40;
    [SerializeField] public float duration;
    private float timer;

    private void OnEnable() { // timer for attack duration
        timer = duration;
    }

    //damage if collided with enemy
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
    }
    // update timer and despawn if timer is 0
    private void Update() {
        if (gameObject.activeSelf && timer > 0) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            gameObject.SetActive(false);
        }
    }
}