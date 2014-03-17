using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnQLiteExplorer.Views
{
    public interface IWindowView : IView
    {
        void SetDialogResult(Boolean value);
    }
}
