using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCreator : MonoBehaviour
{
    [SerializeField] private GameObject worldCreatorTarget;
    public Vector3 _worldCreatorTargetVector3;
    public float _worldCreatorSpeed = 1000;
  
        


    void Start()
    {
        WorldCreatorTargetSpawn(Vector3.zero);
    }
    void FixedUpdate()
    {
     
        WorldCreationMove();
     
    }
    
    private void WorldCreationMove()
    {
        gameObject.transform.position = gameObject.transform.position + (_worldCreatorTargetVector3/_worldCreatorSpeed) ; 
    }
    

    void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("WorldCreatorTarget"))
        {
            WorldCreatorTargetSpawn(other.transform.position);
            Destroy(other);
        }
      

    }

    void WorldCreatorTargetSpawn(Vector3 otherVector3)
    {
        Debug.Log("Pouic"); 
        Vector3 nextTargetVector3;

        if (otherVector3 == Vector3.zero)
        {
            nextTargetVector3 = new Vector3(0f, 0f, 100f);
        }
        else
        {
            nextTargetVector3 = otherVector3 + new Vector3(0f, 0f, 100f);
         
        }
        
        GameObject NewTarget = Instantiate(worldCreatorTarget, nextTargetVector3, Quaternion.identity);
        _worldCreatorTargetVector3 = nextTargetVector3;
        NewTarget.transform.RotateAround(gameObject.transform.position, gameObject.transform.localPosition, Random.Range(-45f, 45f) );
        _worldCreatorTargetVector3 = NewTarget.transform.position;
        
    }
}
