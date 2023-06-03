using UnityEngine;

public class Target : MonoBehaviour
{

    public Scorable scorable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balloon"))
        {
            var balloon = other.GetComponent<Balloon>();
            var playerId = balloon.OwnerId;
            scorable.Score(playerId);

            balloon.Pop();
            Destroy(gameObject);
        }
    }
}
