using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Tower_SO tower_SO;
    CircleCollider2D myCollider;
    SpriteRenderer MySpriteRenderer;
    Transform target;
    float fireRate => tower_SO.ShootInterval;
    float fireTimer;
    List<GameObject> bulletPool = new List<GameObject>();
    float rorateSpeed = 20f;
    private void Awake() {
        myCollider = GetComponent<CircleCollider2D>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if(target == null) return;
        if(IsTargetDead())
        {
            target = null;
            return;
        }

        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ), Time.deltaTime * rorateSpeed);

        if(fireTimer <= 0)
        {
            Shoot();
            fireTimer = 1f / fireRate;
        }
        fireTimer -= Time.deltaTime;
    }
    bool IsTargetDead()
    {
        if(target == null) return true;
        return target.GetComponent<Enemy>().Health <= 0;
    }
    public void SetUp(Tower_SO tower_SO)
    {
        this.tower_SO = tower_SO;
        myCollider.radius = tower_SO.Range;
        MySpriteRenderer.sprite = tower_SO.TowerSprite;
    }

    void Shoot()
    {
        GameObject bullet = GetBulletFromPool();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetUp(target, tower_SO.Damage);
    }

    GameObject GetBulletFromPool()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if(!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].transform.position = transform.position;
                bulletPool[i].SetActive(true);
                return bulletPool[i];
            }
        }

        GameObject bullet = Instantiate(TowerDataKeeper.Instance.GetBullet(), transform.position, Quaternion.identity);
        bulletPool.Add(bullet);
        return bullet;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Contains("Enemy"))
            target = other.transform;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name.Contains("Enemy"))
            target = null;
    }

    private void OnMouseUpAsButton() {
        print("Tower so: " + tower_SO.BuildPrice);
    }
}
