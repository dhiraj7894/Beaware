using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace landFall.Control
{
    public class controlPlateformGenrator : MonoBehaviour
    {
        public List<GameObject> PlateForm = new List<GameObject>();
        public GameObject plateformCube;
        public Vector2 ArrayList;
        public float Spacing;
        public float Speed;
        public bool StartDestroying;
        public int currentNum;
        void Start()
        {
            //SpawnPlateform();
            foreach(Transform t in transform)
            {
                if (!PlateForm.Contains(t.gameObject))
                    PlateForm.Add(t.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            destroyPlateForm();
        }
        float x = 0.1f;
        void destroyPlateForm()
        {
            if (StartDestroying)
            {
                if (x > 0)
                    x -= Time.deltaTime;
                if (x <= 0 && currentNum <= PlateForm.Count-1)
                {
                   PlateForm[currentNum].AddComponent<Rigidbody>();
                    currentNum += 1;
                    x = Speed;
                }
            }
        }
        public void SpawnPlateform()
        {
            for(int i = 0; i <= ArrayList.y; i++)
            {
                for(int j = 0; j <= ArrayList.x; j++) 
                {
                    Vector3 SpwnPos = new Vector3(transform.position.x + j * Spacing, transform.position.y, transform.position.z + i * Spacing);
                    GameObject p = Instantiate(plateformCube, SpwnPos, Quaternion.identity, transform);
                    if (!PlateForm.Contains(p))
                        PlateForm.Add(p);
                }
            }
        }
    }
}
