using Autodesk.Revit.UI;

namespace RevitAddin.DI.Simple.Services.Commands
{
    public class CommandC : ICommand
    {
        private readonly UIApplication uiapp;

        public CommandC(UIApplication uiapp)
        {
            this.uiapp = uiapp;
        }
        public void Execute()
        {
            System.Windows.MessageBox.Show($"{this.GetType().Name} - {uiapp}");
        }
    }
}
