namespace CollectionManagerApi.DTOs
{
    public class ReturnStatisticsDTO
    {
        public int NumberOfTotalItems { get; set; }
        public int NumberOfUniqueItems { get; set; }
        public int NumberOfCollections { get; set; }
        public int TotalValueOfItems { get; set; }
        public int ItemsForSale { get; set; }
        public int ItemsOnWishlist { get; set; }
    }
}
