using UnityEngine;

public class GroundSlam : MonoBehaviour {
    [SerializeField] public float duration;

    public int damage = 40;
    private float timer;
    private Vector3 scale = new Vector3(5, 5, 5);
    //set timer for duration length
    private void OnEnable() {
        timer = duration;
    }

    private void Update() {
        //update timer for lifetime of slam and scale size
        if (gameObject.activeSelf && timer > 0) {
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, 20f * Time.deltaTime);
            timer -= Time.deltaTime;
        }
        //reset scale and deactivate slam
        if (timer <= 0) {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            
        }
        //make sure slam doesn't rotate
        transform.rotation = Quaternion.identity;
    }

    //deal damage when it contacts enemy and pause their movement
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
            enemy.PauseMovement();
        }
    }
}