using UnityEngine;

public class Target : MonoBehaviour
{
    public BalloonManager balloonManager;
    public SkinnedMeshRenderer meshRenderer;
    
    public Scorable scorable;

    private int health = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon") || other.CompareTag("superweapon"))
        {
            var weapon = other.GetComponent<Weapon>();

            health -= weapon.damage;
            meshRenderer.SetBlendShapeWeight(0, health < 0 ? 100 : 100 - health);

            if (health <= 0)
            {
                var playerId = weapon.OwnerId;
                scorable.Score(playerId);
                
                balloonManager.DecreaseBalloons();
                weapon.Pop();
                Destroy(gameObject);
                return;
            }
            
            weapon.Pop();
        }
    }
}
