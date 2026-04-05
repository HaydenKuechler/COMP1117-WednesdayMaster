using UnityEngine;

public class Audiomanager : MonoBehaviour
{

    public AudioSource audioSource;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
   

