using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    private GameObject pointPrefab;
    private GameObject newPoint;

    private float x;
    private float y;
    private float z;

    [SerializeField]
    private GameObject database;

    // Start is called before the first frame update
    void Awake()
    {
        //Transform point = Instantiate(pointPrefab);
        //point.localPosition = Vector3.right;
        //point = Instantiate(pointPrefab);
        // point.localPosition = Vector3.right * 2f;
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
        Debug.Log(transform.position.z);
        Debug.Log("");

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if x < or > then Instantiate(pointPrefab);
        if (x < (transform.position.x - 2f) || x > (transform.position.x + 2f)) {
            x = transform.position.x;
            
            newPoint = Instantiate(pointPrefab);
            newPoint.transform.position = new Vector3(x, y, z);
            database.GetComponent<DBScript>().CreateRecord(newPoint.name, x, z);
        }

        if (y < (transform.position.y - 2f) || y > (transform.position.y + 2f))
        {
            y = transform.position.y;

            newPoint = Instantiate(pointPrefab);
            newPoint.transform.position = new Vector3(x, y, z);
        }
        if (z < (transform.position.z - 2f) || z > (transform.position.z + 2f))
        {
            z = transform.position.z;

            newPoint = Instantiate(pointPrefab);
            newPoint.transform.position = new Vector3(x, y, z);
            database.GetComponent<DBScript>().CreateRecord(newPoint.name, x, z);
        }

    }
}
