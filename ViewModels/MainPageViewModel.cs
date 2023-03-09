using AsyncProgressDemo.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AsyncProgressDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private BackgroundWorker bw;
        private int _currentProgress;
        public int CurrentProgress
        {
            get { return _currentProgress; }
            set
            {
                _currentProgress = value;
                OnPropertyChanged(nameof(CurrentProgress));
            }
        }

        private string? _progressText;
        public string ProgressText
        {
            get { return _progressText; }
            set
            {
                _progressText = value;
                OnPropertyChanged(nameof(ProgressText));
            }
        }

        public ICommand ExecuteCommand { get; set; }

        public MainPageViewModel()
        {
            InitializeBackgroundWorker();
            ProgressText = "Waiting for click";
            
            ExecuteCommand = new ExecuteCommand(this, bw);
        }

        public void InitializeBackgroundWorker()
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_RunWorker_DoWork);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation= true;
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        private void bw_RunWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            ProgressText = "In progress";
        }

        private void bw_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            CurrentProgress = 100;
            MessageBox.Show("Completed");
        }

        private void bw_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            CurrentProgress = e.ProgressPercentage;
        }
    }
}
