using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    
    public GameObject balloon;

    public GameObject spawn;

    public int balloonsAmount;

    private int _balloonsCurrentAmount;

    private void Awake()
    {
        _balloonsCurrentAmount = balloonsAmount;
        var position = spawn.transform.position;
        
        for (var index = 0; index < balloonsAmount; index++)
        {
            var prefab = Instantiate(balloon).GetComponent<Target>();
            prefab.balloonManager = this;
            prefab.transform.position = new Vector3(
                position.x + Random.Range(-3, 3),
                position.y + Random.Range(0, 6),
                0
            );
            prefab.transform.localScale = Vector3.one * Random.Range(10, 26);
        }
    }

    public void DecreaseBalloons()
    {
        _balloonsCurrentAmount--;

        if (_balloonsCurrentAmount <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
