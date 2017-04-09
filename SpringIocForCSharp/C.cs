using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   public class C
    {
    private int id;
    private A a;
    private B b;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
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

    public B B
    {
        get
        {
            return b;
        }

        set
        {
            b = value;
        }
    }
}
