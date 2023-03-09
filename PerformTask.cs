using AsyncProgressDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgressDemo
{
    public static class PerformTask
    {
        public static void InitializeTask(MainPageViewModel _mainPageViewModel, BackgroundWorker _bw)
        {
            for (int i = 0; i < 10; i++)
            {
                //
            }
            //_bw.RunWorkerAsync();
            _bw.ReportProgress(10);
            //_bw.CancelAsync();


            for (int i = 0; i < 3; i++)
            {
                //
            }
            _bw.RunWorkerAsync("Text");
            _bw.ReportProgress(20);

            for (int i = 0; i < 3; i++)
            {
                //
            }
        }
    }
}
