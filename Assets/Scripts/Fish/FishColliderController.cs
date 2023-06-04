
using UnityEngine;

public class FishColliderController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            Destroy(other.gameObject);
        }
    }
}
