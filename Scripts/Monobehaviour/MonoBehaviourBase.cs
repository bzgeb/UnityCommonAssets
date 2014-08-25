using UnityEngine;
using System.Collections;

public class MonoBehaviourBase : MonoBehaviour {
    public delegate void Task();

    public void Invoke(Task task, float time)
    {
       Invoke(task.Method.Name, time);
    }
}
