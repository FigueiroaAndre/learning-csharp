namespace Exercise1
{
    public class Engine
    {
        private readonly Workflow _workflow;

        public Engine(Workflow workflow)
        {
            this._workflow = workflow;
        }

        public void Run()
        {
            foreach (var activity in _workflow
            .Activities)
            {
                activity.Execute();
            }
        }
    }
}