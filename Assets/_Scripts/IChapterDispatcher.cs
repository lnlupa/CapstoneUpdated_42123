using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChapterDispatcher 
{
    public Transform[] FindPath(string from, string to);
}
