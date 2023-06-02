using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconDemo : MonoBehaviour {
	
	private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
    public float threshold = 3f;
    public Rigidbody rb;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float force = 100f;
    public float gravity = 9.8f;
    public float fillAmount = 1f;
    public float minFill = 1f;
    public float depletionRate = 0.025f;
    public float growRate = 0.025f;

    bool released = false;

    void Start ()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			Destroy(gameObject);
		}
	}

    // Update is called once per frame
    void Update () {
		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];
			

            stick = j.GetStick();

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();

            if(j.GetButtonUp(Joycon.Button.SHOULDER_2))
            {
                released = true;
            }

            if (j.GetButtonUp(Joycon.Button.DPAD_UP))
            {
                Debug.Log("POW");
                rb.AddExplosionForce(10f, gameObject.transform.position + new Vector3(0, -2, 0), 50f);
            }

            if (j.GetButton(Joycon.Button.SHOULDER_2))
            {
                if (accel.magnitude > threshold)
                {
                    fillAmount = Mathf.Max(minFill, fillAmount + growRate * Time.deltaTime);
                }
            }

            skinnedMeshRenderer.SetBlendShapeWeight(0, (minFill - fillAmount) * 100);

            //gameObject.transform.localScale = Vector3.one * fillAmount;

            if (released)
            {
                Deflate();
            }
        }
    }

    private void Deflate()
    {
        if (fillAmount > minFill)
        {
            rb.AddForce(transform.forward * force * (fillAmount - minFill));
        }

        fillAmount = Mathf.Max(minFill, fillAmount - depletionRate * Time.deltaTime);
    }
}