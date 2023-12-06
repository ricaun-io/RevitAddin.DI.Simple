namespace RevitAddin.DI.Simple.Services.My
{
    // constructor injection
    // MyServiceC is better to be registered to the Container to get created automatically with an instance of IMyServiceA
    public class MyServiceC : ContainerObject, IMyServiceC
    {
        public MyServiceC(IMyServiceA serviceA)
        {
            this.ServiceA = serviceA;
        }
        private IMyServiceA ServiceA { get; set; }
        public void Method()
        {
            this.ServiceA.Method();
        }
    }
}