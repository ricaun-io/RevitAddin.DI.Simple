namespace RevitAddin.DI.Simple.Services.My
{
    // property injection
    public class MyServiceB : ContainerObject, IMyServiceB
    {
        [Inject]
        private IMyServiceA ServiceA { get; set; }
        public void Method()
        {
            this.ServiceA.Method();
        }
    }
}