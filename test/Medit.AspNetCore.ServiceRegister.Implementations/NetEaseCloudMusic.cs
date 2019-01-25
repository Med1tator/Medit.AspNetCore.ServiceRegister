using Medit.AspNetCore.ServiceRegister.Interfaces;
using System;

namespace Medit.AspNetCore.ServiceRegister.Implementations
{
    public class NetEaseCloudMusic : IMusicPlayer
    {
        public void PlayJayChou()
        {
            Console.WriteLine("Play Jay Chou in NetEase Cloud Music.");
        }
    }
}
