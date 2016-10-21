using UnityEngine;
using System.Collections;

public class TourellesManager : MonoBehaviour {

    public HackersManager hackersManager;
    public ArrayList tourellesList = new ArrayList();

    // Use this for initialization
    void Start () {
        hackersManager = FindObjectOfType<HackersManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addTourelle(Tourelle _t1)
    {
        tourellesList.Add(_t1);
    }
}
