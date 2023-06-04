using UnityEngine;

public class Target : MonoBehaviour
{
    public BalloonManager balloonManager;
    public SkinnedMeshRenderer meshRenderer;
    
    public Scorable scorable;

    private int health = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balloon"))
        {
            var weapon = other.GetComponent<Weapon>();

            health -= weapon.damage;
            meshRenderer.SetBlendShapeWeight(0, health < 0 ? 0 : health);

            if (health <= 0)
            {
                var playerId = weapon.OwnerId;
                scorable.Score(playerId);
                
                balloonManager.DecreaseBalloons();
                weapon.Pop();
                Destroy(gameObject);
            }
            
            weapon.Pop();
        }
    }
}
