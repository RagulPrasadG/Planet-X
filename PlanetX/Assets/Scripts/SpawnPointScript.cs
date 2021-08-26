
using UnityEngine;


public class SpawnPointScript : MonoBehaviour
{
    public GameObject meteorPrefab;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    private Vector2 _spawnPoint;
    float scount;
    private ParticleSystem pS;
   

    private void Start()
    {
        pS = meteorPrefab.GetComponentInChildren<ParticleSystem>();
        InvokeRepeating("ChangeSpawnPoint", 3f, 3.5f);
    }
    void ChangeSpawnPoint()
    {
        if (scount == 0)
        {
            _spawnPoint = SpawnPoint1.position;
            var ph = pS.shape;
            ph.rotation = new Vector3(0, 20, 0);



        }
        if (scount == 1)
        {
            _spawnPoint = SpawnPoint2.position;
            var ph = pS.shape;
          
            ph.rotation = new Vector3(0, -20, 0);

        }


        AudioScript.instance.ad[0].Play();
        GameObject tempMeteor = Instantiate(meteorPrefab, _spawnPoint,Quaternion.identity);
        transform.position = new Vector2(Random.Range(-15f, 15f), transform.position.y);
        scount = Random.Range( -1, 3);
    }
   


}
