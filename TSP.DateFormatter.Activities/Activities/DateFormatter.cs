using System;
using System.Activities;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using TSP.DateFormatter.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace TSP.DateFormatter.Activities
{
    [LocalizedDisplayName(nameof(Resources.DateFormatter_DisplayName))]
    [LocalizedDescription(nameof(Resources.DateFormatter_Description))]
    public class DateFormatter : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.Timeout_DisplayName))]
        [LocalizedDescription(nameof(Resources.Timeout_Description))]
        public InArgument<int> TimeoutMS { get; set; } = 60000;

        [LocalizedDisplayName(nameof(Resources.DateFormatter_InputDate_DisplayName))]
        [LocalizedDescription(nameof(Resources.DateFormatter_InputDate_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InputDate { get; set; }

        [LocalizedDisplayName(nameof(Resources.DateFormatter_OutputDate_DisplayName))]
        [LocalizedDescription(nameof(Resources.DateFormatter_OutputDate_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> OutputDate { get; set; }

        [LocalizedDisplayName(nameof(Resources.DateFormatter_ResultDate_DisplayName))]
        [LocalizedDescription(nameof(Resources.DateFormatter_ResultDate_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> ResultDate { get; set; }

        #endregion


        #region Constructors

        public DateFormatter()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            string str = this.InputDate.Get((ActivityContext)context);
            string format1 = this.InputDate.Get((ActivityContext)context);
            string format2 = this.OutputDate.Get((ActivityContext)context);
            string ResultDate = DateTime.ParseExact(str.ToString(), format1, (IFormatProvider) CultureInfo.InvariantCulture).ToString(format2);
            return (Action<AsyncCodeActivityContext>)(ctx => this.ResultDate.Set((ActivityContext)ctx, ResultDate));
        }

        private async Task ExecuteWithTimeout(AsyncCodeActivityContext context, CancellationToken cancellationToken = default)
        {
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
        }

        #endregion
    }
}

