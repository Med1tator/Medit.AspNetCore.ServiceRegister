using Medit.AspNetCore.ServiceRegister.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medit.AspNetCore.ServiceRegister.Implementations
{
    public class QQMusic : IMusicPlayer
    {
        public void PlayJayChou()
        {
            Console.WriteLine("Play Jay Chou by QQ Music.");
        }
    }
}
