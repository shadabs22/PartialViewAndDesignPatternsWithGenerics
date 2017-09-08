using System;
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
    public sealed class sealedClass: AbstractClass, SimpleInterface
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

    public class NonSealedClass: SimpleInterface
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

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                sealedClass sealedCls = new sealedClass();
                sealedClass.method();

                SimpleInterface nonSealedCls = new NonSealedClass();
                

                TestPrivateConstructor b = new TestPrivateConstructor();
                var a = TestPrivateConstructor.GetInstance();
            }
            catch (Exception e)
            {

            }
        }
    }
}
