using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Medit.AspNetCore.ServiceRegister.Test
{
    public class AssemblyLoadTests
    {
        [Fact]
        public void LoadFromRefPathTest()
        {
            var relPath = @"ext\Medit.AspNetCore.ServiceRegister.Implementations.dll";
            Assert.False(Path.IsPathRooted(relPath));

            var ass = Assembly.LoadFrom(relPath);
            Assert.NotNull(ass);
        }

        [Fact]
        public void LoadFromAbsPathTest()
        {
            var absPath = @"C:\Users\admin\Documents\WeChat Files\JAY576264928\Files\Medit.ServiceRegister\Medit.ServiceRegister\Medit.ServiceRegister.Tests\bin\Debug\netcoreapp2.2\ext\Medit.AspNetCore.ServiceRegister.Implementations.dll";

            Assert.True(Path.IsPathRooted(absPath));
            var ass = Assembly.LoadFrom(absPath);
            Assert.NotNull(ass);
        }
    }
}
