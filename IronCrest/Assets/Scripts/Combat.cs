using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            attack(GameObject.Find("Enemy"));
        }*/
    }

    private void Start()
    {
        EventManager.SendCombatStartRequest += Attack;
    }

    private void Attack(Unit unit, Unit target)
    {

        StartCoroutine(Attacking(unit, target));

    }

    private IEnumerator Attacking(Unit unit, Unit target)
    {
        print("attacking!");
        int unitAttack = 0;
        int weaponAttack = 0;
        int divideDmg = 0;

        Weapon weapon = unit.activeWeapon;
        int numBullet = unit.activeWeapon.numBulletsFired;

        if(weapon.weaponType == WeaponType.Melee)
        {
            unitAttack = unit.might;
            weaponAttack = weapon.might;
            divideDmg = 1;

            yield return null;
            print("Melee");
            StartCoroutine(AttackTypeMelee(unit, target, weapon, numBullet, unitAttack, weaponAttack, divideDmg));
        } else if (weapon.weaponType == WeaponType.Rifle)
        {
            unitAttack = unit.dex;
            weaponAttack = weapon.dex;

            divideDmg = 3;

            yield return null;

            StartCoroutine(AttackTypeRanged(unit, target, weapon, numBullet, unitAttack, weaponAttack, divideDmg));
        }

        yield return null;

        
        
        
    }

    public IEnumerator AttackTypeRanged (Unit unit, Unit target, Weapon weapon, int numBullet, int unitAttack, int weaponAttack, int divideDmg)
    {
        for (int i = 0; i < unit.activeWeapon.numBulletsFired; i++)
        {
            if (CalculateHit(target.ac))
            {

                if (UnityEngine.Random.Range(0, 100) <= unit.crit + weapon.crit)
                {
                    target.health -= Damage((weaponAttack + (unitAttack / (numBullet * divideDmg))), target.defense / unit.activeWeapon.numBulletsFired) * 3;

                    print("I hit a crit on " + target.name + "!");
                }
                else
                {


                    target.health -= Damage(weaponAttack + (unitAttack / (numBullet * divideDmg)), target.defense / (unit.activeWeapon.numBulletsFired  * 2));

                    target.Explode();  

                    print("I hit " + target.name + "!");
                }
                if (target.health <= 0)
                {
                    target.Explode();

                    yield return new WaitForSeconds(1f);

                    target.Death();

                    //yield return null;

                    break;


                }
            }
            else
            {
                print("Ohhhh I missed!");
            }

            yield return new WaitForSeconds(unit.activeWeapon.fireRate);
        }

        yield return new WaitForSeconds(0.1f);

        if (GameManager.Instance.State == GameState.PlayerAction)
        {
            EventManager.RecieveEndPlayerTurn();
        }
        else if (GameManager.Instance.State == GameState.EnemyAction)
        {
            GameManager.Instance.NewGameState(GameState.EnemySelect, null);
        }
    }

    public IEnumerator AttackTypeMelee(Unit unit, Unit target, Weapon weapon, int numBullet, int unitAttack, int weaponAttack, int divideDmg)
    {
     
            if (CalculateHit(target.ac))
            {

                if (UnityEngine.Random.Range(0, 100) <= unit.crit + weapon.crit)
                {
                    target.health -= Damage((weaponAttack + (unitAttack / (numBullet * divideDmg))), target.defense / unit.activeWeapon.numBulletsFired) * 3;

                    print("I hit a crit on " + target.name + "!");
                }
                else
                {


                    target.health -= Damage(weaponAttack + (unitAttack / (numBullet * divideDmg)), target.defense / unit.activeWeapon.numBulletsFired);

                    target.Explode();

                    print("I hit " + target.name + "!");
                }
                if (target.health <= 0)
                {
                    target.Explode();

                    yield return new WaitForSeconds(1f);

                    target.Death();

                    //yield return null;

                  


                }
            }
            else
            {
                print("Ohhhh I missed!");
            }

       

        yield return new WaitForSeconds(0.1f);

        if (GameManager.Instance.State == GameState.PlayerAction)
        {
            EventManager.RecieveEndPlayerTurn();
        }
        else if (GameManager.Instance.State == GameState.EnemyAction)
        {
            GameManager.Instance.NewGameState(GameState.EnemySelect, null);
        }
    }

    public bool CalculateHit(int dodge)
    {
        int rint = UnityEngine.Random.Range(0, 100);
        if (rint <= 100 - dodge)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public int Damage(int attack, int defense)
    {
        print(attack - defense);
        return (attack - defense);
    }

}

