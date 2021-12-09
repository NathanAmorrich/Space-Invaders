using UnityEngine;

// This script controls the behaviour of the projectile game object
public class EnnemyProjectileBehaviour : MonoBehaviour
{
    // How fast will the project travel
    public float speed;

    // How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
