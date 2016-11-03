using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ennemi : MonoBehaviour {

    private ArrayList coordinates = new ArrayList();
    public float speed;
    public float maxHp;
    public int rotateSpeed;
    public Text coordinatesCountText;
    public Text coordinatesTargetText;
    public Text coordinatesPosText;
    public Text hpText;
    public Rigidbody rigidbody;
    public Collider collider;
    public GameObject HpBar;
    public GameObject hideWhenDead1;
    public GameObject hideWhenDead2;
    public GameObject hideWhenDead3;
    public GameObject hideWhenDead4;

    private HackersManager hackersManager;
    private int pathPosition;
    private int coordinatesCount;
    private Vector3 nextTargetPosition;
    public bool isDead;
    private float hp;
    private float deathTime = 0.0f;
    private float despawnTime = 2f;
    private float timeOffset;
    private bool rotationDisabled;

    // Use this for initialization
    void Start () {
        hackersManager = FindObjectOfType<HackersManager>();
        transform.SetParent(hackersManager.gameObject.transform, false); // Luc, je suis ton père

        timeOffset = Random.Range(0f, 100f);

        isDead = false;
        pathPosition = 0;
        hp = maxHp;
        //hpText.text = "HP : " + hp.ToString("N2") + "/100";
        coordinates = hackersManager.coordinates;
        coordinatesCount = coordinates.Count;
        //coordinatesCountText.text = "CoordinatesCount : " + coordinatesCount.ToString();
        transform.localPosition = (Vector3) coordinates[pathPosition]; // Spawn à la première coordonnée
        pathPosition++;

        setNextTargetPosition();

        hackersManager.addEnnemi(this);
    }

    public void disableRotation()
    {
        rotationDisabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //coordinatesTargetText.text = "Target: " + nextTargetPosition.x.ToString() + ", " + nextTargetPosition.y.ToString() + ", " + nextTargetPosition.z.ToString();
        //coordinatesPosText.text = "POS: " + transform.localPosition.x.ToString() + ", " + transform.localPosition.y.ToString() + ", " + transform.localPosition.z.ToString();
        //hpText.text = "HP : " + hp.ToString("N2") + "/100";

        if (!isDead) {
            HpBar.transform.localScale = new Vector3(0.1f, hp / (maxHp * 2), 0.1f);
            transform.localPosition = movePosition();
            if (transform.localPosition.x == nextTargetPosition.x && transform.localPosition.z == nextTargetPosition.z)
            {
                setNextTargetPosition();
            }
        }
        else
        {
            if (Time.time > despawnTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    Vector3 movePosition()
    {
        float x;
        float z;
        float y;
        float effectiveSpeed = speed;

        if ((transform.localPosition.x != nextTargetPosition.x) && (transform.localPosition.z != nextTargetPosition.z))
        {
            effectiveSpeed = speed * 0.7f;
        }


        // X Coord
        if (transform.localPosition.x < nextTargetPosition.x)
        {
            x = System.Math.Min(transform.localPosition.x + effectiveSpeed * Time.deltaTime, nextTargetPosition.x);
        }
        else if (transform.localPosition.x > nextTargetPosition.x)
        {
            x = System.Math.Max(transform.localPosition.x - effectiveSpeed * Time.deltaTime, nextTargetPosition.x);
        }
        else
        {
            x = nextTargetPosition.x;
        }

        // Z Coord
        if (transform.localPosition.z < nextTargetPosition.z)
        {
            z = System.Math.Min(transform.localPosition.z + effectiveSpeed * Time.deltaTime, nextTargetPosition.z);
        }
        else if (transform.localPosition.z > nextTargetPosition.z)
        {
            z = System.Math.Max(transform.localPosition.z - effectiveSpeed * Time.deltaTime, nextTargetPosition.z);
        }
        else
        {
            z = nextTargetPosition.z;
        }

        // Y Coord
        float time = Time.fixedTime * 3f + timeOffset;
        y = ((float)System.Math.Sin(time) + 1f) * 0.1f + 0.5f;

        if (!rotationDisabled)
        {
            setOrientation(x - transform.localPosition.x, z - transform.localPosition.z);
        }

        return new Vector3(x, y, z);
    }
    
    void setOrientation(float _x, float _z)
    {
        if (_x != 0 || _z != 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(_x, 0, _z)), Time.deltaTime * rotateSpeed);
        }
    }
    
    void setNextTargetPosition()
    {
        if (pathPosition >= coordinatesCount)
        {
            die();
        }
        else
        {
            nextTargetPosition = (Vector3)coordinates[pathPosition];
            pathPosition++;
        }
    }

    private void die()
    {
        hackersManager.removeEnnemi(this);
        isDead = true;
        //hpText.text = "HP : 0/100";
        HpBar.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        rigidbody.useGravity = true;
        collider.enabled = true;
        deathTime = Time.time;
        despawnTime += deathTime;
        hideWhenDead1.SetActive(false);
        hideWhenDead2.SetActive(false);
        hideWhenDead3.SetActive(false);
        hideWhenDead4.SetActive(false);

        Vector3 movement = new Vector3(0.0f, 100f, 10.0f);
        Vector3 position = new Vector3(1f, 0.0f, 0.0f);
        rigidbody.AddForceAtPosition(position.normalized, movement);

        // Inertie de l'objet simulée
        rigidbody.AddRelativeForce(Vector3.forward * 50);
        // On pousse l'objet sur le côté
        if (UnityEngine.Random.Range(0, 2) > 0)
        {
            rigidbody.AddRelativeForce(Vector3.left * 25);
        }
        else
        {
            rigidbody.AddRelativeForce(Vector3.right * 25);
        }
    }

    public void takeDamage(float _dmg)
    {
        hp = hp - _dmg;
        if (hp < 0)
        {
            die();
        }
    }
}
