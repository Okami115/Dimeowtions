using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObstacles : MonoBehaviour
{
    public GameObject objetoPrefab;  
    public int cantidadInicial;      

    private List<GameObject> objetosEnPool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < cantidadInicial; i++)
        {
            CrearObjetoEnPool();
        }
    }

    GameObject ObtenerObjetoDePool()
    {
        if (objetosEnPool.Count == 0)
        {
            CrearObjetoEnPool();
        }

        GameObject objeto = objetosEnPool[0];
        objetosEnPool.RemoveAt(0);
        objeto.SetActive(true);

        return objeto;
    }

    public void DevolverObjetoAPool(GameObject objeto)
    {
        objeto.SetActive(false);
        objetosEnPool.Add(objeto);
    }

    void CrearObjetoEnPool()
    {
        GameObject nuevoObjeto = Instantiate(objetoPrefab);
        nuevoObjeto.SetActive(false);
        objetosEnPool.Add(nuevoObjeto);
    }
}
