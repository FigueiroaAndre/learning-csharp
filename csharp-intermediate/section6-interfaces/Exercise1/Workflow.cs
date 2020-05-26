using System.Collections.Generic;

namespace Exercise1
{
    public class Workflow
    {
        public Queue<IActivity> _activities;

        public Workflow()
        {
            _activities = new Queue<IActivity>();
        }

        public Queue<IActivity> Activities
        {
            get
            {
                return _activities;
            }
        }

        public void Push(IActivity activity)
        {
            _activities.Enqueue(activity);
        }

        public void Clear()
        {
            _activities.Clear();
        }
    }
}