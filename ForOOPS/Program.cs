using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForOOPS
{

    class TestPrivateConstructor : Exception
    {

        //private TestPrivateConstructor()
        //{
        //    Console.WriteLine("Instance is created, Private Constructor called");
        //}

        static TestPrivateConstructor()
        {
            Console.WriteLine("Instance is created, Private Constructor called");
        }

        static TestPrivateConstructor _instance;

        public static TestPrivateConstructor GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TestPrivateConstructor();
            }
            return _instance;
        }

        public static void DisposeInstance()
        {
            if (_instance != null)
            {
                _instance.Dispose();
                _instance = null;
            }
        }
        public void TestMethod()
        {
            Console.WriteLine("Test MEthod Called");
        }
        void Dispose()
        {
            //Do something
        }
    }


    interface SimpleInterface
    {
        void SimpleInterfaceMthd();
    }

    public abstract class AbstractClass
    {

        public AbstractClass()
        {

        }

        public virtual void NonAbstractMthd()
        {

        }
        public abstract void AbstractMthd();

    }

    public static class StatiClass
    {
        static StatiClass()
        {

        }

        public static void StaticMthd()
        {

        }


    }
    public sealed class sealedClass : AbstractClass, SimpleInterface
    {
        public sealedClass()
        {
        }
        public static void method()
        {

        }

        public override void AbstractMthd()
        {
            throw new NotImplementedException();
        }

        public override void NonAbstractMthd()
        {

        }

        public void SimpleInterfaceMthd()
        {
            throw new NotImplementedException();
        }
    }

    public class NonSealedClass : SimpleInterface
    {
        public NonSealedClass()
        {

        }

        public void SimpleInterfaceMthd()
        {
            throw new NotImplementedException();
        }

        void method()
        {

        }
    }

    enum SimpleEnum { }


    class Comp1
    {
        public void Comp1Print()
        {
            Console.WriteLine("Comp1");
        }
    }

    class Comp2
    {
        public void Comp2Print()
        {
            Console.WriteLine("Comp2");
        }
    }

    class Comp3
    {
        public void Comp3Print()
        {
            Console.WriteLine("Comp3");
        }
    }

    public class BaseInfo {

    }

    public class ParentInfo : BaseInfo
    {

    }


    public class RequInfo : BaseInfo
    {

    }

    public class ResInfo : BaseInfo
    {

    }

    class TestClass<T, U>
        where U:struct
        where T: BaseInfo
    {

    }
    class Program
    {
        
        List<object> ComponentList = new List<object>();
        ArrayList Components = new ArrayList();
        //public<T> a = new <T>();
        public static T Add<T>(T a,T b)
        {
            dynamic num1 = a;
            dynamic num2 = b;
            return num1 + num2;
        }

        public T GetComponent<T>() where T:new ()
        {
            dynamic result = new T();           
           return (T)result;
        }

        public T GetComponentOne<T>() where T : new()
        {
            if (ComponentList.Count == 0)
            {
                throw new Exception();
            }
            List<T> generics = new List<T>();
            foreach (object obj in ComponentList)
            {
                if (obj.GetType().Equals(typeof(T)))
                {
                    generics.Add((T)obj);
                }
                else if (obj.GetType().Equals(typeof(T)))
                {
                    generics.Add((T)obj);
                }
                else
                {
                    // error.
                }
            }
            if (generics.Count == 1)
            {
                dynamic result = generics[0];
                return (T)result;
            }
            else
            {
                throw new Exception();
            }
           
        }
        public List<T> GetComponents<T>() where T : new()
        {
            if (ComponentList.Count == 0)
            {
                throw new Exception();
            }
            List<T> generics = new List<T>();
            foreach (object obj in ComponentList)
            {
                if (obj.GetType().Equals(typeof(T)))
                {
                    generics.Add((T)obj);
                }               
            }
            if (generics.Count > 0)
            {
                dynamic result = generics;
                return (List<T>)result;
            }
            else
            {
                throw new Exception();
            }

        }

        public U GetComponentOfContrainedClass<T,U>(T requinfo,U respinfo) 
            where T : BaseInfo, new()
            where U : BaseInfo, new()
        {
         
            dynamic result = respinfo;
            return (U)result;
        }

        public T GetComponentOfGenericWithMultiConstrained<T, U>(T requinfo, T respinfo)
            where T : BaseInfo
            where U : new()
        {
            dynamic result = new U();
            return (T)result;
        }


        public void AddComponent<T>() where T : new()
        {
            dynamic result = new T();
            ComponentList.Add((T)result);
        }

        public void AddComponent<T>(T obj) where T : new()
        {
            dynamic result = obj;
            ComponentList.Add((T)result);
        }

        static void Main(string[] args)
        {
            try
            {
                sealedClass sealedCls = new sealedClass();
                sealedClass.method();

                SimpleInterface nonSealedCls = new NonSealedClass();
                Program program = new Program();
                RequInfo requinfo = new RequInfo();
                ResInfo resinfo = new ResInfo();

                TestPrivateConstructor b = new TestPrivateConstructor();
                var a = TestPrivateConstructor.GetInstance();
                program.GetComponentOfContrainedClass<RequInfo, ResInfo>(requinfo, resinfo);
                //program.GetComponentOfGenericWithMultiConstrained(requinfo, resinfo);
                Comp1 comp1 = program.GetComponent<Comp1>();

                program.AddComponent<Comp1>();
                program.AddComponent<Comp2>(new Comp2());
                program.AddComponent<Comp1>(new Comp1());

                Comp2 comp2 = program.GetComponent<Comp2>();
                List<Comp1> comp1List= program.GetComponents<Comp1>();
                comp1 = program.GetComponentOne<Comp1>();

                comp1.Comp1Print();

                Console.WriteLine(Program.Add<int>(5,6));
                Console.ReadLine();
            }
            catch (Exception e)
            {

            }
        }
    }
}
