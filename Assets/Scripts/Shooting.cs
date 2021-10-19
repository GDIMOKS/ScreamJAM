using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform PivotPoint;
    public GameObject Bullet;
    public int StartAmmo;

    public int dmg;
    public int altDmg;
    public int speed;
    public float bullLifeTime;
    public float reloadTime;
    public float shootTime;
    public float altShootTime;
    public AudioClip ShotSound;
    public AudioClip ReloadSound;
    public AudioClip WaitSound;

    [HideInInspector]//����� ����������, �� � �����, ���� �� ���������
    public bool CanShoot = true;
    public int Ammo;
    public int ammoInColler;
    [HideInInspector]//����� ����������, �� � �����, ���� �� ���������
    public Animator anim;
    [HideInInspector]//����� ����������, �� � �����, ���� �� ���������
    public AudioSource audio;

    private void Start()
    {
        StartAmmo -= ammoInColler;
        Ammo = ammoInColler;
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = altDmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            AltShoot();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*�������� �� ������*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot && StartAmmo > 0)
        {
            //if (CanShoot)
            Reload();
            CanShoot = false;
        }
    }
    public void PlayShot()
    {
        audio.clip = ShotSound;
        audio.Play();
    }
    public void PlayReload()
    {
        audio.clip = ReloadSound;
        audio.Play();
    }
    public void PlayWait()
    {
        audio.clip = WaitSound;
        audio.Play();
    }
    public void WaitEnd()
    {
        CanShoot = true;
    }
    public virtual void ReloadEnd()
    {
        if (StartAmmo > 0)
        {
            if (StartAmmo >= ammoInColler)
            {
                StartAmmo -= ammoInColler;
                Ammo = ammoInColler;
            }
            else
            {
                Ammo = StartAmmo;
                StartAmmo -= StartAmmo;
            }
        }

        CanShoot = true;
    }
    public virtual void Reload()
    {
        StartCoroutine(Reload(reloadTime));
    }
    public virtual void Wait()
    {
        StartCoroutine(WaitTillShoot(shootTime));
    }
    public IEnumerator Reload(float _time)//����� �������� ��� �� ����� ��������, � � ��� ����� ���������� �����, ������� �����������
    {
        yield return new WaitForSeconds(_time);
        if (StartAmmo > 0)
        {
            if (StartAmmo >= ammoInColler)
            {
                StartAmmo -= ammoInColler;
                Ammo = ammoInColler;
            }
            else
            {
                Ammo = StartAmmo;
                StartAmmo -= StartAmmo;
            }
        }
        
        CanShoot = true;
    }
    public IEnumerator WaitTillShoot(float _time)//����� ���� ����� �������� ������ � ����� � ���
    {
        yield return new WaitForSeconds(_time);
        CanShoot = true;
    }

    public virtual void Shoot()
    {
        Ammo--;
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(shootTime));
    }

    public virtual void AltShoot()
    {
        int bullets = 3;

        if (Ammo < 3)
        {
            bullets = Ammo;
        }

        for (int i = 0; i < bullets; i++)
        {
            Ammo--;
            Instantiate(Bullet, PivotPoint.position - transform.TransformDirection(new Vector3(0, 0, 1f * i)), PivotPoint.rotation);
        }
        
        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(altShootTime));
    }
}
