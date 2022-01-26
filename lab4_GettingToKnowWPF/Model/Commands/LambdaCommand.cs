using System;

namespace lab4_GettingToKnowWPF.Model.Commands
{
    class LambdaCommand : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object Parameter) => _CanExecute?.Invoke(Parameter) ?? true;
        public override void Execute(object Parameter) => _Execute(Parameter);
    }
}
