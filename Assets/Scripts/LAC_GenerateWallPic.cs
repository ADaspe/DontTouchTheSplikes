using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAC_GenerateWallPic : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] GameObject wall;
    [SerializeField] GameObject picPrefab;

    [Header("Pos Settings")]
    [SerializeField] float wallHeight;
    [SerializeField] float picSpacing;
    [SerializeField] float yOffeset;

    [Header("Difficulty")]
    [Range(0,1)]
    public float spawnRatio;
    List<Vector3> picPos = new List<Vector3>();
    List<GameObject> pic = new List<GameObject>();


    private void Start()
    {


        InitializePicPos();
        GeneratePic();
    }

    void InitializePicPos()
    {

        Vector3 origin = wall.transform.position - ((wallHeight * 0.5f - yOffeset) * Vector3.up);
        for (int i = 0; i < (int)Mathf.Floor(wallHeight / picSpacing); i++)
        {
            picPos.Add((origin + i * picSpacing * Vector3.up));
        }
    }
    public void GeneratePic()
    {
        foreach (GameObject o in pic)
            Destroy(o);

        for (int i = 0; i < picPos.Count; i++)
        {
            

            Debug.Log("Pos" + picPos[i]);
            if (Random.value >= spawnRatio)
            {
               GameObject picObj = Instantiate(picPrefab, picPos[i], transform.rotation);
                pic.Add(picObj);
            }
        }

    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < (int)Mathf.Floor(wallHeight / picSpacing) ; i++)
        {
            Gizmos.DrawSphere(transform.position + (-wallHeight * 0.5f + picSpacing * i + yOffeset) * Vector3.up, 0.3f);
        }
        
    }

    [ContextMenu("GeneratePic")]
    void DebugGeneratePic()
    {
        GeneratePic();
    }

}
