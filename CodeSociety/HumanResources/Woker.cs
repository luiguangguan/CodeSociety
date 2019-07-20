using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    /// <summary>
    /// a woker objiect
    /// </summary>
    public class Woker
    {
        private Action _job;
        private object _locker = new object();
        private bool _starting = false;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="job">worker's job</param>
        public Woker(Action job)
        {
            _job = job;
        }
        #endregion

        #region Start Working
        /// <summary>
        /// Start Working
        /// start his job
        /// </summary>
        public void StartWorking()
        {

            lock (_locker)
            {
                if (!_starting)
                {
                    _locker = true;
                    _job.Invoke();
                    _locker = false;
                }
            }
        }
        #endregion

    }
}
