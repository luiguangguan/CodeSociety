using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResources.Exceptions;

namespace HumanResources
{

    /// <summary>
    /// a woker object
    /// <typeparamref name="JobResult">job result of type</typeparamref>
    /// </summary>
    public class Worker<JobResult>
    {
        private List<Func<JobResult>> _job = new List<Func<JobResult>>();
        private object _locked = new object();
        private bool _starting = false;

        #region Trigger when the job is finished Handle
        /// <summary>
        /// Trigger when the job is finished Handle
        /// </summary>
        /// <param name="sender">trigger object</param>
        /// <param name="e">EventArgs</param>
        public delegate void WorkedEvent(object sender, JobResult jobResult, EventArgs e);
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="job">worker's job</param>
        public Worker(Func<JobResult> job)
        {
            _job.Add(job);
        }
        #endregion

        #region Start Working
        /// <summary>
        /// Start Working
        /// start his job
        /// </summary>
        public void StartWorking()
        {

            if (!_starting)
            {
                lock (_locked)
                {

                    if (_job == null)
                    {
                        throw new WokerException();
                    }
                    _starting = true;
                    for (int i = 0; i < _job.Count; i++)
                    {
                        var result = _job[i].Invoke();
                        Worked?.Invoke(this, result, null);
                    }
                    _starting = false;
                }
            }
        }
        #endregion

        #region when working is finished
        /// <summary>
        /// when working is finished
        /// </summary>
        public event WorkedEvent Worked;
        #endregion

    }
}
