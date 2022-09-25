
using UnityEngine;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
     public GameObject actualPlanet;
     public float rotateSpeed;
     public GameObject obsPrefab;
     public Transform circleEdge;
     public Text scoreText;
     private float scoreCount;
     public Text highScoreText;
     private int highScoreCount;
     float angle;
     public GameObject rocketCol;
     public Transform rocSpawnPoint;
   
     void Start()
     {
        Time.timeScale = 1;
        highScoreCount = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore");
        InvokeRepeating("SpawnObstacle", 2f, 15f);
        InvokeRepeating("ChangeDir", 10f, 20f);
        InvokeRepeating("RocketSpawn", 2f,15f);
     }
    private void Update()
    {
        ScoreIncrement();

    }
    private void FixedUpdate()
    {
        RotatePlanet(rotateSpeed);
    }
    private void ScoreIncrement()
    {
        scoreCount += Time.deltaTime * 5;
        scoreText.text = "Score: " + (int)scoreCount;
        if(scoreCount > highScoreCount)
        {
            highScoreCount = (int)scoreCount;
            PlayerPrefs.SetInt("HighScore", (int)highScoreCount);
        }
        
    }

    private void RotatePlanet(float rotateSpeed)
    {
        actualPlanet.transform.Rotate(0, 0, rotateSpeed);
    }
    void SpawnObstacle()
    {
            Vector2 rpoc = RandomPointOnCircle(CalculateRadius());
            rpoc += (Vector2)actualPlanet.transform.position;
            GameObject tempObs = Instantiate(obsPrefab, rpoc, Quaternion.identity);
            tempObs.transform.SetParent(actualPlanet.transform);
            Destroy(tempObs, 12f);
    }
    public Vector2 RandomPointOnCircle(float radius)
    {
         angle = Random.Range(30f, 300f);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        return new Vector2(x, y);
    }

    float CalculateRadius()
    {
        float radius = Vector2.Distance(actualPlanet.transform.position, circleEdge.position);
        return radius;
    }
    void ChangeDir()
    {
        rotateSpeed = -rotateSpeed;
       
    }
    void RocketSpawn()
    {
       
        GameObject tempRocket = Instantiate(rocketCol, rocSpawnPoint.position, rocketCol.transform.rotation);
        tempRocket.transform.SetParent(actualPlanet.transform);
        Destroy(tempRocket, 15f);
    }
}
