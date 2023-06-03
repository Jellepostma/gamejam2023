using UnityEngine;

public class Target : MonoBehaviour
{
    public BalloonManager balloonManager;
    
    public Scorable scorable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balloon"))
        {
            var weapon = other.GetComponent<Weapon>();
            var playerId = weapon.OwnerId;
            scorable.Score(playerId);

            weapon.Pop();
            balloonManager.DecreaseBalloons();
            Destroy(gameObject);
        }
    }
}
