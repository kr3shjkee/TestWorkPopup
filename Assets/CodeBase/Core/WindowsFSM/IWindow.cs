using System;

namespace CodeBase.Core.WindowsFSM
{
    public interface IWindow
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        void Open();
        void Close();
    }
}