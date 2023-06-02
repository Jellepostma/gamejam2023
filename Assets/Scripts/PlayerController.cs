using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 0;
    public float pumpThreshold = 3f;
    public Transform direction;

    private List<Joycon> joycons;

    //private float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public Quaternion orientation;
    public float offset = 90f;

    public GameObject pump;

    private SkinnedMeshRenderer skinnedMeshRenderer;

    Joycon joycon;

    void Start()
    {
        gyro = accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;

        if (joycons.Count > 0)
        {
            joycon = joycons[playerNumber];
        }

        skinnedMeshRenderer = pump.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        accel = joycon.GetAccel();
        direction.rotation = joycon.GetVector();
        offset = -direction.forward.z;

        skinnedMeshRenderer.SetBlendShapeWeight(0, Mathf.Clamp(-direction.forward.z * 300f, 0f, 100f));

        /*if (joycon.GetButton(Joycon.Button.SHOULDER_2))
        {
            if (accel.magnitude > pumpThreshold)
            {
                
            }
        }*/
    }
}