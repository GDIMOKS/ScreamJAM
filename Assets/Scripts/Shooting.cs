using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform PivotPoint;
    public GameObject Bullet;
    public int StartAmmo = 30;

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
            Ammo--;
            Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
            //TODO: Звук выстрела и спавн эффекта выстрела
            CanShoot = false;
            StartCoroutine(WaitTillShoot(0.1f));
        }
        else if (Input.GetKeyDown(KeyCode.R)/*Заменить на баттон*/ || (Input.GetButtonDown("Fire1") && Ammo <= 0))
        {
            StartCoroutine(Reload(2f));
            CanShoot = false;
        }
    }
    private IEnumerator Reload(float _time)//Потом заменить это на вызов анимации, и в ней ивент вызывающий метод, который перезарядит
    {
        yield return new WaitForSeconds(_time);
        Ammo = StartAmmo;
        CanShoot = true;
    }
    private IEnumerator WaitTillShoot(float _time)//Можно тоже через анимацию оружия и ивент в ней
    {
        yield return new WaitForSeconds(_time);
        CanShoot = true;
    }
}
