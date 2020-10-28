using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public BulletController bulletCon;

    public int maxBullets;
    

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> bulletPool = new Queue<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        bulletCon.manager = this;
        // TODO: add a series of bullets to the Bullet Pool
        BuildBulletPool();

    }
    private void BuildBulletPool()
    {
        
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet, new Vector3(-10.0f, 0.0f, 0.0f), Quaternion.identity);
            obj.SetActive(false);
            bulletPool.Enqueue(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject temp;
        if(!QueueIsEmpty())
        {
            temp = bulletPool.Dequeue();
            temp.SetActive(true);
        }
        else
        {
            temp = MonoBehaviour.Instantiate(bullet, new Vector3(-10.0f, 0.0f, 0.0f), Quaternion.identity);
            maxBullets += 1;
        }
        return temp;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    public bool QueueIsEmpty()
    {
        return bulletPool.Count == 0;
    }
}
