using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pinch out on the phone screen to start the animation for Plane 1
public class plane3_anims : MonoBehaviour
{

    private Animator anim;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if ((PinchCheck() > 0) && (flag == true))
        {
            Debug.Log("Pinch In.\n");
            if (null != anim)
            {
                //Play Plane_3
                anim.Play("plane3_reverse 0");
                flag = false;
            }
            else
            {
                Debug.Log("Animation is Null");
            }

        }
        else if ((flag == false) && (PinchCheck() < 0))
        {
            Debug.Log("Pinch out.\n");
            //Debug.Log(PinchCheck());
            if (null != anim)
            {
                //Play Plane_3
                anim.Play("plane_3 0");
                flag = true;
            }
            else
            {
                Debug.Log("Animation is Null");
            }
        }
    }

    float PinchCheck()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            return deltaMagnitudeDiff;
        }

        return 0;
    }
}