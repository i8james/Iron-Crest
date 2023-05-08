using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : BasePart
{

    public int ac;

    public int dex;
    public int defense;

    public bool buildMenu;

    public Material hover;

    public Unit owner;

    public GameObject armPoint;

    public GameObject explosion;

    public GameObject smallExplosion;

    

    //public GameObject legs;
    //public GameObject body;
    //public GameObject arms;

    public GameObject self;

    //public GameObject select;

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var ray : Ray = cam.ScreenPointToRay(Input.mousePosition);

    }

    public void AddToOwner(Unit newOwner)
    {
        newOwner.health += health;
        newOwner.ac += ac;
        newOwner.dex += dex;
        newOwner.defense += defense;
    }



    private void OnMouseOver()
    {
        
    }

    public void Explode()
    {
        StartCoroutine(Explosion());

    }

    public void Explode2(GameObject target)
    {
        StartCoroutine(Explosion2(target));

    }

    private IEnumerator Explosion()
    {
        GameObject exp = Instantiate(explosion, this.gameObject.transform);
        exp.transform.position = Vector3.zero;
        yield return new WaitForSeconds(1f);
        Destroy(exp);
    }

    private IEnumerator Explosion2(GameObject target)
    {
        GameObject exp = Instantiate(smallExplosion, target.gameObject.transform);
        exp.transform.position = Vector3.zero;
        yield return new WaitForSeconds(1f);
        Destroy(exp);
    }
}
