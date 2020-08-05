using System.Collections;
using System.Collections.Generic;
using Tools.Extentions;
using UnityEngine;

public enum PooledObjectType
{
    Bullet,
    EnemyBall
}

[System.Serializable]
public class PooledObject
{
    public GameObject Object;
    public int Amount;
    public PooledObjectType PooledObjectType;

}

public class ObjectPooling : MonoBehaviour
{

    public static ObjectPooling Instance;

    public PooledObject[] Objects;
    private List<GameObject>[] pool;


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    void Start()
    {
        GameObject temp;
        pool = new List<GameObject>[Objects.Length];

        for (int count = 0; count < Objects.Length; count++)
        {
            pool[count] = new List<GameObject>();
            for (int num = 0; num < Objects[count].Amount; num++)
            {
                temp = (GameObject)Instantiate(Objects[count].Object, new Vector3(0.0f, 1000.0f, 0.0f), Quaternion.identity);
                temp.SetActive(false);
                temp.transform.parent = transform;
                pool[count].Add(temp);
            }
        }
    }

    public GameObject GetFromThePool(PooledObjectType pooledObjectType, Vector3 position, Quaternion rotation)
    {
        int id = (int)pooledObjectType;

        for (int count = 0; count < pool[id].Count; count++)
        {
            if (!pool[id][count].activeSelf)
            {
                GameObject currObj = pool[id][count];
                Transform currTrans = currObj.transform;

                currObj.SetActive(true);
                currTrans.position = position;
                currTrans.rotation = rotation;
                return currObj;
            }
        }
        GameObject newObj = Instantiate(Objects[id].Object) as GameObject;
        Transform newTrans = newObj.transform;
        newTrans.position = position;
        newTrans.rotation = rotation;
        newTrans.parent = transform;
        pool[id].Add(newObj);
        return newObj;
    }

    public void DeactivateObject(GameObject obj)
    {
        obj.SetActive(false);
    }


}
