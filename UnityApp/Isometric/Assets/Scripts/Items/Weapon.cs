using UnityEngine;
using System.Collections;

public class Weapon : BaseItem {

    public float Damage;

    public Type WeaponType;
    public Target WeaponTarget;
    public Effect WeaponEffect;

    public float PhysicsPushForce;
    public float AreaForceSize;

    // Effect - Fire (dot), Cold (slow), Lightning (stun), Physical
    // Target - Friendly , Enemy, ground
    // Type - AOE, Chain, single, line, trail, wave, pulse

    public override void Use(Vector3 t)
    {
        base.Use(t);
    }

    public override BaseItem Setup(ItemHandler owner)
    {
        return base.Setup(owner);
    }

    public virtual void ApplyDamage(Stats t)
    {
        t.Health -= Damage;
    }

    public void OnHit(Collision c)
    {
        switch (WeaponType)
        {
            case Type.Area:
                var coll = Physics.OverlapSphere(c.contacts[0].point, 10);
                
                foreach(var hit in coll)
                {
                    OnHit(hit);
                    ApplyForce(hit, c.contacts[0].point);
                }
                break;
            case Type.Single:
            case Type.Line:
                OnHit(c.collider);
                ApplyForce(c.collider, c.contacts[0].point);
                break;
        }
    }

    void ApplyForce(Collider c, Vector3 point)
    {
        if (c.GetComponent<Rigidbody>() != null)
        {
            c.GetComponent<Rigidbody>().isKinematic = false;
            c.GetComponent<Rigidbody>().AddExplosionForce(PhysicsPushForce, point, AreaForceSize);
        }
    }

    public void OnHit(Collider hit)
    {
        switch (WeaponType)
        {
            case Type.Area:
                if (hit.GetComponent<Stats>() != null)
                    hit.GetComponent<Stats>().Health -= Damage;
                break;
            case Type.Single:
                if (hit.GetComponent<Stats>() != null)
                    hit.GetComponent<Stats>().Health -= Damage;
                break;
        }
    }
}

public enum Effect
{
    Physical,
    Fire,
    Cold,
    Lightning,
}

public enum Target
{
    None,
    Enemy,
    Friendly
}

public enum Type
{
    Single,
    Area,
    Chain,
    Line,
    Trail,
    Pulse
}