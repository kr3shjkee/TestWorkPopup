namespace CodeBase.Core.WindowsFSM
{
    public interface IWindowResolve
    {
        void Set<TView>() 
            where TView : class, IWindow, new();

        void Set<TWindow>(TWindow window) 
            where TWindow : class, IWindow;

        void CleanUp();
    }
}