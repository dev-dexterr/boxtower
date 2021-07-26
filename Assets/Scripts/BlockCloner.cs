using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCloner : MonoBehaviour
{
    public GameObject block;
    public void CloneBlock()
    {
        GameObject new_block = Instantiate(block);
        //Vector3 vector = transform.position;
        //vector.z = 0f;
        new_block.transform.position = transform.position;
    }
}
