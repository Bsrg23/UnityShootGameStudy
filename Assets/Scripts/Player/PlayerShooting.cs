using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 10;//    射击伤害
    public float timeBetweenBullets = 0.15f;//  开火间隔时间
    public float range = 100f;//    子弹轨迹长度
    float timer;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;
        //  按键开枪
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }
        //  子弹轨迹和灯光函数
        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }

    //  子弹轨迹和灯光函数
    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    //  射击函数
    void Shoot ()
    {

        timer = 0f;
        //  播放开火音效
        gunAudio.Play ();
        //  制造子弹轨迹
        gunLight.enabled = true;
        //  播放粒子特效
        //gunParticles.Stop ();
        gunParticles.Play ();

       
        gunLine.SetPosition (0, transform.position);//  子弹轨迹起点和终点
        
        shootRay.origin = transform.position;//  子弹检测射线起点
        shootRay.direction = transform.forward;//   子弹检测射线方向

        //  判断子弹射线是否击中目标    (射线,集中目标返回值,射线长度,目标图层)
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            //  获取敌人血量
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                //  造成伤害
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            //  设置子弹轨迹到击中地点
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            //  设置默认子弹轨迹
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
