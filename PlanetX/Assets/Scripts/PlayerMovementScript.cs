

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlanetName
{ 
    Mars,Jupiter,Moon
}

public class PlayerMovementScript : MonoBehaviour
{
   
    public float jumpValue;
    private bool isGround;
    public float radius;
    public Vector2 offset;
    public LayerMask planetLayer;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator anim;
    private bool isRun = true;
    public PlanetName planetName;
    public Text collText;
    int collectCount;
    private AudioScript Audio;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Audio = FindObjectOfType<AudioScript>();
        collectCount = PlayerPrefs.GetInt("RocketCount");
    }

    void Update()
    {
        Move();
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -1.3f, 1.3f), transform.position.y);
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + offset,radius,planetLayer);
        if(isGround && Input.GetKeyDown(KeyCode.Space))
        {
            Audio.ad[2].Play();
           rb.velocity = Vector2.up * jumpValue;
        }
       
        anim.SetBool("CanRun", isRun);
        anim.SetBool("CanJump",isGround);
        collText.text = collectCount.ToString();

        
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed,rb.velocity.y);
        if(x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (x > 0)
        {
            transform.rotation = Quaternion.identity;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag ==  "Obstacle")
        {
            switch (planetName)
            {
                case PlanetName.Mars:
                    SceneManager.LoadScene(6);
                    break;
                case PlanetName.Jupiter:
                    SceneManager.LoadScene(7);
                    break;
                case PlanetName.Moon:
                    SceneManager.LoadScene(5);
                    break;
                default:
                    break;
            }

        }
        if (other.gameObject.tag == "Meteor")
        {
            switch (planetName)
            {
                case PlanetName.Mars:
                    SceneManager.LoadScene(6);
                    break;
                case PlanetName.Jupiter:
                    SceneManager.LoadScene(7);
                    break;
                case PlanetName.Moon:
                    SceneManager.LoadScene(5);
                    break;
                default:
                    break;
            }
            //if (planetName == PlanetName.Mars)
            //{
            //    SceneManager.LoadScene(6);
            //}
            //if (planetName == PlanetName.Jupiter)
            //{
            //    SceneManager.LoadScene(7);
            //}
            //if (planetName == PlanetName.Moon)
            //{
            //    SceneManager.LoadScene(5);
            //}
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Rocket")
        {
            collectCount++;
            PlayerPrefs.SetInt("RocketCount", collectCount);
            Audio.ad[1].Play();
            Destroy(other.gameObject);
        }
      
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + offset, radius);
    }

}
