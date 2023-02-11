using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoUrl : MonoBehaviour
{
    public void GoTuUrl(string url)
    {
        Application.OpenURL(url);
    }
}