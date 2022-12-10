using UnityEngine;

public class GroundSlam : MonoBehaviour {
    [SerializeField] public float duration;

    public int damage = 40;
    private float timer;
    private Vector3 scale = new Vector3(5, 5, 5);

    private void OnEnable() {
        timer = duration;
        
    }

    private void Update() {
        if (gameObject.activeSelf && timer > 0) {
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, 20f * Time.deltaTime);
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            
        }
        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
            enemy.PauseMovement();
        }
    }
}