using UnityEngine;
using System.Collections;

public class GuiProvider : MonoBehaviour {

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(0, 0, 400, 20), "Your current HP:" + (gameObject.GetComponent<Existance>().hp));
    }
}
