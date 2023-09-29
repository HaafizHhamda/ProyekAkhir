using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoldierManager : MonoBehaviour
{
    public SoldierCardScriptableObject thisSO;
    public Transform shootPoint;
    public GameObject Bullet;
    public float health;
    public float damage;
    public float range;
    public float speed;
    public LayerMask EnemyLayer;

    public float fireRate;
    public static EnemyManager prefabmusuh;
    public bool ledak ;
    private SlotsManagerCollider newCek;   

    public AudioClip damageAudio;

    public GameObject mineParticles;

    public bool isDragging = true;
    Animator animation;
    
    private void Start()
    {
        health = thisSO.health;
        damage = thisSO.damage;
        range = thisSO.range;
        speed = thisSO.speed;
        Bullet = thisSO.Bullet;
        EnemyLayer = thisSO.EnemyLayer;
        fireRate = thisSO.fireRate;
        ledak = thisSO.ledak;
        prefabmusuh = GetComponent<EnemyManager>();

        //animation = GetComponent<Animator>();
        transform.gameObject.tag = "soldier";
        animation = GetComponent<Animator>();
        StartCoroutine(Attack());
      
    }

    private void Update()
    {
        SoldierDie();
    }
    public void SoldierDie()
    {
        if (health <= 0)
        {
            newCek = transform.gameObject.GetComponentInParent<SlotsManagerCollider>();
            newCek.isOccupied = false;
            newCek.plant = null;
            Debug.Log("qqqq");
            Destroy(this.gameObject, 0.3f);
            
        }
    }
    public IEnumerator colordie()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        yield return new WaitForSeconds(1);

    }
    public IEnumerator Attack()
    {
        Debug.Log("Attacking... Plants " + this.gameObject.name);
        yield return new WaitUntil(() => !isDragging);

        if (!ledak)
        {
            animation.enabled = false;
            yield return new WaitForSeconds(fireRate);
            if (speed > 0)
            {
                
                RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, shootPoint.right, range, EnemyLayer);

                Debug.DrawRay(shootPoint.position, shootPoint.right, Color.red);

                if (hit)
                {
                    Debug.Log("Attacking Info plant name : " + this.gameObject.name + ", gameObject name : " + hit.collider.name + ", tag : " + hit.collider.tag);

                    if (hit.transform.tag == "Zombie")
                    {
                        Debug.Log("Hit zombie");
                        GameObject bullet = Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);
                       
                        
                        bullet.GetComponent<PeaManager>().damage = damage;
                        Debug.Log(damage);
                   
                        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
                    }
                }
                StartCoroutine(Attack());
            }
        }
        else if (ledak)
        {

            yield return new WaitForSeconds(fireRate);
            if (speed > 0)
            { 
                RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, shootPoint.right, range, EnemyLayer);
                
                Debug.Log(hit);
                Debug.DrawLine(shootPoint.position, shootPoint.right, Color.red);

                if (hit)
                {

                    animation.enabled= true;
                    Debug.Log("Attacking Info plant name : " + this.gameObject.name + ", gameObject name : " + hit.collider.name + ", tag : " + hit.collider.tag);
                    animation.SetBool("animateactive", true);
                    if (hit.transform.tag == "Zombie")
                    {
                        Debug.Log("Hit zombie");
                        GameObject bullet = Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);


                        bullet.GetComponent<PeaManager>().damage = damage;
                        //var x = Mathf.MoveTowards(transform.position.x,y, speed * Time.deltaTime);
                        bullet.GetComponent<Rigidbody2D>().velocity= 2.5f*(transform.right+transform.up)*speed;
                        Debug.Log(bullet.transform.up);
                        Debug.DrawLine(bullet.GetComponent<Rigidbody2D>().position, transform.right + transform.up, Color.blue);
                    } 
                }
                //else
                //{
                //    animation.SetBool("animateactive", false);
                //}
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator kenaMusuh()
    {

        //yield return new WaitForSeconds(0.3f);
        this.GetComponent<SpriteRenderer>().color = new Color(225, 0, 0);
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<SpriteRenderer>().color = new Color(225,225,225);
    }
    public void Damage(float amnt)
    {
        this.health -= amnt;

        
        if (this.health <= 0) { 
        StartCoroutine(colordie());
        }
        else { 
            StartCoroutine(kenaMusuh());
        }
        Debug.Log("Darah" + health);
    }

}
