using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class SpawnerSphere : MonoBehaviour
{
    public TMP_Text score;
    public GameObject spherePrefab;

    Vector3 spawnPos;
    public float startDelay = 2;
    public float repeatRate = 2;
    public float forceSphere = 7;    

    public List<Material> materials = new List<Material>();
    public List<GameObject> prefabs = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Guardar la posición inicial del spawner
        spawnPos = transform.position;

        //Llamar de forma repetida a esta función y crear esferas
        InvokeRepeating("SpawnSphere", startDelay, repeatRate);
    }

    void SpawnSphere()
    {
        //modicar la posición del Spawner
        float posX = Random.Range(-7, 7);
        float posZ = Random.Range(-7, 7);
        spawnPos = new Vector3(posX, transform.position.y, posZ);     

        //Verificar si hay objetos destruídos
        prefabs.RemoveAll(item => item == null);

        if (prefabs.Count < 10)
        {
            GameObject newPrefab = Instantiate(spherePrefab, spawnPos, spherePrefab.transform.rotation);
            newPrefab.GetComponent<Rigidbody>().AddForce( new Vector3(Random.Range(-1f,1f), 1, Random.Range(-1f, 1f))*forceSphere, ForceMode.Impulse);

            //Cambiar el material de forma aleatoria
            Material[] mats = newPrefab.GetComponent<MeshRenderer>().materials;
            mats[0] = materials[Random.Range(0, materials.Count)];
            newPrefab.GetComponent<MeshRenderer>().materials = mats; 

            prefabs.Add(newPrefab);
            ActualizarScore();           
        }
    }

    void ActualizarScore()
    {        
        score.text = "" + prefabs.Count;
    }
}
