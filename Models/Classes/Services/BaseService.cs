using Microsoft.Extensions.Logging;
using System;

namespace Models.Classes
{
    public class BaseService
    {
        #region  Data members and Constants

        protected readonly ILogger<BaseService> _logger;

        #endregion Data members and Constants

        #region Constructors

        protected BaseService(ILogger<BaseService> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(paramName: nameof(logger));
        }

        #endregion Constructors
    }
}
