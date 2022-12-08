using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {
    public int damage = 40;
    [SerializeField] public float duration;
    private float timer;

    private void OnEnable() {
        timer = duration;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
    }

    private void Update() {
        if (gameObject.activeSelf && timer > 0) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            gameObject.SetActive(false);
        }
    }
}