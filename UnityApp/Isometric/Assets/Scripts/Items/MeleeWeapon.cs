using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeWeapon : Weapon
{
    public Transform Effects;
    public Collider HitArea;
    Transform effects;
    List<Collider> targets = new List<Collider>();

    public override void Use()
    {
        base.Use();

        if(effects != null)
        {
            effects.gameObject.SetActive(true);
        }

        targets.ForEach((c) => OnHit(c));
    }

    void Update()
    {
        targets.RemoveAll(m => m == null);
    }

    public override BaseItem Setup(ItemHandler owner)
    {
        var ret = base.Setup(owner);

        if (effects == null && Effects != null)
        {
            var e  = Instantiate(Effects);
            e.SetParent(owner.transform, false);
            e.localPosition = Effects.transform.position;// owner.transform.forward;
            e.localEulerAngles = Effects.transform.eulerAngles;//.right * -90;
            (ret as MeleeWeapon).effects = e;
        }

        return ret;
    }

    void OnTriggerEnter(Collider other)
    {
        targets.Add(other);            
    }

    void OnTriggerExit(Collider other)
    {
        targets.Remove(other);
    }

    public override void ApplyDamage(Stats t)
    {
        t.Health -= Damage * MyPlayer.MyStats.Strength;
    }
}
