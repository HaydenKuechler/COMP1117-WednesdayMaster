using UnityEngine;
using UnityEngine.Events;

public class Cherry : MonoBehaviour
{
  public UnityEvent onCollected = new UnityEvent();


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onCollected.Invoke();


            GetComponent<Renderer>().material.color = Color.red;
            
            
            Debug.Log("Collected Cherry");
            Destroy(gameObject);

        }
        
    
    }
}

