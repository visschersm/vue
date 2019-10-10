using System.Collections.Generic;

namespace ViewModels
{
    /// <summary>
    /// Generic object used for filtering and paging large amounts of data. The result is based on the PageSize and PageIndex. A PageSize of 50 and PageIndex of 3 will return the records 100 to 150.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Number of records to fetch per page. Recommended 50-100, depending on the data. Default 50.
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// The current page index. Default 1.
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Returns the total amount of records.
        /// </summary>
        public int PageTotal { get; set; } = 0;

        /// <summary>
        /// Provide property to sort on. Include asc or desc if needed. Only 1 property is supported. Example: 'name desc'.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Used to fetch foreign keys when syncing with offline version.
        /// </summary>
        /// 
        public Dictionary<string, string> Links { get; set; }
    }
}
