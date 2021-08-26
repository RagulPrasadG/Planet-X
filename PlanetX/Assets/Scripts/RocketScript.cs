
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45 * speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
