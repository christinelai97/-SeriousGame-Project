using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCanvas : MonoBehaviour
{
    private bool flipped;

    public void Flip()
    {
        // invert the local X-axis scale
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        flipped = true;
    }
}
