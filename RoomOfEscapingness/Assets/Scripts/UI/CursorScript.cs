using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public List<Sprite> list = new List<Sprite>();
    private InteractLookCheck interactLookCheck;
    // Start is called before the first frame update
    void Start()
    {
        interactLookCheck = GameObject.FindWithTag("Player").GetComponent<InteractLookCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
