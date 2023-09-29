using UnityEngine;

[CreateAssetMenu(menuName = "Entities/Enemy", fileName = "New Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
	public GameObject EnemyDefault;
	//public GameObject zombieAccessory;

	public EnemyType enemyType;

	//public float accessoryHealth;
	public float enemyHealth;
	//public float zombieHandHealth;
	public float enemyDamage;
	public float emenySpeed;
	public float attackInterval;

	public bool ovveridDefaultSprite;
	public bool useChildObjects = true;
	//public int tankMuncul;
	//public float jumpDuration = 1f;
	//public float jumpPower;
	public Sprite newSprite;

	
	public enum EnemyType
	{
		Normal,
		Mobil,
		//BucketZombie,
		//PoleVaulter,
		tank
	}
}