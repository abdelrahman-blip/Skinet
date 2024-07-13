namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex {get; set;} = 1;
        private int _PageSize = 6;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string sort { get; set; }

        private string _serach;
        public string search
        {
              get => _serach;
              set => _serach = value.ToLower();
        }
    }
}