using Autodesk.Revit.UI;

namespace RevitAddin.DI.Simple.Services.Commands
{
    public class CommandB : ICommand
    {
        private readonly UIApplication uiapp;

        public CommandB(UIApplication uiapp)
        {
            this.uiapp = uiapp;
        }
        public void Execute()
        {
            System.Windows.MessageBox.Show($"{this.GetType().Name} - {uiapp}");
        }
    }
}
