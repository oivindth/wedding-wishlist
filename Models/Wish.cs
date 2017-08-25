namespace wedding_wishlist.Models
{
    public class Wish
    {
        public long Id { get; set; }
        public string Name { get; set;}
        public string Url {get; set;}
        public int Price { get; set; }  
        public int NumberWished { get; set; }
        public int NumberBought { get; set; }

    }
}