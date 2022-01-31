using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public class Quest
    {
        public int questId;
        public int questIndex;
        public string qName;

        public Quest(int questId, int questIndex, string qName)
        {
            this.questId = questId;
            this.questIndex = questIndex;
            this.qName = qName;
        }
    }

    List<Quest> questList = new List<Quest>
    {
        new Quest(0,0,"���� ����"), new Quest(1,0,"1�� ����"), new Quest(2,0,"2�� ����"), new Quest(3,0, "3�� ����")
    };

    public int questId = 0;
    public int questIndex = 0;

    void Start()
    {

    }

    void Update()
    {
        
    }

}
