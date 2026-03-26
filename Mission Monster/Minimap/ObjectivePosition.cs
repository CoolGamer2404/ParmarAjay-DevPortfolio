using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePosition : MonoBehaviour
{
    [SerializeField]private bool isAddMarkerOnStart=true;
    [SerializeField]private bool isBigMarker=false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled=false;
        if(isAddMarkerOnStart==true && !isBigMarker)
        FindObjectOfType<MarkerHolder>().AddObjectiveMarker(this);
        else if(isAddMarkerOnStart==true && isBigMarker)
        FindObjectOfType<MarkerHolder>().AddObjectiveBigMarker(this);
    }

    public void AddMarker(){
        if( !isBigMarker)
        FindObjectOfType<MarkerHolder>().AddObjectiveMarker(this);
        else if( isBigMarker)
        FindObjectOfType<MarkerHolder>().AddObjectiveBigMarker(this);
    }
    public void RemoveMarker(){
        FindObjectOfType<MarkerHolder>().RemoveObjectiveMarker(this);
    }


}
