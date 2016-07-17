using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float AggressionRange = 20;
    public ItemHandler ItemHandler;
    public Stats Stats;
    public Transform target;

    public Transform OnDeathEffect;

    float targetupdate = 0;

	// Use this for initialization
    public virtual void Start()
    {
        tag = "Enemy";
        ItemHandler = GetComponent<ItemHandler>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
        if (Stats.Health <= 0)
        {
            Destroy(gameObject);
        }

        targetupdate += Time.deltaTime;

        if (target != null)
        {
            if (ItemHandler != null)
            {
                if (Vector3.Distance(target.position, transform.position) <= ItemHandler.Items[0].Range)
                {
                    transform.LookAt(target);
                    ItemHandler.UseItem(0, target.position);
                }
            }
        }
        else
        {
            if (targetupdate >= 1)
            {
                targetupdate = 0f;
                if (Vector3.Distance(MyPlayer.MyTransform.position, transform.position) <= AggressionRange)
                    target = MyPlayer.MyTransform;
            }
        }
	}

    void OnDisable()
    {
        if(OnDeathEffect != null)
        {
            var de = (Transform)Instantiate(OnDeathEffect, transform.position, OnDeathEffect.rotation);
            Destroy(de.gameObject, 5f);
        }
    }
}
