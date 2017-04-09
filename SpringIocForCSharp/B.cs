using UnityEngine;
using System.Collections;

public class B {
    private string name;
    private A a;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public A A
    {
        get
        {
            return a;
        }

        set
        {
            a = value;
        }
    }
}
