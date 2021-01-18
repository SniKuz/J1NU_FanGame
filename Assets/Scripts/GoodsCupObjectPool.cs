using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsCupObjectPool : MonoBehaviour
{
    public static GoodsCupObjectPool Instance;

    [SerializeField]
    GameObject poolingObject;
    Queue<GameObject> poolingObjectQueue = new Queue<GameObject>();

    private void Awake() {
        Instance = this;
        Initialize(30);
    }
    void Initialize(int initcount){
        for(int i = 0; i < initcount; i++){
            poolingObjectQueue.Enqueue(CreateNewOnject());
        }
    }

    GameObject CreateNewOnject(){
        var newObj = Instantiate(poolingObject);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static GameObject GetObject(){
        if(Instance.poolingObjectQueue.Count >0){
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else{
            var newobj = Instance.CreateNewOnject();
            newobj.transform.SetParent(null);
            newobj.gameObject.SetActive(true);
            return newobj;
        }
    }

    public static void ReturnObject(GameObject obj){
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
