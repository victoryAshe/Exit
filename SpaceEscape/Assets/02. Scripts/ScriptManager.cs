using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public class Talk
    {
        public int objectId;
        public string talk;

        public Talk(int objectId, string talk)
        {
            this.objectId = objectId;
            this.talk = talk;
        }

    }

    //Dictionary<int questId, Talk[]>: questId�� ���� objectId���� talk�� ����
    public Dictionary<int, Talk[]> Script = new Dictionary<int, Talk[]>()
    {

    };

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowScript(int objectId)
    {
        
    }

    public void CloseScript()
    {
        
    }
}
