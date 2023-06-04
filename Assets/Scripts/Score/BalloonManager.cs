using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    
    public GameObject balloon;

    public GameObject spawn;

    public Vector2 spawnRangeX;
    public Vector2 spawnRangeY;
    public Vector2 spawnRangeZ;

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
                position.x + Random.Range(spawnRangeX.x, spawnRangeX.y),
                position.y + Random.Range(spawnRangeY.x, spawnRangeY.y),
                position.z + Random.Range(spawnRangeZ.x, spawnRangeZ.y)
            );
            prefab.transform.localScale = Vector3.one * Random.Range(0.6f, 1f);
            prefab.GetComponent<LineRenderer>().SetPosition(0, prefab.transform.position);
            prefab.GetComponent<LineRenderer>().SetPosition(1, transform.position);
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
