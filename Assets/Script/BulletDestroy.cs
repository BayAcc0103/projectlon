using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{	
	[SerializeField] GameObject Bullet;
	public float timeToDestroy = 5.0f;
	void Start()
	{
		Destroy(Bullet,timeToDestroy);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Destroy(Bullet);
		}
	}
}
