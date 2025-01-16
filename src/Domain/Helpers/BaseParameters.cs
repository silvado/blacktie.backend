using System.Diagnostics.CodeAnalysis;

namespace Domain.Helpers
{
    [ExcludeFromCodeCoverage]
    public abstract record BaseParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string? SearchTerm { get; set; } = string.Empty;

        public string? Id { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? ColumnSort { get; set; } = string.Empty;
        public string? SortDirection { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; }

    }
}
