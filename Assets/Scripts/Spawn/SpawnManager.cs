using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    [System.Serializable]
    public class ObiettiviPool
    {
        public ObiettiviContainer prefab;
        public List<ObiettiviContainer> inactiveObjs;
        public List<ObiettiviContainer> activeObjs;
        public ObiettiviContainer Spawn(Vector3 position, Transform parent)
        {
            if (inactiveObjs.Count == 0)
            {
                ObiettiviContainer newObj = GameObject.Instantiate(prefab, parent);
                newObj.transform.position = position;
                activeObjs.Add(newObj);
                return newObj;
            }
            else
            {
                ObiettiviContainer oldObj = inactiveObjs[0];
                oldObj.gameObject.SetActive(true);
                oldObj.transform.SetParent(parent);
                oldObj.transform.position = position;
                activeObjs.Add(oldObj);
                inactiveObjs.RemoveAt(0);
                return oldObj;
            }
        }
        public void Release(ObiettiviContainer obj)
        {
            if (activeObjs.Contains(obj))
            {
                activeObjs.Remove(obj);
                inactiveObjs.Add(obj);
                obj.gameObject.SetActive(false);
            }
        }
    }
    public class SpawnManager : MonoBehaviour
    {
        private static SpawnManager instance;
        public static SpawnManager Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<SpawnManager>();
                return instance;
            }
        }
        [SerializeField] private ObiettiviPool obiettiviPool;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public ObiettiviContainer SpawnObiettivi(Vector3 position)
        {
            ObiettiviContainer obiettivi = obiettiviPool.Spawn(position, transform);
            return obiettivi;
        }
        public void ReleaseObiettivi(ObiettiviContainer obj)
        {
            obiettiviPool.Release(obj);
        }
    }
}
