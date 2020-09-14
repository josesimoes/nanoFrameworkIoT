

namespace System
{
    /// <summary>
    /// Environment class
    /// </summary>
    public static class Environment
    {
        /// <summary>
        /// Tick Count
        /// </summary>
        public static int TickCount => (int)DateTime.UtcNow.Ticks;
    }
}
