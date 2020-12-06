using UnityEngine;
using CarlyLib.IO; 

public class Test : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Hoge");
        var writer = new JsonWriter(new TextWriter("~/Desktop/hoge.txt"));
        writer.Write("SSS");
    }
}
