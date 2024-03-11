using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //TP2 Marques
    public static AudioManager Instance;

    private AudioSource audioSource;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound (AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
