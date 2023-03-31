using LDCalculator.ViewModels.Base;
using System;
using LDCalculator.Infrastructure.Commands;
using System.Windows.Input;

namespace LDCalculator.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Property

        #region Title
        private string _title = "LDCalculator";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Input Output
        private string _inputOutput = "0";

        public string InputOutput
        {
            get => _inputOutput;
            set => Set(ref _inputOutput, value);
        }


        private string _inputStack = "0";

        public string InputStack
        {
            get => _inputStack;
            set => Set(ref _inputStack, value);
        }
        #endregion

        #endregion

        #region Commands
        public ICommand AddSignCommand { get; }

        private void OnAddSignCommand(object parameter)
        {
            // TODO
            string value = parameter as string ?? throw new ArgumentNullException(nameof(parameter));
            if(InputOutput == "0")
            {
                InputOutput = value;
                return;
            }
            InputOutput += value;
        }

        private bool CanAddSign(object parameter)
        {
            return true;
        }

        public ICommand GetResultCommand { get; }

        private void OnGetResultCommand(object parameter)
        {
            InputOutput = StackMachine.StackMachineCalculator.result(InputOutput).ToString();
        }

        private bool CanGetResult(object parameter)
        {
            return true;
        }

        public ICommand ClearAllCommand { get; }

        private void OnClearAllCommand(object parameter)
        {
            InputOutput = "0";
        }

        private bool CanClearAll(object parameter)
        {
            return true;
        } 

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            #region commands

            AddSignCommand = new LambdaCommand(OnAddSignCommand, CanAddSign);
            GetResultCommand = new LambdaCommand(OnGetResultCommand, CanGetResult);
            ClearAllCommand = new LambdaCommand(OnClearAllCommand, CanClearAll);

            #endregion
        }

        #endregion
    }
}
