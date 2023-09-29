using UnityEngine;

[CreateAssetMenu(menuName ="Cards/Soldier Card", fileName ="New Plant Card")]
public class SoldierCardScriptableObject : ScriptableObject
{
    public Texture plantIcon;
    public GameObject Bullet;
    public Sprite plantSprite;
    public LayerMask EnemyLayer;
    //public soldierType jenistentara;
    public int cost;
    public float cooldown;
    public bool isSunFlower;
    public SunSpawner sunSpawnerTemplate;
    public float health;
    public float damage;
    public float range;
    public float speed;
    public float fireRate;
    [Header("Mine Parameters")]
    public bool ledak;
    public GameObject Explosion;
    
    public Vector2 size;

    public Vector2 colliderSize;
    public float radius;
    //public Animator animsi;

    //public enum soldierType
    //{
    //    Biasa,
    //    Tank,
    //    Mobil,
    //}
}
