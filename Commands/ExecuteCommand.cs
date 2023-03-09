using AsyncProgressDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgressDemo.Commands
{
    public class ExecuteCommand : CommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;
        BackgroundWorker _bw;

        public ExecuteCommand(MainPageViewModel mainPageViewModel, BackgroundWorker bw)
        {
            _mainPageViewModel = mainPageViewModel;
            _bw = bw;
        }

        public event EventHandler CanExexuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            PerformTask.InitializeTask(_mainPageViewModel, _bw);
        }
    }
}
