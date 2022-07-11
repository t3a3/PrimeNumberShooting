using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjGetNumberScript : MonoBehaviour
{

    public int textNumber;

    private void OnCollisionEnter(Collision other)
    {
        //ê‘Ç¢èeíe(ëfêî)Ç™ìñÇΩÇ¡ÇΩéû
        if (other.gameObject.tag == "RBullet"&&PrimeNumberScript.TargetNumber(textNumber)==true)
        {
            Destroy(other.gameObject);
            GameSystemScript.hitObject = this.gameObject;
            GameSystemScript.targetCorrect = true;
        }
        else if(other.gameObject.tag == "RBullet" && PrimeNumberScript.TargetNumber(textNumber) == false)
        {
            Destroy(other.gameObject);
            GameSystemScript.targetWrong = true;
        }
        //ê¬Ç¢èeíe(ëfêîà»äO)Ç™ìñÇΩÇ¡ÇΩéû
        if (other.gameObject.tag == "BBullet" && PrimeNumberScript.TargetNumber(textNumber) == false)
        {
            Destroy(other.gameObject);
            GameSystemScript.hitObject = this.gameObject;
            GameSystemScript.targetCorrect = true;
        }
        else if(other.gameObject.tag == "BBullet" && PrimeNumberScript.TargetNumber(textNumber) == true)
        {
            Destroy(other.gameObject);
            GameSystemScript.targetWrong = true;
        }
    }
}
