using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedConcept.Polymorphism.NewAndVirtual
{
    public class BaseClass
    {
        public virtual void DoWorks()
        {
            Console.WriteLine("Base class method");
        }
        public void DoWorks2()
        {
            Console.WriteLine("Base class DOwork2");
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void DoWorks() //method overriding .When BaseClass obj = new DerivedClass() this method get call and base class method hide
        {
            Console.WriteLine("Derived Class method");
        }
        public new void DoWorks2() // method hiding. When BaseClass obj = new DerivedClass() this method get hides and call base class method
        {
            Console.WriteLine("Derived class Doworks2");
        }
      
    }

    public class ChildClass : IBaseClass1, IBaseClass
    {
        public void DoWorks()
        {
            Console.WriteLine("Child class method");
        }

        void IBaseClass1.DoWorks() // two different interface having same method name can be implemented like this
        {
            Console.WriteLine("Child class IBaseClass1 method");
        }
    }
    public interface IBaseClass
    {
        public virtual void DoWorks()
        {
            Console.WriteLine("Base class method");
        }
    }
    public interface IBaseClass1
    {
         void DoWorks();
    }
}
