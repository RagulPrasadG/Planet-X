
using UnityEngine;


public class MeteorScript : MonoBehaviour
{
      GameObject Planet;
      public Transform endPoint;

    bool canFall = true;
    void Start()
    {
        Planet = GameObject.Find("Planet Base");       
    }
    private void Update()
    {
        if (!canFall) return;


        Fall();
        endPoint = GameObject.Find("EndPoint").transform;
    }
    void Fall()
    {
        transform.position = Vector3.MoveTowards(transform.position,Planet.transform.position, 8f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            canFall = false;
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            gameObject.transform.SetParent(Planet.transform);
            Destroy(gameObject, 5f);
        }

    }
}
