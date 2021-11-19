namespace DreamTeam.Lighthouse.Core.Events
{
    public interface IEventManager
    {
        public void AddEvent(GameEvent gameEvent, int delayInMiliSeconds = 0);        

        public void ConstantRun();

        public GameEvent CurrentEvent();

        public GameEvent NextEvent();
    }
}
