namespace RevitAddin.DI.Simple.Services.My
{
    public class MyServiceA : IMyServiceA
    {
        public void Method()
        {
            System.Windows.MessageBox.Show(this.GetType().Name);
        }
    }
}