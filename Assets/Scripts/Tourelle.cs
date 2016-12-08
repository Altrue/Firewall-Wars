using UnityEngine;
using System.Collections;

public class Tourelle : MonoBehaviour {

    TourellesManager tourellesManager;
    LineRenderer line;
    Ennemi closest;
    float distanceClosest;
    public float attackRange;
    public float dps;
    public float targetSpeedMultiplier;
    public Light lightTourelle;
    public int cost;

    private bool isPaused;

    // Use this for initialization
    void Start () {
        line = gameObject.GetComponent<LineRenderer>();

        tourellesManager = FindObjectOfType<TourellesManager>();
        transform.SetParent(tourellesManager.gameObject.transform, false); // Luc, je suis ton père
        tourellesManager.addTourelle(this);

        line.enabled = false;
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isPaused)
        {
            if (tourellesManager.hackersManager.countEnnemis() == 0)
            {
                line.enabled = false;
            }
            fireOnClosest();
        }
	}

    public void setPosition(float _x, float _y, float _z)
    {
        transform.localPosition = new Vector3(_x, _y, _z);
    }

    private void fireOnClosest()
    {
        // We have a closest target, we fire on it
        if (closest)
        {
            distanceClosest = Vector3.Distance(closest.transform.position, transform.position);
            // We fire on the current closest target
            if (distanceClosest < attackRange && !closest.isDead)
            {
                line.enabled = true;
                tourellesManager.hackersManager.damageEnnemi(closest, dps * Time.deltaTime, targetSpeedMultiplier);

                var heading = closest.transform.position - lightTourelle.transform.position;
                Ray ray = new Ray(lightTourelle.transform.position, heading);

                line.SetPosition(0, ray.origin);
                line.SetPosition(1, ray.GetPoint(distanceClosest));
            }
            // Closest target is out of range, unsetting closest
            else
            {
                line.enabled = false;
                closest = null;
            }
        }

        // We don't have a closest target, we find one to fire on it
        if (!closest)
        {
            closest = tourellesManager.hackersManager.closestEnnemi(transform.position, this);
            // We fire on the new closest target
            if (closest)
            {
                distanceClosest = Vector3.Distance(closest.transform.position, transform.position);
                if (distanceClosest < attackRange)
                {
                    line.enabled = true;
                    tourellesManager.hackersManager.damageEnnemi(closest, dps * Time.deltaTime, targetSpeedMultiplier);

                    var heading = closest.transform.position - lightTourelle.transform.position;
                    Ray ray = new Ray(lightTourelle.transform.position, heading);

                    line.SetPosition(0, ray.origin);
                    line.SetPosition(1, ray.GetPoint(distanceClosest));
                }
                // New closest target is still too far
                else
                {
                    line.enabled = false;
                }
            }
        }
        
    }

    public void startPause()
    {
        if (!isPaused)
        {
            isPaused = true;
        }
    }

    public void stopPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
    }

}
