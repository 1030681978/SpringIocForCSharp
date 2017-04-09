using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("x")) {
            test10();
        }
	}
    private void test10() {
        BeanFactory factory = new ClassPathXmlApplicationContext("E:/unityDemo/反射/Assets/ClassPathApplicationContext.xml");
        A a = (A)factory.getBean("a");
        print(a.Age);
        print(a.Name);
        B b = (B)factory.getBean("b");
        print(b.A.Age);
        print(b.A.Name);
        print(b.Name);
        C c = (C)factory.getBean("c");
        print(c.Id);
        print(c.A.Name);
        print(c.B.A.Name);
    }
}
