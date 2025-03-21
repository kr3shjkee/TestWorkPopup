using CodeBase.Core.MVP.Presenters;

namespace CodeBase.Core.MVP.Views
{
    public interface IView
    {
        void Construct(IPresenter presenter);
    }
}