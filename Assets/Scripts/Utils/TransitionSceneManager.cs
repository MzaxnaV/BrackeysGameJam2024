using Portals;
using Portals.Utility;

namespace Utils
{
    public class TransitionSceneManager : MonoBehaviourSingleton<TransitionSceneManager>
    {
        public Portal portalTo;
        public Portal portalFrom;

        public void Transition(bool shouldReturn)
        {
            portalFrom.Destination = portalTo;
            if (shouldReturn)
            {
                portalTo.Destination = portalFrom;
            }
            
            // cleanup the references
            portalTo = null;
            portalFrom = null;
        }
    }
}
