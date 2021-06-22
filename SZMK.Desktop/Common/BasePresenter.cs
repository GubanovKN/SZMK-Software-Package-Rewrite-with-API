using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Common
{
    public abstract class BasePresener<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresener(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
        public DialogResult RunDialog(Form Owner)
        {
            SetOwner(Owner);
            return View.ShowDialog();
        }
        public async Task<DialogResult> RunDialogAsync(Form Owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                SetOwner(Owner);
                return View.ShowDialog();
            }
        }
        public void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }

        public void Finish()
        {
            View.Close();
        }
    }

    public abstract class BasePresener<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresener(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run(TArg argument);
        public abstract DialogResult RunDialog(TArg argument, Form owner);
        public abstract Task<DialogResult> RunDialogAsync(TArg argument, Form owner);
        public abstract void SetOwner(Form owner);
        public abstract void Finish();
    }
}
