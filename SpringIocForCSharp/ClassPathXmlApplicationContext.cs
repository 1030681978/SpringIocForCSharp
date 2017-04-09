using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using UnityEngine;

public class ClassPathXmlApplicationContext : BeanFactory
{
    //容器
    private Dictionary<string, object> beans = new Dictionary<string, object>();
    public ClassPathXmlApplicationContext(string path) {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);// 得到根节点bean
        XmlNode xn = doc.SelectSingleNode("beans");
        XmlNodeList xnl = xn.ChildNodes;
        if (xnl != null) {
            foreach (XmlNode beanNod in xnl) {
                XmlElement xe = (XmlElement)beanNod;
                string id = xe.GetAttribute("id").ToString();
                string clazz = xe.GetAttribute("class").ToString();

                object obj = ReflectionClazz(clazz);
                beans.Add(id, obj);//向容器中添加对象
               // XmlNode pro = xe.SelectSingleNode("property");
               // Debug.Log(pro.Name);
                // 得到property节点的所有子节点
                XmlNodeList xnlPro = xe.ChildNodes;
                foreach (XmlNode porNod in xnlPro) {
                    XmlElement proXe = (XmlElement)porNod;
                    string name = proXe.GetAttribute("name").ToString();
                    string value = proXe.GetAttribute("value").ToString();
                    string Ref = proXe.GetAttribute("ref").ToString();
                    if (value != null&&Ref =="")
                    {
                       string proNmae = property(name);
                       PropertyInfo info = obj.GetType().GetProperty(proNmae);
                       info.SetValue(obj, Convert.ChangeType(value, info.PropertyType), null);
                    }
                    if (Ref != null&&Ref != "")
                    {
                        object beanObj = getBean(name);
                        string proNmae = property(name);
                        PropertyInfo info = obj.GetType().GetProperty(proNmae);
                        info.SetValue(obj, Convert.ChangeType(beanObj, info.PropertyType), null);
                        //形成set方法todo...
                    }
                }
            }
        }
    }

    public object getBean(string beanName)
    {
        return beans[beanName];
    }
    private object ReflectionClazz(string clazz) {
        Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
        object obj = assembly.CreateInstance(clazz); // 创建类的实例，返回为 object 类
        return obj;
    }
    /// <summary>
    /// 设置成首字母大写的字段
    /// 如 "hello world" ==> "Hello world"并返回
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private string property(string str) {
        if (str.Length > 0)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }
        else {
            return null;
        }
    }
}
