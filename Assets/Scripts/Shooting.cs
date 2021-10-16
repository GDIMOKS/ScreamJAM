using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform PivotPoint;
    public GameObject Bullet;
    public int StartAmmo = 30;

    public int dmg;
    public int speed;
    public float bullLifeTime;
    public float reloadTime;

    [HideInInspector]//можно отобразить, но я убрал, чтоб не отвлекало
    public bool CanShoot = true;
    public int Ammo;

    private void Start()
    {
        Ammo = StartAmmo;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            Shoot();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || (Input.GetButtonDown("Fire1") && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
                StartCoroutine(Reload(reloadTime));
            CanShoot = false;
        }
    }
    public IEnumerator Reload(float _time)//Потом заменить это на вызов анимации, и в ней ивент вызывающий метод, который перезарядит
    {
        yield return new WaitForSeconds(_time);
        Ammo = StartAmmo;
        CanShoot = true;
    }
    public IEnumerator WaitTillShoot(float _time)//Можно тоже через анимацию оружия и ивент в ней
    {
        yield return new WaitForSeconds(_time);
        CanShoot = true;
    }

    public virtual void Shoot()
    {
        Ammo--;
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        //TODO: Звук выстрела и спавн эффекта выстрела
        CanShoot = false;
        StartCoroutine(WaitTillShoot(0.1f));
    }
}
