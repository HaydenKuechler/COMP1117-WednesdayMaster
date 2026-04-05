using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public class TestCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Player hit Object");
        }
    }

}
