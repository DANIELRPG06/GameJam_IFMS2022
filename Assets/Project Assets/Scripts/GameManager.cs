using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isMapOpen { get; private set; } = false;
    [SerializeField]
    private GameObject Mapa;
    [SerializeField]
    private Player player;

    void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            isMapOpen = !isMapOpen;
            Mapa.SetActive(isMapOpen);
            if (isMapOpen)
            {
                GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
                // acha inimigo mais proximo
                GameObject closest = null;
                float distance = Mathf.Infinity;
                Vector3 position = player.transform.position;
                foreach (GameObject go in inimigos)
                {
                    Vector3 diff = go.transform.position - position;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        closest = go;
                        distance = curDistance;
                    }
                }

                closest.GetComponent<Inimigo>().AlertaPlayer(player.transform);

            }
        }

    }
}
