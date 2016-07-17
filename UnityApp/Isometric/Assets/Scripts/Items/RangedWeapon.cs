using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedWeapon : Weapon {

    public int ShotsFired = 1;
    public Projectile Projectile;
    List<Projectile> projectiles;
    int currentIndex = 0;

    public override void Use(Vector3 target)
    {
        base.Use(target);

        for (int i = 0; i < ShotsFired; i++)
        {
            projectiles[currentIndex].transform.position = Owner.transform.position + Owner.transform.forward;// Projectile.transform.position;
            projectiles[currentIndex].transform.LookAt(target);
            //projectiles[currentIndex].transform.forward = Owner.transform.forward;
            //projectiles[currentIndex].transform.forward = 3 * Owner.transform.forward + Owner.transform.up * Random.Range(-1 / MyPlayer.MyStats.Perception, 1 / MyPlayer.MyStats.Perception) + Owner.transform.right * Random.Range(-1 / MyPlayer.MyStats.Perception, 1 / MyPlayer.MyStats.Perception);
            projectiles[currentIndex].gameObject.SetActive(true);
            projectiles[currentIndex].ShootMe();

            currentIndex++;
            if (currentIndex >= projectiles.Count)
                currentIndex = 0;
        }
    }

    public override BaseItem Setup(ItemHandler owner)
    {
        var ret = base.Setup(owner) as RangedWeapon;
        ret.projectiles = new List<Projectile>();
        currentIndex = 0;

        for(int i = 0; i < 25; i++)
        {
            Projectile effects = Instantiate(Projectile);
            //effects.transform.SetParent(owner.transform, false);
            effects.transform.localPosition = Projectile.transform.position;
            effects.transform.localEulerAngles = Projectile.transform.eulerAngles;
            effects.gameObject.SetActive(false);
            effects.Owner = this;

            ret.projectiles.Add(effects);
        }

        return ret;
    }
}
