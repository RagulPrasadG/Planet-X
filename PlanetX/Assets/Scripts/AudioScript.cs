
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource[] ad;
    public static AudioScript instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
}
