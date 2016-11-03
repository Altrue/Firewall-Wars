using UnityEngine;
using System.Collections;

public class Rotator3 : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 45, 15) * Time.deltaTime);
    }
}
