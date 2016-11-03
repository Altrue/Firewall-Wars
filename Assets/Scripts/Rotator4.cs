using UnityEngine;
using System.Collections;

public class Rotator4 : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 15, 45) * Time.deltaTime);
    }
}
