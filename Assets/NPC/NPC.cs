using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Transform ruta;
    int indiceHijos;
    Vector3 destino;
    public GameObject panel;

    public Vector3 min, max;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        //destino = ruta.GetChild(indiceHijos).position;
        //destino = DestinoAleatorio();
        //GetComponent<NavMeshAgent>().SetDestination(destino);
    }

    // Update is called once per frame
    void Update()
    {

        #region Movimiento por click
        /*if (Input.GetButtonDown("Fire1"))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(rayo, out hit, 1000))
            {
              GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }*/
        #endregion

        #region Movimiento de Patrulla
        /*if (Vector3.Distance(transform.position, destino) < 1.5f)
        {
            indiceHijos = Random.Range(0, ruta.childCount);
            //indiceHijos++;
           // indiceHijos = indiceHijos % ruta.childCount;
           //or
           // if (indiceHijos > ruta.childCount)
            //    indiceHijos = 0;
           destino = ruta.GetChild(indiceHijos).position;
            GetComponent<NavMeshAgent>().SetDestination(destino);

        }*/
        #endregion

        #region Movimiento Area
        /*if (Vector3.Distance(transform.position, destino) < 1.5f)
        {
            destino = DestinoAleatorio();
            GetComponent<NavMeshAgent>().SetDestination(destino);

        }*/
        #endregion

        destino = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (Vector3.Distance(transform.position, destino) < 1f)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        GetComponent<NavMeshAgent>().SetDestination(destino);
    }

    Vector3 DestinoAleatorio()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.y));
    }
}
