using System.ComponentModel;

namespace ViewModels
{
    public class ResponseObject<T>
    {
        /// <summary>
        /// Initialize the response object. Data gets the default value of the specified type.
        /// </summary>
        public ResponseObject()
        {
            Data = default(T);
            Meta = null;
        }

        /// <summary>
        /// Actual data to be returned.
        /// </summary>
        [DefaultValue(null)]
        public T Data { get; set; }

        /// <summary>
        /// Information about paging.
        /// </summary>
        [DefaultValue(null)]
        public Meta Meta { get; set; }
    }
}
