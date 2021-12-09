using UnityEngine;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    public GameObject AlienProjectilePrefab;

    public GameManager gm;
    
    public AudioSource audioSource;
    public AudioClip destroySFX;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

	// A function automatically triggerred when another game object with Collider2D component
	// Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Projectile")
        {
            audioSource.PlayOneShot(destroySFX);
            gm.addScore(50);
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }
    }

    public void ShootPlayer()
    {
        Instantiate(AlienProjectilePrefab, gameObject.transform.position, Quaternion.identity);
    }


}
