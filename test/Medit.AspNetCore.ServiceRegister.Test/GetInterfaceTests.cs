using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Medit.AspNetCore.ServiceRegister.Test
{
    public class GetInterfaceTests
    {
        [Fact]
        public void GetInterfaceByClassNameTest()
        {
            var type=typeof(Student).GetInterface("Person");

            Assert.IsNotType<Person>(type);
        }

        [Fact]
        public void GetInterfaceByInterfaceFullNameTest()
        {
            var type = typeof(Student).GetInterface("Medit.AspNetCore.ServiceRegister.Test.IEatable");

            Assert.NotNull(type);
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public interface IEatable
    {
        void Eat();
    }

    public class Student : Person, IEatable
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }
}
