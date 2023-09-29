using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    public EnemyScriptableObject thisEnemySO;

    public float speed;
    public float health;
    public float handHealth;
    public float currentHealth;
   // public GameObject accessory;
    public float accessoryHealth;
    public float damage;
    public float attackInterval;
    public GameObject target;
    public bool isAttacking;
    GameManager menang;

    [Tooltip("Index 0 : Normal Zombie, Index 1 : Cone Head Zombie, Index 2 : Bucket Head Zombie")]
    public List<AudioClip> damageAudio;
    public static int skor=0;    
    public GameObject gameSkor;
    public GameObject pole;
    public bool isPole = true;
    public float damageDelay = 2f;
    bool isDying;
    bool incremented = false;

    [Header("Animator Parameters")]
    public bool isWalking;
   
    float time = 0f;
    private void Start()
    {
        //isPole = true;
        speed = thisEnemySO.emenySpeed;
        health = thisEnemySO.enemyHealth;
        damage = thisEnemySO.enemyDamage;
        attackInterval = thisEnemySO.attackInterval;
        currentHealth = health;
        gameSkor = GameObject.FindWithTag("skor");
        

        menang = FindObjectOfType<GameManager>();
        if (thisEnemySO.ovveridDefaultSprite)
		{
            this.GetComponent<SpriteRenderer>().sprite = thisEnemySO.newSprite;
		}
   
    }

    private void Update()
    {
        if (target == null)
        {
            isAttacking = false;
           
        }

        if (!isAttacking && !isDying)
        {
            Debug.Log("Walking!");
            isWalking = true;
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            isWalking = false;
            this.transform.position = this.transform.position;
        }

        if (currentHealth <= 0)
        {
            isDying = true;
			if (!incremented)
			{
                incremented = true; 
                int randomInt = Random.Range(0, 101);
                skor++;
                gameSkor.GetComponent<TextMeshProUGUI>().text = skor.ToString();
                Win();
            }
            StartCoroutine(die());
            Destroy(gameObject, 1f); 

            Destroy(this.GetComponent<Rigidbody2D>());
            
            //Instantiate(bomm,)
            foreach (var item in this.GetComponents<BoxCollider2D>())
            {
                Destroy(item);
            }
            Destroy(this.gameObject, 2f);
        }
        switch (thisEnemySO.enemyType)
        {
            case EnemyScriptableObject.EnemyType.Normal:

                this.GetComponent<SpriteRenderer>().sortingOrder = 3;
                break;
            case EnemyScriptableObject.EnemyType.tank:

                this.GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;
            case EnemyScriptableObject.EnemyType.Mobil:

                this.GetComponent<SpriteRenderer>().sortingOrder = 2;
                break;
            default:
                break;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SoldierManager>())
        {
            time += Time.deltaTime;
            isAttacking = true;
            target = collision.gameObject;
            Debug.Log("tines" + time);
            StartCoroutine(Attack());
            Debug.Log("PPP");
        }
        else
        {
            mati();
        }
        //else
        //{
        //    target = null;
        //    isAttacking = false;
        //    StopCoroutine(Attack());
        //    Debug.Log("keluar");
        //}
    }
       


    public void mati()
    {

        target = null;
        isAttacking = false;
        StopCoroutine(Attack());
        Debug.Log("keluar");
    }

    public IEnumerator Attack()
    {
      
        isWalking = false;
        Debug.Log("bobo");
        yield return new WaitForSeconds(attackInterval);
        if (target != null)
        {
            target.GetComponent<SoldierManager>().Damage(damage);
            
        }
        yield return new WaitForSeconds(attackInterval+0.5f);
        isAttacking = false;
    }

    public IEnumerator die()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
       
    }
    public void DealDamage(float amnt)
    {
        //Audio to play
        switch (thisEnemySO.enemyType)
        {
            case EnemyScriptableObject.EnemyType.Normal:
                this.GetComponent<AudioSource>().PlayOneShot(damageAudio[0]);
                
                break;
            case EnemyScriptableObject.EnemyType.tank:
                this.GetComponent<AudioSource>().PlayOneShot(damageAudio[0]);
         ;
                break;
            case EnemyScriptableObject.EnemyType.Mobil:
                this.GetComponent<AudioSource>().PlayOneShot(damageAudio[0]);
        
                break;
            default:
                break;
        }

        currentHealth -= amnt;

        StartCoroutine(DamageColor(this.gameObject.GetComponent<SpriteRenderer>()));

        //foreach (Transform item in this.transform.GetComponentInChildren<Transform>())
        //{
        //    StartCoroutine(DamageColor(item.gameObject.GetComponent<SpriteRenderer>()));   
        //}
    }

    public IEnumerator DamageColor(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.1f);
        
        spriteRenderer.color = new Color(255,255,255);
        yield return new WaitForSeconds(0.1f);
    }
    public void Win()
    {
        
        if (skor == menang.PointMenang)
        {
            StopAllCoroutines();
            Destroy(menang.spawnMusuh.gameObject);
            Destroy(GameObject.Find("Sun Manager"));
            LeanTween.moveLocalY(GameObject.Find("NotifWin"), 0, 1.25f).setEaseOutBounce().setDelay(2f);
            Debug.Log("menang");
            skor = 0;
        }
    }
}
