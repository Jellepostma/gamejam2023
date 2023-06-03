using UnityEngine;

public class Target : MonoBehaviour
{

    public Scorable scorable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balloon"))
        {
            Destroy(gameObject);
            
            var playerId = other.GetComponent<Balloon>().OwnerId;
            scorable.Score(playerId);
        }
    }
}
