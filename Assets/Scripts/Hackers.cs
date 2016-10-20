using UnityEngine;
using System.Collections;
using FirewallWars;

public class Hackers : MonoBehaviour {

    public ArrayList coordinates = new ArrayList()
    {
        new Vector3(-4, 0, 4),  // Index 0 = Coordonnée de Spawn
        new Vector3(4, 0, 4),
        new Vector3(4, 0, -4),
        new Vector3(-4, 0, -4),
        new Vector3(-4, 0, 2),
        new Vector3(2, 0, 2)
    };

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
