using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] List<GameObject> ships;
    
    [SerializeField] Button button_L;
    [SerializeField] Button button_R;
    int pos;
    [SerializeField] int spacing = 80;
    Vector3 startPos = Vector3.zero;
    [SerializeField] float duration = 0.5f;
    public int numberOfchildren;
    float elapsedTime;
    int dir = 0;
    // Start is called before the first frame update
    void Start()
    {
        numberOfchildren = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == -1)
        {
            startPos = transform.localPosition;
            
        }
        if (dir == 1 )
        {
            startPos = transform.localPosition;
            
        }
        if(numberOfchildren == 12)
        {
            button_R.interactable = false;
        }
        if (numberOfchildren == 1)
        {
            button_L.interactable = false;
        }
        if (numberOfchildren < 12 && numberOfchildren > 1)
        {
            button_R.interactable = true;
            button_L.interactable = true;
        }
        
        Lerp();
    }

    public void ScrollLeft()
    {
        numberOfchildren -= 1;
        dir = -1;
        pos += spacing * dir;
        elapsedTime = 0;
    }
    public void ScrollRight()
    {
        dir = 1;
        pos += spacing * dir;
        elapsedTime = 0;
        numberOfchildren += 1;
    }
    void Lerp()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        transform.localPosition = Vector3.Lerp(startPos, new Vector3(pos, 0,0), Mathf.SmoothStep(0, 1, percentageComplete));
    }
   
}
