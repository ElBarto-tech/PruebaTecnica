using System.Collections;
using UnityEngine;

public class PrefabSphere : MonoBehaviour
{
    SpawnerSphere spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<SpawnerSphere>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        spawner.prefabs.RemoveAll(item => item == null);
        spawner.score.text = "" + (spawner.prefabs.Count - 1);
        Destroy(gameObject);
    }
}
