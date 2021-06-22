using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Common
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
    where TImplementation : class, TView
    where TView : IView;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        TPresenter Create<TPresenter>()
            where TPresenter : class, IPresenter;
        TPresenter Create<TPresenter, TArgumnent>()
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}
