using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GageScript : MonoBehaviour
{
    public void GageDown(float current,float max)
    {
        gameObject.GetComponent<Image>().fillAmount = current / max;
    }
}
