using System.Collections.Generic;
using System.Threading;

namespace DreamTeam.Lighthouse.Core.Events
{
    public class EventManager : IEventManager
    {
        private readonly Queue<GameEvent> eventQueue;

        private GameEvent currentEvent;

        public EventManager()
        {
            eventQueue = new Queue<GameEvent>();
        }

        private void RunEvent(GameEvent gameEvent)
        {
            Thread.Sleep(gameEvent.DelayInMiliSeconds);
            gameEvent.Run();
            gameEvent.Status = EventStatus.InProgress;
            currentEvent = gameEvent;
        }

        public GameEvent CurrentEvent()
            => currentEvent;

        public GameEvent NextEvent()
            => eventQueue.Peek();

        public void AddEvent(GameEvent gameEvent, int delayInMiliSeconds = 0)
        {
            // New delay value (if any) overwrites event delay time
            gameEvent.DelayInMiliSeconds = delayInMiliSeconds != 0 ? delayInMiliSeconds : gameEvent.DelayInMiliSeconds;
            
            eventQueue.Enqueue(gameEvent);
            gameEvent.Status = EventStatus.Queued;
        }

        /// <summary>
        /// Should be called all the time
        /// </summary>
        public void ConstantRun()
        {
            if (currentEvent.Status == EventStatus.InProgress)
            {
                // Nothing to do
                return;
            }
            else if (currentEvent.HasEnded())
            {
                currentEvent.Status = EventStatus.Finished;
            }

            while (eventQueue.Count > 0)
            {
                var nextEvent = eventQueue.Peek();
                if (nextEvent.IsReady())
                {
                    RunEvent(nextEvent);
                    eventQueue.Dequeue();
                }
            }
        }
    }
}
